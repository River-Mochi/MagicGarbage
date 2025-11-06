// Locale/LocaleEN.cs
// English (en-US) localization for "Magic Garbage Truck [MGT]".

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleEN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleEN(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Root entry in Options → mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tab caption
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "Actions" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Total Magic" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-Magic" },

                // Checkbox: MagicGarbage (Total Magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Magic Garbage (Total Magic)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Enabled = Removes all garbage.**\n" +
                    "Buildings never pile up garbage, trucks and facilities are for looks only.\n" +
                    "Turn this OFF if you want vanilla garbage simulation or to use the Semi-magic options."
                },

                // Checkbox: HideGarbageNotifications (Semi-magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideGarbageNotifications)),
                    "Hide garbage warning icons"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HideGarbageNotifications)),
                    "Hides the **Garbage Piling Up** warning icons above buildings.\n" +
                    "The underlying problem still exists and can be seen in an affected building info panel."
                },

                // Slider: GarbageTruckCapacityMultiplier (Semi-magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Garbage truck capacity"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Semi-MagicSuper-trucks mode**.\n" +
                    "Adjust garbage capacity as a percentage of vanilla.\n" +
                    "100% = 20 tons (vanilla game default)\n" +
                    "500% = 100 tons per truck.\n" +
                    "Bonus: unload speed scales with capacity so high capacity trucks don’t take longer to unload at the facility."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
