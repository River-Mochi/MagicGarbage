// <copyright file="GarbagePriorityAssistSystem.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Systems/GarbagePriorityAssistSystem.cs
// Adds a lightweight early-intervention assist when the installed game exposes
// target-capacity reservation. The optional field is accessed through a
// compatibility bridge so one Magic Garbage binary remains safe across 1.6.x.

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
        public const int EarlyInterventionGarbage = 8000;

        private bool m_HaveBase;
        private float m_BaseAdaptiveMargin;

        private int m_RaisedPassCount;
        private int m_NormalPassCount;

        private int m_LastScannedRequests;
        private int m_LastCriticalBuildings;
        private int m_CriticalGarbageThreshold;
        private int m_HighestCriticalBuildingGarbage;
        private Entity m_HighestCriticalBuildingEntity;
        private bool m_HighestCriticalBuildingHasRequest;
        private bool m_HighestCriticalBuildingDispatched;
        private bool m_IsPriorityAssistLive;
        private float m_NormalAdaptiveMargin;
        private float m_EffectiveAdaptiveMargin;
        private ComponentLookup<GarbageProducer> m_GarbageProducerLookup;

#if DEBUG
        private double m_LastElapsedMs;
#endif

        public int RaisedPassCount => m_RaisedPassCount;
        public int NormalPassCount => m_NormalPassCount;

        public int LastScannedRequests => m_LastScannedRequests;
        public int LastCriticalBuildings => m_LastCriticalBuildings;
        public int CriticalGarbageThreshold => m_CriticalGarbageThreshold;

        public int HighestCriticalBuildingGarbage => m_HighestCriticalBuildingGarbage;
        public Entity HighestCriticalBuildingEntity => m_HighestCriticalBuildingEntity;
        public bool HighestCriticalBuildingHasRequest => m_HighestCriticalBuildingHasRequest;
        public bool HighestCriticalBuildingDispatched => m_HighestCriticalBuildingDispatched;

        public bool IsPriorityAssistLive => m_IsPriorityAssistLive;
        public bool AdaptiveCollectionSupported => GarbageAdaptiveCollection.IsSupported;
        public float NormalAdaptiveMargin => m_NormalAdaptiveMargin;
        public float EffectiveAdaptiveMargin => m_EffectiveAdaptiveMargin;

#if DEBUG
        public double LastElapsedMs => m_LastElapsedMs;
