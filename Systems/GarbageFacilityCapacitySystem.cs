// Systems/GarbageFacilityCapacitySystem.cs
// Semi-Magic: scales facility trucks, processing speed, and storage capacity.

namespace MagicGarbage
{
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageFacilityData (vehicle count, processing speed, storage)
    /// according to Semi-Magic sliders. Disabled while Total Magic is enabled.
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

            // System runs only when Setting.Apply() turns it on.
            Enabled = false;
        }

        protected override void OnUpdate()
        {
            Setting? setting = Mod.Setting;
            if (setting == null)
            {
                Enabled = false;
                return;
            }

            // If Total Magic mode is on, Semi-Magic facility tuning is pointless.
            if (setting.TotalMagic)
            {
                Enabled = false;
                return;
            }

            // Semi-Magic must be enabled for these sliders to matter.
            if (!setting.SemiMagic)
            {
                Enabled = false;
                return;
            }

            // Clamp sliders to safe ranges.
            // Facility trucks: 100–400% (up to +300% more)
            int vehicleMult =
                math.clamp(setting.GarbageFacilityVehicleMultiplier, 100, 400);

            // Processing speed: 100–500%
            int processingMult =
                math.clamp(setting.GarbageFacilityProcessingMultiplier, 100, 500);

            // Storage capacity: 100–500%
            int storageMult =
                math.clamp(setting.GarbageFacilityStorageMultiplier, 100, 500);

            // If nothing changed since last application, bail out.
            if (vehicleMult == m_LastVehicleMultiplier &&
                processingMult == m_LastProcessingMultiplier &&
                storageMult == m_LastStorageMultiplier)
            {
                Enabled = false;
                return;
            }

            // Compute scale factors relative to previous state so changes are incremental.
            float vehicleScale =
                (float)vehicleMult / m_LastVehicleMultiplier;
            float processingScale =
                (float)processingMult / m_LastProcessingMultiplier;
            float storageScale =
                (float)storageMult / m_LastStorageMultiplier;

            // Scale all garbage facility prefabs in-place.
            Entities
                .ForEach((ref GarbageFacilityData data) =>
                {
                    // Number of trucks this facility can have.
                    data.m_VehicleCapacity =
                        (int)math.round(data.m_VehicleCapacity * vehicleScale);

                    // How quickly it processes garbage.
                    data.m_ProcessingSpeed =
                        (int)math.round(data.m_ProcessingSpeed * processingScale);

                    // How much garbage it can store.
                    data.m_GarbageCapacity =
                        (int)math.round(data.m_GarbageCapacity * storageScale);
                })
                .Run(); // Only a handful of prefabs; main thread is fine.

            // Remember new multipliers for next time.
            m_LastVehicleMultiplier = vehicleMult;
            m_LastProcessingMultiplier = processingMult;
            m_LastStorageMultiplier = storageMult;

            // Go back to sleep until settings change again.
            Enabled = false;
        }
    }
}
