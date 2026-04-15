// File: Systems/GarbageTransferProbe.cs
// Transfer probe helpers for detailed status log.
// Purpose:
// - Probe garbage storage-transfer behavior used by dump trucks.
// - Keep logic in a separate file so removal is easy later.

namespace MagicGarbage
{
    using Game.Common;
    using Game.Companies;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.Tools;
    using System;
    using System.Collections.Generic;
    using Unity.Entities;

    public sealed partial class GarbageStatusSystem
    {
        public readonly struct GarbageTransferProbeEntry
        {
            public readonly Entity Facility;
            public readonly string PrefabName;
            public readonly int StoredGarbage;
            public readonly int PerResourceCapacity;
            public readonly int ExportStartThreshold;
            public readonly int LowStockThreshold;
            public readonly int MinTransferAmount;
            public readonly int OutgoingGarbageRequests;
            public readonly int IncomingGarbageRequests;
            public readonly int ActiveTransferAmount;
            public readonly bool HasTransferPath;
            public readonly bool IsStationStyle;

            public GarbageTransferProbeEntry(
                Entity facility,
                string prefabName,
                int storedGarbage,
                int perResourceCapacity,
                int exportStartThreshold,
                int lowStockThreshold,
                int minTransferAmount,
                int outgoingGarbageRequests,
                int incomingGarbageRequests,
                int activeTransferAmount,
                bool hasTransferPath,
                bool isStationStyle)
            {
                Facility = facility;
                PrefabName = prefabName;
                StoredGarbage = storedGarbage;
                PerResourceCapacity = perResourceCapacity;
                ExportStartThreshold = exportStartThreshold;
                LowStockThreshold = lowStockThreshold;
                MinTransferAmount = minTransferAmount;
                OutgoingGarbageRequests = outgoingGarbageRequests;
                IncomingGarbageRequests = incomingGarbageRequests;
                ActiveTransferAmount = activeTransferAmount;
                HasTransferPath = hasTransferPath;
                IsStationStyle = isStationStyle;
            }
        }

