// <copyright file="GarbageAccumulationRateSystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/GarbageAccumulationRateSystem.cs
// Power User: scales prefab garbage accumulation source values.
// Total Magic, Trash Boss OFF, or Power User OFF: reverts to vanilla (100%) once, then sleeps.

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
    /// Scales prefab ConsumptionData.m_GarbageAccumulation for supported prefab sources.
    /// Uses authoring values when possible, with cached live-prefab fallback if authoring lookup fails.
    /// This targets prefab source values instead of live building garbage so vanilla systems can continue
    /// to recalculate accumulation naturally each update.
    /// </summary>
    public partial class GarbageAccumulationRateSystem : GameSystemBase
    {
        private int m_LastMultiplier = 100;
        private bool m_ForceApply;

        // Prefab entity -> baseline garbage accumulation source value.
        private readonly Dictionary<Entity, float> m_Base = new Dictionary<Entity, float>();

        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            RequireForUpdate<ConsumptionData>();
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
            LogUtils.Info("[MG] [Power User] GarbageAccumulationRateSystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
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

            if (!m_ForceApply && targetMultiplier == m_LastMultiplier)
            {
#if DEBUG
                LogUtils.Info("[MG] [Power User] GarbageAccumulationRate sleep");
#endif
                Enabled = false;
                return;
            }

            // Only touch prefab entities here.
            // Live buildings keep using vanilla recalculation from these prefab source values.
            foreach ((RefRW<ConsumptionData> consumption, Entity entity) in SystemAPI
                         .Query<RefRW<ConsumptionData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref ConsumptionData data = ref consumption.ValueRW;

                // Cache baseline once per prefab entity so scaling stays stable and reversible to vanilla.
                if (!m_Base.TryGetValue(entity, out float baseAccumulation))
                {
                    if (!TryGetAuthoringBase(entity, out baseAccumulation))
                    {
                        if (m_LastMultiplier == 100)
                        {
                            baseAccumulation = data.m_GarbageAccumulation;
                        }
                        // Fallback: if authoring lookup fails, undo the last applied multiplier once
                        // to approximate the original prefab source value before applying new multiplier.
                        else
                        {
                            float lastFactor = m_LastMultiplier / 100f;
                            baseAccumulation = data.m_GarbageAccumulation / lastFactor;
                        }
                    }

                    m_Base[entity] = baseAccumulation;
                }

                data.m_GarbageAccumulation = baseAccumulation * (targetMultiplier / 100f);
            }

#if DEBUG
            LogUtils.Info($"[MG] GarbageAccumulationRate apply: {m_LastMultiplier}% -> {targetMultiplier}%");
#endif

            m_LastMultiplier = targetMultiplier;
            m_ForceApply = false;
            Enabled = false;
        }

        // Prefer authoring prefab values as true baseline.
        // ServiceConsumption covers service/unique-style buildings.
        // ZoneServiceConsumption covers zoned buildings source values.
        private bool TryGetAuthoringBase(Entity prefabEntity, out float baseline)
        {
            baseline = 0f;

            if (m_PrefabSystem == null)
            {
                return false;
            }

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
