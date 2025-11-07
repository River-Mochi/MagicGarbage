// Systems/GarbageTruckCapacitySystem.cs

using Game;
using Game.Prefabs;
using Unity.Entities;
using Unity.Mathematics;

namespace MagicGarbage
{
    /// <summary>
    /// Scales garbage truck capacity and unload rate according to the Semi-Magic slider.
    /// Disabled while Total Magic (MagicGarbage) is enabled.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        // Last applied slider value (percent). 100 = vanilla.
        private int m_LastMultiplier = 100;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Do not run at all unless garbage truck prefabs exist in this world.
            RequireForUpdate<GarbageTruckData>();

            // System is driven explicitly by Setting.Apply().
            Enabled = false;
        }

        protected override void OnUpdate()
        {
            var setting = Mod.Setting;
            if (setting == null)
            {
                Enabled = false;
                return;
            }

            // When Total Magic is enabled, capacity scaling is disabled.
            if (setting.MagicGarbage)
            {
                Enabled = false;
                return;
            }

            // Slider is stored as 100–500 (%).
            int newMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);

            // No change since the previous run.
            if (newMult == m_LastMultiplier)
            {
                Enabled = false;
                return;
            }

            float oldFactor = m_LastMultiplier / 100f;
            float newFactor = newMult / 100f;
            float scale = newFactor / oldFactor;

            // Rescale all garbage truck prefabs in-place.
            // Both capacity and unload rate are scaled so unload time stays roughly stable.
            Entities
                .ForEach((ref GarbageTruckData data) =>
                {
                    data.m_GarbageCapacity =
                        (int)math.round(data.m_GarbageCapacity * scale);

                    data.m_UnloadRate =
                        (int)math.round(data.m_UnloadRate * scale);
                })
                .Run(); // Executes once on the main thread; only a small number of prefabs.

            m_LastMultiplier = newMult;

            // Back to disabled until Setting.Apply() sets Enabled = true again.
            Enabled = false;
        }
    }
}
