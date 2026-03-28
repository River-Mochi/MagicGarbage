// File: Systems/GarbageStatusSystem.cs
// Purpose: Snapshot builder for GarbageStatus.cs.
// Design:
// - No automatic simulation work.
// - OnUpdate is intentionally empty.
// - GarbageStatus.cs pulls a snapshot only while Options UI is open.

namespace MagicGarbage
{
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Companies;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Game.Vehicles;
    using System;
    using System.Collections.Generic;
    using Unity.Entities;

    public sealed partial class GarbageStatusSystem : GameSystemBase
    {
        public readonly struct FacilityEntry
        {
            public readonly Entity Facility;
            public readonly int Total;
            public readonly int Moving;
            public readonly int Parked;
            public readonly int MaxWorkers;

            public FacilityEntry(Entity facility, int total, int moving, int parked, int maxWorkers)
            {
                Facility = facility;
                Total = total;
                Moving = moving;
                Parked = parked;
                MaxWorkers = maxWorkers;
            }
        }

        public readonly struct Snapshot
        {
            public readonly bool InGame;
            public readonly Entity City;

            public readonly bool TotalMagic;
            public readonly bool TrashBoss;

            public readonly bool HaveParams;
            public readonly int RequestLimit;
            public readonly int CollectLimit;
            public readonly int WarningLimit;
            public readonly int MaxAccumulation;

            public readonly long GarbageTonsPerMonth;
            public readonly long ProcessingTonsPerMonth;

            public readonly int ProducerTotal;
            public readonly int ProducerGarbageGt0;
            public readonly int ProducerOverRequest;
            public readonly int ProducerOverWarning;
            public readonly int ProducerNearWarning75;
            public readonly int ProducerAverageGarbage;
            public readonly int ProducerMedianGarbage;
            public readonly int ProducerMaxGarbage;
            public readonly Entity ProducerMaxGarbageEntity;

            public readonly int RequestTotal;
            public readonly int RequestPending;
            public readonly int RequestDispatched;
            public readonly int PendingMaxTargetGarbage;
            public readonly Entity PendingMaxTargetEntity;

            public readonly int TruckTotal;
            public readonly int TruckParked;
            public readonly int TruckMoving;
            public readonly int TruckReturning;
            public readonly int TruckDisabled;

            public readonly int FacilityTotal;
            public readonly int FacilityTruckTotal;
            public readonly int FacilityMaxWorkers;

            public readonly FacilityEntry[] Facilities;

            public Snapshot(
                bool inGame,
                Entity city,
                bool totalMagic,
                bool trashBoss,
                bool haveParams,
                int requestLimit,
                int collectLimit,
                int warningLimit,
                int maxAccumulation,
                long garbageTonsPerMonth,
                long processingTonsPerMonth,
                int producerTotal,
                int producerGarbageGt0,
                int producerOverRequest,
                int producerOverWarning,
                int producerNearWarning75,
                int producerAverageGarbage,
                int producerMedianGarbage,
                int producerMaxGarbage,
                Entity producerMaxGarbageEntity,
                int requestTotal,
                int requestPending,
                int requestDispatched,
                int pendingMaxTargetGarbage,
                Entity pendingMaxTargetEntity,
                int truckTotal,
                int truckParked,
                int truckMoving,
                int truckReturning,
                int truckDisabled,
                int facilityTotal,
                int facilityTruckTotal,
                int facilityMaxWorkers,
                FacilityEntry[] facilities)
            {
                InGame = inGame;
                City = city;

                TotalMagic = totalMagic;
                TrashBoss = trashBoss;

                HaveParams = haveParams;
                RequestLimit = requestLimit;
                CollectLimit = collectLimit;
                WarningLimit = warningLimit;
                MaxAccumulation = maxAccumulation;

                GarbageTonsPerMonth = garbageTonsPerMonth;
                ProcessingTonsPerMonth = processingTonsPerMonth;

                ProducerTotal = producerTotal;
                ProducerGarbageGt0 = producerGarbageGt0;
                ProducerOverRequest = producerOverRequest;
                ProducerOverWarning = producerOverWarning;
                ProducerNearWarning75 = producerNearWarning75;
                ProducerAverageGarbage = producerAverageGarbage;
                ProducerMedianGarbage = producerMedianGarbage;
                ProducerMaxGarbage = producerMaxGarbage;
                ProducerMaxGarbageEntity = producerMaxGarbageEntity;

                RequestTotal = requestTotal;
                RequestPending = requestPending;
                RequestDispatched = requestDispatched;
                PendingMaxTargetGarbage = pendingMaxTargetGarbage;
                PendingMaxTargetEntity = pendingMaxTargetEntity;

                TruckTotal = truckTotal;
                TruckParked = truckParked;
                TruckMoving = truckMoving;
                TruckReturning = truckReturning;
                TruckDisabled = truckDisabled;

                FacilityTotal = facilityTotal;
                FacilityTruckTotal = facilityTruckTotal;
                FacilityMaxWorkers = facilityMaxWorkers;

                Facilities = facilities;
            }
        }

