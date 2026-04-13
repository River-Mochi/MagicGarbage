// File: Systems/GarbagePriorityAssistSystem.cs
// Trash Boss optional assist.
// When any active garbage request target is critically overloaded,
// temporarily raise pickup threshold to the live request threshold.
// Goal: reduce extra side pickups and help badly overloaded targets get reached sooner.

namespace MagicGarbage
{
    using Colossal.Serialization.Entities; // Purpose
    using Game;
    using Game.Buildings;
    using Game.Common;
    using Game.Prefabs;
    using Game.Simulation;
    using Game.Tools;
    using Unity.Entities;
    using Unity.Mathematics;

    public sealed partial class GarbagePriorityAssistSystem : GameSystemBase
    {
        private bool m_HaveBase;
        private int m_BaseCollectLimit;

        public override int GetUpdateInterval(SystemUpdatePhase phase)
        {
            return 128;
        }

        protected override void OnCreate()
        {
            base.OnCreate();

            RequireForUpdate<GarbageParameterData>();
            Enabled = false;
        }

        protected override void OnGameLoadingComplete(Purpose purpose, GameMode mode)
        {
            base.OnGameLoadingComplete(purpose, mode);

            m_HaveBase = false;
            m_BaseCollectLimit = 0;

            if (Mod.TryGetSetting(out Setting setting))
            {
                Enabled =
                    !setting.TotalMagic &&
                    setting.TrashBossEnabled &&
                    setting.PrioritySystemEnabled;
            }
            else
            {
                Enabled = false;
            }
        }

        protected override void OnUpdate()
        {
            if (!Mod.TryGetSetting(out Setting setting))
            {
                return;
            }

            if (!SystemAPI.TryGetSingletonRW<GarbageParameterData>(out RefRW<GarbageParameterData> parameters))
            {
                return;
            }

            ref GarbageParameterData data = ref parameters.ValueRW;

            if (!m_HaveBase)
            {
                m_BaseCollectLimit = math.max(1, data.m_CollectionGarbageLimit);
                m_HaveBase = true;
            }

            int normalCollect = m_BaseCollectLimit;

            if (!setting.TotalMagic && setting.TrashBossEnabled && setting.PowerUserOptions)
            {
                int requestLimit = math.clamp(
                    setting.GarbageDispatchRequestThreshold,
                    Setting.VanillaDispatchRequestThreshold,
                    Setting.MaxDispatchRequestThreshold);

                normalCollect = math.clamp(
                    setting.GarbagePickupThreshold,
                    Setting.VanillaPickupThreshold,
                    Setting.MaxPickupThreshold);

                if (normalCollect > requestLimit)
                {
                    normalCollect = requestLimit;
                }
            }

            bool assistAllowed =
                !setting.TotalMagic &&
                setting.TrashBossEnabled &&
                setting.PrioritySystemEnabled;

            int criticalTargetCount = 0;

            if (assistAllowed)
            {
                ComponentLookup<GarbageProducer> producerLookup = SystemAPI.GetComponentLookup<GarbageProducer>(true);

                foreach ((RefRO<GarbageCollectionRequest> request, RefRO<ServiceRequest> serviceRequest) in SystemAPI
                             .Query<RefRO<GarbageCollectionRequest>, RefRO<ServiceRequest>>()
                             .WithNone<Deleted, Temp>())
                {
                    if ((serviceRequest.ValueRO.m_Flags & ServiceRequestFlags.Reversed) != 0)
                    {
                        continue;
                    }

                    Entity target = request.ValueRO.m_Target;
                    if (target == Entity.Null)
                    {
                        continue;
                    }

                    if (!producerLookup.TryGetComponent(target, out GarbageProducer producer))
                    {
                        continue;
                    }

                    if (producer.m_Garbage >= Setting.PriorityCriticalGarbage)
                    {
                        criticalTargetCount++;
                    }
                }
            }

            int targetCollect = normalCollect;

            // Safe first pass:
            // temporarily lift pickup threshold to the current request threshold.
            // This keeps pickup <= request and narrows extra side pickups.
            if (assistAllowed && criticalTargetCount > 0)
            {
                targetCollect = math.max(normalCollect, data.m_RequestGarbageLimit);
            }

            if (data.m_CollectionGarbageLimit != targetCollect)
            {
                int oldCollect = data.m_CollectionGarbageLimit;
                data.m_CollectionGarbageLimit = targetCollect;

#if DEBUG
                Mod.Log.Info(
                    $"[MG] Priority assist: critical targets={criticalTargetCount}, pickup {oldCollect}->{targetCollect}");
#endif
            }

            if (!assistAllowed && data.m_CollectionGarbageLimit == normalCollect)
            {
                Enabled = false;
            }
        }
    }
}
