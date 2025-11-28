// Locale/LocalePL.cs
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
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "O modzie" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Automatyczne czyszczenie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Ręczne zarządzanie"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Informacje o modzie"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki"                   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UWAGI DOT. UŻYCIA"       },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia całkowita" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** natychmiast usuwa wszystkie śmieci w mieście.\n" +
                    "Budynki i pojazdy do wywozu śmieci stają się głównie dekoracją.\n\n" +

                    "Gdy **Magia całkowita** jest WŁĄCZONA:\n" +
                    "- Pół-magiczny tryb jest automatycznie wyłączany.\n" +
                    "- Wszystkie suwaki Pół-magii są ignorowane.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Pół-magiczny tryb" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Bezpośrednio zarządza systemami śmieci, przy zachowaniu vanilla logiki gry.\n\n" +
                    "- Gdy **Pół-magiczny tryb jest WŁĄCZONY [ ✓ ]**, Magia całkowita zostaje automatycznie wyłączona.\n" +
                    "- Możesz dostosować wszystkie śmieciarki i budynki związane ze śmieciami.\n" +
                    "- Suwaki mają efekt tylko wtedy, gdy Pół-magiczny tryb jest włączony [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Ładowność śmieciarki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ilość śmieci, jaką może przewieźć pojedyncza śmieciarka.**\n" +
                    "100% = domyślna wartość gry.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Liczba śmieciarek na obiekt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Liczba śmieciarek, które jeden obiekt może wysłać.**\n" +
                    "100% = standardowa liczba śmieciarek.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Szybkość przetwarzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Szybkość, z jaką obiekty przetwarzają napływające śmieci.**\n" +
                    "100% = standardowa szybkość przetwarzania.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Pojemność magazynowa obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ilość śmieci, jaką obiekt może przechowywać.**\n" +
                    "100% = domyślna pojemność.\n" +
                    "Wyższe wartości = obiekt może przechować więcej śmieci.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Wartości domyślne" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Przywraca wszystkie suwaki do **100%** (wartości vanilla).\n" +
                    "Przywraca normalne zachowanie gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Zastosuj zalecane wartości Pół-magii:\n" +
                    "- Ładowność śmieciarki: **200%**\n" +
                    "- Liczba śmieciarek na obiekt: **150%**\n" +
                    "- Szybkość przetwarzania: **200%**\n" +
                    "- Pojemność magazynowa: **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Wyświetlana nazwa tego moda."
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
                    "Otwiera stronę **Paradox Mods** z modami autora."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Otwiera **Discord** w przeglądarce (CS2 Modding)."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Tryb automatycznego czyszczenia>\n" +
                    "  * Magia całkowita WŁĄCZONA = **[ ✓ ]**\n" +
                    "  * Wszystkie śmieci są natychmiast usuwane\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb samodzielnego zarządzania>\n" +
                    "  * Włącz Pół-magiczny tryb = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki [100 >> 500] według uznania.\n" +
                    "  * Styl vanilla z mocniejszymi i regulowanymi pojazdami i obiektami.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normalna gra vanilla>\n" +
                    "  * Pół-magiczny tryb = **[ ✓ ]**\n" +
                    "  * Kliknij **[Wartości domyślne]**\n" +
                    "  * Wszystkie suwaki na 100% (vanilla)\n" +
                    "  * Standardowa rozgrywka.\n"
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