#endif

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return UpdateIntervalFrames;
        }

        public static int CalculateCriticalThreshold(in GarbageParameterData data)
        {
            int threshold = EarlyInterventionGarbage;

            // Keep the assist proactive even if a game mode or later update uses
            // a warning or hard cap below Magic Garbage's normal 8t target.
            if (data.m_WarningGarbageLimit > 0)
            {
                threshold = math.min(threshold, data.m_WarningGarbageLimit);
            }

            if (data.m_MaxGarbageAccumulation > 0)
            {
                threshold = math.min(threshold, data.m_MaxGarbageAccumulation);
            }

            return math.max(1, threshold);
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_GarbageProducerLookup = GetComponentLookup<GarbageProducer>(true);
            RequireForUpdate<GarbageParameterData>();
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_HaveBase = false;
            m_BaseAdaptiveMargin = 0f;

            m_RaisedPassCount = 0;
            m_NormalPassCount = 0;

            m_LastScannedRequests = 0;
            m_LastCriticalBuildings = 0;
            m_CriticalGarbageThreshold = 0;

            m_HighestCriticalBuildingGarbage = 0;
            m_HighestCriticalBuildingEntity = Entity.Null;
            m_HighestCriticalBuildingHasRequest = false;
            m_HighestCriticalBuildingDispatched = false;
            m_IsPriorityAssistLive = false;
            m_NormalAdaptiveMargin = 0f;
            m_EffectiveAdaptiveMargin = 0f;

#if DEBUG
            m_LastElapsedMs = 0.0;
#endif

            if (Mod.TryGetSetting(out Setting setting))
            {
                Enabled =
                    GarbageAdaptiveCollection.IsSupported &&
                    !setting.TotalMagic &&
                    setting.TrashBossEnabled;
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

            if (!Mod.TryGetSetting(out Setting setting) ||
                !SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
                FinishTiming();
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;

            if (!GarbageAdaptiveCollection.TryGet(in data, out float currentMargin))
            {
                m_IsPriorityAssistLive = false;
                Enabled = false;
                FinishTiming();
                return;
            }

            if (!m_HaveBase)
            {
                m_BaseAdaptiveMargin = math.clamp(currentMargin, 0f, 1f);
                m_HaveBase = true;
            }

            bool trashBossActive = !setting.TotalMagic && setting.TrashBossEnabled;
            float normalMargin = m_BaseAdaptiveMargin;

            if (trashBossActive)
            {
                int marginPercent = math.clamp(
                    setting.AdaptiveReservationMargin,
                    Setting.MinAdaptiveReservationMargin,
                    Setting.MaxAdaptiveReservationMargin);

                normalMargin = marginPercent / 100f;
            }

            bool assistAllowed = trashBossActive && setting.PriorityAssistEnabled;
            int criticalThreshold = CalculateCriticalThreshold(in data);

            int scannedRequests = 0;
            int criticalBuildings = 0;
            int highestCriticalGarbage = 0;
            Entity highestCriticalEntity = Entity.Null;
            bool highestDispatched = false;

            if (assistAllowed)
            {
                m_GarbageProducerLookup.Update(this);

                foreach ((RefRO<GarbageCollectionRequest> request, RefRO<ServiceRequest> serviceRequest, Entity requestEntity) in SystemAPI
                             .Query<RefRO<GarbageCollectionRequest>, RefRO<ServiceRequest>>()
                             .WithEntityAccess()
                             .WithNone<Deleted, Temp>())
                {
                    if ((serviceRequest.ValueRO.m_Flags & ServiceRequestFlags.Reversed) != 0)
                    {
                        continue;
                    }

                    scannedRequests++;

                    Entity target = request.ValueRO.m_Target;
                    if (!m_GarbageProducerLookup.TryGetComponent(target, out GarbageProducer producer) ||
                        producer.m_Garbage < criticalThreshold)
                    {
                        continue;
                    }

                    criticalBuildings++;

                    if (producer.m_Garbage <= highestCriticalGarbage)
                    {
                        continue;
                    }

                    highestCriticalGarbage = producer.m_Garbage;
                    highestCriticalEntity = target;
                    highestDispatched =
                        SystemAPI.HasComponent<Dispatched>(requestEntity) ||
                        SystemAPI.HasComponent<Game.Pathfind.PathInformation>(requestEntity);
                }
            }

            bool assistLive = assistAllowed && criticalBuildings > 0;
            float targetMargin = assistLive
                ? math.max(normalMargin, Setting.PriorityAdaptiveReservationMargin / 100f)
                : normalMargin;

            if (assistLive)
            {
                m_RaisedPassCount++;
            }
            else
            {
                m_NormalPassCount++;
            }

            m_LastScannedRequests = scannedRequests;
            m_LastCriticalBuildings = criticalBuildings;
            m_CriticalGarbageThreshold = criticalThreshold;

            m_HighestCriticalBuildingGarbage = highestCriticalGarbage;
            m_HighestCriticalBuildingEntity = highestCriticalEntity;
            m_HighestCriticalBuildingHasRequest = highestCriticalEntity != Entity.Null;
            m_HighestCriticalBuildingDispatched = highestDispatched;

            m_IsPriorityAssistLive = assistLive;
            m_NormalAdaptiveMargin = normalMargin;
            m_EffectiveAdaptiveMargin = targetMargin;

            if (math.abs(currentMargin - targetMargin) > 0.0001f &&
                !GarbageAdaptiveCollection.TrySet(ref data, targetMargin))
            {
                m_IsPriorityAssistLive = false;
                Enabled = false;
                FinishTiming();
                return;
            }

            // Keep polling only while the adaptive boost may need to switch on or off.
            if (!assistAllowed)
            {
                Enabled = false;
            }

            FinishTiming();

            void FinishTiming()
            {
#if DEBUG
                sw.Stop();
                m_LastElapsedMs = sw.Elapsed.TotalMilliseconds;
#endif
            }
        }
    }
}
