// File: Systems/GarbageTruckCapacitySystem.cs
// Trash Boss: scales truck prefab capacity & unload rate.
// Total Magic (or Trash Boss OFF): reverts to vanilla (100%) once, then sleeps.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Prefabs;
    using System.Collections.Generic;
    using Unity.Entities;
    using Unity.Mathematics;

    /// <summary>
    /// Scales garbage truck capacity and unload rate according to the Trash Boss slider.
    /// When Total Magic is enabled (or Trash Boss disabled), it reverts to vanilla (100%) once.
    /// Uses authoring prefab values as the true baseline, with cache fallback if authoring lookup fails.
    /// </summary>
    public partial class GarbageTruckCapacitySystem : GameSystemBase
    {
        private int m_LastMultiplier = 100;

        private readonly Dictionary<Entity, (int Capacity, int UnloadRate)> m_Base = new();

        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();

            RequireForUpdate<GarbageTruckData>();

            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_Base.Clear();
            m_LastMultiplier = 100;

            Enabled = true;

#if DEBUG
            Mod.Log.Info("[MG] [Trash Boss] GarbageTruckCapacitySystem: OnGameLoadingComplete -> Enabled");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            int targetMult = 100;

            if (!setting.TotalMagic && setting.TrashBossEnabled)
            {
                targetMult = math.clamp(setting.GarbageTruckCapacityMultiplier, 100, 500);
            }

            if (targetMult == m_LastMultiplier)
            {
#if DEBUG
                Mod.Log.Info("[MG] [Trash Boss] TruckCapacity sleep");
#endif
                Enabled = false;
                return;
            }

            foreach ((RefRW<GarbageTruckData> truck, Entity entity) in
                     SystemAPI.Query<RefRW<GarbageTruckData>>().WithEntityAccess())
            {
                ref GarbageTruckData data = ref truck.ValueRW;

                if (!m_Base.TryGetValue(entity, out (int Capacity, int UnloadRate) b))
                {
                    if (!TryGetAuthoringBase(entity, out b))
                    {
                        if (m_LastMultiplier == 100)
                        {
                            b = (data.m_GarbageCapacity, data.m_UnloadRate);
                        }
                        else
                        {
                            float lastFactor = m_LastMultiplier / 100f;
                            b = (
                                (int)math.round(data.m_GarbageCapacity / lastFactor),
                                (int)math.round(data.m_UnloadRate / lastFactor));
                        }
                    }

                    m_Base[entity] = b;
                }

                data.m_GarbageCapacity = (int)math.round(b.Capacity * (targetMult / 100f));
                data.m_UnloadRate = (int)math.round(b.UnloadRate * (targetMult / 100f));
            }

#if DEBUG
            Mod.Log.Info($"[MG] TruckCapacity apply: {m_LastMultiplier}% -> {targetMult}%");
#endif

            m_LastMultiplier = targetMult;
            Enabled = false;
        }

        private bool TryGetAuthoringBase(Entity prefabEntity, out (int Capacity, int UnloadRate) baseline)
        {
            baseline = default;

            if (m_PrefabSystem == null)
            {
                return false;
            }

            if (!m_PrefabSystem.TryGetPrefab(prefabEntity, out PrefabBase prefabBase) || prefabBase == null)
            {
                return false;
            }

            if (!prefabBase.TryGet(out Game.Prefabs.GarbageTruck authoring))
            {
                return false;
            }

            baseline = (authoring.m_GarbageCapacity, authoring.m_UnloadRate);
            return true;
        }
    }
}
