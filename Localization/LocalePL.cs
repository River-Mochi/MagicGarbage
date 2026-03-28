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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Zarządzanie ręczne" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UŻYCIE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n\n" +
                    "Gdy **Total Magic** jest ON:\n" +
                    "- Trash Boss jest wymuszony na OFF.\n" +
                    "- Suwaki Trash Boss nie są stosowane (wartości zostają zapisane na później).\n" +
                    "- Kilka ciężarówek może nadal się poruszać z powodu timingu dispatchu vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Bezpośrednio zarządza systemami śmieci; logika vanilla nadal działa.\n\n" +
                    "- Gdy **Trash Boss jest ON [ ✓ ]**, Total Magic jest wymuszony na OFF.\n" +
                    "- Suwaki działają tylko, gdy Trash Boss jest włączony.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile śmieci może przewieźć każda ciężarówka.**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Magazyn obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile śmieci może przechować obiekt.**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Szybkość przetwarzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają napływające śmieci.**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Progi budynków" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Opcjonalne: podnosi **progi**, które budynek musi osiągnąć, aby dostać odbiór śmieci. \n" +
                    "Zwiększenie tego może pomóc zmniejszyć ruch śmieciarek; ale zbyt wysoka wartość ograniczy kursy odbioru.\n" +
                    "Większość osób <nie> musi tego ruszać. Mod działał dobrze, zanim dodano tę opcję; to tylko bonus do eksperymentów.\n"+
                    "--------------------------------\n" +
                    "- **Próg żądania dispatchu (R)** = ilość śmieci w budynku potrzebna, by wywołać <żądanie wysłania ciężarówki>.\n" +
                    "- **Próg odbioru (P)** = minimalna ilość śmieci, zanim ciężarówka może je odebrać.\n" +
                    "**1x** = vanilla (100 R, 20 P). Uwaga: **1 000** jednostek śmieci to zwykle **1t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Przy suwaku **20x** wartość **R** budynku musi osiągnąć >= **2 000 (2t)** jednostek, zanim ciężarówka dostanie <żądanie dispatchu>;\n" +
                    "Gra vanilla pozwala też ciężarówkom zatrzymywać się przy budynkach w drodze do/z budynku <dispatch>, jeśli ciężarówka nie jest pusta; przy 20x budynki na trasie muszą mieć ponad **400 śmieci** (20 x vanilla P = 20).\n" +
                    "Rada balansu: często sprawdzaj przycisk szczegółowego raportu w logu podczas regulacji.\n" +
                    "Może być potrzebne zwiększenie pojemności ciężarówek, jeśli mocno podniesiesz próg, bo domy będą trzymać śmieci dużo dłużej, zanim wezwą ciężarówkę."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Zastosuj zalecane wartości Trash Boss:\n" +
                    "- Ładowność ciężarówek: **200%**\n" +
                    "- Próg dispatchu: **5x**\n" +
                    "- Szybkość przetwarzania: **200%**\n" +
                    "- Pojemność magazynu: **150%**\n" +
                    "- Liczba ciężarówek obiektu: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Przywraca wszystkie suwaki Trash Boss do wartości vanilla.\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Próg dispatchu wraca do **1x**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Wyświetlana nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Otwórz stronę Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Otwórz zaproszenie Discord w przeglądarce." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stan Auto Clean>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Śmieci są usuwane automatycznie - Gotowe.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Stan zarządzania ręcznego>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki według uznania.\n" +
                    "  * Te same śmieci w grze; lepsze samodzielnie zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normalna gra vanilla>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Wszystkie suwaki na wartościach vanilla\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Śmieci/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje aktualną ilość śmieci w całym mieście i całkowite tempo przetwarzania.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięcznie produkowane śmieci są znacznie wyższe.\n" +
                    "**Produced** i **Processed** używają ton na miesiąc.\n" +
                    "<Czas aktualizacji = ostatnie odświeżenie.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Żądania odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = aktywne żądania odbioru, które obecnie nie są przypisane do ciężarówki ani trasy.\n" +
                    "**Dispatched** = aktywne żądania odbioru już przypisane.\n" +
                    "**Total** = liczy bieżące **aktywne** encje żądań (w pipeline śmieci).\n\n" +
                    "Uwaga techniczna: to co innego niż <Powyżej progu żądania>. Tutaj liczone są <żądania>, a nie budynki.\n" +
                    "Część żądań Pending zostanie przypisana później; część może też później zniknąć, jeśli vanilla po ponownej weryfikacji uzna, że cel nie potrzebuje już obsługi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ma śmieci** = budynki, które obecnie mają śmieci.\n" +
                    "**Total** = wszystkie budynki produkujące śmieci w mieście.\n" +
                    "**Powyżej progu żądania** = bieżąca liczba **budynków** z wystarczającą ilością śmieci, aby utworzyć żądanie odbioru.\n" +
                    "W vanilla próg żądania to **100** wewnętrznych jednostek śmieci.\n" +
                    "**Próg dispatchu** Trash Boss podnosi razem próg odbioru i próg żądania.\n" +
                    "To zmniejsza ruch śmieciarek, bo obniża liczbę budynków <powyżej progu żądania> i sumę <dispatched>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie policzonych obiektów śmieciowych.\n" +
                    "**Facilities** = policzone budynki śmieciowe.\n" +
                    "**Trucks total** = śmieciarki należące do tych obiektów.\n" +
                    "**Max workers** = łączna maksymalna liczba pracowników tych samych obiektów."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = ciężarówki aktualnie w mieście.\n" +
                    "**Returning** = podzbiór jadących ciężarówek oznaczonych do powrotu do obiektu.\n" +
                    "**Parked** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Total** = liczba wszystkich śmieciarek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wysyła bardziej szczegółowy raport o śmieciach do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera krótką legendę, wartości referencyjne vanilla i dużo dodatkowych statystyk o aktualnych śmieciach w mieście."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwórz folder gry Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Żadne miasto nie jest jeszcze wczytane." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t wyprodukowane | {1:N0} t przetworzone | aktualizacja {2}" },
                { "MG.Status.Row.Requests", "{1:N0} oczekujące | {2:N0} przydzielone | {0:N0} łącznie" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma śmieci | {2:N0} powyżej progu zgłoszenia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiekty | {1:N0} ciężarówek łącznie | max pracowników {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} w ruchu ({3:N0} wraca) | {2:N0} zaparkowane | {0:N0} łącznie" },
                { "MG.Status.Row.FacilitiesNone", "Brak danych o obiektach." },

                // Log strings
                { "MG.Status.Log.Title", "Stan śmieci ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Wyprodukowane/Przetworzone używa ton na miesiąc.\n" +
                    "- Poniższe wartości progowe używają wewnętrznych jednostek śmieci, a nie ton.\n" +
                    "- Dla gracza gra przelicza 1 000 jednostek = 1t.\n" +
                    "Suwak progu wysłania:\n" +
                    "  - Próg odbioru = minimalna ilość śmieci, zanim ciężarówka odbierze je z budynku.\n" +
                    "  - Próg zgłoszenia = minimalna ilość śmieci, zanim gra utworzy lub utrzyma zgłoszenie odbioru.\n" +
                    "- Ikona ostrzeżenia = ilość śmieci, która powoduje pojawienie się ikony ostrzeżenia nad budynkiem.\n" +
                    "- Twardy limit = maksymalna ilość śmieci, jaką budynek może zgromadzić.\n" +
                    "- Oczekujące = aktywne zgłoszenia, które obecnie nie są przypisane do ciężarówki ani trasy.\n" +
                    "- Część oczekujących zgłoszeń zostanie przypisana później; część może też zniknąć później, jeśli vanilla podczas ponownej walidacji uzna, że cel nie potrzebuje już usługi.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Progi gry (wewnętrzne jednostki śmieci): odbiór={1:N0}, zgłoszenie={0:N0}, ikona ostrzeżenia={2:N0}, twardy limit={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.GarbageProcessing", "Śmieci: {0:N0} t/mies. | Przetwarzanie: {1:N0} t/mies." },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: oczekujące={1:N0}, przydzielone={2:N0}, łącznie={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Największy oczekujący cel śmieci: {0:N0} ({1:N1}t) przy {2}" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} łącznie | {1:N0} ma śmieci | {2:N0} powyżej progu zgłoszenia | {3:N0} na poziomie ostrzeżenia" },
                { "MG.Status.Log.ProducerGarbageStats", "Śmieci w budynkach (tylko >0): średnia={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) przy {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko ostrzeżenia (>= {1:N0} jednostek / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} łącznie | {1:N0} ciężarówek łącznie | max pracowników {2:N0}" },
                { "MG.Status.Log.Trucks", "Śmieciarki: {2:N0} w ruchu ({3:N0} wraca) | {1:N0} zaparkowane | {4:N0} wyłączone | {0:N0} łącznie" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: w ruchu={2:N0}, zaparkowane={3:N0}, łącznie={1:N0}, max pracowników={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
