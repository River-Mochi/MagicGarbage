// File: Systems/GarbageStatus.cs
// Purpose: FastBikes-style Options UI status cache.
// Behavior:
// - Refresh runs only when Options UI reads status properties.
// - Button forces refresh and writes full report to MagicGarbage.log.
// - No per-frame simulation work.

namespace MagicGarbage
{
    using Game;
    using Game.SceneFlow;
    using System;
    using System.Text;
    using Unity.Entities;
    using UnityEngine;

    internal static class GarbageStatus
    {
        private const int AutoRefreshSeconds = 10;

        private static int s_LastUiFrame = -1;
        private static long s_LastRefreshUtcTicks;
        private static bool s_WasInGame;

        private static string s_UiGarbageProcessing = "-";
        private static string s_UiProducers = "-";
        private static string s_UiRequests = "-";
        private static string s_UiTrucks = "-";
        private static string s_UiFacilities = "-";

        public static void ResetUi()
        {
            s_LastUiFrame = -1;
            s_LastRefreshUtcTicks = 0;
            s_WasInGame = false;

            s_UiGarbageProcessing = "-";
            s_UiProducers = "-";
            s_UiRequests = "-";
            s_UiTrucks = "-";
            s_UiFacilities = "-";
        }

        public static void RefreshIfNeeded()
        {
            int frame = Time.frameCount;
            if (frame == s_LastUiFrame)
            {
                return;
            }

            s_LastUiFrame = frame;

            bool isGame = IsGameMode();
            if (!isGame)
            {
                s_WasInGame = false;
                SetNoCityUi();
                return;
            }

            if (!s_WasInGame)
            {
                s_WasInGame = true;
                RefreshNow(writeToLog: false);
                return;
            }

            long nowUtc = DateTime.UtcNow.Ticks;
            if (s_LastRefreshUtcTicks > 0)
            {
                long ageTicks = nowUtc - s_LastRefreshUtcTicks;
                long minTicks = AutoRefreshSeconds * TimeSpan.TicksPerSecond;
                if (ageTicks < minTicks)
                {
                    return;
                }
            }

            RefreshNow(writeToLog: false);
        }

        public static void RefreshNow(bool writeToLog)
        {
            if (!IsGameMode())
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            if (!TryGetWorld(out World world))
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            GarbageStatusSystem sys = world.GetOrCreateSystemManaged<GarbageStatusSystem>();
            GarbageStatusSystem.Snapshot snap = sys.BuildSnapshot();

            if (!snap.InGame)
            {
                SetNoCityUi();

                if (writeToLog)
                {
                    Mod.Log.Info($"{Mod.ModTag} {Mod.L("MG.Status.NoCity")}");
                }

                return;
            }

            ApplySnapshotToUi(snap);
            s_LastRefreshUtcTicks = DateTime.UtcNow.Ticks;

            if (writeToLog)
            {
                string logText = BuildLogText(snap);
                Mod.Log.Info($"{Mod.ModTag} {logText}");
            }
        }

        public static string GetUiGarbageProcessing()
        {
            return string.IsNullOrEmpty(s_UiGarbageProcessing) ? "-" : s_UiGarbageProcessing;
        }

        public static string GetUiProducers()
        {
            return string.IsNullOrEmpty(s_UiProducers) ? "-" : s_UiProducers;
        }

        public static string GetUiRequests()
        {
            return string.IsNullOrEmpty(s_UiRequests) ? "-" : s_UiRequests;
        }

        public static string GetUiTrucks()
        {
            return string.IsNullOrEmpty(s_UiTrucks) ? "-" : s_UiTrucks;
        }

        public static string GetUiFacilities()
        {
            return string.IsNullOrEmpty(s_UiFacilities) ? "-" : s_UiFacilities;
        }

        private static void ApplySnapshotToUi(GarbageStatusSystem.Snapshot snap)
        {
            string updatedAt = DateTime.Now.ToString("HH:mm:ss");

            s_UiGarbageProcessing = Mod.LF(
                "MG.Status.Row.GarbageProcessing",
                snap.GarbageTonsPerMonth,
                snap.ProcessingTonsPerMonth,
                updatedAt);

            s_UiRequests = Mod.LF(
                "MG.Status.Row.Requests",
                snap.RequestTotal,
                snap.RequestPending,
                snap.RequestDispatched);

            s_UiProducers = Mod.LF(
                "MG.Status.Row.Producers",
                snap.ProducerGarbageGt0,
                snap.ProducerTotal,
                snap.ProducerOverRequest);

            s_UiFacilities = BuildFacilitiesSummary(snap);

            s_UiTrucks = Mod.LF(
                "MG.Status.Row.Trucks",
                snap.TruckTotal,
                snap.TruckMoving,
                snap.TruckParked,
                snap.TruckReturning);
        }

