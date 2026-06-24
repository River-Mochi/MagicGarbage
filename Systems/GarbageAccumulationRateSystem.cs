// <copyright file="GarbageAccumulationRateSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/GarbageAccumulationRateSystem.cs
// Power User: scales prefab garbage accumulation source values.
// Total Magic, Trash Boss OFF, or Power User OFF: restores prefab values to vanilla 100% once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using CS2Shared.RiverMochi; // LogUtils
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// One-shot prefab system that scales ConsumptionData.m_GarbageAccumulation
    /// from authoring values where available. The system is enabled on city load
    /// or by settings callbacks, applies once, then disables itself.
    /// </summary>
    public partial class GarbageAccumulationRateSystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private EntityQuery m_ConsumptionPrefabQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            m_ConsumptionPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData>()
                .WithAllRW<ConsumptionData>()
                .Build();

            RequireForUpdate(m_ConsumptionPrefabQuery);

            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            bool isRealGame =
                mode == GameMode.Game &&
                (purpose == Purpose.NewGame || purpose == Purpose.LoadGame);

            if (!isRealGame)
            {
                return;
            }

            Enabled = true;

#if DEBUG
            LogUtils.Info("[MG] [Power User] GarbageAccumulationRateSystem: city load -> Enabled");
#endif
        }

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 1;
        }

        protected override void OnUpdate()
        {
            GameManager gameManager = GameManager.instance;
            if (gameManager == null || !gameManager.gameMode.IsGame())
            {
                Enabled = false;
                return;
            }

            if (!Mod.TryGetSetting(out Setting setting))
            {
                Enabled = false;
                return;
            }

            int targetMultiplier = 100;
            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                targetMultiplier = math.clamp(
                    setting.GarbageAccumulationRate,
                    Setting.MinGarbageAccumulationRate,
                    Setting.MaxGarbageAccumulationRate);
            }

            foreach ((RefRW<ConsumptionData> consumption, Entity prefabEntity) in SystemAPI
                         .Query<RefRW<ConsumptionData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref ConsumptionData data = ref consumption.ValueRW;

                if (!TryGetAuthoringBase(prefabEntity, out float baseAccumulation))
                {
                    continue;
                }

                float targetAccumulation = baseAccumulation * targetMultiplier / 100f;
                if (data.m_GarbageAccumulation != targetAccumulation)
                {
                    data.m_GarbageAccumulation = targetAccumulation;
                }
            }

#if DEBUG
            LogUtils.Info($"[MG] GarbageAccumulationRate apply: target={targetMultiplier}%");
#endif

            Enabled = false;
        }

        private bool TryGetAuthoringBase(Entity prefabEntity, out float baseline)
        {
            baseline = 0f;

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase) || prefabBase == null)
            {
                return false;
            }

            if (prefabBase.TryGet(out Game.Prefabs.ServiceConsumption serviceConsumption))
            {
                baseline = serviceConsumption.m_GarbageAccumulation;
                return true;
            }

            if (prefabBase.TryGet(out Game.Prefabs.ZoneServiceConsumption zoneServiceConsumption))
            {
                baseline = zoneServiceConsumption.m_GarbageAccumulation;
                return true;
            }

            return false;
        }
    }
}
