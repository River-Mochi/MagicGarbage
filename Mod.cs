// Mod.cs
// Entry point for MGT

namespace MagicGarbage
{
    using Colossal.IO.AssetDatabase;
    using Colossal.Logging;
    using Game;
    using Game.Modding;
    using Game.SceneFlow;

    public sealed class Mod : IMod
    {
        public const string ModName = "Magic Garbage Truck [MGT]";
        public const string VersionShort = "1.0.0";

        // Log file: MagicGarbage.log
        public static readonly ILog Log =
            LogManager.GetLogger("MagicGarbage").SetShowsErrorsInUI(false);

        // Shared settings instance (nullable because it's cleared on dispose)
        public static Setting? Setting
        {
            get; private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            // Lightweight banner: only at load
            Log.Info($"[MGT] {ModName} v{VersionShort} OnLoad");

            var setting = new Setting(this);
            Setting = setting;

            var lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn("[MGT] LocalizationManager is null; skipping locale registration.");
            }
            else
            {
                // First, Register all supported locales once
                lm.AddSource("en-US", new LocaleEN(setting));
                lm.AddSource("fr-FR", new LocaleFR(setting));
                lm.AddSource("es-ES", new LocaleES(setting));
                lm.AddSource("de-DE", new LocaleDE(setting));
                lm.AddSource("it-IT", new LocaleIT(setting));
                lm.AddSource("zh-HANS", new LocaleZH_CN(setting));
            }

            // Load + register in Options UI
            AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));
            setting.RegisterInOptionsUI();

            // Systems in the main simulation phase:
            // - MagicGarbageSystem: wipes garbage + requests when MagicGarbage is ON
            // - GarbageNotificationRemoverSystem: hides/shows problem icons
            // - GarbageTruckCapacitySystem: adjusts truck capacity & unload rate
            updateSystem.UpdateAfter<MagicGarbageSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageNotificationRemoverSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);

            if DEBUG
                                        Log.Info("[MGT] Systems scheduled (GameSimulation only).");
#endif
        }

        public void OnDispose()
        {
            if (Setting != null)
            {
                Setting.UnregisterInOptionsUI();
                Setting = null;
            }

#if DEBUG
            Log.Info("[MGT] OnDispose");
#endif
        }
    }
}
