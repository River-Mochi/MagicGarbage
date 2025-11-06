// Systems/MagicGarbageSystem.cs

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
    /// - Every update, wipes all GarbageProducer.m_Garbage
    /// - Clears collection requests & dispatch index
    /// - Removes "garbage piling up" icons when present.
    ///
    /// This leaves trucks/facilities purely cosmetic.
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

            // For the notification prefab
            m_GarbageParamsQuery = GetEntityQuery(
                ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageProducerQuery);
            RequireForUpdate(m_GarbageParamsQuery);
        }

        protected override void OnUpdate()
        {
            // TOTAL MAGIC toggle – if off, we do nothing.
            bool magicOn = Mod.Setting?.MagicGarbage ?? false;
            if (!magicOn)
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

            public void Execute(
                in ArchetypeChunk chunk,
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

                    bool hadWarning =
                        (producer.m_Flags & GarbageProducerFlags.GarbagePilingUpWarning) != 0;

                    // Nothing to do for totally clean buildings with no warning flag.
                    if (producer.m_Garbage == 0 && !hadWarning)
                        continue;

                    // Clean completely
                    producer.m_Garbage = 0;
                    producer.m_CollectionRequest = Entity.Null;
                    producer.m_DispatchIndex = 0;
                    producer.m_Flags &= ~GarbageProducerFlags.GarbagePilingUpWarning;

                    producers[i] = producer;

                    // If there used to be a warning, remove its icon.
                    if (hadWarning)
                    {
                        m_IconCommandBuffer.Remove(
                            building,
                            m_GarbageParameters.m_GarbageNotificationPrefab);
                    }
                }
            }
        }
    }
}
