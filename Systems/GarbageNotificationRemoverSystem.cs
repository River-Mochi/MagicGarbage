// Systems/GarbageNotificationRemoverSystem.cs
// Controls visibility of the global "Garbage piling up" notification icon prefab.

using Game;
using Game.Prefabs;
using Unity.Entities;

namespace MagicGarbage
{
    /// <summary>
    /// Icon visibility logic:
    /// - When Total Magic (MagicGarbage) is ON → garbage icons are always hidden.
    /// - When Total Magic is OFF:
    ///     • HideGarbageNotifications = true  → hide icons
    ///     • HideGarbageNotifications = false → show icons (vanilla)
    ///
    /// This only affects the 3D/world icon prefab. It does not change
    /// the underlying garbage simulation or building UI text.
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
            var setting = Mod.Setting;
            if (setting == null)
                return;

            bool totalMagicOn = setting.MagicGarbage;
            bool hideSemiMagic = setting.HideGarbageNotifications;

            // Decide final visibility of the garbage icon prefab.
            bool wantVisible;

            if (totalMagicOn)
            {
                // Total Magic → there should never be garbage icons.
                wantVisible = false;
            }
            else
            {
                // Semi-Magic mode → honour the Hide toggle.
                wantVisible = !hideSemiMagic;
            }

            var garbageParams = m_GarbageParamsQuery.GetSingleton<GarbageParameterData>();
            Entity prefab = garbageParams.m_GarbageNotificationPrefab;

            if (!EntityManager.HasComponent<NotificationIconDisplayData>(prefab))
                return;

            bool isEnabled = EntityManager.IsComponentEnabled<NotificationIconDisplayData>(prefab);
            if (isEnabled != wantVisible)
            {
                EntityManager.SetComponentEnabled<NotificationIconDisplayData>(
                    prefab,
                    wantVisible);
            }
        }
    }
}