        public GarbageTransferProbeEntry[] GetGarbageTransferProbeEntries()
        {
            List<GarbageTransferProbeEntry> entries = new List<GarbageTransferProbeEntry>(16);

            BufferLookup<StorageTransferRequest> storageTransferRequestLookup = GetBufferLookup<StorageTransferRequest>(true);
            ComponentLookup<StorageTransfer> storageTransferLookup = GetComponentLookup<StorageTransfer>(true);
            ComponentLookup<PathInformation> pathInformationLookup = GetComponentLookup<PathInformation>(true);
            ComponentLookup<CompanyData> companyDataLookup = GetComponentLookup<CompanyData>(true);

            foreach ((RefRO<Game.Buildings.GarbageFacility> _facility, RefRO<Game.Companies.StorageCompany> _storageCompany, RefRO<PrefabRef> prefabRef, DynamicBuffer<Game.Economy.Resources> resources, Entity facilityEntity) in SystemAPI
                         .Query<RefRO<Game.Buildings.GarbageFacility>, RefRO<Game.Companies.StorageCompany>, RefRO<PrefabRef>, DynamicBuffer<Game.Economy.Resources>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Destroyed, Temp>())
            {
                Entity prefabEntity = prefabRef.ValueRO.m_Prefab;

                if (!SystemAPI.HasComponent<StorageCompanyData>(prefabEntity) ||
                    !SystemAPI.HasComponent<StorageLimitData>(prefabEntity))
                {
                    continue;
                }

                StorageCompanyData storageCompanyData = SystemAPI.GetComponent<StorageCompanyData>(prefabEntity);
                if ((storageCompanyData.m_StoredResources & Game.Economy.Resource.Garbage) == Game.Economy.Resource.NoResource)
                {
                    continue;
                }

                int storedKinds = Game.Economy.EconomyUtils.CountResources(storageCompanyData.m_StoredResources);
                if (storedKinds <= 0)
                {
                    continue;
                }

                StorageLimitData limitData = SystemAPI.GetComponent<StorageLimitData>(prefabEntity);

                SpawnableBuildingData spawnableData = SystemAPI.HasComponent<SpawnableBuildingData>(prefabEntity)
                    ? SystemAPI.GetComponent<SpawnableBuildingData>(prefabEntity)
                    : new SpawnableBuildingData { m_Level = 1 };

                BuildingData buildingData = SystemAPI.HasComponent<BuildingData>(prefabEntity)
                    ? SystemAPI.GetComponent<BuildingData>(prefabEntity)
                    : new BuildingData { m_LotSize = new Unity.Mathematics.int2(1, 1) };

                int totalEffectiveCapacity = limitData.GetAdjustedLimitForWarehouse(spawnableData, buildingData);
                int perResourceCapacity = storedKinds > 0 ? totalEffectiveCapacity / storedKinds : 0;

                // Probe-only approximation:
                // StorageCompanySystem uses CompanyData for company-style storage and excludes it for station-style storage.
                bool isStationStyle = !companyDataLookup.HasComponent(facilityEntity);

                int exportStartCap = isStationStyle ? 200000 : 100000;
                int lowStockCap = isStationStyle ? 100000 : 25000;
                int minTransferCap = isStationStyle ? 30000 : 10000;

                int exportStartThreshold = ClampThresholdFromCapacity(perResourceCapacity, 0.8d, exportStartCap);
                int lowStockThreshold = ClampThresholdFromCapacity(perResourceCapacity, 0.5d, lowStockCap);
                int minTransferAmount = ClampThresholdFromCapacity(perResourceCapacity, 0.5d, minTransferCap);

                int storedGarbage = Game.Economy.EconomyUtils.GetResources(Game.Economy.Resource.Garbage, resources);

                int outgoingGarbageRequests = 0;
                int incomingGarbageRequests = 0;

                if (storageTransferRequestLookup.HasBuffer(facilityEntity))
                {
                    DynamicBuffer<StorageTransferRequest> requests = storageTransferRequestLookup[facilityEntity];

                    for (int i = 0; i < requests.Length; i++)
                    {
                        StorageTransferRequest request = requests[i];
                        if (request.m_Resource != Game.Economy.Resource.Garbage)
                        {
                            continue;
                        }

                        if ((request.m_Flags & StorageTransferFlags.Incoming) != 0)
                        {
                            incomingGarbageRequests += request.m_Amount;
                        }
                        else
                        {
                            outgoingGarbageRequests += request.m_Amount;
                        }
                    }
                }

                int activeTransferAmount = 0;
                bool hasTransferPath = false;

                if (storageTransferLookup.HasComponent(facilityEntity))
                {
                    StorageTransfer transfer = storageTransferLookup[facilityEntity];
                    if (transfer.m_Resource == Game.Economy.Resource.Garbage)
                    {
                        activeTransferAmount = transfer.m_Amount;
                        hasTransferPath = pathInformationLookup.HasComponent(facilityEntity);
                    }
                }

                string prefabName = m_GamePrefabSystem.GetPrefabName(prefabEntity);

                entries.Add(new GarbageTransferProbeEntry(
                    facilityEntity,
                    prefabName,
                    storedGarbage,
                    perResourceCapacity,
                    exportStartThreshold,
                    lowStockThreshold,
                    minTransferAmount,
                    outgoingGarbageRequests,
                    incomingGarbageRequests,
                    activeTransferAmount,
                    hasTransferPath,
                    isStationStyle));
            }

            entries.Sort(CompareGarbageTransferProbeEntries);
            return entries.ToArray();
        }

        private static int CompareGarbageTransferProbeEntries(GarbageTransferProbeEntry a, GarbageTransferProbeEntry b)
        {
            int aActivity = ((a.ActiveTransferAmount != 0) ? 2 : 0) + (((a.OutgoingGarbageRequests + a.IncomingGarbageRequests) > 0) ? 1 : 0);
            int bActivity = ((b.ActiveTransferAmount != 0) ? 2 : 0) + (((b.OutgoingGarbageRequests + b.IncomingGarbageRequests) > 0) ? 1 : 0);

            int cmp = bActivity.CompareTo(aActivity);
            if (cmp != 0)
            {
                return cmp;
            }

            cmp = b.StoredGarbage.CompareTo(a.StoredGarbage);
            if (cmp != 0)
            {
                return cmp;
            }

            return a.Facility.Index.CompareTo(b.Facility.Index);
        }

        private static int ClampThresholdFromCapacity(int perResourceCapacity, double factor, int cap)
        {
            if (perResourceCapacity <= 0)
            {
                return 0;
            }

            double scaled = Math.Ceiling((perResourceCapacity * factor) / 10000.0) * 10000.0;
            return (int)Math.Min(scaled, cap);
        }
    }
}
