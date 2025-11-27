// LocalePL.cs
// Polish (pl-PL)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Opcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "O modzie" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Pełna magia" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Pół-magiczny tryb" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Informacje"        },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki"             },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UWAGI DOT. UŻYCIA" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Pełna magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [X]** natychmiast usuwa wszystkie śmieci w mieście.\n" +
                    "Budynki i pojazdy śmieciarki stają się prawie wyłącznie dekoracją.\n\n" +

                    "Gdy **Pełna magia** jest WŁĄCZONA:\n" +
                    "- Tryb pół-magiczny jest automatycznie wyłączany.\n" +
                    "- Wszystkie suwaki trybu pół-magicznego są ignorowane.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "Pół-magiczny tryb" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "Aktywuje wzmocnioną, ale wciąż normalną obsługę śmieci.\n" +
                    "- Zamiast pełnej magii używa mocniejszych ciężarówek i instalacji.\n" +
                    "- Gdy tryb pół-magiczny jest WŁĄCZONY, pełna magia zostaje wyłączona.\n" +
                    "- Suwaki poniżej działają tylko wtedy, gdy tryb pół-magiczny jest aktywny.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Ładowność ciężarówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile śmieci może przewieźć każda ciężarówka.**\n" +
                    "- 100% = standardowa ładowność.\n" +
                    "- Wyższe wartości = mniej kursów potrzebnych do sprzątnięcia miasta.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Liczba ciężarówek na instalację" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każda instalacja.**\n" +
                    "- 100% = standardowa liczba pojazdów.\n" +
                    "- Do 400% = nawet o 300% więcej ciężarówek w razie potrzeby.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Szybkość przetwarzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko instalacje przetwarzają napływające śmieci.**\n" +
                    "- 100% = standardowa szybkość.\n" +
                    "- Wyższe wartości = śmieci są szybciej spalane / recyklingowane.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Pojemność magazynowa instalacji" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile śmieci instalacja może przechować, zanim uzna się ją za przepełnioną.**\n" +
                    "- 100% = standardowa pojemność.\n" +
                    "- Wyższe wartości = więcej śmieci przed pojawieniem się komunikatu o przepełnieniu.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Wartości domyślne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Przywraca wszystkie suwaki trybu pół-magicznego do **100%** (wartości vanilla).\n" +
                    "Użyj, jeśli chcesz mieć moda włączonego, ale bez zmiany statystyk usług śmieciowych."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Stosuje zalecane wartości trybu pół-magicznego:\n" +
                    "- Ładowność ciężarówek: **200%**\n" +
                    "- Liczba ciężarówek na instalację: **150%**\n" +
                    "- Szybkość przetwarzania: **200%**\n" +
                    "- Pojemność magazynowa: **200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nazwa wyświetlana tego modu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktualna wersja modu." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Otwiera stronę Paradox Mods z modami autora."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Otwiera nawigator z serwerem Discord poświęconym modowaniu CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Zalecany stan domyślny>\n" +
                    "  * Pełna magia WŁĄCZONA = **[X]**\n" +
                    "  * Wszystkie śmieci są natychmiast usuwane\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb pół-magiczny – super ciężarówki>\n" +
                    "  * Pełna magia WYŁĄCZONA = **[ ]**\n" +
                    "  * Tryb pół-magiczny WŁĄCZONY = **[X]** i ustaw suwaki [100 >> 500] / [100 >> 400] według uznania.\n" +
                    "  * Rozgrywka w stylu vanilla, ale z mocniejszymi ciężarówkami i instalacjami.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Całkowicie vanilla>\n" +
                    "  * Pełna magia WYŁĄCZONA = **[ ]**\n" +
                    "  * Tryb pół-magiczny = **[X]** (kliknij „Wartości domyślne”)\n" +
                    "  * Wszystkie suwaki na 100% (limity vanilla)\n" +
                    "  * W pełni standardowa rozgrywka.\n"
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
