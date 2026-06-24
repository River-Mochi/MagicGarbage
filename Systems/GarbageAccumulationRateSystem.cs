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
    using System.Collections.Generic;
    using Colossal.Serialization.Entities; // Purpose
    using CS2Shared.RiverMochi; // LogUtils
    using Game;
    using Game.Prefabs;
    using Unity.Entities;

    /// <summary>
    /// Scales prefab ConsumptionData.m_GarbageAccumulation for supported prefab sources.
    /// Runs only on city load or when settings wake it, then disables itself.
    /// </summary>
    public partial class GarbageAccumulationRateSystem : GameSystemBase
    {
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

            // Clear per-city/session cache. Next update reapplies from PrefabBase authoring values.
            m_Base.Clear();

            Enabled = true;

#if DEBUG
            LogUtils.Info("[MG] [Power User] GarbageAccumulationRateSystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                Enabled = false;
                return;
            }

            int targetMultiplier = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                targetMultiplier = Unity.Mathematics.math.clamp(
                    setting.GarbageAccumulationRate,
                    Setting.MinGarbageAccumulationRate,
                    Setting.MaxGarbageAccumulationRate);
            }

            float factor = targetMultiplier / 100f;

            // Only touch prefab entities here.
            // Live buildings keep using vanilla recalculation from these prefab source values.
            foreach ((RefRW<ConsumptionData> consumption, Entity prefabEntity) in
                     SystemAPI.Query<RefRW<ConsumptionData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref ConsumptionData data = ref consumption.ValueRW;

                if (!m_Base.TryGetValue(prefabEntity, out float baseAccumulation))
                {
                    if (!TryGetAuthoringBase(prefabEntity, out baseAccumulation))
                    {
                        baseAccumulation = data.m_GarbageAccumulation;
                    }

                    m_Base[prefabEntity] = baseAccumulation;
                }

                float targetAccumulation = baseAccumulation * factor;

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
