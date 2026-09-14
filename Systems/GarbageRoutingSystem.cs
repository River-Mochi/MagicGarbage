// <copyright file="GarbageRoutingSystem.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Systems/GarbageRoutingSystem.cs
// Trash Boss: applies the game's assigned-target protection margin once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities;
    using CS2Shared.RiverMochi;
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// One-shot settings system for the built-in garbage-truck target protection.
    /// It runs on city load or after a relevant Options change and then disables itself.
    /// </summary>
    public sealed partial class GarbageRoutingSystem : GameSystemBase
    {
        private bool m_HaveBase;
        private float m_BaseAdaptiveMargin;

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
            m_BaseAdaptiveMargin = Setting.VanillaAdaptiveReservationMargin / 100f;

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

            if (!m_HaveBase)
            {
                m_BaseAdaptiveMargin = math.clamp(data.m_AdaptiveCollectionMargin, 0f, 1f);
                m_HaveBase = true;
            }

            bool trashBossActive = !setting.TotalMagic && setting.TrashBossEnabled;
            float targetMargin = trashBossActive
                ? math.clamp(
                    setting.AdaptiveReservationMargin,
                    Setting.MinAdaptiveReservationMargin,
                    Setting.MaxAdaptiveReservationMargin) / 100f
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
    }
}
