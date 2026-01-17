// File: Systems/GarbageTruckCapacitySystem.cs
// Semi-Magic: scales truck prefab capacity & unload rate.
// Total Magic (or Semi-Magic OFF): reverts to vanilla (100%) once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Scales garbage truck capacity and unload rate according to the Semi-Magic slider.
    /// When Total Magic is enabled (or Semi-Magic disabled), it reverts to vanilla (100%) once.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        // Last applied multiplier percent. 100 = vanilla.
        private int m_LastMultiplier = 100;

        protected override void OnCreate()
        {
            base.OnCreate();

            // Do not run at all unless garbage truck prefabs exist.
            RequireForUpdate<GarbageTruckData>();

            // Stay asleep most of the time; OnGameLoadingComplete and Setting.Apply() wake it.
            Enabled = false;
        }

        /// <summary>
        /// City load completed (new game/load save/switch city). Kick once so saved .coc is applied.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MGT] GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            var setting = Mod.Setting;
            if (setting == null)
            {
                // Don't force-disable if null; allow a later tick to catch.
                return;
            }

            // Decide what the effective multiplier should be right now.
            // - Total Magic ON => behave like vanilla 100% (but keep user's saved Semi sliders).
            // - Semi-Magic OFF => also behave like vanilla 100%.
            // - Semi-Magic ON  => use slider.
            int targetMult = 100;

            if (!setting.TotalMagic && setting.SemiMagicEnabled)
            {
                targetMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);
            }

            // Nothing to do.
            if (targetMult == m_LastMultiplier)
            {
#if DEBUG
                Mod.Log.Info("[MGT] TruckCapacity sleep");
#endif
                Enabled = false;
                return;
            }

            // Scale relative to last applied value so it can be reverted cleanly (e.g. 200% -> 100%).
            float oldFactor = m_LastMultiplier / 100f;
            float newFactor = targetMult / 100f;
            float scale = newFactor / oldFactor;

            foreach (RefRW<GarbageTruckData> truck in SystemAPI.Query<RefRW<GarbageTruckData>>())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                // Capacity and unload rate both scaled so unload time stays roughly stable.
                data.m_GarbageCapacity = (int)math.round(data.m_GarbageCapacity * scale);
                data.m_UnloadRate = (int)math.round(data.m_UnloadRate * scale);
            }

#if DEBUG
            Mod.Log.Info($"[MGT] TruckCapacity apply: {m_LastMultiplier}% -> {targetMult}%");
#endif

            m_LastMultiplier = targetMult;
            Enabled = false; // Back to sleep until next OptionsUI change or city load.
        }
    }
}
