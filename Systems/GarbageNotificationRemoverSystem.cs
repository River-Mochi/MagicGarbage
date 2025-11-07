// Systems/GarbageNotificationRemoverSystem.cs
// Legacy placeholder: notification icons are now handled by the base game
// and by MagicGarbageSystem cleaning building garbage and flags.

using Game;

namespace MagicGarbage
{

    /// <summary>
    /// This system is intentionally disabled.
    /// It exists only so Mod.OnLoad can reference GarbageNotificationRemoverSystem
    /// without compile errors. All actual icon behaviour is:
    /// - Vanilla (when MagicGarbage = false)
    /// - MagicGarbageSystem + vanilla (when MagicGarbage = true)
    /// </summary>
    public partial class GarbageNotificationRemoverSystem : GameSystemBase
    {
        protected override void OnCreate()
        {
            base.OnCreate();
            Enabled = false;
        }

        protected override void OnUpdate()
        {
            // No-op on purpose.
        }
    }
}
