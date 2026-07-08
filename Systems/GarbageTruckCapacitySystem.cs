// <copyright file="GarbageTruckCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/GarbageTruckCapacitySystem.cs
// Trash Boss: scales garbage truck prefab capacity and unload rate.
// Total Magic or Trash Boss OFF: restores prefab values to vanilla 100% once, then sleeps.

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
    /// One-shot prefab system that scales garbage truck capacity and unload rate
    /// from PrefabBase authoring values. The system is enabled on city load or
    /// by settings callbacks, applies once, then disables itself.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private EntityQuery m_GarbageTruckPrefabQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            m_GarbageTruckPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData>()
                .WithAllRW<GarbageTruckData>()
                .Build();

            RequireForUpdate(m_GarbageTruckPrefabQuery);

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
            LogUtils.Info("[MG] [Trash Boss] GarbageTruckCapacitySystem: city load -> Enabled");
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

            int targetMult = 100;
            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 1000);
            }

            foreach ((RefRW<GarbageTruckData> truck, Entity prefabEntity) in SystemAPI
                         .Query<RefRW<GarbageTruckData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                if (!TryGetAuthoringBase(prefabEntity, out int baseCapacity, out int baseUnloadRate))
                {
                    continue;
                }

                int targetCapacity = ScalePercentKeepZero(baseCapacity, targetMult);
                int targetUnloadRate = ScalePercentKeepZero(baseUnloadRate, targetMult);

                if (data.m_GarbageCapacity != targetCapacity)
                {
                    data.m_GarbageCapacity = targetCapacity;
                }

                if (data.m_UnloadRate != targetUnloadRate)
                {
                    data.m_UnloadRate = targetUnloadRate;
                }
            }

#if DEBUG
            LogUtils.Info($"[MG] TruckCapacity apply: target={targetMult}%");
#endif

            Enabled = false;
        }

        private bool TryGetAuthoringBase(Entity prefabEntity, out int capacity, out int unloadRate)
        {
            capacity = 0;
            unloadRate = 0;

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase) || prefabBase == null)
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.GarbageTruck authoring))
            {
                return false;
            }

            capacity = authoring.m_GarbageCapacity;
            unloadRate = authoring.m_UnloadRate;
            return true;
        }

        private static int ScalePercentKeepZero(int baseValue, int percent)
        {
            if (baseValue <= 0)
            {
                return 0;
            }

            return math.max(1, (int)math.round(baseValue * percent / 100f));
        }
    }
}
