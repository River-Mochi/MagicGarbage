// File: Systems/GarbagePriorityAssistSystem.cs
// Trash Boss optional assist.
// When any active garbage request target is critically overloaded,
// temporarily raise pickup threshold to the live request threshold.
// Goal: reduce extra side pickups and help badly overloaded targets get reached sooner.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using System.Collections.Generic;
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

        private int m_LastScannedRequests;
        private int m_LastCriticalRequestTargets;
        private int m_HighestCriticalTargetGarbage;
        private Entity m_HighestCriticalTargetEntity;
        private bool m_HighestCriticalTargetDispatched;
        private bool m_IsPriorityAssistLive;

#if DEBUG
        private double m_LastElapsedMs;
#endif

        public int RaisedPassCount => m_RaisedPassCount;
        public int NormalPassCount => m_NormalPassCount;
        public int LastScannedRequests => m_LastScannedRequests;
        public int LastCriticalRequestTargets => m_LastCriticalRequestTargets;
        public int HighestCriticalTargetGarbage => m_HighestCriticalTargetGarbage;
        public Entity HighestCriticalTargetEntity => m_HighestCriticalTargetEntity;
        public bool HighestCriticalTargetDispatched => m_HighestCriticalTargetDispatched;
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
            m_LastScannedRequests = 0;
            m_LastCriticalRequestTargets = 0;
            m_HighestCriticalTargetGarbage = 0;
            m_HighestCriticalTargetEntity = Entity.Null;
            m_HighestCriticalTargetDispatched = false;
            m_IsPriorityAssistLive = false;

#if DEBUG
            m_LastElapsedMs = 0.0;
#endif

            if (Mod.TryGetSetting(out Setting setting))
            {
                Enabled =
                    !setting.TotalMagic &&
                    setting.TrashBossEnabled &&
                    setting.PrioritySystemEnabled;
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

            int normalCollect = m_BaseCollectLimit;

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

            bool assistAllowed =
                !setting.TotalMagic &&
                setting.TrashBossEnabled &&
                setting.PrioritySystemEnabled;

            int scannedRequests = 0;
            int criticalTargetCount = 0;
            int highestCriticalTargetGarbage = 0;
            Entity highestCriticalTargetEntity = Entity.Null;
            bool highestCriticalTargetDispatched = false;

            if (assistAllowed)
            {
                ComponentLookup<GarbageProducer> producerLookup = SystemAPI.GetComponentLookup<GarbageProducer>(true);
                HashSet<Entity> uniqueCriticalTargets = new HashSet<Entity>();

                foreach ((RefRO<GarbageCollectionRequest> request, RefRO<ServiceRequest> serviceRequest, Entity requestEntity) in SystemAPI
                             .Query<RefRO<GarbageCollectionRequest>, RefRO<ServiceRequest>>()
                             .WithEntityAccess()
                             .WithNone<Deleted, Temp>())
                {
                    scannedRequests++;

                    if ((serviceRequest.ValueRO.m_Flags & ServiceRequestFlags.Reversed) != 0)
                    {
                        continue;
                    }

                    Entity target = request.ValueRO.m_Target;
                    if (target == Entity.Null)
                    {
                        continue;
                    }

                    if (!producerLookup.TryGetComponent(target, out GarbageProducer producer))
                    {
                        continue;
                    }

                    int garbage = producer.m_Garbage;
                    if (garbage < Setting.PriorityCriticalGarbage)
                    {
                        continue;
                    }

                    uniqueCriticalTargets.Add(target);

                    bool dispatched =
                        SystemAPI.HasComponent<Dispatched>(requestEntity) ||
                        SystemAPI.HasComponent<PathInformation>(requestEntity);

                    if (garbage > highestCriticalTargetGarbage)
                    {
                        highestCriticalTargetGarbage = garbage;
                        highestCriticalTargetEntity = target;
                        highestCriticalTargetDispatched = dispatched;
                    }
                }

                criticalTargetCount = uniqueCriticalTargets.Count;
            }

            int targetCollect = normalCollect;
            bool assistLive = assistAllowed && criticalTargetCount > 0;

            // Safe first pass:
            // temporarily lift pickup threshold to the current request threshold.
            // This keeps pickup <= request and narrows extra side pickups.
            if (assistLive)
            {
                targetCollect = math.max(normalCollect, data.m_RequestGarbageLimit);
                m_RaisedPassCount++;
            }
            else
            {
                m_NormalPassCount++;
            }

            m_LastScannedRequests = scannedRequests;
            m_LastCriticalRequestTargets = criticalTargetCount;
            m_HighestCriticalTargetGarbage = highestCriticalTargetGarbage;
            m_HighestCriticalTargetEntity = highestCriticalTargetEntity;
            m_HighestCriticalTargetDispatched = highestCriticalTargetDispatched;
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
