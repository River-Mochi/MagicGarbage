// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocalePL.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto sprzątanie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Zarządzaj samodzielnie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Informacje o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UŻYCIE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n" +
                    "\n" +
                    "Gdy **Total Magic** jest WŁĄCZONE:\n" +
                    "- Trash Boss jest wymuszony na WYŁ.\n" +
                    "- Suwaki Trash Boss nie są stosowane (wartości są zapisywane na później).\n" +
                    "- Kilka ciężarówek może nadal jeździć z powodu timingu waniliowej logiki wysyłania."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Bezpośrednio zarządza systemami odpadów, pozostawiając włączoną waniliową logikę odpadów.\n" +
                    "\n" +
                    "- Gdy **Trash Boss jest WŁĄCZONY [ ✓ ]**, Total Magic jest wymuszony na WYŁ.\n" +
                    "- Suwaki działają tylko wtedy, gdy Trash Boss jest włączony.\n" +
                    "- Total Magic i Trash Boss mogą być jednocześnie **WYŁĄCZONE**, aby korzystać z ustawień waniliowych,\n" +
                    "  a nadal możesz oglądać **raport stanu**, który aktualizuje się tylko po wejściu do menu Opcje (lekki)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile odpadów może przewieźć każda ciężarówka.**\n" +
                    "**100% = waniliowa** pojemność ciężarówki (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Pojemność magazynowa obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile odpadów może przechować obiekt.**\n" +
                    "**100% = waniliowa** pojemność magazynowa.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Szybkość przetwarzania obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają przychodzące odpady.**\n" +
                    "**100% = waniliowa** szybkość przetwarzania.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "**100% = waniliowa** liczba ciężarówek.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Rezerwa dla celu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Określa, jak wcześnie ciężarówki zaczynają wybiórczo traktować opcjonalne odbiory w drodze do przypisanego budynku.**\n" +
                    "**10% to wartość waniliowa w wersji 1.6.2.**\n" +
                    "Dla zwykłej ciężarówki 20t:\n" +
                    "- 10% zaczyna chronić przypisany przystanek 2t wcześniej.\n" +
                    "- 15% zaczyna 3t wcześniej.\n" +
                    "- 25% zaczyna 5t wcześniej.\n" +
                    "Wyższe wartości dają większy margines bezpieczeństwa. Ciężarówki wcześniej pomijają małe odbiory, zostawiając więcej miejsca dla przypisanego budynku."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Stosuje zrównoważone wartości dla ruchliwych miast.\n" +
                    "Ładunek ciężarówki **200%** | magazyn **150%** | przetwarzanie **250%**\n" +
                    "Flota **100%** | rezerwa dla celu **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Resetuj suwaki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Resetuje standardowe suwaki Trash Boss.\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Rezerwa dla celu wraca do **waniliowych 10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Wyświetlana nazwa tego moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktualna wersja moda." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Otwórz stronę Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Otwórz zaproszenie Discord w przeglądarce." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stan Auto sprzątanie>\n" +
                    "  * Total Magic WŁ. = **[ ✓ ]**\n" +
                    "  * Odpady są usuwane automatycznie - gotowe.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stan Zarządzaj samodzielnie>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki według potrzeb.\n" +
                    "  * Te same odpady w grze; lepiej samodzielnie zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stan Status / wanilia>\n" +
                    "  * Total Magic = WYŁ.\n" +
                    "  * Trash Boss = WYŁ.\n" +
                    "  * Tylko raport stanu.\n" +
                    "  * Waniliowy system odpadów pozostaje bez zmian."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Ocena usług odbioru odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Średni dla całego miasta wpływ odpadów na zadowolenie według gry.\n" +
                    "Dobra ocena ogólna może nadal obejmować kilka problematycznych budynków, dlatego sprawdź też **budynki 7t+**.\n" +
                    "**0 = Ogólnie doskonale**\n" +
                    "**-1 = Wymaga drobnej korekty**\n" +
                    "**-2 do -4 = Trochę śmierdzi**\n" +
                    "**-5 lub mniej = Problem z odpadami**\n" +
                    "\n" +
                    "Popraw usługę suwakami ciężarówek i obiektów, a potem pozwól miastu działać przez chwilę przed ponownym sprawdzeniem."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Budynki 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Liczba budynków produkujących odpady z co najmniej **7000 / 7t**.\n" +
                    "Ten stały wskaźnik wczesnego ostrzegania pomaga zdecydować, czy zwiększyć poziom usług, zanim budynki osiągną poziom ikony ostrzeżenia w grze.\n" +
                    "Użyj Szczegółowego statusu do logu, aby wyświetlić ich identyfikatory Entity."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Odpady/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje produkcję odpadów w całym mieście, bieżące przetwarzanie i dostępną zdolność przetwarzania obiektów.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięczna produkcja jest wyższa niż zdolność.\n" +
                    "Wszystkie wartości są w tonach na miesiąc."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Żądania odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Oczekujące** = aktywne żądania odbioru, które obecnie nie są przypisane do ciężarówki ani trasy.\n" +
                    "**Wysłane** = aktywne żądania odbioru, które już przypisano.\n" +
                    "**Łącznie** = wszystkie obecne **aktywne** żądania w potoku odpadów.\n" +
                    "\n" +
                    "To różni się od **Powyżej progu żądania**, gdzie liczone są budynki, a nie żądania.\n" +
                    "Niektóre oczekujące żądania zostaną przypisane później; inne mogą też później zniknąć, jeśli waniliowa ponowna walidacja uzna, że cel nie potrzebuje już obsługi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ma odpady** = budynki, które obecnie zawierają jakiekolwiek odpady.\n" +
                    "**Łącznie** = wszystkie budynki produkujące odpady w mieście.\n" +
                    "**Powyżej progu żądania** = bieżąca liczba **budynków** z wystarczającą ilością odpadów, aby utworzyć żądanie odbioru.\n" +
                    "Szczegółowy status w logu pokazuje aktualny aktywny próg żądania gry.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie zliczonych obiektów odpadów.\n" +
                    "**Obiekty** = zliczone budynki związane z odpadami.\n" +
                    "**Śmieciarki** = zwykłe ciężarówki odbierające odpady. W obiektach odpadów przemysłowych odbierają odpady przemysłowe zamiast zwykłych odpadów.\n" +
                    "**Wywrotki** = transfery odpadów między obiektami.\n" +
                    "**Maks. pracowników** = łączna pojemność pracowników w tych samych obiektach."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Śmieciarki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**W ruchu** = ciężarówki obecnie jeżdżące po mieście.\n" +
                    "**Wracające** = część jadących ciężarówek oznaczonych do powrotu do obiektu.\n" +
                    "**Zaparkowane** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Łącznie** = liczba wszystkich śmieciarek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wysyła bardziej szczegółowy raport o odpadach do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera uporządkowane statystyki odpadów w mieście."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwiera **MagicGarbage.log**. Jeśli pliku brakuje lub nie można go otworzyć, zamiast tego otwiera folder Logs gry." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie wczytano jeszcze miasta." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Ogólnie doskonale ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Wymaga drobnej korekty ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Trochę śmierdzi ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problem z odpadami ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} budynków 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produkcji | {2:N0} t przetwarzania | {1:N0} t zdolności" },
                { "MG.Status.Row.Requests", "{1:N0} oczekujących | {2:N0} wysłanych | {0:N0} łącznie" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma odpady | {2:N0} powyżej progu żądania" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiektów | {1:N0}/{2:N0} śmieciarki/wywrotki | {3:N0} pracowników" },
                { "MG.Status.Row.Trucks", "{1:N0} w ruchu ({3:N0} wracających) | {2:N0} zaparkowanych | {0:N0} łącznie" },
                { "MG.Status.Row.FacilitiesNone", "Brak jeszcze danych obiektów." },

                // Log strings
                { "MG.Status.Log.Title", "Stan odpadów ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Bieżące ustawienia moda" },
                { "MG.Status.Log.SettingsTrashBoss", "Suwaki Trash Boss (zapisane): ładunek ciężarówki={0:N0}% | magazyn obiektu={1:N0}% | przetwarzanie obiektu={2:N0}% | flota obiektu={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produkcja, bieżące przetwarzanie i zdolność używają ton na miesiąc.\n" +
                    "- Poniższe wartości progów używają wewnętrznych jednostek odpadów, a nie ton.\n" +
                    "- Na potrzeby wyświetlania graczowi gra przelicza 100 jednostek = 0.1t i 1,000 jednostek = 1t.\n" +
                    "- Ocena usług odbioru odpadów = współczynnik zadowolenia miasta związanego z odpadami w grze.\n" +
                    "  - 0 = Ogólnie doskonale\n" +
                    "  - -1 = Wymaga drobnej korekty\n" +
                    "  - -2 do -4 = Trochę śmierdzi\n" +
                    "  - -5 do -10 = Problem z odpadami\n" +
                    "Wartości trasowania:\n" +
                    "  - Próg odbioru to waniliowe minimum; trasowanie uwzględniające cel może zwiększać go osobno dla każdej ciężarówki, aby chronić pojemność dla jej miejsca docelowego.\n" +
                    "  - Próg żądania to minimalna ilość odpadów, zanim gra utworzy lub zachowa żądanie odbioru.\n" +
                    "- Ikona ostrzeżenia pojawia się, gdy odpady budynku przekroczą aktualny poziom ostrzegawczy.\n" +
                    "- Twardy limit = maksymalna ilość odpadów, jaką może zgromadzić budynek.\n" +
                    "- Oczekujące = aktywne żądania, które obecnie nie są przypisane do ciężarówki ani trasy.\n" +
                    "- Niektóre oczekujące żądania zostaną przypisane później; inne mogą też później zniknąć, jeśli waniliowa ponowna walidacja uzna, że cel nie potrzebuje już obsługi.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Progi gry (wewnętrzne jednostki odpadów): odbiór={1:N0}, żądanie={0:N0}, ikona ostrzeżenia={2:N0}, twardy limit={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.AdaptiveMargin", "Rezerwa dla celu: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Rezerwa dla celu: bieżąca={0:N0}% | wartość bazowa gry przy wczytaniu={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Produkcja odpadów: {0:N0} t/mies. | Bieżące przetwarzanie: {2:N0} t/mies. | Zdolność przetwarzania: {1:N0} t/mies." },
                { "MG.Status.Log.GarbageServiceRating", "Ocena usług odbioru odpadów: {0} | surowa={1:N2} | zaokrąglona={2:N0}" },
                { "MG.Status.Log.Requests", "Żądania odbioru: oczekujące={1:N0}, wysłane={2:N0}, łącznie={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Największa ilość odpadów w oczekującym celu: {0:N0} ({1:N1}t) przy {2}" },
                { "MG.Status.Log.PendingPeakNone", "Największa ilość odpadów w oczekującym celu: brak" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} powyżej poziomu ostrzegawczego | {1:N0} łącznie | {2:N0} ma odpady | {3:N0} powyżej progu żądania" },
                { "MG.Status.Log.ProducerGarbageStats", "Odpady w budynkach (tylko wartości niezerowe): śr={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | maks={4:N0} ({5:N1}t) przy {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko ikony ostrzeżenia (co najmniej {1:N0} jednostek / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} łącznie | {1:N0} śmieciarek | {2:N0} wywrotek ({3:N0} w ruchu) | {4:N0} pracowników" },
                { "MG.Status.Log.Trucks", "Śmieciarki: {2:N0} w ruchu ({3:N0} wracających) | {1:N0} zaparkowanych | {4:N0} wyłączonych | {0:N0} łącznie" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: śmieciarki={1:N0} ({2:N0} w ruchu, {3:N0} zaparkowane) | wywrotki={4:N0} ({5:N0} w ruchu) | maks. pracowników={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Ogólnie doskonale" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Wymaga drobnej korekty" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Trochę śmierdzi" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problem z odpadami" },

                { "MG.Status.Log.ThresholdsHeader", "Progi + usługi" },
                { "MG.Status.Log.RequestsHeader", "Żądania" },
                { "MG.Status.Log.BuildingsHeader", "Budynki" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Budynki 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Sonda lokalnego transferu odpadów" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nie znaleziono lokalnych obiektów odpadów." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda transferu odpadów przez połączenia zewnętrzne" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nie znaleziono obiektów odpadów dla połączeń zewnętrznych." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda transferu odpadów" },
                { "MG.Status.Log.TransferProbeNone", "Nie znaleziono obiektów magazynowania-transferu odpadów." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | składowane={1,7:N0} ({2,4:N1}t) / poj={3,7:N0} ({4,4:N1}t) | przyjmij={5:N2} | wyślij={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Ciężarówki" },

                { "MG.Status.Log.CriticalBuildingsNone", "brak" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