        private static string BuildFacilitiesSummary(GarbageStatusSystem.Snapshot snap)
        {
            if (snap.FacilityTotal <= 0)
            {
                return Mod.L("MG.Status.Row.FacilitiesNone");
            }

            return Mod.LF(
                "MG.Status.Row.FacilitiesSummary",
                snap.FacilityTotal,
                snap.FacilityGarbageTruckTotal,
                snap.FacilityDumpTruckTotal,
                snap.FacilityMaxWorkers);
        }

        private static string BuildLogText(GarbageStatusSystem.Snapshot snap)
        {
            string nowText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            StringBuilder log = new StringBuilder(1400);

            log.AppendLine(Mod.LF("MG.Status.Log.Title", nowText));
            log.AppendLine(Mod.LF("MG.Status.Log.City", Fmt(snap.City)));
            log.AppendLine(Mod.LF("MG.Status.Log.Mode", snap.TotalMagic, snap.TrashBoss));
            log.AppendLine(Mod.L("MG.Status.Log.Legend"));
            log.AppendLine();

            if (snap.HaveParams)
            {
                log.AppendLine(Mod.LF(
                    "MG.Status.Log.Thresholds",
                    snap.RequestLimit,
                    snap.CollectLimit,
                    snap.WarningLimit,
                    snap.MaxAccumulation));
            }
            else
            {
                log.AppendLine(Mod.L("MG.Status.Log.ThresholdsMissing"));
            }

            log.AppendLine();
            log.AppendLine(Mod.LF(
                "MG.Status.Log.GarbageProcessing",
                snap.GarbageTonsPerMonth,
                snap.ProcessingTonsPerMonth));

            log.AppendLine();
            log.AppendLine(Mod.LF(
                "MG.Status.Log.Requests",
                snap.RequestTotal,
                snap.RequestPending,
                snap.RequestDispatched));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.PendingPeak",
                snap.PendingMaxTargetGarbage,
                ToTons(snap.PendingMaxTargetGarbage),
                Fmt(snap.PendingMaxTargetEntity)));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.Producers",
                snap.ProducerTotal,
                snap.ProducerGarbageGt0,
                snap.ProducerOverRequest,
                snap.ProducerOverWarning));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.ProducerGarbageStats",
                snap.ProducerAverageGarbage,
                ToTons(snap.ProducerAverageGarbage),
                snap.ProducerMedianGarbage,
                ToTons(snap.ProducerMedianGarbage),
                snap.ProducerMaxGarbage,
                ToTons(snap.ProducerMaxGarbage),
                Fmt(snap.ProducerMaxGarbageEntity)));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.NearWarning75",
                snap.ProducerNearWarning75,
                snap.HaveParams ? (int)Math.Ceiling(snap.WarningLimit * 0.75d) : 0,
                ToTons(snap.HaveParams ? (int)Math.Ceiling(snap.WarningLimit * 0.75d) : 0)));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.FacilitiesSummary",
                snap.FacilityTotal,
                snap.FacilityGarbageTruckTotal,
                snap.FacilityDumpTruckTotal,
                snap.FacilityDumpTruckMoving,
                snap.FacilityMaxWorkers));

            log.AppendLine(Mod.LF(
                "MG.Status.Log.Trucks",
                snap.TruckTotal,
                snap.TruckParked,
                snap.TruckMoving,
                snap.TruckReturning,
                snap.TruckDisabled));

            if (snap.Facilities != null && snap.Facilities.Length > 0)
            {
                log.AppendLine();
                log.AppendLine(Mod.L("MG.Status.Log.FacilitiesHeader"));

                for (int i = 0; i < snap.Facilities.Length; i++)
                {
                    GarbageStatusSystem.FacilityEntry f = snap.Facilities[i];
                    log.AppendLine(Mod.LF(
                        "MG.Status.Log.FacilityLine",
                        Fmt(f.Facility),
                        f.GarbageTruckTotal,
                        f.GarbageTruckMoving,
                        f.GarbageTruckParked,
                        f.DumpTruckTotal,
                        f.DumpTruckMoving,
                        f.MaxWorkers));
                }
            }

            return log.ToString().TrimEnd();
        }

        private static void SetNoCityUi()
        {
            string msg = Mod.L("MG.Status.NoCity");

            s_UiGarbageProcessing = msg;
            s_UiProducers = "-";
            s_UiRequests = "-";
            s_UiTrucks = "-";
            s_UiFacilities = "-";
        }

        private static bool IsGameMode()
        {
            GameManager gm = GameManager.instance;
            return gm != null && gm.gameMode.IsGame();
        }

        private static bool TryGetWorld(out World world)
        {
            world = World.DefaultGameObjectInjectionWorld;
            return world != null && world.IsCreated;
        }

        private static string Fmt(Entity e)
        {
            return e == Entity.Null ? "Entity.Null" : $"Entity({e.Index}:{e.Version})";
        }

        private static double ToTons(int garbageUnits)
        {
            return garbageUnits / 1000.0;
        }
    }
}
