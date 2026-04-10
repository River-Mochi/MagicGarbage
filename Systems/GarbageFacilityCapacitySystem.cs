// File: Systems/GarbageFacilityCapacitySystem.cs
// Trash Boss: scales facility trucks, processing speed, and storage capacity.
// Total Magic (or Trash Boss OFF): reverts to vanilla (100%) once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using System.Collections.Generic;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageFacilityData (vehicle count, processing speed, storage)
    /// according to Trash Boss sliders. When Total Magic is enabled (or Trash Boss disabled),
    /// it reverts to vanilla (100%) once.
    /// Uses authoring prefab values as the true baseline, with cache fallback if authoring lookup fails.
    /// </summary>
    public partial class GarbageFacilityCapacitySystem : GameSystemBase
    {
        private int m_LastVehicleMultiplier = 100;
        private int m_LastProcessingMultiplier = 100;
        private int m_LastStorageMultiplier = 100;

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

            m_Base.Clear();
            m_LastVehicleMultiplier = 100;
            m_LastProcessingMultiplier = 100;
            m_LastStorageMultiplier = 100;

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MG] [Trash Boss] GarbageFacilityCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
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

            if (targetVehicle == m_LastVehicleMultiplier &&
                targetProcessing == m_LastProcessingMultiplier &&
                targetStorage == m_LastStorageMultiplier)
            {
#if DEBUG
                Mod.Log.Info("[MG] [Trash Boss] FacilityCapacity sleep");
#endif
                Enabled = false;
                return;
            }

            foreach ((RefRW<GarbageFacilityData> facility, Entity entity) in
                     SystemAPI.Query<RefRW<GarbageFacilityData>>().WithEntityAccess())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                if (!m_Base.TryGetValue(entity, out (int VehicleCap, int ProcessingSpeed, int StorageCap) b))
                {
                    if (!TryGetAuthoringBase(entity, out b))
                    {
                        if (m_LastVehicleMultiplier == 100 &&
                            m_LastProcessingMultiplier == 100 &&
                            m_LastStorageMultiplier == 100)
                        {
                            b = (data.m_VehicleCapacity, data.m_ProcessingSpeed, data.m_GarbageCapacity);
                        }
                        else
                        {
                            float v = m_LastVehicleMultiplier / 100f;
                            float p = m_LastProcessingMultiplier / 100f;
                            float s = m_LastStorageMultiplier / 100f;

                            b = (
                                (int)math.round(data.m_VehicleCapacity / v),
                                (int)math.round(data.m_ProcessingSpeed / p),
                                (int)math.round(data.m_GarbageCapacity / s));
                        }
                    }

                    m_Base[entity] = b;
                }

                data.m_VehicleCapacity = (int)math.round(b.VehicleCap * (targetVehicle / 100f));
                data.m_ProcessingSpeed = (int)math.round(b.ProcessingSpeed * (targetProcessing / 100f));
                data.m_GarbageCapacity = (int)math.round(b.StorageCap * (targetStorage / 100f));
            }

#if DEBUG
            Mod.Log.Info(
                $"[MG] FacilityCapacity apply: veh {m_LastVehicleMultiplier}%->{targetVehicle}%, " +
                $"proc {m_LastProcessingMultiplier}%->{targetProcessing}%, " +
                $"stor {m_LastStorageMultiplier}%->{targetStorage}%");
#endif

            m_LastVehicleMultiplier = targetVehicle;
            m_LastProcessingMultiplier = targetProcessing;
            m_LastStorageMultiplier = targetStorage;

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
