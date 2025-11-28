// Systems/GarbageTruckCapacitySystem.cs
// Semi-Magic: scales truck prefab capacity & unload rate.

namespace MagicGarbage
{
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Scales garbage truck capacity and unload rate according to the Semi-Magic slider.
    /// Disabled while Total Magic is enabled.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        // Last applied slider value percent, 100 = vanilla.
        private int m_LastMultiplier = 100;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Do not run at all unless garbage truck prefabs exist.
            RequireForUpdate<GarbageTruckData>();

            // System is driven by Setting.Apply().
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

            // Total Magic overrides everything.
            if (setting.TotalMagic)
            {
                Enabled = false;
                return;
            }

            // Semi-Magic must be enabled for sliders to matter.
            if (!setting.SemiMagicEnabled)
            {
                Enabled = false;
                return;
            }

            // Slider stored as 100–500 %.
            var newMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);

            // Slider value unchanged since last run: nothing to update.
            if (newMult == m_LastMultiplier)
            {
                Enabled = false;
                return;
            }

            var oldFactor = m_LastMultiplier / 100f;
            var newFactor = newMult / 100f;
            var scale = newFactor / oldFactor;

            // Chunk-friendly iteration via SystemAPI.Query.
            foreach (RefRW<GarbageTruckData> truck in SystemAPI.Query<RefRW<GarbageTruckData>>())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                // Capacity and unload rate both scaled so unload time stays roughly stable.
                data.m_GarbageCapacity =
                    (int)math.round(data.m_GarbageCapacity * scale);

                data.m_UnloadRate =
                    (int)math.round(data.m_UnloadRate * scale);
            }

            m_LastMultiplier = newMult;

            // Back to disabled until Setting.Apply() sets Enabled = true again.
            Enabled = false;
        }
    }
}
