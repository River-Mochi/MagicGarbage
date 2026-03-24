// File: Systems/TotalMagicRequestSystem.cs
// Purpose: While Total Magic is ON, prevent *new* garbage dispatches by deleting
//          pending (not yet Dispatched / not in Pathfinding) GarbageCollectionRequest entities.
// Safety: Does NOT touch requests already in progress, so current jobs can finish.
// Cheap: only scans request entities (0-hundreds), not all buildings.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Pathfind;
    using Game.Simulation; // GarbageCollectionRequest, Dispatched, GarbageCollectorDispatchSystem
    using Game.Tools;
    using Unity.Burst;
    using Unity.Burst.Intrinsics;
    using Unity.Collections;
    using Unity.Entities;
    using Unity.Jobs;

    public sealed partial class TotalMagicRequestSystem : GameSystemBase
    {
        private EndFrameBarrier m_EndFrameBarrier = null!;
        private EntityQuery m_PendingRequestsQuery;

        public override int GetUpdateInterval(SystemUpdatePhase phase) => 16;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_EndFrameBarrier = World.GetOrCreateSystemManaged<EndFrameBarrier>();

            // Pending request = has GarbageCollectionRequest, NOT already being processed (Dispatched/PathInformation),
            // and not removed.
            m_PendingRequestsQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<GarbageCollectionRequest>()
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Dispatched>(),
                    ComponentType.ReadOnly<PathInformation>(),
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Temp>()
                }
            });

            // Reliability-first: stay enabled with cheap early-outs.
            Enabled = true;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);
            Enabled = true; // never perma-off
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

            if (m_PendingRequestsQuery.IsEmptyIgnoreFilter)
            {
                return;
            }

            JobHandle handle = new SuppressPendingRequestsJob
            {
                m_EntityType = SystemAPI.GetEntityTypeHandle(),
                m_RequestType = SystemAPI.GetComponentTypeHandle<GarbageCollectionRequest>(true),
                m_GarbageProducerLookup = SystemAPI.GetComponentLookup<GarbageProducer>(),
                m_CommandBuffer = m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter(),
            }.ScheduleParallel(m_PendingRequestsQuery, Dependency);

            m_EndFrameBarrier.AddJobHandleForProducer(handle);
            Dependency = handle;
        }

        [BurstCompile]
        private struct SuppressPendingRequestsJob : IJobChunk
        {
            [ReadOnly] public EntityTypeHandle m_EntityType;
            [ReadOnly] public ComponentTypeHandle<GarbageCollectionRequest> m_RequestType;

            // Clear producer pointers so they don't keep referencing a request we deleted.
            [NativeDisableParallelForRestriction]
            public ComponentLookup<GarbageProducer> m_GarbageProducerLookup;

            public EntityCommandBuffer.ParallelWriter m_CommandBuffer;

            public void Execute(in ArchetypeChunk chunk, int unfilteredChunkIndex, bool useEnabledMask, in v128 chunkEnabledMask)
            {
                NativeArray<Entity> entities = chunk.GetNativeArray(m_EntityType);
                NativeArray<GarbageCollectionRequest> reqs = chunk.GetNativeArray(ref m_RequestType);

                for (int i = 0; i < chunk.Count; i++)
                {
                    Entity requestEntity = entities[i];
                    GarbageCollectionRequest req = reqs[i];

                    // Clear target's pointer if it points at this request.
                    Entity target = req.m_Target;
                    if (target != Entity.Null && m_GarbageProducerLookup.HasComponent(target))
                    {
                        GarbageProducer gp = m_GarbageProducerLookup[target];
                        if (gp.m_CollectionRequest == requestEntity)
                        {
                            gp.m_CollectionRequest = Entity.Null;
                            gp.m_DispatchIndex = 0;
                            m_GarbageProducerLookup[target] = gp;
                        }
                    }

                    // Mark request Deleted (structural change via ECB).
                    m_CommandBuffer.AddComponent<Deleted>(unfilteredChunkIndex, requestEntity);
                }
            }
        }
    }
}
