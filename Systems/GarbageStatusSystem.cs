// File: Systems/GarbageStatusSystem.cs
// Purpose: Status snapshot for Options UI + detailed report to MagicGarbage.log.
// Design:
// - Auto refresh: once per Options-open (getter-driven gap detection).
// - Button: forces refresh and writes the detailed report to log.
// - No Frame output.

namespace MagicGarbage
{
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Objects;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Game.Simulation;
    using Game.Tools;
    using Game.Vehicles;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using Unity.Entities;
    using UnityEngine;

    public sealed partial class GarbageStatusSystem : GameSystemBase
    {
        private const int TopFacilitiesMax = 10;

        private static double s_LastOptionsReadRealtime;
        private static double s_LastAutoRefreshRealtime;

        private static string s_Rates = "-";
        private static string s_Producers = "-";
        private static string s_Requests = "-";
        private static string s_Trucks = "-";
        private static readonly string[] s_Facilities = new string[TopFacilitiesMax];
        private static string s_LastUpdate = "-";

        private CitySystem m_CitySystem = null!;
        private SimulationSystem m_SimulationSystem = null!;
        private GarbageAccumulationSystem m_GarbageAccumulationSystem = null!;

        private EntityQuery m_ProducerQuery;
        private EntityQuery m_RequestQuery;
        private EntityQuery m_TruckQuery;

        private const string K_Running = "MG.Status.Running";
        private const string K_NoCity = "MG.Status.NoCity";

        private const string K_Title = "MG.Status.Title";

        private const string K_Mode = "MG.Status.Mode";
        private const string K_Mode_TotalMagic = "MG.Status.Mode.TotalMagic";
        private const string K_Mode_TrashBoss = "MG.Status.Mode.TrashBoss";

        private const string K_Params = "MG.Status.Params";
        private const string K_Params_Missing = "MG.Status.Params.Missing";

        private const string K_Rates = "MG.Status.Rates";
        private const string K_Line_Producers = "MG.Status.Line.Producers";
        private const string K_Line_Requests = "MG.Status.Line.Requests";
        private const string K_Line_Trucks = "MG.Status.Line.Trucks";

        private const string K_TopFacilityLine = "MG.Status.TopFacilities.Line";
        private const string K_LastUpdate = "MG.Status.LastUpdate";

        protected override void OnCreate()
        {
            base.OnCreate();

            m_GarbageAccumulationSystem = World.GetOrCreateSystemManaged<GarbageAccumulationSystem>();
            m_CitySystem = World.GetOrCreateSystemManaged<CitySystem>();
            m_SimulationSystem = World.GetOrCreateSystemManaged<SimulationSystem>();

            m_ProducerQuery = SystemAPI.QueryBuilder()
                .WithAll<GarbageProducer>()
                .WithNone<Deleted, Destroyed, Temp>()
                .Build();

            m_RequestQuery = SystemAPI.QueryBuilder()
                .WithAll<GarbageCollectionRequest, ServiceRequest>()
                .WithNone<Deleted, Temp>()
                .Build();

            m_TruckQuery = SystemAPI.QueryBuilder()
                .WithAll<Game.Vehicles.GarbageTruck>()
                .WithNone<Deleted, Temp>()
                .Build();

            Enabled = false;
        }

        internal static void ResetUi()
        {
            s_Rates = "-";
            s_Producers = "-";
            s_Requests = "-";
            s_Trucks = "-";
            for (int i = 0; i < s_Facilities.Length; i++)
            {
                s_Facilities[i] = "-";
            }

            s_LastUpdate = "-";

            s_LastOptionsReadRealtime = 0.0;
            s_LastAutoRefreshRealtime = 0.0;
        }

        internal static void SetUiRunning()
        {
            string running = Mod.L(K_Running);
            s_Rates = running;
            s_Producers = running;
            s_Requests = running;
            s_Trucks = running;
            for (int i = 0; i < s_Facilities.Length; i++)
            {
                s_Facilities[i] = running;
            }

            s_LastUpdate = running;
        }

        internal static void SetUiNoCity()
        {
            string msg = Mod.L(K_NoCity);
            s_Rates = msg;
            s_Producers = msg;
            s_Requests = msg;
            s_Trucks = msg;
            for (int i = 0; i < s_Facilities.Length; i++)
            {
                s_Facilities[i] = msg;
            }

            s_LastUpdate = msg;
        }

        internal static string GetRates() => s_Rates;
        internal static string GetProducers() => s_Producers;
        internal static string GetRequests() => s_Requests;
        internal static string GetTrucks() => s_Trucks;
        internal static string GetFacility(int index) => (index < 0 || index >= TopFacilitiesMax) ? "-" : s_Facilities[index] ?? "-";
        internal static string GetLastUpdate() => s_LastUpdate;

