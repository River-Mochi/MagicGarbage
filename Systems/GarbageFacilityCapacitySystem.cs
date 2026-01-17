// File: Systems/GarbageFacilityCapacitySystem.cs
// Semi-Magic: scales facility trucks, processing speed, and storage capacity.
// Total Magic (or Semi-Magic OFF): reverts to vanilla (100%) once, then sleeps.

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
    /// according to Semi-Magic sliders. When Total Magic is enabled (or Semi-Magic disabled),
    /// it reverts to vanilla (100%) once.
    /// Uses cached base values to avoid rounding drift.
    /// </summary>
    public partial class GarbageFacilityCapacitySystem : GameSystemBase
    {
        // Last applied multipliers (percent). 100 = vanilla.
        private int m_LastVehicleMultiplier = 100;
        private int m_LastProcessingMultiplier = 100;
        private int m_LastStorageMultiplier = 100;

        // Cache base values per prefab entity so scaling is exact (no drift).
        private readonly Dictionary<Entity, (int VehicleCap, int ProcessingSpeed, int StorageCap)> m_Base =
            new Dictionary<Entity, (int VehicleCap, int ProcessingSpeed, int StorageCap)>();

        protected override void OnCreate()
        {
            base.OnCreate();

            // Only run if there are any garbage facilities.
            RequireForUpdate<GarbageFacilityData>();

            // Wake on city load + UI changes only.
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
            Mod.Log.Info("[MGT] GarbageFacilityCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return; // allow a later tick to catch
            }

            // Effective targets:
            // - Total Magic ON => behave like vanilla 100% (but keep user's saved Semi sliders).
            // - Semi-Magic OFF => also behave like vanilla 100%.
            // - Semi-Magic ON  => use sliders.
            int targetVehicle = 100;
            int targetProcessing = 100;
            int targetStorage = 100;

            if (!setting.TotalMagic && setting.SemiMagicEnabled)
            {
                targetProcessing = math.clamp(setting.GarbageFacilityProcessingMultiplier, 100, 500);
                targetStorage = math.clamp(setting.GarbageFacilityStorageMultiplier, 100, 500);
                targetVehicle = math.clamp(setting.GarbageFacilityVehicleMultiplier, 100, 400);
            }

            // If nothing changed since last application, bail out.
            if (targetVehicle == m_LastVehicleMultiplier &&
                targetProcessing == m_LastProcessingMultiplier &&
                targetStorage == m_LastStorageMultiplier)
            {
#if DEBUG
                Mod.Log.Info("[MGT] FacilityCapacity sleep");
#endif
                Enabled = false;
                return;
            }

            foreach ((RefRW<GarbageFacilityData> facility, Entity entity) in
                     SystemAPI.Query<RefRW<GarbageFacilityData>>().WithEntityAccess())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                if (!m_Base.TryGetValue(entity, out var b))
                {
                    // Capture base values the first time we touch this prefab entity.
                    // If we were already scaled in-session, reverse last multipliers once (best-effort).
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
                            (int)math.round(data.m_GarbageCapacity / s)
                        );
                    }

                    m_Base[entity] = b;
                }

                data.m_VehicleCapacity = (int)math.round(b.VehicleCap * (targetVehicle / 100f));
                data.m_ProcessingSpeed = (int)math.round(b.ProcessingSpeed * (targetProcessing / 100f));
                data.m_GarbageCapacity = (int)math.round(b.StorageCap * (targetStorage / 100f));
            }

#if DEBUG
            Mod.Log.Info(
                $"[MGT] FacilityCapacity apply: veh {m_LastVehicleMultiplier}%->{targetVehicle}%, " +
                $"proc {m_LastProcessingMultiplier}%->{targetProcessing}%, " +
                $"stor {m_LastStorageMultiplier}%->{targetStorage}%");
#endif

            m_LastVehicleMultiplier = targetVehicle;
            m_LastProcessingMultiplier = targetProcessing;
            m_LastStorageMultiplier = targetStorage;

            Enabled = false; // Go back to sleep until settings change again.
        }
    }
}
