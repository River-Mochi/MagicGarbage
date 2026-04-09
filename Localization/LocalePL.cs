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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "O modzie" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto czyszczenie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Ręczne zarządzanie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Ekspert" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UŻYCIE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totalna magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n\n" +
                    "Gdy **Totalna magia** jest ON:\n" +
                    "- Sterowanie odpadami jest wymuszone na OFF.\n" +
                    "- Suwaki Sterowania odpadami nie są stosowane (wartości zostają zapisane na później).\n" +
                    "- Kilka ciężarówek może nadal jeździć przez timing logiki vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Sterowanie odpadami" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Bezpośrednio zarządza systemami odpadów; logika garbage vanilla nadal działa.\n\n" +
                    "- Gdy **Sterowanie odpadami jest ON [ ✓ ]**, Totalna magia jest wymuszona na OFF.\n" +
                    "- Suwaki działają tylko wtedy, gdy Sterowanie odpadami jest włączone.\n" +
                    "- Zarówno Totalna magia, jak i Sterowanie odpadami mogą być **OFF**, jeśli potrzebny jest tylko **raport statusu**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile odpadów może zabrać każda ciężarówka.**\n" +
                    "**100% = normalna** domyślna wartość gry.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Magazyn obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile odpadów może przechować obiekt.**\n" +
                    "**100% = magazyn vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Szybkość przetwarzania obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają napływające odpady.**\n" +
                    "**100% = szybkość przetwarzania vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "**100% = vanilla** liczba ciężarówek.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Zastosuj standardowe **zalecane** wartości Sterowania odpadami.\n" +
                    "Nie zmienia ustawień Eksperta (osobne)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Przywróć suwaki Sterowania odpadami do **wartości vanilla**.\n" +
                    "<Nie> zmienia ustawień Eksperta.\n" +
                    "**Vanilla:**\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Dispatch Request Threshold wraca do **100 units**.\n" +
                    "- Pickup Threshold wraca do **20 units**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opcje eksperta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Opcjonalne ustawienia zaawansowane\n" +
                    "<Ostrzeżenie: NIE są potrzebne> do dobrej obsługi; są dla graczy, którzy chcą eksperymentować albo lepiej rozumieć działanie systemów.\n" +
                    "Gdy **OFF**, wszystkie ustawienia Eksperta **zostają vanilla**.\n" +
                    "Gdy **ON**, pojawiają się **zaawansowane suwaki**.\n\n" +
                    "<--- Przykłady zadowolenia --->\n" +
                    " - <Vanilla> 100/65 = 1. kara przy <165>.\n" +
                    " - Kliknij <Zalecane>, aby ustawić 550/150 = 1. kara przy <700>.\n" +
                    " - <Bardzo łagodne> 950/200 = 1. kara za odpady przy <1150>.\n" +
                    "Wygoda: ostatnie wartości suwaków są zapisywane, gdy ta opcja jest OFF (na wypadek późniejszego włączenia)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Ilość odpadów w budynku potrzebna do utworzenia lub utrzymania zgłoszenia wysłania ciężarówki.**\n" +
                    "Vanilla = **100** units garbage.\n" +
                    "**100 units garbage = 0.1t**\n" +
                    "**1,000 units garbage = 1t**\n" +
                    "Trzymaj tę wartość na poziomie lub powyżej Pickup Threshold.\n" +
                    "Zwykle zwiększa to liczbę używanych ciężarówek zamiast zaparkowanych."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimalna ilość odpadów w budynku, zanim ciężarówka będzie mogła je odebrać.**\n" +
                    "Vanilla = **20** units garbage.\n" +
                    "Suwak odbioru <nie może> być wyższy niż Dispatch Request (DR); jest ograniczany, żeby uniknąć problemów logiki.\n" +
                    "Jeśli ciężarówka zostanie wysłana do budynku, a wartość odbioru jest wyższa niż DR, czasem może nie dać rady odebrać odpadów z budynku (wpływa na to także tempo akumulacji).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Bazowy próg zadowolenia z odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Poziom odpadów w budynku, od którego zaczyna się kara do zdrowia + zadowolenia.**\n" +
                    "**Vanilla = 100** units garbage.\n" +
                    "Wyższa baza = budynki mogą trzymać więcej odpadów, zanim zacznie się kara.\n" +
                    "100 units garbage = 0.1t\n" +
                    "Przegląd:\n" +
                    "- <Threshold> = punkt wyzwalający zachowanie systemu\n" +
                    "- <Baseline> = punkt startowy wzoru kary\n" +
                    "- <Step> = wielkość kroku we wzorze, czyli jak szybko kara rośnie po starcie"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Krok zadowolenia z odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Dodatkowa ilość odpadów ponad bazę, która uruchamia karę -1.**\n" +
                    "Vanilla = **65** units garbage.\n" +
                    "Wyższy krok = wolniejszy wzrost kary.\n" +
                    "Gra ogranicza karę za odpady do **-10**.\n" +
                    "Pierwsza kara vanilla <-1 penalty> pojawia się przy **165 garbage** (100 base + 65 step)\n" +
                    "Zmieniaj progi ostrożnie razem z suwakami zadowolenia, inaczej kary mogą być mocniejsze niż normalnie."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tempo gromadzenia odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaluje wspierane wartości źródła odpadów w budynkach.**\n" +
                    "To mocna dźwignia i zmiana tej wartości wpływa na wiele rzeczy.\n" +
                    "Da się zbudować dobry system bez jej używania.\n\n" +
                    "**100% = gromadzenie vanilla**.\n" +
                    "**20%** = znacznie wolniejsze narastanie.\n" +
                    "**200%** = podwójne tempo - naprawdę dużo odpadów.\n" +
                    "Przy 20% wszyscy Cims najwyraźniej kompostują, więc odpadów przybywa mniej ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Zastosuj **zalecane** wartości Eksperta.\n" +
                    "Włącza Eksperta.\n" +
                    "Pierwsza kara za odpady zaczyna się przy **700** garbage (550 baseline + 150 step).\n" +
                    "Tempo gromadzenia odpadów zostaje na **100%** vanilla, chyba że zmienisz je ręcznie."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Przywróć wartości Eksperta **do vanilla**.\n" +
                    "Przełącza **Eksperta na OFF**.\n"
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
                    "<Tryb auto czyszczenia>\n" +
                    "  * Totalna magia ON = **[ ✓ ]**\n" +
                    "  * Odpady są usuwane automatycznie - gotowe.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb ręcznego zarządzania>\n" +
                    "  * Sterowanie odpadami = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki według uznania.\n" +
                    "  * Opcjonalnie: włącz zaawansowane suwaki (nie jest wymagane).\n" +
                    "  * Te same odpady w grze; lepiej zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb statusu / vanilla>\n" +
                    "  * Totalna magia = OFF\n" +
                    "  * Sterowanie odpadami = OFF\n" +
                    "  * Tylko raport statusu.\n" +
                    "  * Garbage vanilla w grze bez zmian."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Ocena usług odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Prosta miejska ocena zadowolenia z odpadów z gry.\n" +
                    "**0 = Doskonale**\n" +
                    "**-1 = Wymaga drobnej poprawki** gra może często skakać między 0 i -1, więc można to zignorować.\n" +
                    "**-2 do -4 = Lekko śmierdzi**\n" +
                    "**-5 do -10 = Problem z odpadami**\n" +
                    "**Pośrednie suwaki:** suwaki ciężarówek/obiektów/progów mogą z czasem to poprawić przez zmniejszenie realnego nagromadzenia odpadów.\n" +
                    "**Bezpośrednie suwaki:** <Bazowy próg zadowolenia z odpadów> + <Krok zadowolenia z odpadów> zmieniają to, ile cims znoszą, zanim będą niezadowoleni.\n" +
                    "**Suwak źródła:** <Tempo gromadzenia odpadów> zmienia, jak szybko wspierane budynki produkują odpady."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Odpady/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje bieżącą ilość odpadów w całym mieście i całkowite tempo przetwarzania odpadów.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięcznie produkowanych odpadów jest dużo więcej.\n" +
                    "**Produced** i **Processed** są liczone w tonach na miesiąc.\n" +
                    "<Czas aktualizacji = ostatnie odświeżenie.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Zgłoszenia odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = aktywne zgłoszenia odbioru, które nie są jeszcze przypisane do ciężarówki ani trasy.\n" +
                    "**Dispatched** = aktywne zgłoszenia odbioru już przypisane.\n" +
                    "**Total** = liczba bieżących **aktywnych** encji zgłoszeń (w pipeline garbage).\n\n" +
                    "Uwaga techniczna: to nie to samo co <Powyżej progu zgłoszenia>. Tutaj liczone są <zgłoszenia>, nie budynki.\n" +
                    "Część oczekujących zgłoszeń zostanie przypisana później; część może też zniknąć, jeśli rewalidacja vanilla uzna, że cel nie potrzebuje już obsługi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ma odpady** = budynki, które aktualnie mają jakiekolwiek odpady.\n" +
                    "**Total** = wszystkie budynki produkujące odpady w mieście.\n" +
                    "**Powyżej progu zgłoszenia** = bieżąca liczba **budynków** z ilością odpadów wystarczającą do utworzenia zgłoszenia odbioru.\n" +
                    "W vanilla próg zgłoszenia to **100** wewnętrznych units garbage.\n" +
                    "Opcje eksperta mogą nadpisać progi zgłoszenia i odbioru.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie policzonych obiektów garbage.\n" +
                    "**Obiekty** = policzone budynki odpadów.\n" +
                    "**Garbage trucks** = zwykłe ciężarówki odbioru. W obiektach odpadów przemysłowych zbierają odpady przemysłowe zamiast zwykłych odpadów.\n" +
                    "**Dump trucks** = transfery odpadów między obiektami.\n" +
                    "**Max workers** = łączna pojemność pracowników w tych samych obiektach."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = ciężarówki aktualnie w trasie po mieście.\n" +
                    "**Returning** = część jadących ciężarówek oznaczona do powrotu do obiektu.\n" +
                    "**Parked** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Total** = liczba wszystkich garbage trucks."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wyślij bardziej szczegółowy raport garbage do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera krótką legendę, wartości referencyjne vanilla i wiele dodatkowych realnych statystyk odpadów z miasta."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwórz folder gry Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie wczytano jeszcze miasta." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Doskonale ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Wymaga drobnej poprawki ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Lekko śmierdzi ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problem z odpadami ({0:N0})" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed | aktualizacja {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma odpady | {2:N0} powyżej progu zgłoszenia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiektów | {1:N0} garbage trucks | {2:N0} dump trucks | {3:N0} max workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Brak jeszcze danych o obiektach." },

                // Log strings
                { "MG.Status.Log.Title", "Status odpadów ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Totalna magia={0}, Sterowanie odpadami={1}" },
                { "MG.Status.Log.SettingsHeader", "Bieżące ustawienia moda" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Suwaki Sterowania odpadami (zapisane): ładowność ciężarówki={0:N0}% | magazyn obiektu={1:N0}% | przetwarzanie obiektu={2:N0}% | flota obiektu={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Ekspert (zapisane): enabled={0} | request={1:N0} | pickup={2:N0} | bazowy próg zadowolenia={3:N0} | krok zadowolenia={4:N0} | tempo gromadzenia={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed używa ton na miesiąc.\n" +
                    "- Poniższe wartości progów używają wewnętrznych units garbage, nie ton.\n" +
                    "- Dla gracza gra przelicza 100 units = 0.1t oraz 1,000 units = 1t.\n" +
                    "- Ocena usług odpadów = miejski współczynnik zadowolenia z odpadów z gry.\n" +
                    "  - 0 = Doskonale\n" +
                    "  - -1 = Wymaga drobnej poprawki lub można zignorować\n" +
                    "  - -2 do -4 = Lekko śmierdzi\n" +
                    "  - -5 do -10 = Problem z odpadami\n" +
                    "Suwaki progów:\n" +
                    "  - Pickup threshold = minimalna ilość odpadów, zanim ciężarówka odbierze je z budynku.\n" +
                    "  - Request threshold = minimalna ilość odpadów, zanim gra utworzy lub utrzyma zgłoszenie odbioru.\n" +
                    "- Warning icon = ilość odpadów, przy której nad budynkiem pojawia się ikona ostrzeżenia.\n" +
                    "- Hard cap = maksymalna ilość odpadów, jaką może zgromadzić budynek.\n" +
                    "- Pending = aktywne zgłoszenia, które nie są aktualnie przypisane do ciężarówki ani trasy.\n" +
                    "- Część oczekujących zgłoszeń zostanie przypisana później; część może też zniknąć, jeśli rewalidacja vanilla uzna, że cel nie potrzebuje już obsługi.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Progi gry (wewnętrzne units garbage): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage: {0:N0} t/mies. | Processing: {1:N0} t/mies." },
                { "MG.Status.Log.GarbageServiceRating", "Ocena usług odpadów: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Najwyższa ilość odpadów w oczekującym celu: {0:N0} ({1:N1}t) przy {2}" },
                { "MG.Status.Log.PendingPeakNone", "Najwyższa ilość odpadów w oczekującym celu: brak" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} warning icons | {1:N0} total | {2:N0} ma odpady | {3:N0} powyżej progu zgłoszenia " },
                { "MG.Status.Log.ProducerGarbageStats", "Odpady w budynkach (tylko wartości niezerowe): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) przy {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko warning icon (co najmniej {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Doskonale" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Wymaga drobnej poprawki" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Lekko śmierdzi" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problem z odpadami" },
            };
        }

        public void Unload()
        {
        }
    }
}
