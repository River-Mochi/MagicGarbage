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

                // Tab
                { m_Setting.GetOptionTabLocaleID(Setting.MainTab), "Main" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Total Magic" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Semi-magic (Trucks)" },

                // Checkbox: MagicGarbage (Total Magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Magic Garbage (total)"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "Completely removes garbage gameplay.\n" +
                    "Buildings never pile up garbage, trucks and facilities are for looks only.\n" +
                    "Turn this OFF if you want the vanilla garbage simulation."
                },

                // Checkbox: HideGarbageNotifications (Semi-magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.HideGarbageNotifications)),
                    "Hide garbage problem icons"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.HideGarbageNotifications)),
                    "When Magic Garbage is OFF, hide the vanilla garbage warning icons.\n" +
                    "Turn this OFF to see the standard garbage problem notifications."
                },

                // Slider: GarbageTruckCapacityMultiplier (Semi-magic)
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Garbage truck capacity"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Super-trucks mode. Adjust garbage capacity as a percentage of vanilla.\n" +
                    "100% = vanilla (~20 tons). 500% ≈ ~100 tons per truck.\n" +
                    "Unload speed scales with capacity so they don’t clog the depot."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
