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
    using UnityEngine;

    public sealed partial class GarbageStatusSystem : GameSystemBase
    {
        // Per-facility summary used by the detailed log.
        public readonly struct FacilityEntry
        {
            public readonly Entity Facility;
            public readonly int GarbageTruckTotal;
            public readonly int GarbageTruckMoving;
            public readonly int GarbageTruckParked;
            public readonly int DumpTruckTotal;
            public readonly int DumpTruckMoving;
            public readonly int MaxWorkers;

            public FacilityEntry(
                Entity facility,
                int garbageTruckTotal,
                int garbageTruckMoving,
                int garbageTruckParked,
                int dumpTruckTotal,
                int dumpTruckMoving,
                int maxWorkers)
            {
                Facility = facility;
                GarbageTruckTotal = garbageTruckTotal;
                GarbageTruckMoving = garbageTruckMoving;
                GarbageTruckParked = garbageTruckParked;
                DumpTruckTotal = dumpTruckTotal;
                DumpTruckMoving = dumpTruckMoving;
                MaxWorkers = maxWorkers;
            }
        }


        public readonly struct CriticalBuildingEntry
        {
            public readonly Entity Building;
            public readonly int Garbage;
            public readonly string PrefabName;

            public CriticalBuildingEntry(Entity building, int garbage, string prefabName)
            {
                Building = building;
                Garbage = garbage;
                PrefabName = prefabName;
            }
        }

        // Full snapshot consumed by GarbageStatus.cs for UI + log output.
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
            public readonly int HappinessBaseline;
            public readonly int HappinessStep;

            public readonly long GarbageTonsPerMonth;
            public readonly long ProcessingTonsPerMonth;

            public readonly double GarbageServiceRatingRaw;
            public readonly int GarbageServiceRatingRounded;

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
            public readonly int FacilityGarbageTruckTotal;
            public readonly int FacilityDumpTruckTotal;
            public readonly int FacilityDumpTruckMoving;
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
                int happinessBaseline,
                int happinessStep,
                long garbageTonsPerMonth,
                long processingTonsPerMonth,
                double garbageServiceRatingRaw,
                int garbageServiceRatingRounded,
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
                int facilityGarbageTruckTotal,
                int facilityDumpTruckTotal,
                int facilityDumpTruckMoving,
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
                HappinessBaseline = happinessBaseline;
                HappinessStep = happinessStep;

                GarbageTonsPerMonth = garbageTonsPerMonth;
                ProcessingTonsPerMonth = processingTonsPerMonth;

                GarbageServiceRatingRaw = garbageServiceRatingRaw;
                GarbageServiceRatingRounded = garbageServiceRatingRounded;

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
                FacilityGarbageTruckTotal = facilityGarbageTruckTotal;
                FacilityDumpTruckTotal = facilityDumpTruckTotal;
                FacilityDumpTruckMoving = facilityDumpTruckMoving;
                FacilityMaxWorkers = facilityMaxWorkers;

                Facilities = facilities;
            }
        }

        private CitySystem m_CitySystem = null!;
        private GarbageAccumulationSystem m_GarbageAccumulationSystem = null!;
        private CitizenHappinessSystem m_CitizenHappinessSystem = null!;

        private EntityQuery m_ProducerQuery;
        private EntityQuery m_RequestQuery;
        private EntityQuery m_TruckQuery;
        private EntityQuery m_HappinessFactorParameterQuery;
        private PrefabSystem m_PrefabSystem = null!;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_PrefabSystem = World.GetOrCreateSystemManaged<PrefabSystem>();
            m_CitySystem = World.GetOrCreateSystemManaged<CitySystem>();
            m_GarbageAccumulationSystem = World.GetOrCreateSystemManaged<GarbageAccumulationSystem>();
            m_CitizenHappinessSystem = World.GetOrCreateSystemManaged<CitizenHappinessSystem>();

            // Buildings that currently hold garbage.
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

            // Active garbage collection requests in the current city.
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

            // Normal curbside garbage trucks only.
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

            // Buffer used by the game's city happiness factor calculation.
            m_HappinessFactorParameterQuery = GetEntityQuery(
                ComponentType.ReadOnly<HappinessFactorParameterData>());

            Enabled = false;
        }

        // Snapshot system only in Options UI, no auto sim work needed on purpose, does not affect city performance.
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

            // Read current live garbage parameters from the singleton.
            bool haveParams = SystemAPI.TryGetSingleton(out GarbageParameterData gp);

            int requestLimit = 0;
            int collectLimit = 0;
            int warningLimit = 0;
            int maxAccumulation = 0;
            int happinessBaseline = 0;
            int happinessStep = 0;

            if (haveParams)
            {
                requestLimit = gp.m_RequestGarbageLimit;
                collectLimit = gp.m_CollectionGarbageLimit;
                warningLimit = gp.m_WarningGarbageLimit;
                maxAccumulation = gp.m_MaxGarbageAccumulation;
                happinessBaseline = gp.m_HappinessEffectBaseline;
                happinessStep = gp.m_HappinessEffectStep;
            }

            // Early empty snapshot when no city is loaded.
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
                    happinessBaseline: happinessBaseline,
                    happinessStep: happinessStep,
                    garbageTonsPerMonth: 0,
                    processingTonsPerMonth: 0,
                    garbageServiceRatingRaw: 0.0,
                    garbageServiceRatingRounded: 0,
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
                    facilityGarbageTruckTotal: 0,
                    facilityDumpTruckTotal: 0,
                    facilityDumpTruckMoving: 0,
                    facilityMaxWorkers: 0,
                    facilities: Array.Empty<FacilityEntry>());
            }

            ComponentLookup<WorkProvider> workProviderLookup = GetComponentLookup<WorkProvider>(true);
            BufferLookup<OwnedVehicle> ownedVehicleLookup = GetBufferLookup<OwnedVehicle>(true);

            // Citywide production-style number exposed by GarbageAccumulationSystem.
            long garbageRaw = m_GarbageAccumulationSystem != null
                ? m_GarbageAccumulationSystem.garbageAccumulation
                : 0L;

            double garbageServiceRatingRaw = 0.0;
            int garbageServiceRatingRounded = 0;

            // Pull the city's current Garbage happiness factor directly from the game.
            if (m_CitizenHappinessSystem != null && !m_HappinessFactorParameterQuery.IsEmptyIgnoreFilter)
            {
                Entity happinessParamEntity = m_HappinessFactorParameterQuery.GetSingletonEntity();
                BufferLookup<HappinessFactorParameterData> happinessFactorLookup =
                    GetBufferLookup<HappinessFactorParameterData>(true);
                ComponentLookup<Locked> lockedLookup = GetComponentLookup<Locked>(true);

                if (happinessFactorLookup.HasBuffer(happinessParamEntity))
                {
                    DynamicBuffer<HappinessFactorParameterData> parameters =
                        happinessFactorLookup[happinessParamEntity];

                    Unity.Mathematics.float3 factor = m_CitizenHappinessSystem.GetHappinessFactor(
                        CitizenHappinessSystem.HappinessFactor.Garbage,
                        parameters,
                        ref lockedLookup);

                    garbageServiceRatingRaw = factor.x;
                    garbageServiceRatingRounded = Mathf.RoundToInt(factor.x);
                }
            }

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

            // Scan all garbage-producing buildings to build summary stats.
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

                if (haveParams && garbage >= warningLimit)
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

            // Separate pending requests from already-assigned/dispatched requests.
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

                    // Track the worst currently pending target for easier troubleshooting.
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

            // Scan normal garbage trucks only for global truck-state totals.
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
            }

            long processingRaw = 0L;
            int facilityTotal = 0;
            int facilityGarbageTruckTotal = 0;
            int facilityDumpTruckTotal = 0;
            int facilityDumpTruckMoving = 0;
            int facilityMaxWorkers = 0;

            List<FacilityEntry> facilityEntries = new List<FacilityEntry>(16);

            // Build per-facility summaries by scanning each facility's owned vehicles.
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

                int garbageTruckTotal = 0;
                int garbageTruckMoving = 0;
                int garbageTruckParked = 0;
                int dumpTruckTotal = 0;
                int dumpTruckMoving = 0;

                if (ownedVehicleLookup.HasBuffer(facilityEntity))
                {
                    DynamicBuffer<OwnedVehicle> ownedVehicles = ownedVehicleLookup[facilityEntity];

                    for (int i = 0; i < ownedVehicles.Length; i++)
                    {
                        Entity vehicle = ownedVehicles[i].m_Vehicle;
                        if (vehicle == Entity.Null || !EntityManager.Exists(vehicle))
                        {
                            continue;
                        }

                        if (SystemAPI.HasComponent<Deleted>(vehicle) || SystemAPI.HasComponent<Temp>(vehicle))
                        {
                            continue;
                        }

                        // Normal curbside garbage trucks.
                        if (SystemAPI.HasComponent<Game.Vehicles.GarbageTruck>(vehicle))
                        {
                            bool isParked = SystemAPI.HasComponent<ParkedCar>(vehicle);
                            garbageTruckTotal++;

                            if (isParked)
                            {
                                garbageTruckParked++;
                            }
                            else
                            {
                                garbageTruckMoving++;
                            }

                            continue;
                        }

                        // Hazardous-waste / transfer dump trucks use the DeliveryTruck path.
                        if (SystemAPI.HasComponent<Game.Vehicles.DeliveryTruck>(vehicle))
                        {
                            Game.Vehicles.DeliveryTruck deliveryTruck =
                                SystemAPI.GetComponent<Game.Vehicles.DeliveryTruck>(vehicle);

                            // Ignore dummy traffic so only real owned trucks are counted.
                            if ((deliveryTruck.m_State & DeliveryTruckFlags.DummyTraffic) != 0)
                            {
                                continue;
                            }

                            bool isParked = SystemAPI.HasComponent<ParkedCar>(vehicle);

                            dumpTruckTotal++;

                            if (!isParked)
                            {
                                dumpTruckMoving++;
                            }
                        }
                    }
                }

                // Skip facilities that currently contribute nothing useful to the report.
                if (facility.ValueRO.m_ProcessingRate <= 0 &&
                    garbageTruckTotal <= 0 &&
                    dumpTruckTotal <= 0 &&
                    maxWorkers <= 0)
                {
                    continue;
                }

                processingRaw += facility.ValueRO.m_ProcessingRate;
                facilityTotal++;
                facilityGarbageTruckTotal += garbageTruckTotal;
                facilityDumpTruckTotal += dumpTruckTotal;
                facilityDumpTruckMoving += dumpTruckMoving;
                facilityMaxWorkers += maxWorkers;

                facilityEntries.Add(new FacilityEntry(
                    facilityEntity,
                    garbageTruckTotal,
                    garbageTruckMoving,
                    garbageTruckParked,
                    dumpTruckTotal,
                    dumpTruckMoving,
                    maxWorkers));
            }

            // Sort busiest facilities first for the log.
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
                happinessBaseline: happinessBaseline,
                happinessStep: happinessStep,
                garbageTonsPerMonth: garbageTonsPerMonth,
                processingTonsPerMonth: processingTonsPerMonth,
                garbageServiceRatingRaw: garbageServiceRatingRaw,
                garbageServiceRatingRounded: garbageServiceRatingRounded,
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
                facilityGarbageTruckTotal: facilityGarbageTruckTotal,
                facilityDumpTruckTotal: facilityDumpTruckTotal,
                facilityDumpTruckMoving: facilityDumpTruckMoving,
                facilityMaxWorkers: facilityMaxWorkers,
                facilities: facilityEntries.ToArray());
        }

        // Sort by activity first, then total fleet, then stable entity order.
        private static int CompareFacilityEntries(FacilityEntry a, FacilityEntry b)
        {
            int aActivity = a.GarbageTruckMoving + a.DumpTruckMoving;
            int bActivity = b.GarbageTruckMoving + b.DumpTruckMoving;

            int cmp = bActivity.CompareTo(aActivity);
            if (cmp != 0)
            {
                return cmp;
            }

            int aTotal = a.GarbageTruckTotal + a.DumpTruckTotal;
            int bTotal = b.GarbageTruckTotal + b.DumpTruckTotal;

            cmp = bTotal.CompareTo(aTotal);
            if (cmp != 0)
            {
                return cmp;
            }

            return a.Facility.Index.CompareTo(b.Facility.Index);
        }

        // Convert internal raw garbage totals to the player-facing tons-per-month style output.
        private static long ToTonsPerMonth(long raw)
        {
            if (raw <= 0L)
            {
                return 0L;
            }

            return (long)Math.Round(raw / 1000.0, MidpointRounding.AwayFromZero);
        }

        // ----------- HELPERS -----------

        public CriticalBuildingEntry[] GetCriticalBuildings()
        {
            List<CriticalBuildingEntry> entries = new List<CriticalBuildingEntry>(16);

            foreach ((RefRO<GarbageProducer> producer, Entity buildingEntity) in SystemAPI
                         .Query<RefRO<GarbageProducer>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Destroyed, Temp>())
            {
                int garbage = producer.ValueRO.m_Garbage;
                if (garbage >= Setting.PriorityCriticalGarbage)
                {
                    entries.Add(new CriticalBuildingEntry(buildingEntity, garbage));
                }
            }

            entries.Sort(CompareCriticalBuildingEntries);
            return entries.ToArray();
        }

        private static int CompareCriticalBuildingEntries(CriticalBuildingEntry a, CriticalBuildingEntry b)
        {
            int cmp = b.Garbage.CompareTo(a.Garbage);
            if (cmp != 0)
            {
                return cmp;
            }

            return a.Building.Index.CompareTo(b.Building.Index);
        }

    }
}
