// File: Systems/GarbageThresholdSystem.cs
// Trash Boss: adjusts pickup/request thresholds and garbage happiness tuning.
// Total Magic, Trash Boss OFF, or Power User Options OFF: reverts to vanilla once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageParameterData request/pickup thresholds and garbage
    /// happiness parameters according to the Power User sliders.
    /// Uses the live singleton as the source of truth for the base values.
    /// Runtime clamp limits come from Setting.cs.
    /// </summary>
    public partial class GarbageThresholdSystem : GameSystemBase
    {
        private bool m_HaveBase;
        private int m_BaseCollectLimit;
        private int m_BaseRequestLimit;
        private int m_BaseHappinessBaseline;
        private int m_BaseHappinessStep;

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
            m_BaseHappinessBaseline = 0;
            m_BaseHappinessStep = 0;

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
                m_BaseHappinessBaseline = math.max(0, data.m_HappinessEffectBaseline);
                m_BaseHappinessStep = math.max(1, data.m_HappinessEffectStep);
                m_HaveBase = true;
            }

            int targetCollect = m_BaseCollectLimit;
            int targetRequest = m_BaseRequestLimit;
            int targetHappinessBaseline = m_BaseHappinessBaseline;
            int targetHappinessStep = m_BaseHappinessStep;

            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                targetRequest = math.clamp(
                    setting.GarbageDispatchRequestThreshold,
                    Setting.VanillaDispatchRequestThreshold,
                    Setting.MaxDispatchRequestThreshold);

                targetCollect = math.clamp(
                    setting.GarbagePickupThreshold,
                    Setting.VanillaPickupThreshold,
                    Setting.MaxPickupThreshold);

                if (targetCollect > targetRequest)
                {
                    targetCollect = targetRequest;
                }

                targetHappinessBaseline = math.clamp(
                    setting.GarbageHappinessBaseline,
                    Setting.MinGarbageHappinessBaseline,
                    Setting.MaxGarbageHappinessBaseline);

                targetHappinessStep = math.clamp(
                    setting.GarbageHappinessStep,
                    Setting.MinGarbageHappinessStep,
                    Setting.MaxGarbageHappinessStep);
            }

            if (data.m_CollectionGarbageLimit == targetCollect &&
                data.m_RequestGarbageLimit == targetRequest &&
                data.m_HappinessEffectBaseline == targetHappinessBaseline &&
                data.m_HappinessEffectStep == targetHappinessStep)
            {
#if DEBUG
                Mod.Log.Info("[MG] [Trash Boss] Threshold/Happiness sleep");
#endif
                Enabled = false;
                return;
            }

            int oldCollect = data.m_CollectionGarbageLimit;
            int oldRequest = data.m_RequestGarbageLimit;
            int oldHappinessBaseline = data.m_HappinessEffectBaseline;
            int oldHappinessStep = data.m_HappinessEffectStep;

            data.m_CollectionGarbageLimit = targetCollect;
            data.m_RequestGarbageLimit = targetRequest;
            data.m_HappinessEffectBaseline = targetHappinessBaseline;
            data.m_HappinessEffectStep = targetHappinessStep;

#if DEBUG
            Mod.Log.Info(
                $"[MG] Threshold apply: pickup {oldCollect}->{targetCollect}, request {oldRequest}->{targetRequest}, " +
                $"garbage happiness baseline {oldHappinessBaseline}->{targetHappinessBaseline}, " +
                $"garbage happiness step {oldHappinessStep}->{targetHappinessStep}");
#endif

            Enabled = false;
        }
    }
}
