// File: Systems/GarbageFacilityCapacitySystem.cs
// Semi-Magic: scales facility trucks, processing speed, and storage capacity.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Adjusts GarbageFacilityData (vehicle count, processing speed, storage)
    /// according to Semi-Magic sliders. Disabled while full TotalMagic is enabled.
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
            Mod.Log.Info($"{Mod.ModTag} GarbageFacilityCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                // don't disable if settings aren't ready yet; allow a later tick to catch
                return;
            }

            // If full TotalMagic is on, Semi-Magic facility tuning is pointless.
            if (setting.TotalMagic)
            {
                Enabled = false;
                return;
            }

            // Semi-Magic must be enabled for these sliders to matter.
            if (!setting.SemiMagicEnabled)
            {
                Enabled = false;
                return;
            }

            // Clamp sliders:
            var processingMult =
                math.clamp(setting.GarbageFacilityProcessingMultiplier, 100, 500);  // processing up to 500%
            var storageMult =
                math.clamp(setting.GarbageFacilityStorageMultiplier, 100, 500);     // storage up to 500%
            var vehicleMult =
                math.clamp(setting.GarbageFacilityVehicleMultiplier, 100, 400);     // number of trucks up to 400%

            // If nothing changed since last application, bail out.
            if (vehicleMult == m_LastVehicleMultiplier &&
                processingMult == m_LastProcessingMultiplier &&
                storageMult == m_LastStorageMultiplier)
            {
                Enabled = false;
                return;
            }

            // Compute scale factors relative to previous state so changes are incremental.
            var vehicleScale =
                (float)vehicleMult / m_LastVehicleMultiplier;
            var processingScale =
                (float)processingMult / m_LastProcessingMultiplier;
            var storageScale =
                (float)storageMult / m_LastStorageMultiplier;
#if DEBUG
Mod.Log.Info(
    $"{Mod.ModTag} FacilityCapacity apply: veh {m_LastVehicleMultiplier}%->{vehicleMult}%, " +
    $"proc {m_LastProcessingMultiplier}%->{processingMult}%, stor {m_LastStorageMultiplier}%->{storageMult}%");
#endif

            // Chunk-friendly SystemAPI iteration over all garbage facilities.
            foreach (RefRW<GarbageFacilityData> facility in SystemAPI.Query<RefRW<GarbageFacilityData>>())
            {
                ref GarbageFacilityData data = ref facility.ValueRW;

                // How quickly it processes garbage.
                data.m_ProcessingSpeed =
                    (int)math.round(data.m_ProcessingSpeed * processingScale);
                // How much garbage it can store.
                data.m_GarbageCapacity =
                    (int)math.round(data.m_GarbageCapacity * storageScale);
                // Number of trucks this facility can have.
                data.m_VehicleCapacity =
                    (int)math.round(data.m_VehicleCapacity * vehicleScale);
            }

            // Remember new multipliers for next time.
            m_LastVehicleMultiplier = vehicleMult;
            m_LastProcessingMultiplier = processingMult;
            m_LastStorageMultiplier = storageMult;
#if DEBUG
Mod.Log.Info($"{Mod.ModTag} FacilityCapacity sleep");
#endif
            Enabled = false;    // Go back to sleep until settings change again.
        }
    }
}