        private readonly struct FacilityCounts
        {
            public readonly int Total;
            public readonly int Moving;
            public readonly int Parked;

            public FacilityCounts(int total, int moving, int parked)
            {
                Total = total;
                Moving = moving;
                Parked = parked;
            }
        }

        private CitySystem m_CitySystem = null!;
        private GarbageAccumulationSystem m_GarbageAccumulationSystem = null!;

        private EntityQuery m_ProducerQuery;
        private EntityQuery m_RequestQuery;
        private EntityQuery m_TruckQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_CitySystem = World.GetOrCreateSystemManaged<CitySystem>();
            m_GarbageAccumulationSystem = World.GetOrCreateSystemManaged<GarbageAccumulationSystem>();

            m_ProducerQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<GarbageProducer>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Destroyed>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            m_RequestQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<GarbageCollectionRequest>(),
                    ComponentType.ReadOnly<ServiceRequest>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            m_TruckQuery = GetEntityQuery(new EntityQueryDesc
            {
                All = new[]
                {
                    ComponentType.ReadOnly<Game.Vehicles.GarbageTruck>(),
                },
                None = new[]
                {
                    ComponentType.ReadOnly<Deleted>(),
                    ComponentType.ReadOnly<Temp>(),
                },
            });

            Enabled = false;
        }

        protected override void OnUpdate()
        {
        }

