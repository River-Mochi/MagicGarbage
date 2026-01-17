// File: Systems/GarbageTruckCapacitySystem.cs
// Semi-Magic: scales truck prefab capacity & unload rate.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Scales garbage truck capacity and unload rate according to the Semi-Magic sliders.
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

            // Stay asleep most of the time; OnGameLoadingComplete and Setting.Apply() for wake up.
            Enabled = false;
        }

        /// <summary>
        /// City load completed (new game/load save/switch city). Kick once so saved .coc is applied.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            // No extra GameMode gating: RequireForUpdate prevents useless work.
            Enabled = true;

#if DEBUG
            Mod.Log.Info($"{Mod.ModTag} GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                // IMPORTANT: do not force-disable if settings aren't ready yet.
                return;
            }

            // Total Magic overrides everything.
            if (setting.TotalMagic)
            {
                Enabled = false;
                return;
            }

            // Sliders don't matter if semi-magic toggle is off.
            if (!setting.SemiMagicEnabled)
            {
                Enabled = false;
                return;
            }

            var newMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500); // max 500%

            // Slider value unchanged since last run: nothing to update.
            if (newMult == m_LastMultiplier)
            {
                Enabled = false;
                return;
            }

            var oldFactor = m_LastMultiplier / 100f;
            var newFactor = newMult / 100f;
            var scale = newFactor / oldFactor;

#if DEBUG
Mod.Log.Info($"{Mod.ModTag} TruckCapacity apply: {m_LastMultiplier}% -> {newMult}%");
#endif
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
#if DEBUG
Mod.Log.Info($"{Mod.ModTag} TruckCapacity sleep");
#endif
            Enabled = false;     // Back to sleep until next OptionsUI change or city load.
        }
    }
}
