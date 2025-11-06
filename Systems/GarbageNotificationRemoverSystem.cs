// Systems/GarbageNotificationRemoverSystem.cs

using Game;
using Game.Prefabs;
using Unity.Entities;

namespace MagicGarbage
{
    /// <summary>
    /// SEMI-MAGIC:
    /// Controls global visibility of the "Garbage piling up" icon prefab.
    /// Independent of whether Total Magic is on.
    ///
    /// If HideGarbageNotifications is true:
    ///   - Disables NotificationIconDisplayData on the garbage icon prefab.
    ///   - This hides the icon everywhere while keeping the simulation intact.
    /// </summary>
    public partial class GarbageNotificationRemoverSystem : GameSystemBase
    {
        private EntityQuery m_GarbageParamsQuery;

        protected override void OnCreate()
        {
            base.OnCreate();

            m_GarbageParamsQuery = GetEntityQuery(
                ComponentType.ReadOnly<GarbageParameterData>());

            RequireForUpdate(m_GarbageParamsQuery);
        }

        protected override void OnUpdate()
        {
            bool hide = Mod.Setting?.HideGarbageNotifications ?? false;
            var garbageParams = m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();

            Entity prefab = garbageParams.m_GarbageNotificationPrefab;

            if (EntityManager.HasComponent<NotificationIconDisplayData>(prefab))
            {
                // true = component enabled = icon visible
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(
                    prefab,
                    !hide);
            }
        }
    }
}
