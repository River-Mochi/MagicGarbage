// <copyright file="GarbageRoutingSystem.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Systems/GarbageRoutingSystem.cs
// Trash Boss sets the game's target-protection margin once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;
    using Unity.Mathematics;

    public sealed partial class GarbageRoutingSystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private bool m_HaveBase;
        private float m_BaseAdaptiveMargin;

        protected override void OnCreate()
        {
            base.OnCreate();
            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            RequireForUpdate<GarbageParameterData>();
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            Enabled =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);
        }

        protected override void OnUpdate()
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            if (!Mod.TryGetSetting(out Setting setting) ||
                !SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
                Enabled = false;
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;
            Entity parameterEntity = SystemAPI.GetSingletonEntity<GarbageParameterData>();

            m_HaveBase = false;
            // The live singleton may still contain another city's MG value.
            if (!TryGetAuthoringBase(parameterEntity, out m_BaseAdaptiveMargin))
            {
                LogUtils.Warn("[MG] Could not read the vanilla target reserve. No routing change was applied.");
                Enabled = false;
                return;
            }

            m_HaveBase = true;

            bool trashBossActive = !setting.TotalMagic && setting.TrashBossEnabled;
            float targetMargin = trashBossActive
                ? math.clamp(
                    setting.AdaptiveReservationMargin,
                    Setting.kMinAdaptiveReservationMargin,
                    Setting.kMaxAdaptiveReservationMargin) / 100f
                : m_BaseAdaptiveMargin;

            if (math.abs(data.m_AdaptiveCollectionMargin - targetMargin) > 0.0001f)
            {
                data.m_AdaptiveCollectionMargin = targetMargin;
            }

#if DEBUG
            LogUtils.Info(
                $"[MG] Target protection apply: {targetMargin * 100f:N0}% " +
                $"(Trash Boss active={trashBossActive})");
#endif

            Enabled = false;
        }

        private bool TryGetAuthoringBase(Entity parameterEntity, out float margin)
        {
            margin = 0f;

            if (!m_PrefabSystem.TryGetPrefab(parameterEntity, out PrefabBase prefabBase) ||
                prefabBase is not GarbagePrefab garbagePrefab)
            {
                return false;
            }

            margin = math.clamp(garbagePrefab.m_AdaptiveCollectionMargin, 0f, 1f);
            return true;
        }

        internal bool TryGetBaseAdaptiveMargin(out float margin)
        {
            margin = m_BaseAdaptiveMargin;
            return m_HaveBase;
        }
    }
}
