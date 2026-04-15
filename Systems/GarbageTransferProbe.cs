// File: Systems/GarbageTransferProbe.cs
// Transfer probe helpers for detailed status log.
// Purpose:
// - Probe garbage transfer behavior used by dump trucks.
// - Split local garbage facilities from outside connections.
// - Keep logic in a separate file so removal is easy later.

namespace MagicGarbage
{
    using Game.Common;
    using Game.Economy;
    using Game.Objects;
    using Game.Pathfind;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using System.Collections.Generic;
    using Unity.Entities;

    public sealed partial class GarbageStatusSystem
    {
        public readonly struct GarbageTransferProbeEntry
        {
            public readonly Entity Facility;
            public readonly string PrefabName;
            public readonly bool IsOutsideConnection;

            public readonly int StoredGarbage;
            public readonly int GarbageCapacity;

            public readonly float AcceptPriority;
            public readonly float DeliverPriority;

            public readonly Entity AcceptRequestEntity;   // others deliver garbage here
            public readonly bool AcceptRequestExists;
            public readonly int AcceptRequestAmount;
            public readonly float AcceptRequestPriority;
            public readonly bool AcceptRequestRequireTransport;
            public readonly bool AcceptRequestAssigned;

            public readonly Entity SendRequestEntity;     // this facility sends garbage away
            public readonly bool SendRequestExists;
            public readonly int SendRequestAmount;
            public readonly float SendRequestPriority;
            public readonly bool SendRequestRequireTransport;
            public readonly bool SendRequestAssigned;

            public GarbageTransferProbeEntry(
                Entity facility,
                string prefabName,
                bool isOutsideConnection,
                int storedGarbage,
                int garbageCapacity,
                float acceptPriority,
                float deliverPriority,
                Entity acceptRequestEntity,
                bool acceptRequestExists,
                int acceptRequestAmount,
                float acceptRequestPriority,
                bool acceptRequestRequireTransport,
                bool acceptRequestAssigned,
                Entity sendRequestEntity,
                bool sendRequestExists,
                int sendRequestAmount,
                float sendRequestPriority,
                bool sendRequestRequireTransport,
                bool sendRequestAssigned)
            {
                Facility = facility;
                PrefabName = prefabName;
                IsOutsideConnection = isOutsideConnection;

                StoredGarbage = storedGarbage;
                GarbageCapacity = garbageCapacity;

                AcceptPriority = acceptPriority;
                DeliverPriority = deliverPriority;

                AcceptRequestEntity = acceptRequestEntity;
                AcceptRequestExists = acceptRequestExists;
                AcceptRequestAmount = acceptRequestAmount;
                AcceptRequestPriority = acceptRequestPriority;
                AcceptRequestRequireTransport = acceptRequestRequireTransport;
                AcceptRequestAssigned = acceptRequestAssigned;

                SendRequestEntity = sendRequestEntity;
                SendRequestExists = sendRequestExists;
                SendRequestAmount = sendRequestAmount;
                SendRequestPriority = sendRequestPriority;
                SendRequestRequireTransport = sendRequestRequireTransport;
                SendRequestAssigned = sendRequestAssigned;
            }
        }