        public Snapshot BuildSnapshot()
        {
            Entity city = m_CitySystem != null ? m_CitySystem.City : Entity.Null;
            bool inGame = city != Entity.Null;

            bool totalMagic = false;
            bool trashBoss = false;

            if (Mod.TryGetSetting(out Setting setting))
            {
                totalMagic = setting.TotalMagic;
                trashBoss = setting.TrashBossEnabled;
            }

            bool haveParams = SystemAPI.TryGetSingleton(out GarbageParameterData gp);

            int requestLimit = 0;
            int collectLimit = 0;
            int warningLimit = 0;
            int maxAccumulation = 0;

            if (haveParams)
            {
                requestLimit = gp.m_RequestGarbageLimit;
                collectLimit = gp.m_CollectionGarbageLimit;
                warningLimit = gp.m_WarningGarbageLimit;
                maxAccumulation = gp.m_MaxGarbageAccumulation;
            }

            if (!inGame)
            {
                return new Snapshot(
                    inGame: false,
                    city: city,
                    totalMagic: totalMagic,
                    trashBoss: trashBoss,
                    haveParams: haveParams,
                    requestLimit: requestLimit,
                    collectLimit: collectLimit,
                    warningLimit: warningLimit,
                    maxAccumulation: maxAccumulation,
                    garbageTonsPerMonth: 0,
                    processingTonsPerMonth: 0,
                    producerTotal: 0,
                    producerGarbageGt0: 0,
                    producerOverRequest: 0,
                    producerOverWarning: 0,
                    producerNearWarning75: 0,
                    producerAverageGarbage: 0,
                    producerMedianGarbage: 0,
                    producerMaxGarbage: 0,
                    producerMaxGarbageEntity: Entity.Null,
                    requestTotal: 0,
                    requestPending: 0,
                    requestDispatched: 0,
                    pendingMaxTargetGarbage: 0,
                    pendingMaxTargetEntity: Entity.Null,
                    truckTotal: 0,
                    truckParked: 0,
                    truckMoving: 0,
                    truckReturning: 0,
                    truckDisabled: 0,
                    facilityTotal: 0,
                    facilityTruckTotal: 0,
                    facilityMaxWorkers: 0,
                    facilities: Array.Empty<FacilityEntry>());
            }

            ComponentLookup<WorkProvider> workProviderLookup = GetComponentLookup<WorkProvider>(true);

            long garbageRaw = m_GarbageAccumulationSystem != null
                ? m_GarbageAccumulationSystem.garbageAccumulation
                : 0L;

            int producerTotal = m_ProducerQuery.CalculateEntityCount();
            int producerGarbageGt0 = 0;
            int producerOverRequest = 0;
            int producerOverWarning = 0;
            int producerNearWarning75 = 0;
            int producerAverageGarbage = 0;
            int producerMedianGarbage = 0;
            int producerMaxGarbage = 0;
            Entity producerMaxGarbageEntity = Entity.Null;

            int nearWarning75Limit = 0;
            if (haveParams && warningLimit > 0)
            {
                nearWarning75Limit = (int)Math.Ceiling(warningLimit * 0.75d);
            }

            long garbageSum = 0L;
            List<int> garbageValues = new List<int>(producerTotal > 0 ? producerTotal : 16);

            foreach ((RefRO<GarbageProducer> producer, Entity producerEntity) in SystemAPI
                         .Query<RefRO<GarbageProducer>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Destroyed, Temp>())
            {
                int garbage = producer.ValueRO.m_Garbage;

                if (garbage > 0)
                {
                    producerGarbageGt0++;
                    garbageSum += garbage;
                    garbageValues.Add(garbage);

                    if (garbage > producerMaxGarbage)
                    {
                        producerMaxGarbage = garbage;
                        producerMaxGarbageEntity = producerEntity;
                    }
                }

                if (haveParams && garbage > requestLimit)
                {
                    producerOverRequest++;
                }

                if (haveParams && garbage > warningLimit)
                {
                    producerOverWarning++;
                }

                if (haveParams && nearWarning75Limit > 0 && garbage >= nearWarning75Limit)
                {
                    producerNearWarning75++;
                }
            }

            if (producerGarbageGt0 > 0)
            {
                producerAverageGarbage = (int)Math.Round(
                    garbageSum / (double)producerGarbageGt0,
                    MidpointRounding.AwayFromZero);

                garbageValues.Sort();
                int middle = garbageValues.Count / 2;

                if ((garbageValues.Count & 1) == 1)
                {
                    producerMedianGarbage = garbageValues[middle];
                }
                else
                {
                    producerMedianGarbage = (int)Math.Round(
                        (garbageValues[middle - 1] + garbageValues[middle]) / 2.0,
                        MidpointRounding.AwayFromZero);
                }
            }

            int requestTotal = m_RequestQuery.CalculateEntityCount();
            int requestPending = 0;
            int requestDispatched = 0;
            int pendingMaxTargetGarbage = 0;
            Entity pendingMaxTargetEntity = Entity.Null;

            foreach ((RefRO<GarbageCollectionRequest> request, Entity requestEntity) in SystemAPI
                         .Query<RefRO<GarbageCollectionRequest>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Temp>())
            {
                if (!SystemAPI.HasComponent<ServiceRequest>(requestEntity))
                {
                    continue;
                }

                bool hasDispatched = SystemAPI.HasComponent<Dispatched>(requestEntity);
                bool hasPath = SystemAPI.HasComponent<PathInformation>(requestEntity);

                if (hasDispatched || hasPath)
                {
                    requestDispatched++;
                }
                else
                {
                    requestPending++;

                    Entity target = request.ValueRO.m_Target;
                    if (target != Entity.Null && SystemAPI.HasComponent<GarbageProducer>(target))
                    {
                        int targetGarbage = SystemAPI.GetComponent<GarbageProducer>(target).m_Garbage;
                        if (targetGarbage > pendingMaxTargetGarbage)
                        {
                            pendingMaxTargetGarbage = targetGarbage;
                            pendingMaxTargetEntity = target;
                        }
                    }
                }
            }

            int truckTotal = m_TruckQuery.CalculateEntityCount();
            int truckParked = 0;
            int truckReturning = 0;
            int truckDisabled = 0;

            Dictionary<Entity, FacilityCounts> facilityStats =
                new Dictionary<Entity, FacilityCounts>(32);

            foreach ((RefRO<Game.Vehicles.GarbageTruck> truckRef, Entity truckEntity) in SystemAPI
                         .Query<RefRO<Game.Vehicles.GarbageTruck>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Temp>())
            {
                bool isParked = SystemAPI.HasComponent<ParkedCar>(truckEntity);
                if (isParked)
                {
                    truckParked++;
                }

                GarbageTruckFlags state = truckRef.ValueRO.m_State;

                if ((state & GarbageTruckFlags.Returning) != 0)
                {
                    truckReturning++;
                }

                if ((state & GarbageTruckFlags.Disabled) != 0)
                {
                    truckDisabled++;
                }

                if (!SystemAPI.HasComponent<Owner>(truckEntity))
                {
                    continue;
                }

                Entity owner = SystemAPI.GetComponent<Owner>(truckEntity).m_Owner;
                if (owner == Entity.Null)
                {
                    continue;
                }

                if (!SystemAPI.HasComponent<Game.Buildings.GarbageFacility>(owner))
                {
                    continue;
                }

                FacilityCounts counts;
                if (!facilityStats.TryGetValue(owner, out counts))
                {
                    counts = new FacilityCounts(0, 0, 0);
                }

                int nextTotal = counts.Total + 1;
                int nextMoving = counts.Moving + (isParked ? 0 : 1);
                int nextParked = counts.Parked + (isParked ? 1 : 0);

                facilityStats[owner] = new FacilityCounts(nextTotal, nextMoving, nextParked);
            }

            long processingRaw = 0L;
            int facilityTotal = 0;
            int facilityTruckTotal = 0;
            int facilityMaxWorkers = 0;

            List<FacilityEntry> facilityEntries =
                new List<FacilityEntry>(facilityStats.Count > 0 ? facilityStats.Count : 8);

            foreach ((RefRO<Game.Buildings.GarbageFacility> facility, Entity facilityEntity) in SystemAPI
                         .Query<RefRO<Game.Buildings.GarbageFacility>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Destroyed, Temp>())
            {
                if (!SystemAPI.HasComponent<Building>(facilityEntity))
                {
                    continue;
                }

                int maxWorkers = 0;
                if (workProviderLookup.HasComponent(facilityEntity))
                {
                    maxWorkers = workProviderLookup[facilityEntity].m_MaxWorkers;
                }

                FacilityCounts counts;
                if (!facilityStats.TryGetValue(facilityEntity, out counts))
                {
                    counts = new FacilityCounts(0, 0, 0);
                }

                if (facility.ValueRO.m_ProcessingRate <= 0 &&
                    counts.Total <= 0 &&
                    maxWorkers <= 0)
                {
                    continue;
                }

                processingRaw += facility.ValueRO.m_ProcessingRate;
                facilityTotal++;
                facilityTruckTotal += counts.Total;
                facilityMaxWorkers += maxWorkers;

                facilityEntries.Add(new FacilityEntry(
                    facilityEntity,
                    counts.Total,
                    counts.Moving,
                    counts.Parked,
                    maxWorkers));
            }

            facilityEntries.Sort(CompareFacilityEntries);

            int truckMoving = truckTotal - truckParked;
            long garbageTonsPerMonth = ToTonsPerMonth(garbageRaw);
            long processingTonsPerMonth = ToTonsPerMonth(processingRaw);

            return new Snapshot(
                inGame: true,
                city: city,
                totalMagic: totalMagic,
                trashBoss: trashBoss,
                haveParams: haveParams,
                requestLimit: requestLimit,
                collectLimit: collectLimit,
                warningLimit: warningLimit,
                maxAccumulation: maxAccumulation,
                garbageTonsPerMonth: garbageTonsPerMonth,
                processingTonsPerMonth: processingTonsPerMonth,
                producerTotal: producerTotal,
                producerGarbageGt0: producerGarbageGt0,
                producerOverRequest: producerOverRequest,
                producerOverWarning: producerOverWarning,
                producerNearWarning75: producerNearWarning75,
                producerAverageGarbage: producerAverageGarbage,
                producerMedianGarbage: producerMedianGarbage,
                producerMaxGarbage: producerMaxGarbage,
                producerMaxGarbageEntity: producerMaxGarbageEntity,
                requestTotal: requestTotal,
                requestPending: requestPending,
                requestDispatched: requestDispatched,
                pendingMaxTargetGarbage: pendingMaxTargetGarbage,
                pendingMaxTargetEntity: pendingMaxTargetEntity,
                truckTotal: truckTotal,
                truckParked: truckParked,
                truckMoving: truckMoving,
                truckReturning: truckReturning,
                truckDisabled: truckDisabled,
                facilityTotal: facilityTotal,
                facilityTruckTotal: facilityTruckTotal,
                facilityMaxWorkers: facilityMaxWorkers,
                facilities: facilityEntries.ToArray());
        }

        private static int CompareFacilityEntries(FacilityEntry a, FacilityEntry b)
        {
            int cmp = b.Moving.CompareTo(a.Moving);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = b.Total.CompareTo(a.Total);
            if (cmp != 0)
            {
                return cmp;
            }

            return a.Facility.Index.CompareTo(b.Facility.Index);
        }

        private static long ToTonsPerMonth(long raw)
        {
            if (raw <= 0L)
            {
                return 0L;
            }

            return (long)Math.Round(raw / 1000.0, MidpointRounding.AwayFromZero);
        }
    }
}