        internal static void AutoRefreshOnOptionsRead()
        {
            double now = Time.realtimeSinceStartupAsDouble;

            double gap = (s_LastOptionsReadRealtime <= 0.0) ? double.MaxValue : (now - s_LastOptionsReadRealtime);
            s_LastOptionsReadRealtime = now;

            const double OpenGapSeconds = 0.75;
            if (gap < OpenGapSeconds)
            {
                return;
            }

            const double DoubleFireGuardSeconds = 0.10;
            if (now - s_LastAutoRefreshRealtime < DoubleFireGuardSeconds)
            {
                return;
            }

            s_LastAutoRefreshRealtime = now;

            RunNow(writeToLog: false);
        }

        internal static void RunNow(bool writeToLog)
        {
            World world = World.DefaultGameObjectInjectionWorld;
            if (world == null || !world.IsCreated)
            {
                SetUiNoCity();
                return;
            }

            GarbageStatusSystem sys = world.GetOrCreateSystemManaged<GarbageStatusSystem>();
            sys.BuildSnapshot(writeToLog);
        }

        private void BuildSnapshot(bool writeToLog)
        {
            GameManager gm = GameManager.instance;
            if (gm == null || !gm.gameMode.IsGame())
            {
                SetUiNoCity();
                return;
            }

            Entity city = (m_CitySystem != null) ? m_CitySystem.City : Entity.Null;

            bool totalMagic = false;
            bool trashBoss = false;
            if (Mod.TryGetSetting(out Setting setting))
            {
                totalMagic = setting.TotalMagic;
                trashBoss = setting.TrashBossEnabled;
            }

            bool haveParams = SystemAPI.TryGetSingleton<GarbageParameterData>(out GarbageParameterData gp);

            long producedRaw = (m_GarbageAccumulationSystem != null) ? m_GarbageAccumulationSystem.garbageAccumulation : 0L;
            long processingRaw = 0L;

            foreach (RefRO<Game.Buildings.GarbageFacility> fac in SystemAPI.Query<RefRO<Game.Buildings.GarbageFacility>>().WithNone<Deleted, Temp>())
            {
                processingRaw += fac.ValueRO.m_ProcessingRate;
            }

            long garbageT = ToTonsPerMonth(producedRaw);
            long processingT = ToTonsPerMonth(processingRaw);

            int producerTotal = m_ProducerQuery.CalculateEntityCount();
            int reqTotal = m_RequestQuery.CalculateEntityCount();
            int truckTotal = m_TruckQuery.CalculateEntityCount();

            int gt0 = 0;
            int gOverReq = 0;
            int gOverWarn = 0;
            int hasRequestPtr = 0;

            int reqLimit = haveParams ? gp.m_RequestGarbageLimit : int.MaxValue;
            int warnLimit = haveParams ? gp.m_WarningGarbageLimit : int.MaxValue;

            foreach (RefRO<GarbageProducer> producer in SystemAPI.Query<RefRO<GarbageProducer>>().WithNone<Deleted, Destroyed, Temp>())
            {
                int g = producer.ValueRO.m_Garbage;
                if (g > 0) gt0++;
                if (g > reqLimit) gOverReq++;
                if (g > warnLimit) gOverWarn++;
                if (producer.ValueRO.m_CollectionRequest != Entity.Null) hasRequestPtr++;
            }

            int reqPending = 0;
            int reqDispatched = 0;

            foreach ((RefRO<GarbageCollectionRequest> _, Entity e) in SystemAPI.Query<RefRO<GarbageCollectionRequest>>().WithEntityAccess().WithAll<ServiceRequest>().WithNone<Deleted, Temp>())
            {
                bool hasDisp = SystemAPI.HasComponent<Dispatched>(e);
                bool hasPath = SystemAPI.HasComponent<PathInformation>(e);

                if (hasDisp || hasPath) reqDispatched++;
                else reqPending++;
            }

            int parked = 0;
            int returning = 0;
            int disabled = 0;

            Dictionary<Entity, (int total, int moving, int parked)> facilityStats = new Dictionary<Entity, (int total, int moving, int parked)>(32);

            foreach ((RefRO<Game.Vehicles.GarbageTruck> truck, Entity e) in SystemAPI.Query<RefRO<Game.Vehicles.GarbageTruck>>().WithEntityAccess().WithNone<Deleted, Temp>())
            {
                bool isParked = SystemAPI.HasComponent<ParkedCar>(e);
                if (isParked) parked++;

                GarbageTruckFlags state = truck.ValueRO.m_State;
                if ((state & GarbageTruckFlags.Returning) != 0) returning++;
                if ((state & GarbageTruckFlags.Disabled) != 0) disabled++;

                if (SystemAPI.HasComponent<Owner>(e))
                {
                    Entity owner = SystemAPI.GetComponent<Owner>(e).m_Owner;
                    if (owner != Entity.Null && SystemAPI.HasComponent<Game.Buildings.GarbageFacility>(owner))
                    {
                        facilityStats.TryGetValue(owner, out (int total, int moving, int parked) cur);
                        cur.total += 1;
                        if (isParked) cur.parked += 1;
                        else cur.moving += 1;
                        facilityStats[owner] = cur;
                    }
                }
            }

            int moving = truckTotal - parked;

            s_Rates = Mod.LF(K_Rates, garbageT.ToString("N0", CultureInfo.InvariantCulture), processingT.ToString("N0", CultureInfo.InvariantCulture));
            s_Producers = Mod.LF(K_Line_Producers, producerTotal, gt0, gOverReq, gOverWarn, hasRequestPtr);
            s_Requests = Mod.LF(K_Line_Requests, reqTotal, reqPending, reqDispatched);
            s_Trucks = Mod.LF(K_Line_Trucks, truckTotal, parked, moving, returning, disabled);

            for (int i = 0; i < s_Facilities.Length; i++)
            {
                s_Facilities[i] = "-";
            }

            if (facilityStats.Count > 0)
            {
                List<(Entity facility, int total, int moving, int parked)> list = new List<(Entity facility, int total, int moving, int parked)>(facilityStats.Count);
                foreach (KeyValuePair<Entity, (int total, int moving, int parked)> kvp in facilityStats)
                {
                    list.Add((kvp.Key, kvp.Value.total, kvp.Value.moving, kvp.Value.parked));
                }

                list.Sort((a, b) => b.total.CompareTo(a.total));

                int n = Math.Min(TopFacilitiesMax, list.Count);
                for (int i = 0; i < n; i++)
                {
                    (Entity facility, int total, int moving, int parked) it = list[i];
                    s_Facilities[i] = Mod.LF(K_TopFacilityLine, Fmt(it.facility), it.total, it.moving, it.parked);
                }
            }

            string stamp;
            try { stamp = DateTime.Now.ToString("HH:mm:ss", CultureInfo.InvariantCulture); }
            catch { stamp = "-"; }

            s_LastUpdate = Mod.LF(K_LastUpdate, stamp);

            if (writeToLog)
            {
                StringBuilder sb = new StringBuilder(1024);

                string ts;
                try { ts = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture); }
                catch { ts = "n/a"; }

                sb.AppendLine(Mod.LF(K_Title, ts));
                sb.AppendLine($"City loaded: Yes ({Fmt(city)})");
                sb.AppendLine($"{Mod.L(K_Mode)}: {Mod.L(K_Mode_TotalMagic)}={totalMagic}, {Mod.L(K_Mode_TrashBoss)}={trashBoss}");

                if (haveParams)
                {
                    sb.AppendLine(Mod.LF(K_Params, gp.m_RequestGarbageLimit, gp.m_CollectionGarbageLimit, gp.m_WarningGarbageLimit, gp.m_MaxGarbageAccumulation));
                }
                else
                {
                    sb.AppendLine(Mod.L(K_Params_Missing));
                }

                sb.AppendLine(s_Rates);
                sb.AppendLine();
                sb.AppendLine(s_Producers);
                sb.AppendLine(s_Requests);
                sb.AppendLine(s_Trucks);

                bool anyFacility = false;
                for (int i = 0; i < TopFacilitiesMax; i++)
                {
                    if (!string.IsNullOrEmpty(s_Facilities[i]) && s_Facilities[i] != "-")
                    {
                        anyFacility = true;
                        break;
                    }
                }

                if (anyFacility)
                {
                    sb.AppendLine();
                    sb.AppendLine("Facilities");
                    for (int i = 0; i < TopFacilitiesMax; i++)
                    {
                        if (!string.IsNullOrEmpty(s_Facilities[i]) && s_Facilities[i] != "-")
                        {
                            sb.AppendLine("- " + s_Facilities[i]);
                        }
                    }
                }

                Mod.Log.Info($"{Mod.ModTag} {sb}");
            }
        }

        private static long ToTonsPerMonth(long raw)
        {
            if (raw <= 0L)
            {
                return 0L;
            }

            return (long)Math.Round(raw / 1000.0, MidpointRounding.AwayFromZero);
        }

        private static string Fmt(Entity e)
        {
            return e == Entity.Null ? "Entity.Null" : $"Entity({e.Index}:{e.Version})";
        }
    }
}