        public GarbageTransferProbeEntry[] GetGarbageTransferProbeEntries()
        {
            List<GarbageTransferProbeEntry> entries = new List<GarbageTransferProbeEntry>(16);

            ComponentLookup<Game.Objects.OutsideConnection> outsideConnectionLookup = GetComponentLookup<Game.Objects.OutsideConnection>(true);
            BufferLookup<Game.Economy.Resources> resourcesLookup = GetBufferLookup<Game.Economy.Resources>(true);

            ComponentLookup<GarbageTransferRequest> garbageTransferRequestLookup = GetComponentLookup<GarbageTransferRequest>(true);
            ComponentLookup<Dispatched> dispatchedLookup = GetComponentLookup<Dispatched>(true);
            ComponentLookup<PathInformation> pathInformationLookup = GetComponentLookup<PathInformation>(true);

            foreach ((RefRO<Game.Buildings.GarbageFacility> facility, RefRO<PrefabRef> prefabRef, Entity facilityEntity) in SystemAPI
                         .Query<RefRO<Game.Buildings.GarbageFacility>, RefRO<PrefabRef>>()
                         .WithEntityAccess()
                         .WithNone<Deleted, Destroyed, Temp>())
            {
                Entity prefabEntity = prefabRef.ValueRO.m_Prefab;
                if (!SystemAPI.HasComponent<GarbageFacilityData>(prefabEntity))
                {
                    continue;
                }

                GarbageFacilityData prefabData = SystemAPI.GetComponent<GarbageFacilityData>(prefabEntity);

                int storedGarbage = 0;
                if (resourcesLookup.HasBuffer(facilityEntity))
                {
                    storedGarbage = Game.Economy.EconomyUtils.GetResources(Game.Economy.Resource.Garbage, resourcesLookup[facilityEntity]);
                }

                bool isOutsideConnection = outsideConnectionLookup.HasComponent(facilityEntity);
                string prefabName = m_GamePrefabSystem.GetPrefabName(prefabEntity);

                Entity acceptRequestEntity = facility.ValueRO.m_GarbageDeliverRequest;
                bool acceptRequestExists = false;
                int acceptRequestAmount = 0;
                float acceptRequestPriority = 0f;
                bool acceptRequestRequireTransport = false;
                bool acceptRequestAssigned = false;

                if (acceptRequestEntity != Entity.Null && garbageTransferRequestLookup.HasComponent(acceptRequestEntity))
                {
                    GarbageTransferRequest request = garbageTransferRequestLookup[acceptRequestEntity];
                    acceptRequestExists = true;
                    acceptRequestAmount = request.m_Amount;
                    acceptRequestPriority = request.m_Priority;
                    acceptRequestRequireTransport = (request.m_Flags & GarbageTransferRequestFlags.RequireTransport) != 0;
                    acceptRequestAssigned = dispatchedLookup.HasComponent(acceptRequestEntity) || pathInformationLookup.HasComponent(acceptRequestEntity);
                }

                Entity sendRequestEntity = facility.ValueRO.m_GarbageReceiveRequest;
                bool sendRequestExists = false;
                int sendRequestAmount = 0;
                float sendRequestPriority = 0f;
                bool sendRequestRequireTransport = false;
                bool sendRequestAssigned = false;

                if (sendRequestEntity != Entity.Null && garbageTransferRequestLookup.HasComponent(sendRequestEntity))
                {
                    GarbageTransferRequest request = garbageTransferRequestLookup[sendRequestEntity];
                    sendRequestExists = true;
                    sendRequestAmount = request.m_Amount;
                    sendRequestPriority = request.m_Priority;
                    sendRequestRequireTransport = (request.m_Flags & GarbageTransferRequestFlags.RequireTransport) != 0;
                    sendRequestAssigned = dispatchedLookup.HasComponent(sendRequestEntity) || pathInformationLookup.HasComponent(sendRequestEntity);
                }

                entries.Add(new GarbageTransferProbeEntry(
                    facilityEntity,
                    prefabName,
                    isOutsideConnection,
                    storedGarbage,
                    prefabData.m_GarbageCapacity,
                    facility.ValueRO.m_AcceptGarbagePriority,
                    facility.ValueRO.m_DeliverGarbagePriority,
                    acceptRequestEntity,
                    acceptRequestExists,
                    acceptRequestAmount,
                    acceptRequestPriority,
                    acceptRequestRequireTransport,
                    acceptRequestAssigned,
                    sendRequestEntity,
                    sendRequestExists,
                    sendRequestAmount,
                    sendRequestPriority,
                    sendRequestRequireTransport,
                    sendRequestAssigned));
            }

            entries.Sort(CompareGarbageTransferProbeEntries);
            return entries.ToArray();
        }

        private static int CompareGarbageTransferProbeEntries(GarbageTransferProbeEntry a, GarbageTransferProbeEntry b)
        {
            // Local facilities first, outside connections second.
            int cmp = a.IsOutsideConnection.CompareTo(b.IsOutsideConnection);
            if (cmp != 0)
            {
                return cmp;
            }

            int aActivity =
                ((a.AcceptRequestExists || a.SendRequestExists) ? 2 : 0) +
                (((a.AcceptPriority > 0f) || (a.DeliverPriority > 0f)) ? 1 : 0);

            int bActivity =
                ((b.AcceptRequestExists || b.SendRequestExists) ? 2 : 0) +
                (((b.AcceptPriority > 0f) || (b.DeliverPriority > 0f)) ? 1 : 0);

            cmp = bActivity.CompareTo(aActivity);
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
    }
}
