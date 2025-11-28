// Systems/MagicGarbageSystem.cs
// Total Magic: instantly clears garbage and cancels requests
namespace MagicGarbage
{
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Notifications;
    using Game.Prefabs;
    using Game.Tools;
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;
    using Unity.Entities;

    /// <summary>
    /// Clears garbage state and garbage icons from all buildings while TotalMagic is enabled.
    /// </summary>
    public partial class MagicGarbageSystem : GameSystemBase
    {
        private IconCommandSystem m_IconCommandSystem = null!;
        private EntityQuery m_GarbageProducerQuery;
        private EntityQuery m_GarbageParamsQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            // System used to enqueue icon removal commands.
            m_IconCommandSystem = World.GetOrCreateSystemManaged<IconCommandSystem>();

            // Query for all active garbage-making buildings.
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

            // Parameters needed to know which notification prefab to remove.
            m_GarbageParamsQuery = GetEntityQuery(
                ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageProducerQuery);
            RequireForUpdate(m_GarbageParamsQuery);
        }

        protected override void OnUpdate()
        {
            Setting? setting = Mod.Setting;
            if (setting == null || !setting.TotalMagic)
            {
                return;
            }

            // Icon command buffer used by the job to remove icons.
            IconCommandBuffer iconBuffer = m_IconCommandSystem.CreateCommandBuffer();

            // Singleton with references to notification prefabs.
            GarbageParameterData garbageParams =
                m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();

            var job = new MagicJob
            {
                m_EntityType = GetEntityTypeHandle(),
                m_GarbageProducerType = GetComponentTypeHandle<GarbageProducer>(false),
                m_IconCommandBuffer = iconBuffer,
                m_GarbageParameters = garbageParams
            };

            // Run over all garbage-making building chunks in parallel.
            Dependency = job.ScheduleParallel(m_GarbageProducerQuery, Dependency);
            m_IconCommandSystem.AddCommandBufferWriter(Dependency);
        }

        [BurstCompile]
        private struct MagicJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            public ComponentTypeHandle<GarbageProducer> m_GarbageProducerType;

            public IconCommandBuffer m_IconCommandBuffer;
            [ReadOnly] public GarbageParameterData m_GarbageParameters;

            public void Execute(
                in ArchetypeChunk chunk,
                int unfilteredChunkIndex,
                bool useEnabledMask,
                in v128 chunkEnabledMask)
            {
                NativeArray<Entity> entities = chunk.GetNativeArray(m_EntityType);
                NativeArray<GarbageProducer> producers =
                    chunk.GetNativeArray(ref m_GarbageProducerType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    Entity building = entities[i];
                    GarbageProducer producer = producers[i];

                    // No garbage, no warning flag, and no collection request:
                    // only potential stale icons need removal.
                    if (producer.m_Garbage == 0 &&
                        (producer.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) == 0 &&
                        producer.m_CollectionRequest == Entity.Null)
                    {
                        m_IconCommandBuffer.Remove(
                            building,
                            m_GarbageParameters.m_GarbageNotificationPrefab);
                        continue;
                    }

                    // Reset garbage state and dispatch data.
                    producer.m_Garbage = 0;
                    producer.m_CollectionRequest = Entity.Null;
                    producer.m_DispatchIndex = 0;
                    producer.m_Flags &= ~GarbageProducerFlags.GarbagePilingUpWarning;

                    producers[i] = producer;

                    // Always attempt to remove the garbage icon; harmless if none exists.
                    m_IconCommandBuffer.Remove(
                        building,
                        m_GarbageParameters.m_GarbageNotificationPrefab);
                }
            }
        }
    }
}
