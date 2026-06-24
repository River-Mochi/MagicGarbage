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
    using System.Collections.Generic;
    using Colossal.Serialization.Entities; // Purpose
    using CS2Shared.RiverMochi; // LogUtils
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Scales garbage truck prefab capacity and unload rate from authoring prefab values.
    /// Runs only on city load or when settings wake it, then disables itself.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        private readonly Dictionary<Entity, (int Capacity, int UnloadRate)> m_Base = new();

        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            RequireForUpdate<GarbageTruckData>();

            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // Clear per-city/session cache. Next update reapplies from PrefabBase authoring values.
            m_Base.Clear();

            Enabled = true;

#if DEBUG
            LogUtils.Info("[MG] [Trash Boss] GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                Enabled = false;
                return;
            }

            int targetMult = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);
            }

            float factor = targetMult / 100f;

            foreach ((RefRW<GarbageTruckData> truck, Entity prefabEntity) in
                     SystemAPI.Query<RefRW<GarbageTruckData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                if (!m_Base.TryGetValue(prefabEntity, out (int Capacity, int UnloadRate) baseline))
                {
                    if (!TryGetAuthoringBase(prefabEntity, out baseline))
                    {
                        baseline = (data.m_GarbageCapacity, data.m_UnloadRate);
                    }

                    m_Base[prefabEntity] = baseline;
                }

                int targetCapacity = (int)math.round(baseline.Capacity * factor);
                int targetUnloadRate = (int)math.round(baseline.UnloadRate * factor);

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

        private bool TryGetAuthoringBase(Entity prefabEntity, out (int Capacity, int UnloadRate) baseline)
        {
            baseline = default;

            if (m_PrefabSystem == null)
            {
                return false;
            }

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase) || prefabBase == null)
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.GarbageTruck authoring))
            {
                return false;
            }

            baseline = (authoring.m_GarbageCapacity, authoring.m_UnloadRate);
            return true;
        }
    }
}
