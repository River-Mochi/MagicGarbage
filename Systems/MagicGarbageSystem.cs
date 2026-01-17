// Systems/MagicGarbageSystem.cs
// Total Magic: clears garbage periodically and cancels collection requests.

namespace MagicGarbage
{
    using Game;                     // GameSystemBase, SystemUpdatePhase
    using Game.Buildings;           // GarbageProducer, GarbageProducerFlags
    using Game.Common;              // Deleted, Destroyed, Temp
    using Game.Notifications;       // IconCommandBuffer, IconCommandSystem
    using Game.Prefabs;             // GarbageParameterData
    using Game.Tools;               // IconCommandSystem
    using Unity.Burst;              // BurstCompile
    using Unity.Burst.Intrinsics;   // v128 for IJobChunk
    using Unity.Collections;        // NativeArray, Allocator
    using Unity.Entities;           // EntityQuery, IJobChunk, ComponentType

    /// <summary>
    /// Periodically wipes garbage from producers and cancels collection requests
    /// when Total Magic mode is enabled in the mod settings.
    /// </summary>
    public partial class MagicGarbageSystem : GameSystemBase
    {
        // ---- UPDATE SCHEDULING ----

        /// <summary>
        /// Times per simulated day this system should run.
        /// 512 updates/day ≈ every 2.8 in-game minutes.
        /// Increase for more frequent cleaning, decrease for less.
        /// </summary>
        public static readonly int UpdatesPerDay = 512;

        // Same value vanilla TimeSystem uses internally.
        private const int TicksPerDay = 262144;

        /// <summary>
        /// Game calls OnUpdate only every N ticks based on this interval.
        /// </summary>
        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return TicksPerDay / UpdatesPerDay; // 262144 / 512 = 512 ticks
        }

        // ---- RUNTIME STATE ----

        private IconCommandSystem m_IconCommandSystem = null!;
        private EntityQuery m_GarbageProducerQuery;
        private EntityQuery m_GarbageParamsQuery;

        // ---- LIFECYCLE ----

        protected override void OnCreate()
        {
            base.OnCreate();

            m_IconCommandSystem = World.GetOrCreateSystemManaged<IconCommandSystem>();

            // All active garbage producers (skip deleted/temp/destroyed).
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

            // Singleton with notification prefab + other parameters.
            m_GarbageParamsQuery =
                GetEntityQuery(ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageProducerQuery);
            RequireForUpdate(m_GarbageParamsQuery);

#if DEBUG
            int intervalTicks   = TicksPerDay / UpdatesPerDay;
            float ticksPerMinute = TicksPerDay / 1440f;
            Mod.Log.Info(
                $"{Mod.ModTag} MagicGarbageSystem created. UpdatesPerDay={UpdatesPerDay}, " +
                $"IntervalTicks={intervalTicks}, TicksPerMinute={ticksPerMinute:F2}.");
#endif
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting) || !setting.TotalMagic)
            {
                return;
            }

#if DEBUG
            // DEBUG ONLY: quick snapshot of how many producers and how many are "dirty".
            int total = m_GarbageProducerQuery.CalculateEntityCount();
            int dirty = 0;

            using (NativeArray<GarbageProducer> producersSnapshot =
                   m_GarbageProducerQuery.ToComponentDataArray<GarbageProducer>(Allocator.Temp))
            {
                for (int i = 0; i < producersSnapshot.Length; i++)
                {
                    GarbageProducer p = producersSnapshot[i];

                    bool hasGarbage = p.m_Garbage != 0;
                    bool hasWarning =
                        (p.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) != 0;
                    bool hasRequest = p.m_CollectionRequest != Entity.Null;

                    if (hasGarbage || hasWarning || hasRequest)
                    {
                        dirty++;
                    }
                }
            }

            Mod.Log.Debug(
                $"{Mod.ModTag} TotalMagic tick: producers={total}, dirty={dirty}, " +
                $"updatesPerDay={UpdatesPerDay}.");

            if (dirty == 0) // DEBUG-only skip: nothing to clean, avoid scheduling job.
            { return; }
#endif

            // Create icon command buffer for this frame.
            IconCommandBuffer iconBuffer = m_IconCommandSystem.CreateCommandBuffer();

            // Read singleton garbage parameters (includes notification prefab).
            GarbageParameterData garbageParams =
                m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();

            // Schedule the Burst job over all garbage producers.
            var job = new MagicJob
            {
                m_EntityType = GetEntityTypeHandle(),
                m_GarbageProducerType = GetComponentTypeHandle<GarbageProducer>(false),
                m_IconCommandBuffer = iconBuffer,
                m_GarbageParameters = garbageParams
            };

            Dependency = job.ScheduleParallel(m_GarbageProducerQuery, Dependency);
            m_IconCommandSystem.AddCommandBufferWriter(Dependency);
        }

        // ---- BURST JOB ----

        /// <summary>
        /// Clears garbage and collection requests from all producers,
        /// and removes the "garbage piling up" notification icon.
        /// </summary>
        [BurstCompile]
        private struct MagicJob : IJobChunk
        {
            [ReadOnly]
            public EntityTypeHandle m_EntityType;

            public ComponentTypeHandle<GarbageProducer> m_GarbageProducerType;

            public IconCommandBuffer m_IconCommandBuffer;

            [ReadOnly]
            public GarbageParameterData m_GarbageParameters;

            public void Execute(
                in ArchetypeChunk chunk,
                int unfilteredChunkIndex,
                bool useEnabledMask,
                in v128 chunkEnabledMask)
            {
                NativeArray<Entity> entities =
                    chunk.GetNativeArray(m_EntityType);
                NativeArray<GarbageProducer> producers =
                    chunk.GetNativeArray(ref m_GarbageProducerType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    Entity building = entities[i];
                    GarbageProducer producer = producers[i];

                    // If there is nothing to clear and no warning / request,
                    // just remove any leftover icon and continue.
                    if (producer.m_Garbage == 0 &&
                        (producer.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) == 0 &&
                        producer.m_CollectionRequest == Entity.Null)
                    {
                        m_IconCommandBuffer.Remove(
                            building,
                            m_GarbageParameters.m_GarbageNotificationPrefab);
                        continue;
                    }

                    // Total Magic: wipe garbage & requests, reset flags/dispatch index.
                    producer.m_Garbage = 0;
                    producer.m_CollectionRequest = Entity.Null;
                    producer.m_DispatchIndex = 0;
                    producer.m_Flags &= ~GarbageProducerFlags.GarbagePilingUpWarning;

                    producers[i] = producer;

                    // Remove the piling-up notification icon.
                    m_IconCommandBuffer.Remove(
                        building,
                        m_GarbageParameters.m_GarbageNotificationPrefab);
                }
            }
        }
    }
}
