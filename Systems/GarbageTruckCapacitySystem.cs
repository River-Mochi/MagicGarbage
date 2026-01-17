// File: Systems/GarbageTruckCapacitySystem.cs
// Semi-Magic: scales truck prefab capacity & unload rate.
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
    /// Scales garbage truck capacity and unload rate according to the Semi-Magic slider.
    /// When Total Magic is enabled (or Semi-Magic disabled), it reverts to vanilla (100%) once.
    /// Uses cached base values to avoid rounding drift.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        // Last applied multiplier percent. 100 = vanilla.
        private int m_LastMultiplier = 100;

        // Cache the "base" (vanilla) values per prefab entity so we can apply exact scaling (no drift).
        private readonly Dictionary<Entity, (int Capacity, int UnloadRate)> m_Base =
            new Dictionary<Entity, (int Capacity, int UnloadRate)>();

        protected override void OnCreate()
        {
            base.OnCreate();

            // Do not run at all unless garbage truck prefabs exist.
            RequireForUpdate<GarbageTruckData>();

            // Stay asleep most of the time; OnGameLoadingComplete and Setting.Apply() wake it.
            Enabled = false;
        }

        /// <summary>
        /// City load completed (new game/load save/switch city).
        /// Clear base cache so we always capture fresh prefab base values for this session.
        /// </summary>
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_Base.Clear();
            m_LastMultiplier = 100;

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MGT] GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                // Don't force-disable if not ready; a later tick can catch.
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

            // Apply exact scaling from cached base (no rounding drift).
            foreach ((RefRW<GarbageTruckData> truck, Entity entity) in
                     SystemAPI.Query<RefRW<GarbageTruckData>>().WithEntityAccess())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                if (!m_Base.TryGetValue(entity, out var b))
                {
                    // Capture base values the first time we touch this prefab entity.
                    // If we were already scaled in-session, approximate base by reversing last multiplier once.
                    if (m_LastMultiplier == 100)
                    {
                        b = (data.m_GarbageCapacity, data.m_UnloadRate);
                    }
                    else
                    {
                        float lastFactor = m_LastMultiplier / 100f;
                        b = (
                            (int)math.round(data.m_GarbageCapacity / lastFactor),
                            (int)math.round(data.m_UnloadRate / lastFactor)
                        );
                    }

                    m_Base[entity] = b;
                }

                data.m_GarbageCapacity = (int)math.round(b.Capacity * (targetMult / 100f));
                data.m_UnloadRate = (int)math.round(b.UnloadRate * (targetMult / 100f));
            }

#if DEBUG
            Mod.Log.Info($"[MGT] TruckCapacity apply: {m_LastMultiplier}% -> {targetMult}%");
#endif

            m_LastMultiplier = targetMult;
            Enabled = false; // Back to sleep until next OptionsUI change or city load.
        }
    }
}
