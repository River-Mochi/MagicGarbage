// Systems/MagicGarbageSystem.cs
// Total Magic: instantly clears garbage and cancels requests.

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

namespace MagicGarbage
{
    /// <summary>
    /// TOTAL MAGIC:
    /// - Zeros out GarbageProducer.m_Garbage on all buildings
    /// - Clears collection requests / dispatch index
    /// - Clears the "garbage piling up" flag
    /// - Removes the garbage notification icon from buildings
    ///
    /// Only runs while Setting.MagicGarbage is true.
    /// </summary>
    public partial class MagicGarbageSystem : GameSystemBase
    {
        private IconCommandSystem m_IconCommandSystem = null!;
        private EntityQuery m_GarbageProducerQuery;
        private EntityQuery m_GarbageParamsQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_IconCommandSystem = World.GetOrCreateSystemManaged<IconCommandSystem>();

            // All real garbage-producing buildings
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

            m_GarbageParamsQuery = GetEntityQuery(
                ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageProducerQuery);
            RequireForUpdate(m_GarbageParamsQuery);
        }

        protected override void OnUpdate()
        {
            var setting = Mod.Setting;
            if (setting == null || !setting.MagicGarbage)
                return;

            IconCommandBuffer iconBuffer = m_IconCommandSystem.CreateCommandBuffer();
            GarbageParameterData garbageParams = m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();

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

        [BurstCompile]
        private struct MagicJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            public ComponentTypeHandle<GarbageProducer> m_GarbageProducerType;

            public IconCommandBuffer m_IconCommandBuffer;
            [ReadOnly] public GarbageParameterData m_GarbageParameters;

            public void Execute(in ArchetypeChunk chunk,
                                int unfilteredChunkIndex,
                                bool useEnabledMask,
                                in v128 chunkEnabledMask)
            {
                NativeArray<Entity> entities = chunk.GetNativeArray(m_EntityType);
                NativeArray<GarbageProducer> producers = chunk.GetNativeArray(ref m_GarbageProducerType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    Entity building = entities[i];
                    GarbageProducer producer = producers[i];

                    // If there is no garbage and no flag, we can skip,
                    // but still safe to just clean everything so behaviour is predictable.
                    if (producer.m_Garbage == 0 &&
                        (producer.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) == 0 &&
                        producer.m_CollectionRequest == Entity.Null)
                    {
                        // Still remove any existing or stale icon, just in case.
                        m_IconCommandBuffer.Remove(
                            building,
                            m_GarbageParameters.m_GarbageNotificationPrefab);
                        continue;
                    }

                    // Clean completely
                    producer.m_Garbage = 0;
                    producer.m_CollectionRequest = Entity.Null;
                    producer.m_DispatchIndex = 0;
                    producer.m_Flags &= ~GarbageProducerFlags.GarbagePilingUpWarning;

                    producers[i] = producer;

                    // Always try to remove the world icon – harmless if none exists.
                    m_IconCommandBuffer.Remove(
                        building,
                        m_GarbageParameters.m_GarbageNotificationPrefab);
                }
            }
        }
    }
}
