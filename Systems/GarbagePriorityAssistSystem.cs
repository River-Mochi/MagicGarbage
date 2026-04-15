// File: Systems/GarbagePriorityAssistSystem.cs
// Trash Boss optional assist.
// When any garbage-producing building is critically overloaded,
// temporarily raise pickup threshold to the live request threshold.
// Goal: reduce extra side pickups and help badly overloaded buildings get reached sooner.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
#if DEBUG
    using System.Diagnostics;
#endif
    using Unity.Entities;
    using Unity.Mathematics;

    public sealed partial class GarbagePriorityAssistSystem : GameSystemBase
    {
        public const int UpdateIntervalFrames = 128;

        private bool m_HaveBase;
        private int m_BaseCollectLimit;

        private int m_RaisedPassCount;
        private int m_NormalPassCount;

        private int m_LastScannedBuildings;
        private int m_LastCriticalBuildings;
        private int m_HighestCriticalBuildingGarbage;
        private Entity m_HighestCriticalBuildingEntity;
        private bool m_HighestCriticalBuildingHasRequest;
        private bool m_HighestCriticalBuildingDispatched;
        private bool m_IsPriorityAssistLive;

#if DEBUG
        private double m_LastElapsedMs;
#endif

        public int RaisedPassCount => m_RaisedPassCount;
        public int NormalPassCount => m_NormalPassCount;

        public int LastScannedBuildings => m_LastScannedBuildings;
        public int LastCriticalBuildings => m_LastCriticalBuildings;

        public int HighestCriticalBuildingGarbage => m_HighestCriticalBuildingGarbage;
        public Entity HighestCriticalBuildingEntity => m_HighestCriticalBuildingEntity;
        public bool HighestCriticalBuildingHasRequest => m_HighestCriticalBuildingHasRequest;
        public bool HighestCriticalBuildingDispatched => m_HighestCriticalBuildingDispatched;

        public bool IsPriorityAssistLive => m_IsPriorityAssistLive;

#if DEBUG
        public double LastElapsedMs => m_LastElapsedMs;
#endif

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return UpdateIntervalFrames;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            RequireForUpdate<GarbageParameterData>();
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_HaveBase = false;
            m_BaseCollectLimit = 0;

            m_RaisedPassCount = 0;
            m_NormalPassCount = 0;

            m_LastScannedBuildings = 0;
            m_LastCriticalBuildings = 0;

            m_HighestCriticalBuildingGarbage = 0;
            m_HighestCriticalBuildingEntity = Entity.Null;
            m_HighestCriticalBuildingHasRequest = false;
            m_HighestCriticalBuildingDispatched = false;
            m_IsPriorityAssistLive = false;

#if DEBUG
            m_LastElapsedMs = 0.0;
#endif

            if (Mod.TryGetSetting(out Setting setting))
            {
                Enabled =
                    !setting.TotalMagic &&
                    setting.TrashBossEnabled &&
                    setting.PriorityAssistEnabled;
            }
            else
            {
                Enabled = false;
            }
        }

        protected override void OnUpdate()
        {
#if DEBUG
            Stopwatch sw = Stopwatch.StartNew();
#endif

            if (!Mod.TryGetSetting(out Setting setting))
            {
#if DEBUG
                sw.Stop();
                m_LastElapsedMs = sw.Elapsed.TotalMilliseconds;
#endif
                return;
            }

            if (!SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
#if DEBUG
                sw.Stop();
                m_LastElapsedMs = sw.Elapsed.TotalMilliseconds;
#endif
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;

            if (!m_HaveBase)
            {
                m_BaseCollectLimit = math.max(1, data.m_CollectionGarbageLimit);
                m_HaveBase = true;
            }

            int normalCollect = Setting.VanillaPickupThreshold;

            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                int requestLimit = math.clamp(
                    setting.GarbageDispatchRequestThreshold,
                    Setting.VanillaDispatchRequestThreshold,
                    Setting.MaxDispatchRequestThreshold);

                normalCollect = math.clamp(
                    setting.GarbagePickupThreshold,
                    Setting.VanillaPickupThreshold,
                    Setting.MaxPickupThreshold);

                if (normalCollect > requestLimit)
                {
                    normalCollect = requestLimit;
                }
            }
            else if (!setting.TotalMagic && !setting.TrashBossEnabled)
            {
                normalCollect = math.max(Setting.VanillaPickupThreshold, m_BaseCollectLimit);
            }

            bool assistAllowed =
                !setting.TotalMagic &&
                setting.TrashBossEnabled &&
                setting.PriorityAssistEnabled;

            int scannedBuildings = 0;
            int criticalBuildings = 0;
            int highestCriticalGarbage = 0;
            Entity highestCriticalEntity = Entity.Null;

            if (assistAllowed)
            {
                foreach ((RefRO<GarbageProducer> producer, Entity buildingEntity) in SystemAPI
                             .Query<RefRO<GarbageProducer>>()
                             .WithEntityAccess()
                             .WithNone<Deleted, Destroyed, Temp>())
                {
                    scannedBuildings++;

                    int garbage = producer.ValueRO.m_Garbage;
                    if (garbage < Setting.PriorityCriticalGarbage)
                    {
                        continue;
                    }

                    criticalBuildings++;

                    if (garbage > highestCriticalGarbage)
                    {
                        highestCriticalGarbage = garbage;
                        highestCriticalEntity = buildingEntity;
                    }
                }
            }

            bool highestHasRequest = false;
            bool highestDispatched = false;

            if (assistAllowed && highestCriticalEntity != Entity.Null)
            {
                foreach ((RefRO<GarbageCollectionRequest> request, RefRO<ServiceRequest> serviceRequest, Entity requestEntity) in SystemAPI
                             .Query<RefRO<GarbageCollectionRequest>, RefRO<ServiceRequest>>()
                             .WithEntityAccess()
                             .WithNone<Deleted, Temp>())
                {
                    if ((serviceRequest.ValueRO.m_Flags & ServiceRequestFlags.Reversed) != 0)
                    {
                        continue;
                    }

                    if (request.ValueRO.m_Target != highestCriticalEntity)
                    {
                        continue;
                    }

                    highestHasRequest = true;

                    if (SystemAPI.HasComponent<Dispatched>(requestEntity) || SystemAPI.HasComponent<Game.Pathfind.PathInformation>(requestEntity))
                    {
                        highestDispatched = true;
                        break;
                    }
                }
            }

            bool assistLive = assistAllowed && criticalBuildings > 0;
            int targetCollect = normalCollect;

            if (assistLive)
            {
                targetCollect = math.max(normalCollect, data.m_RequestGarbageLimit);
                m_RaisedPassCount++;
            }
            else
            {
                m_NormalPassCount++;
            }

            m_LastScannedBuildings = scannedBuildings;
            m_LastCriticalBuildings = criticalBuildings;

            m_HighestCriticalBuildingGarbage = highestCriticalGarbage;
            m_HighestCriticalBuildingEntity = highestCriticalEntity;
            m_HighestCriticalBuildingHasRequest = highestHasRequest;
            m_HighestCriticalBuildingDispatched = highestDispatched;

            m_IsPriorityAssistLive = assistLive;

            if (data.m_CollectionGarbageLimit != targetCollect)
            {
                data.m_CollectionGarbageLimit = targetCollect;
            }

            if (!assistAllowed && data.m_CollectionGarbageLimit == normalCollect)
            {
                Enabled = false;
            }

#if DEBUG
            sw.Stop();
            m_LastElapsedMs = sw.Elapsed.TotalMilliseconds;
#endif
        }
    }
}
