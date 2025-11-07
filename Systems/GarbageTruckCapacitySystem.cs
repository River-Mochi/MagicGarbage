// Systems/GarbageTruckCapacitySystem.cs

using Game;
using Game.Prefabs;
using Unity.Entities;
using Unity.Mathematics;

namespace MagicGarbage
{
    /// <summary>
    /// Semi-Magic: scales garbage truck Capacity and Unload rate for
    ///   players who want fewer trucks and still have a garbage service.
    /// Does nothing while Total Magic (MagicGarbage) is on.
    ///
    /// This system is meant to run ONCE when the slider changes:
    /// - Setting.Apply() sets Enabled = true
    /// - OnUpdate rescales all GarbageTruckData and then disables itself again.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        // Last applied slider value (percent). 100 = vanilla.
        private int m_LastMultiplier = 100;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Skip this system entirely unless the world contains garbage truck prefabs
            RequireForUpdate<GarbageTruckData>();

            // System wakes up only when Setting.Apply() toggles Enabled = true.
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

            // If Total Magic is enabled, truck capacity not needed, bail early.
            if (setting.MagicGarbage)
            {
                Enabled = false;
                return;
            }

            // Slider stored as 100–500 (%)
            int newMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);

            // Nothing changed since last time → nothing to do.
            if (newMult == m_LastMultiplier)
            {
                Enabled = false;
                return;
            }

            float oldFactor = m_LastMultiplier / 100f;
            float newFactor = newMult / 100f;
            float scale = newFactor / oldFactor;

            // Rescale all garbage truck prefabs in-place.
            // We touch *both* capacity and unload rate so a truck still
            // unloades in roughly the same number of in-game seconds.
            Entities
                .ForEach((ref GarbageTruckData data) =>
                {
                    data.m_GarbageCapacity =
                        (int)math.round(data.m_GarbageCapacity * scale);

                    data.m_UnloadRate =
                        (int)math.round(data.m_UnloadRate * scale);
                })
                .Run(); // runs once on the main thread, fine for a few prefabs

            m_LastMultiplier = newMult;

            // Go back to sleep until Setting.Apply() wakes us up again.
            Enabled = false;
        }
    }
}
