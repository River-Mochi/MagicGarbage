// File: Systems/TotalMagicSystem.cs
// Total Magic: clears garbage at low intervals (good for performance) and removes warnings/icons.
// Design:
// - System stays Enabled (never self-sleeps).
// - If settings aren't available or Total Magic isn't active, do a cheap early-return.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;                            // GameMode
    using Game.Buildings;                  // GarbageProducer, GarbageProducerFlags
    using Game.Common;                     // Deleted, Destroyed
    using Game.Notifications;              // IconCommandBuffer, IconCommandSystem
    using Game.Prefabs;                    // GarbageParameterData
    using Game.Tools;                      // Temp
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;                // ReadOnly
    using Unity.Entities;                   // IJobChunk, ComponentType
    using Unity.Jobs;                       // JobHandle

    public partial class TotalMagicSystem : GameSystemBase
    {
        // Tune cadence here. 262144 / 64 = 4096 ticks between sweeps, ~22.5 in-game minutes.
        public static readonly int UpdatesPerDay = 64; // raise (128, 256...) if warn garbage icons appear
        private const int TicksPerDay = 262144;

        private IconCommandSystem m_IconCommandSystem = null!;
        private EntityQuery m_GarbageProducerQuery;
        private EntityQuery m_GarbageParamsQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return TicksPerDay / UpdatesPerDay;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            m_IconCommandSystem = World.GetOrCreateSystemManaged<IconCommandSystem>();

            m_GarbageProducerQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadWrite<GarbageProducer>()
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Temp>()
                }
            });

            m_GarbageParamsQuery = GetEntityQuery(ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageProducerQuery);
            RequireForUpdate(m_GarbageParamsQuery);

            Enabled = true;

#if DEBUG
            int intervalTicks = TicksPerDay / UpdatesPerDay;
            Mod.Log.Info($"{Mod.ModTag} TotalMagicSystem created. UpdatesPerDay={UpdatesPerDay}, IntervalTicks={intervalTicks}.");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            if (!setting.TotalMagic || setting.TrashBossEnabled)
            {
                return;
            }

            IconCommandBuffer iconBuffer = m_IconCommandSystem.CreateCommandBuffer();

            GarbageParameterData garbageParams =
                m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();

            JobHandle cleanHandle = new MagicJob
            {
                m_EntityType = GetEntityTypeHandle(),
                m_GarbageProducerType = GetComponentTypeHandle<GarbageProducer>(false),
                m_IconCommandBuffer = iconBuffer,
                m_GarbageParameters = garbageParams
            }.ScheduleParallel(m_GarbageProducerQuery, Dependency);

            m_IconCommandSystem.AddCommandBufferWriter(cleanHandle);
            Dependency = cleanHandle;
        }

#if DEBUG
        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            if (Mod.TryGetSetting(out Setting setting))
            {
                Mod.Log.Info($"{Mod.ModTag} TotalMagicSystem OnGameLoadingComplete: TotalMagic={setting.TotalMagic}, TrashBoss={setting.TrashBossEnabled}.");
            }
            else
            {
                Mod.Log.Info($"{Mod.ModTag} TotalMagicSystem OnGameLoadingComplete: settings not ready.");
            }
        }
#endif

        [BurstCompile]
        private struct MagicJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            public ComponentTypeHandle<GarbageProducer> m_GarbageProducerType;

            public IconCommandBuffer m_IconCommandBuffer;

            [ReadOnly] public GarbageParameterData m_GarbageParameters;

            public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
            {
                NativeArray<Entity> entities = chunk.GetNativeArray(m_EntityType);
                NativeArray<GarbageProducer> producers = chunk.GetNativeArray(ref m_GarbageProducerType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    Entity building = entities[i];
                    GarbageProducer producer = producers[i];

                    // Fast path: already clean (still remove icon idempotently).
                    if (producer.m_Garbage == 0 &&
                        (producer.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) == 0 &&
                        producer.m_CollectionRequest == Entity.Null)
                    {
                        m_IconCommandBuffer.Remove(building, m_GarbageParameters.m_GarbageNotificationPrefab);
                        continue;
                    }

                    producer.m_Garbage = 0;
                    producer.m_CollectionRequest = Entity.Null;
                    producer.m_DispatchIndex = 0;
                    producer.m_Flags &= ~GarbageProducerFlags.GarbagePilingUpWarning;

                    producers[i] = producer;

                    m_IconCommandBuffer.Remove(building, m_GarbageParameters.m_GarbageNotificationPrefab);
                }
            }
        }
    }
}
