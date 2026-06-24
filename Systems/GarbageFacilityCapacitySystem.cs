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
    using Colossal.Serialization.Entities; // Purpose
    using CS2Shared.RiverMochi; // LogUtils
    using Game;
    using Game.Prefabs;
    using Game.SceneFlow;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// One-shot prefab system that adjusts GarbageFacilityData from PrefabBase
    /// authoring values. The system is enabled on city load or by settings callbacks,
    /// applies once, then disables itself.
    /// </summary>
    public partial class GarbageFacilityCapacitySystem : GameSystemBase
    {
        private PrefabSystem m_PrefabSystem = null!;
        private EntityQuery m_GarbageFacilityPrefabQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            m_GarbageFacilityPrefabQuery = SystemAPI.QueryBuilder()
                .WithAll<PrefabData>()
                .WithAllRW<GarbageFacilityData>()
                .Build();

            RequireForUpdate(m_GarbageFacilityPrefabQuery);

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
            LogUtils.Info("[MG] [Trash Boss] GarbageFacilityCapacitySystem: city load -> Enabled");
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

            int targetVehicle = 100;
            int targetProcessing = 100;
            int targetStorage = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetProcessing = math.clamp(setting.GarbageFacilityProcessingMultiplier, 100, 500);
                targetStorage = math.clamp(setting.GarbageFacilityStorageMultiplier, 100, 500);
                targetVehicle = math.clamp(setting.GarbageFacilityVehicleMultiplier, 100, 400);
            }

            foreach ((RefRW<GarbageFacilityData> facility, Entity prefabEntity) in SystemAPI
                         .Query<RefRW<GarbageFacilityData>>()
                         .WithAll<PrefabData>()
                         .WithEntityAccess())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                if (!TryGetAuthoringBase(
                        prefabEntity,
                        out int baseVehicleCapacity,
                        out int baseProcessingSpeed,
                        out int baseGarbageCapacity))
                {
                    continue;
                }

                int targetVehicleCapacity = ScalePercentKeepZero(baseVehicleCapacity, targetVehicle);
                int targetProcessingSpeed = ScalePercentKeepZero(baseProcessingSpeed, targetProcessing);
                int targetGarbageCapacity = ScalePercentKeepZero(baseGarbageCapacity, targetStorage);

                if (data.m_VehicleCapacity != targetVehicleCapacity)
                {
                    data.m_VehicleCapacity = targetVehicleCapacity;
                }

                if (data.m_ProcessingSpeed != targetProcessingSpeed)
                {
                    data.m_ProcessingSpeed = targetProcessingSpeed;
                }

                if (data.m_GarbageCapacity != targetGarbageCapacity)
                {
                    data.m_GarbageCapacity = targetGarbageCapacity;
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
            out int vehicleCapacity,
            out int processingSpeed,
            out int garbageCapacity)
        {
            vehicleCapacity = 0;
            processingSpeed = 0;
            garbageCapacity = 0;

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase) || prefabBase == null)
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.GarbageFacility authoring))
            {
                return false;
            }

            vehicleCapacity = authoring.m_VehicleCapacity;
            processingSpeed = authoring.m_ProcessingSpeed;
            garbageCapacity = authoring.m_GarbageCapacity;
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
