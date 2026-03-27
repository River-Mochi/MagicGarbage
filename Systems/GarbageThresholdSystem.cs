// File: Systems/GarbageThresholdSystem.cs
// Trash Boss: scales pickup + request thresholds together.
// Total Magic (or Trash Boss OFF): reverts to 1x once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageParameterData pickup/request thresholds together according
    /// to the Trash Boss Dispatch Threshold slider.
    /// Uses the live singleton as the source of truth for the base values.
    /// </summary>
    public partial class GarbageThresholdSystem : GameSystemBase
    {
        private int m_LastScale = 1;
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

            m_LastScale = 1;
            m_HaveBase = false;
            m_BaseCollectLimit = 0;
            m_BaseRequestLimit = 0;

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MG] [Trash Boss] GarbageParameterThresholdSystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            int targetScale = 1;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetScale = math.clamp(setting.GarbageDispatchThresholdScale, 1, 50);
            }

            if (targetScale == m_LastScale)
            {
#if DEBUG
                Mod.Log.Info("[MG] [Trash Boss] Threshold sleep");
#endif
                Enabled = false;
                return;
            }

            if (!SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;

            if (!m_HaveBase)
            {
                if (m_LastScale == 1)
                {
                    m_BaseCollectLimit = math.max(1, data.m_CollectionGarbageLimit);
                    m_BaseRequestLimit = math.max(1, data.m_RequestGarbageLimit);
                }
                else
                {
                    m_BaseCollectLimit = math.max(1, (int)math.round(data.m_CollectionGarbageLimit / (float)m_LastScale));
                    m_BaseRequestLimit = math.max(1, (int)math.round(data.m_RequestGarbageLimit / (float)m_LastScale));
                }

                m_HaveBase = true;
            }

            int oldCollect = math.max(1, m_BaseCollectLimit * m_LastScale);
            int oldRequest = math.max(1, m_BaseRequestLimit * m_LastScale);

            int newCollect = math.max(1, m_BaseCollectLimit * targetScale);
            int newRequest = math.max(1, m_BaseRequestLimit * targetScale);

            data.m_CollectionGarbageLimit = newCollect;
            data.m_RequestGarbageLimit = newRequest;

#if DEBUG
            Mod.Log.Info(
                $"[MG] Threshold apply: scale {m_LastScale}x->{targetScale}x, " +
                $"pickup {oldCollect}->{newCollect}, request {oldRequest}->{newRequest}");
#endif

            m_LastScale = targetScale;
            Enabled = false;
        }
    }
}
