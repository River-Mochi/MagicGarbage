// <copyright file="GarbageTruckCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/GarbageTruckCapacitySystem.cs
// Trash Boss: scales truck prefab capacity & unload rate.
// Total Magic (or Trash Boss OFF): reverts to vanilla (100%) once, then sleeps.

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
    /// Scales garbage truck capacity and unload rate according to the Trash Boss slider.
    /// When Total Magic is enabled (or Trash Boss disabled), it reverts to vanilla (100%) once.
    /// Uses authoring prefab values as the true baseline, with cache fallback if authoring lookup fails.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        private int m_LastMultiplier = 100;
        private bool m_ForceApply;

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

            m_Base.Clear();
            m_LastMultiplier = 100;
            m_ForceApply = true;

            Enabled = true;

#if DEBUG
            LogUtils.Info("[MG] [Trash Boss] GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            int targetMult = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);
            }

            if (!m_ForceApply && targetMult == m_LastMultiplier)
            {
#if DEBUG
                LogUtils.Info("[MG] [Trash Boss] TruckCapacity sleep");
#endif
                Enabled = false;
                return;
            }

            foreach ((RefRW<GarbageTruckData> truck, Entity entity) in SystemAPI
                         .Query<RefRW<GarbageTruckData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                if (!m_Base.TryGetValue(entity, out (int Capacity, int UnloadRate) b))
                {
                    if (!TryGetAuthoringBase(entity, out b))
                    {
                        if (m_LastMultiplier == 100)
                        {
                            b = (data.m_GarbageCapacity, data.m_UnloadRate);
                        }
                        else
                        {
                            float lastFactor = m_LastMultiplier / 100f;
                            b = (
                                (int)math.round(data.m_GarbageCapacity / lastFactor),
                                (int)math.round(data.m_UnloadRate / lastFactor));
                        }
                    }

                    m_Base[entity] = b;
                }

                data.m_GarbageCapacity = (int)math.round(b.Capacity * (targetMult / 100f));
                data.m_UnloadRate = (int)math.round(b.UnloadRate * (targetMult / 100f));
            }

#if DEBUG
            LogUtils.Info($"[MG] TruckCapacity apply: {m_LastMultiplier}% -> {targetMult}%");
#endif

            m_LastMultiplier = targetMult;
            m_ForceApply = false;
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
