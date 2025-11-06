// Locale/LocaleDE.cs

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options -> mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Info" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Vollständige Magie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Halbmagischer Modus" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "Magischer Müll"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**Aktiviert [x]** entfernt den gesamten Müll der Stadt sofort.\n" +
                    "- Müllverbrennungsanlagen und Deponien werden nicht mehr benötigt, außer du magst sie optisch.\n\n" +

                    "<Nutze entweder diese Option **Vollständige Magie** oder die **Halbmagie** unten – nicht beide gleichzeitig.>\n" +
                    "- Es passiert nichts Schlimmes, aber du bekommst keinen zusätzlichen Effekt."
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Müllwagen-Kapazität"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Halbmagischer** Modus mit Super-Müllwagen.\n" +
                    "- Wenn du nur eine einfachere Müllverwaltung willst, ohne sie komplett abzuschalten:\n" +
                    "- Magischer Müll = **[OFF]**\n" +
                    "- Dann nutze diesen Schieberegler **[100 >> 500]**, um die Kapazität der Müllwagen zu erhöhen.\n\n" +

                    "**---------------------------------------**\n" +
                    " Der Regler stellt die Kapazität relativ zum Vanilla-Wert ein.\n" +
                    "**100 % = 20 Tonnen pro Wagen** – Standardwert\n" +
                    "**500 % = 100 Tonnen pro Wagen**\n\n" +
                    " Bonus: Die Entladegeschwindigkeit skaliert mit der Kapazität, damit die Anlagen nicht verstopfen.\n\n" +
                    "**---------------------------------------**\n\n" +
                    "Wenn du wieder komplett Vanilla spielen möchtest, stelle Magischer Müll auf [OFF] und den Regler auf 100 %."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "Mod"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Angezeigter Name dieses Mods."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "Version"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Aktuelle Mod-Version."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Paradox-Mods-Seite"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Öffnet die Magic-Garbage-Truck-Seite auf Paradox Mods."
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet den CS2-Modding-Discord im Browser."
                },
            };
        }

        public void Unload()
        {
        }
    }
}
