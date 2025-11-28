// Mod.cs
// Entry point for "Magic Garbage Truck" [MGT].

namespace MagicGarbage
{
    using System;                         // Exception
    using System.Reflection;              // Assembly version number
    using Colossal;                       // IDictionarySource
    using Colossal.IO.AssetDatabase;      // AssetDatabase
    using Colossal.Localization;          // LocalizationManager
    using Colossal.Logging;               // ILog, LogManager
    using Game;                           // UpdateSystem, SystemUpdatePhase
    using Game.Modding;                   // IMod
    using Game.SceneFlow;                 // GameManager

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Magic Garbage Truck";
        public const string ModId = "MagicGarbageTruck";
        public const string ModTag = "[MGT]";

        /// <summary>
        /// Read Version from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        // Logger (show errors in UI only in DEBUG)
        public static readonly ILog Log =
            LogManager.GetLogger("MagicGarbage").SetShowsErrorsInUI(
#if DEBUG
                true
#else
                false
#endif
            );

        // Shared settings instance
        public static Setting? Setting
        {
            get;
            private set;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            // One-time load banner.
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                Log.Info($"{ModTag} {ModName} v{ModVersion} OnLoad");
            }

            GameManager? gameManager = GameManager.instance;
            if (gameManager == null)
            {
                Log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            // Settings first
            var setting = new Setting(this);
            Setting = setting;

            // Register locales via helper
            AddLocaleSource("en-US", new LocaleEN(setting));
            //AddLocaleSource("fr-FR", new LocaleFR(setting));
            //AddLocaleSource("es-ES", new LocaleES(setting));
            //AddLocaleSource("de-DE", new LocaleDE(setting));
           // AddLocaleSource("it-IT", new LocaleIT(setting));
          //  AddLocaleSource("ja-JP", new LocaleJA(setting));
          //  AddLocaleSource("ko-KR", new LocaleKO(setting));
          //  AddLocaleSource("pl-PL", new LocalePL(setting));
          //  AddLocaleSource("pt-BR", new LocalePT_BR(setting));
          //  AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));   // Simplified Chinese
          //  AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting)); // Traditional Chinese

            // Load saved settings (file name is in Setting.cs [FileLocation])
            AssetDatabase.global.LoadSettings("MagicGarbage", setting, new Setting(this));

            // Show in Options -> Mods
            setting.RegisterInOptionsUI();

            // Main simulation phase:
            // - MagicGarbageSystem: when MagicGarbage toggle ON, clears garbage & requests
            // - GarbageTruckCapacitySystem: adjusts truck capacity & unload rate for Semi-Magic
            // - GarbageFacilityCapacitySystem: adjusts facility trucks, processing speed, storage
            updateSystem.UpdateAfter<MagicGarbageSystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageFacilityCapacitySystem>(SystemUpdatePhase.GameSimulation);

#if DEBUG
            Log.Info("[MGT] All systems are now hooked into the main GameSimulation phase.");
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

        // --------------------------------------------------------------------
        // Localization helper
        // --------------------------------------------------------------------

        /// <summary>
        /// Wrapper for LocalizationManager.AddSource that catches exceptions.
        /// so localization issues can't break mod loading.
        /// </summary>
        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            LocalizationManager? lm = GameManager.instance?.localizationManager;
            if (lm == null)
            {
                Log.Warn($"AddLocaleSource: No LocalizationManager; cannot add source for '{localeId}'.");
                return;
            }

            try
            {
                lm.AddSource(localeId, source);
            }
            catch (Exception ex)
            {
                Log.Warn(
                    $"AddLocaleSource: AddSource for '{localeId}' failed: {ex.GetType().Name}: {ex.Message}");
            }
        }
    }
}
