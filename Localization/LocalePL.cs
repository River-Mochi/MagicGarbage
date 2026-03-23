// File: Localization/LocalePL.cs
// Polish (pl-PL)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocalePL : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePL(Setting setting)
        {
            m_Setting = setting;
        }

        public IEnumerable<KeyValuePair<string, string>> ReadEntries(
            IList<IDictionaryEntryError> errors,
            Dictionary<string, int> indexCounts)
        {
            return new Dictionary<string, string>
            {
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "O modzie" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto czyszczenie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Ręczne sterowanie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTATKI" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** natychmiast usuwa wszystkie śmieci w mieście.\n\n" +

                    "Gdy **Total Magic** jest WŁĄCZONE:\n" +
                    "- Semi-Magic jest wymuszane na OFF.\n" +
                    "- Suwaki Semi-Magic **nie są stosowane** (Twoje wartości są zapisane na później).\n" +
                    "- Kilka ciężarówek może nadal jeździć przez logikę dispatch w grze (zwykle puste)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Ręcznie zarządzaj systemem śmieci; logika vanilla dalej działa.\n\n" +
                    "- Gdy **Semi-Magic jest WŁĄCZONE [ ✓ ]**, Total Magic wyłącza się automatycznie.\n" +
                    "- Suwaki działają tylko, gdy Semi-Magic jest włączone [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Pojemność ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile śmieci może przewieźć jedna ciężarówka.**\n" +
                    "100% = domyślne wartości gry.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Szybkość przetwarzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają śmieci.**\n" +
                    "100% = prędkość vanilla.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Pojemność magazynu obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile śmieci może przechować obiekt.**\n" +
                    "100% = pojemność vanilla.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Liczba ciężarówek w obiekcie"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać obiekt.**\n" +
                    "100% = liczba vanilla.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Polecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Zastosuj polecane wartości Semi-Magic:\n" +
                    "- Pojemność ciężarówki: **200%**\n" +
                    "- Szybkość przetwarzania: **200%**\n" +
                    "- Pojemność magazynu: **160%**\n" +
                    "- Liczba ciężarówek w obiekcie: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Wartości gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Ustaw wszystkie suwaki na **100%** (wartości vanilla).\n" +
                    "Przywraca normalne działanie gry."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nazwa wyświetlana tej modyfikacji."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Aktualna wersja moda."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Otwórz stronę autora na **Paradox Mods**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Otwórz **Discord** w przeglądarce (CS2 Modding)."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stan: Auto czyszczenie>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * Wszystkie śmieci są usuwane natychmiast\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stan: Ręczne sterowanie>\n" +
                    "  * Semi-Magic ON = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki jak chcesz.\n" +
                    "  * Logika vanilla + lepiej zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normalna gra vanilla>\n" +
                    "  * Semi-Magic ON = **[ ✓ ]**\n" +
                    "  * Kliknij **[Wartości gry]**\n" +
                    "  * Wszystkie suwaki na 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)),
                    string.Empty
                },
            };
        }

        public void Unload()
        {
        }
    }
}
