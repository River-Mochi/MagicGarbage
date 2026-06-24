// <copyright file="GarbageFacilityCapacitySystem.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Systems/GarbageFacilityCapacitySystem.cs
// Trash Boss: scales garbage facility fleet, processing speed, and storage capacity.
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
    /// Adjusts GarbageFacilityData from authoring prefab values.
    /// Runs only on city load or when settings wake it, then disables itself.
    /// </summary>
    public partial class GarbageFacilityCapacitySystem : GameSystemBase
    {
        private readonly Dictionary<Entity, (int VehicleCap, int ProcessingSpeed, int StorageCap)> m_Base =
            new Dictionary<Entity, (int VehicleCap, int ProcessingSpeed, int StorageCap)>();

        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            RequireForUpdate<GarbageFacilityData>();

            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // Clear per-city/session cache. Next update reapplies from PrefabBase authoring values.
            m_Base.Clear();

            Enabled = true;

#if DEBUG
            LogUtils.Info("[MG] [Trash Boss] GarbageFacilityCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                Enabled = false;
                return;
            }

            int targetVehicle = 100;
            int targetProcessing = 100;
            int targetStorage = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetProcessing = math.clamp(setting.GarbageFacilityProcessingMultiplier, 100, 500);
                targetStorage = math.clamp(setting.GarbageFacilityStorageMultiplier, 100, 500);
                targetVehicle = math.clamp(setting.GarbageFacilityVehicleMultiplier, 100, 400);
            }

            float vehicleFactor = targetVehicle / 100f;
            float processingFactor = targetProcessing / 100f;
            float storageFactor = targetStorage / 100f;

            foreach ((RefRW<GarbageFacilityData> facility, Entity prefabEntity) in
                     SystemAPI.Query<RefRW<GarbageFacilityData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                if (!m_Base.TryGetValue(prefabEntity, out (int VehicleCap, int ProcessingSpeed, int StorageCap) baseline))
                {
                    if (!TryGetAuthoringBase(prefabEntity, out baseline))
                    {
                        baseline = (data.m_VehicleCapacity, data.m_ProcessingSpeed, data.m_GarbageCapacity);
                    }

                    m_Base[prefabEntity] = baseline;
                }

                int targetVehicleCap = (int)math.round(baseline.VehicleCap * vehicleFactor);
                int targetProcessingSpeed = (int)math.round(baseline.ProcessingSpeed * processingFactor);
                int targetStorageCap = (int)math.round(baseline.StorageCap * storageFactor);

                if (data.m_VehicleCapacity != targetVehicleCap)
                {
                    data.m_VehicleCapacity = targetVehicleCap;
                }

                if (data.m_ProcessingSpeed != targetProcessingSpeed)
                {
                    data.m_ProcessingSpeed = targetProcessingSpeed;
                }

                if (data.m_GarbageCapacity != targetStorageCap)
                {
                    data.m_GarbageCapacity = targetStorageCap;
                }
            }

#if DEBUG
            LogUtils.Info(
                $"[MG] FacilityCapacity apply: veh={targetVehicle}%, " +
                $"proc={targetProcessing}%, stor={targetStorage}%");
#endif

            Enabled = false;
        }

        private bool TryGetAuthoringBase(
            Entity prefabEntity,
            out (int VehicleCap, int ProcessingSpeed, int StorageCap) baseline)
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

            if (!prefabBase.TryGet(out Game.Prefabs.GarbageFacility authoring))
            {
                return false;
            }

            baseline = (
                authoring.m_VehicleCapacity,
                authoring.m_ProcessingSpeed,
                authoring.m_GarbageCapacity);

            return true;
        }
    }
}
