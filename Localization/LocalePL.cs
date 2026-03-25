// File: Locale/LocalePL.cs
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
            string title = Mod.ModName;
            if (!string.IsNullOrEmpty(Mod.ModVersion))
            {
                title = title + " (" + Mod.ModVersion + ")";
            }

            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), title },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Akcje" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Informacje" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto czyszczenie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Ręczne zarządzanie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Informacje o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTATKI UŻYCIA" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n\n" +
                    "Gdy **Total Magic** jest ON:\n" +
                    "- Trash Boss jest wymuszony na OFF.\n" +
                    "- Suwaki Trash Boss nie są stosowane (wartości pozostają zapisane).\n" +
                    "- Niektóre ciężarówki mogą nadal się poruszać z powodu timingu logiki dispatchu vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Pozwala bezpośrednio sterować systemem odpadów, zostawiając logikę vanilla aktywną.\n\n" +
                    "- Gdy **Trash Boss jest ON [ ✓ ]**, Total Magic jest wymuszony na OFF.\n" +
                    "- Suwaki działają tylko, gdy Trash Boss jest włączony.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile odpadów może przewieźć każda ciężarówka.**\n" +
                    "100% = normalna wartość gry.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Prędkość przetwarzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają napływające odpady.**\n" +
                    "100% = prędkość vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Pojemność magazynu obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile odpadów może magazynować obiekt.**\n" +
                    "100% = magazynowanie vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "100% = liczba ciężarówek vanilla.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Polecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Ustawia polecane wartości Trash Boss:\n" +
                    "- Ładowność ciężarówek: **200%**\n" +
                    "- Prędkość przetwarzania: **200%**\n" +
                    "- Pojemność magazynu: **160%**\n" +
                    "- Liczba ciężarówek obiektu: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Wartości gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Przywraca wszystkie suwaki do **100%** (wartości vanilla)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Wyświetlana nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Otwiera stronę Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Otwiera zaproszenie Discord w przeglądarce." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Tryb auto czyszczenia>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Odpady są usuwane automatycznie\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb ręcznego zarządzania>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki jak chcesz.\n" +
                    "  * Logika odpadów vanilla z lepszym zarządzaniem ciężarówkami/obiektami.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normalna gra vanilla>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Kliknij **[Wartości gry]**\n" +
                    "  * Wszystkie suwaki na 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Odpady/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje aktualną ilość odpadów w całym mieście i łączną szybkość przetwarzania.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięczne Produced jest dużo wyższe.\n" +
                    "**Produced** i **Processed** używają ton na miesiąc.\n" +
                    "Czas aktualizacji = ostatnie odświeżenie."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Zgłoszenia odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = aktywne zgłoszenia odbioru, które nie mają jeszcze przypisanego pojazdu lub trasy.\n" +
                    "**Dispatched** = aktywne zgłoszenia odbioru już przypisane.\n" +
                    "**Total** = wszystkie aktywne zgłoszenia odbioru odpadów.\n" +
                    "Ta liczba może chwilowo być wyższa niż **Above request threshold**, bo stare zgłoszenia są czyszczone później przez rewalidację gry."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = budynki, które obecnie mają odpady.\n" +
                    "**Total** = wszystkie budynki produkujące odpady w mieście.\n" +
                    "**Above request threshold** = budynki z ilością odpadów wystarczającą do utworzenia zgłoszenia odbioru.\n" +
                    "W vanilla zwykle oznacza to więcej niż <100> jednostek odpadów."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie liczonych obiektów odpadów.\n" +
                    "**Facilities** = liczba policzonych obiektów odpadów.\n" +
                    "**Trucks total** = wszystkie śmieciarki należące do tych obiektów.\n" +
                    "**Max workers** = łączna maksymalna pojemność pracowników tych samych obiektów."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = ciężarówki aktualnie jeżdżące po mieście.\n" +
                    "**Returning** = część Moving, która wraca do obiektu.\n" +
                    "**Parked** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Total** = całkowita liczba śmieciarek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Zapisuje bardziej szczegółowy raport o odpadach do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera krótką legendę, bieżące progi, wyłączone ciężarówki i maksymalną liczbę pracowników dla każdego obiektu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwiera folder Logs/."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie wczytano jeszcze miasta." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t wyprodukowano | {1:N0} t przetworzono | aktualizacja {2}" },
                { "MG.Status.Row.Requests", "{1:N0} oczekujące | {2:N0} przydzielone | razem {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma odpady | {2:N0} powyżej progu zgłoszenia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiektów | razem ciężarówek {1:N0} | max pracowników {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} w ruchu ({3:N0} wraca) | {2:N0} zaparkowane | razem {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "Brak danych o obiektach." },

                // Log strings
                { "MG.Status.Log.Title", "Status odpadów ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed używa ton na miesiąc.\n" +
                    "- Wartości progów poniżej używają wewnętrznych jednostek odpadów, nie ton.\n" +
                    "- Próg odbioru = minimalna ilość odpadów, przy której ciężarówka odbierze z budynku.\n" +
                    "- Próg zgłoszenia = minimalna ilość odpadów, przy której gra tworzy lub utrzymuje zgłoszenie odbioru.\n" +
                    "- Próg ostrzeżenia = ilość odpadów, przy której nad budynkiem może pojawić się ikona ostrzeżenia.\n" +
                    "- Górny limit = maksymalna ilość odpadów, jaką budynek może zgromadzić.\n" +
                    "- Wraca = część ruchu.\n" +
                    "- Liczba aktywnych zgłoszeń może chwilowo być większa niż liczba budynków powyżej progu, ponieważ stare zgłoszenia są czyszczone później przez rewalidację vanilla.\n" +
                    "- Liczby pracowników poniżej pokazują obecnie **maksymalnych pracowników** dla każdego obiektu."
                },
                { "MG.Status.Log.Thresholds",
                    "Progi (wewnętrzne jednostki odpadów): odbiór={1:N0}, zgłoszenie={0:N0}, ostrzeżenie={2:N0}, górny limit={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.GarbageProcessing", "Odpady: {0:N0} t/mies. | Przetwarzanie: {1:N0} t/mies." },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: oczekujące={1:N0}, przydzielone={2:N0}, razem={0:N0}" },
                { "MG.Status.Log.Producers", "Budynki: razem={0:N0} | ma odpady={1:N0} | powyżej progu zgłoszenia={2:N0} | poziom ostrzeżenia={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: razem={0:N0} | razem ciężarówek={1:N0} | max pracowników={2:N0}" },
                { "MG.Status.Log.Trucks", "Śmieciarki: w ruchu={2:N0} ({3:N0} wraca) | zaparkowane={1:N0} | wyłączone={4:N0} | razem={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: w ruchu={2:N0}, zaparkowane={3:N0}, razem={1:N0}, max pracowników={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
