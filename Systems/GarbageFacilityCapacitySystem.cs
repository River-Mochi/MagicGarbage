// File: Systems/GarbageFacilityCapacitySystem.cs
// Semi-Magic: scales facility trucks, processing speed, and storage capacity.
// Total Magic (or Semi-Magic OFF): reverts to vanilla (100%) once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageFacilityData (vehicle count, processing speed, storage)
    /// according to Semi-Magic sliders. When Total Magic is enabled (or Semi-Magic disabled),
    /// it reverts to vanilla (100%) once.
    /// </summary>
    public partial class GarbageFacilityCapacitySystem : GameSystemBase
    {
        // Last applied multipliers (percent). 100 = vanilla.
        private int m_LastVehicleMultiplier = 100;
        private int m_LastProcessingMultiplier = 100;
        private int m_LastStorageMultiplier = 100;

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

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MGT] GarbageFacilityCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            var setting = Mod.Setting;
            if (setting == null)
            {
                return; // don't disable if null; allow a later tick to catch
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

            // Compute scale factors relative to previous state so changes (and reverts) are incremental.
            float vehicleScale = (float)targetVehicle / m_LastVehicleMultiplier;
            float processingScale = (float)targetProcessing / m_LastProcessingMultiplier;
            float storageScale = (float)targetStorage / m_LastStorageMultiplier;

            foreach (RefRW<GarbageFacilityData> facility in SystemAPI.Query<RefRW<GarbageFacilityData>>())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                data.m_ProcessingSpeed = (int)math.round(data.m_ProcessingSpeed * processingScale);
                data.m_GarbageCapacity = (int)math.round(data.m_GarbageCapacity * storageScale);
                data.m_VehicleCapacity = (int)math.round(data.m_VehicleCapacity * vehicleScale);
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
