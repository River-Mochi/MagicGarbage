// File: Mod.cs
// Entry point for "Magic Garbage" [MG].

namespace MagicGarbage
{
    using Colossal;                       // IDictionarySource
    using Colossal.IO.AssetDatabase;      // AssetDatabase
    using Colossal.Localization;          // LocalizationManager
    using Colossal.Logging;               // ILog, LogManager
    using Game;                           // UpdateSystem, SystemUpdatePhase
    using Game.Modding;                   // IMod
    using Game.SceneFlow;                 // GameManager
    using Game.Simulation;
    using System;                         // Exception
    using System.Reflection;              // Assembly version number

    public sealed class Mod : IMod
    {
        // ---- PUBLIC CONSTANTS / METADATA ----
        public const string ModName = "Magic Garbage";
        public const string ModId = "MagicGarbage";
        public const string ModTag = "[MG]";


        /// <summary>
        /// Read Version from .csproj (3-part).
        /// </summary>
        public static readonly string ModVersion =
            Assembly.GetExecutingAssembly().GetName().Version?.ToString(3) ?? "1.0.0";

        private static bool s_BannerLogged;

        // Logger (show errors in UI only in DEBUG)
        public static readonly ILog Log =
            LogManager.GetLogger(ModId).SetShowsErrorsInUI(
#if DEBUG
                true
#else
                false
#endif
            );

        // Shared settings instance (valid after OnLoad).
        private static Setting s_Setting = null!;
        private static bool s_HasSetting;

        public static Setting Setting
        {
            get => s_Setting;
            private set
            {
                s_Setting = value;
                s_HasSetting = true;
            }
        }

        /// <summary>
        /// Systems can call this without nullable annotations.
        /// </summary>
        public static bool TryGetSetting(out Setting setting)
        {
            if (s_HasSetting)
            {
                setting = s_Setting;
                return true;
            }

            setting = null!;
            return false;
        }

        public void OnLoad(UpdateSystem updateSystem)
        {
            // One-time load banner.
            if (!s_BannerLogged)
            {
                s_BannerLogged = true;
                Log.Info($"{ModTag} {ModName} v{ModVersion} OnLoad");
            }

            GameManager gameManager = GameManager.instance;
            if (gameManager == null)
            {
                Log.Error("GameManager.instance is null in Mod.OnLoad.");
                return;
            }

            // Settings first
            Setting setting = new Setting(this);
            Setting = setting;

            // Register locales via helper
            AddLocaleSource("en-US", new LocaleEN(setting));
            AddLocaleSource("fr-FR", new LocaleFR(setting));
            AddLocaleSource("es-ES", new LocaleES(setting));
            AddLocaleSource("de-DE", new LocaleDE(setting));
            AddLocaleSource("it-IT", new LocaleIT(setting));
            AddLocaleSource("ja-JP", new LocaleJA(setting));
            AddLocaleSource("ko-KR", new LocaleKO(setting));
            AddLocaleSource("pl-PL", new LocalePL(setting));
            AddLocaleSource("pt-BR", new LocalePT_BR(setting));
            AddLocaleSource("zh-HANS", new LocaleZH_CN(setting));   // Simplified Chinese
            AddLocaleSource("zh-HANT", new LocaleZH_HANT(setting)); // Traditional Chinese

            // Load saved settings (file name in [FileLocation])
            AssetDatabase.global.LoadSettings(ModId, setting, new Setting(this));

            // Show in Options UI
            setting.RegisterInOptionsUI();

            // Main simulation phase
            updateSystem.UpdateAfter<GarbageTruckCapacitySystem>(SystemUpdatePhase.GameSimulation);
            updateSystem.UpdateAfter<GarbageFacilityCapacitySystem>(SystemUpdatePhase.GameSimulation);

            // On-demand Status report (disabled by default; button executes)
            updateSystem.UpdateAfter<GarbageStatusSystem>(SystemUpdatePhase.GameSimulation);

            updateSystem.UpdateAfter<TotalMagicSystem>(SystemUpdatePhase.GameSimulation);
            // note to future me: don't add pre-dispatch garbage request suppression for Total Magic. it causes severe Player.log spam ("UpdateFrame added to unsupported type").


#if DEBUG
            Log.Info($"{ModTag} All systems are now hooked into the main GameSimulation phase.");
#endif
        }

        public void OnDispose()
        {
            if (s_HasSetting)
            {
                s_Setting.UnregisterInOptionsUI();
                s_HasSetting = false;
                s_Setting = null!;
            }

#if DEBUG
            Log.Info($"{ModTag} OnDispose");
#endif
        }

        // --------------------------------------------------------------------
        // Localization helper
        // --------------------------------------------------------------------

        /// <summary>
        /// Wrapper for LocalizationManager.AddSource that catches exceptions,
        /// so localization issues can't break mod loading.
        /// </summary>
        private static void AddLocaleSource(string localeId, IDictionarySource source)
        {
            if (string.IsNullOrEmpty(localeId))
            {
                return;
            }

            GameManager gm = GameManager.instance;
            if (gm == null)
            {
                Log.Warn($"AddLocaleSource: No GameManager; cannot add source for '{localeId}'.");
                return;
            }

            LocalizationManager lm = gm.localizationManager;
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

        // --------------------------------------------------------------------
        // Runtime localization helper (for Status report)
        // --------------------------------------------------------------------

        public static string L(string key)
        {
            GameManager gm = GameManager.instance;
            if (gm?.localizationManager?.activeDictionary != null &&
                gm.localizationManager.activeDictionary.TryGetValue(key, out string value) &&
                !string.IsNullOrEmpty(value))
            {
                return value;
            }

            return key; // safe fallback
        }

        public static string LF(string key, params object[] args)
        {
            string fmt = L(key);
            try
            {
                return (args == null || args.Length == 0) ? fmt : string.Format(fmt, args);
            }
            catch
            {
                return fmt; // don’t ever break UI over a bad format string
            }
        }

    }
}
