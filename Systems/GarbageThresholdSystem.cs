// File: Systems/GarbageThresholdSystem.cs
// Trash Boss: adjusts pickup + request thresholds.
// Total Magic, Trash Boss OFF, or Power User Options OFF: reverts to vanilla once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageParameterData request/pickup thresholds according to
    /// the Power User threshold sliders.
    /// Uses the live singleton as the source of truth for the base values.
    /// </summary>
    public partial class GarbageThresholdSystem : GameSystemBase
    {
        private const int MinDispatchRequestThreshold = 100;
        private const int MaxDispatchRequestThreshold = 3000;
        private const int MinPickupThreshold = 20;
        private const int MaxPickupThreshold = 600;

        private bool m_HaveBase;
        private int m_BaseCollectLimit;
        private int m_BaseRequestLimit;

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
            m_BaseRequestLimit = 0;

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MG] [Trash Boss] GarbageThresholdSystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            if (!SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;

            if (!m_HaveBase)
            {
                m_BaseCollectLimit = math.max(1, data.m_CollectionGarbageLimit);
                m_BaseRequestLimit = math.max(1, data.m_RequestGarbageLimit);
                m_HaveBase = true;
            }

            int targetCollect = m_BaseCollectLimit;
            int targetRequest = m_BaseRequestLimit;

            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                targetRequest = math.clamp(
                    setting.GarbageDispatchRequestThreshold,
                    MinDispatchRequestThreshold,
                    MaxDispatchRequestThreshold);

                targetCollect = math.clamp(
                    setting.GarbagePickupThreshold,
                    MinPickupThreshold,
                    MaxPickupThreshold);

                if (targetCollect > targetRequest)
                {
                    targetCollect = targetRequest;
                }
            }

            if (data.m_CollectionGarbageLimit == targetCollect &&
                data.m_RequestGarbageLimit == targetRequest)
            {
#if DEBUG
                Mod.Log.Info("[MG] [Trash Boss] Threshold sleep");
#endif
                Enabled = false;
                return;
            }

            int oldCollect = data.m_CollectionGarbageLimit;
            int oldRequest = data.m_RequestGarbageLimit;

            data.m_CollectionGarbageLimit = targetCollect;
            data.m_RequestGarbageLimit = targetRequest;

#if DEBUG
            Mod.Log.Info(
                $"[MG] Threshold apply: pickup {oldCollect}->{targetCollect}, request {oldRequest}->{targetRequest}");
#endif

            Enabled = false;
        }
    }
}
