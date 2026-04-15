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
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n" +
                    "\n" +
                    "Gdy **Totalna magia** jest WŁ.:\n" +
                    "- Sterowanie odpadami jest wymuszone na WYŁ..\n" +
                    "- Suwaki Sterowania odpadami nie są stosowane (wartości zostają zapisane na później).\n" +
                    "- Kilka ciężarówek może nadal jeździć przez timing logiki vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Sterowanie odpadami" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Bezpośrednio zarządza systemami odpadów; logika odpadów vanilla nadal działa.\n" +
                    "\n" +
                    "- Gdy **Sterowanie odpadami jest WŁ. [ ✓ ]**, Totalna magia jest wymuszona na WYŁ..\n" +
                    "- Suwaki działają tylko wtedy, gdy Sterowanie odpadami jest włączone.\n" +
                    "- Zarówno Totalna magia, jak i Sterowanie odpadami mogą być **WYŁ.**, jeśli potrzebny jest tylko **raport statusu**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "Asysta priorytetu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "Pomoc dla mocno przeciążonych celów odpadów (budynków).\n" +
                    "Gdy jest **ON**, sprawdza, czy jakiś aktywny cel zgłoszenia osiąga **7000+** (**7t**) odpadów.\n" +
                    "Cel: w razie potrzeby ogranicza dodatkowe poboczne odbiory, aby ciężarówki szybciej docierały do najgorszych celów.\n" +
                    "To tylko lekkie wsparcie, a nie twarde, pełne nadpisanie logiki tras vanilla.\n" +
                    "Lekkie, bez patcha Harmony."
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
                    "Przywraca suwaki Sterowania odpadami do **wartości vanilla**.\n" +
                    "Nie <zmienia> ustawień eksperta.\n" +
                    "**Vanilla:**\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Próg wezwania odbioru wraca do **100 jednostek**.\n" +
                    "- Próg odbioru wraca do **20 jednostek**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opcje eksperta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Opcjonalne ustawienia zaawansowane\n" +
                    "<Uwaga: NIE są potrzebne> do dobrej obsługi; są dla graczy, którzy chcą eksperymentować albo lepiej rozumieć działanie systemu.\n" +
                    "Gdy opcja jest **WYŁ.**, elementy eksperta działają jak normalna gra **vanilla**.\n" +
                    "Gdy opcja jest **WŁ.**, pojawiają się zaawansowane **suwaki**.\n" +
                    "\n" +
                    "<--- Przykłady zadowolenia --->\n" +
                    " - <Vanilla> 100/65 = 1. kara przy <165>.\n" +
                    " - Kliknij <Zalecane>, aby ustawić 550/150 = 1. kara przy <700>.\n" +
                    " - <Bardzo łagodne> 950/200 = 1. kara za odpady przy <1150>.\n" +
                    "Wygoda: ostatnie wartości suwaków są zapisywane, gdy ta opcja jest WYŁ. (na wypadek późniejszego włączenia)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Próg wezwania odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Ilość odpadów w budynku potrzebna, zanim zostanie utworzone lub utrzymane wezwanie ciężarówki.**\n" +
                    "Vanilla = **100** jednostek odpadów.\n" +
                    "**100 jednostek odpadów = 0.1t**\n" +
                    "**1 000 jednostek odpadów = 1t**\n" +
                    "Trzymaj tę wartość na poziomie lub powyżej Progu odbioru.\n" +
                    "Zwykle zwiększa to liczbę używanych ciężarówek zamiast zaparkowanych."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Próg odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimalna ilość odpadów w budynku, zanim ciężarówka będzie mogła je odebrać.**\n" +
                    "Vanilla = **20** jednostek odpadów.\n" +
                    "Suwak odbioru <nie może> być wyższy niż Próg wezwania (DR); jest ograniczany, żeby uniknąć problemów logiki.\n" +
                    "Jeśli ciężarówka zostanie wysłana do budynku, a wartość odbioru będzie wyższa niż DR, czasem nie będzie mogła odebrać odpadów z budynku (wpływa na to też tempo narastania).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Bazowy poziom zadowolenia z odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Poziom odpadów w budynku, od którego zaczyna się kara do zdrowia i zadowolenia.**\n" +
                    "**Vanilla = 100** jednostek odpadów.\n" +
                    "Wyższa baza = budynki mogą utrzymać więcej odpadów, zanim zacznie się kara.\n" +
                    "100 jednostek odpadów = 0.1t\n" +
                    "Przegląd:\n" +
                    "- <Próg> = punkt uruchomienia zachowania systemu\n" +
                    "- <Baza> = punkt startowy wzoru kary\n" +
                    "- <Krok> = wielkość kroku we wzorze, czyli jak szybko kara narasta po starcie"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Krok zadowolenia z odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Dodatkowa ilość odpadów ponad bazę, od której zaczyna się kara -1.**\n" +
                    "Vanilla = **65** jednostek odpadów.\n" +
                    "Wyższy krok = wolniejszy wzrost kary.\n" +
                    "Gra ogranicza karę za odpady do **-10**.\n" +
                    "Pierwsza kara vanilla <-1> pojawia się przy **165 odpadów** (baza 100 + krok 65)\n" +
                    "Zmieniając progi, warto też zrównoważyć suwaki zadowolenia, inaczej kary mogą być mocniejsze niż normalnie."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tempo narastania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaluje wartości źródła odpadów w obsługiwanych budynkach.**\n" +
                    "Uwaga: to mocny suwak i zmiana tempa wpływa na wiele rzeczy.\n" +
                    "Dobry system można mieć także bez używania tego ustawienia.\n" +
                    "\n" +
                    "**100% = vanilla** tempo narastania.\n" +
                    "**20%** = dużo wolniejsze narastanie.\n" +
                    "**200%** = podwójne tempo - naprawdę dużo odpadów.\n" +
                    "Przy 20% wszyscy mieszkańcy najwyraźniej kompostują, więc tempo narastania odpadów jest dużo niższe ;)\n" +
                    "\n" +
                    "Uwaga techniczna: gra dodaje odpady stopniowo w ciągu dnia, a nie wszystko naraz."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Zastosuj **zalecane** wartości eksperta.\n" +
                    "Włącza tryb eksperta.\n" +
                    "Pierwsza kara za odpady zaczyna się przy **700** odpadów (baza 550 + krok 150).\n" +
                    "Tempo narastania odpadów zostaje na poziomie **100%** vanilla, chyba że zmienisz je ręcznie."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Przywraca wszystkie wartości eksperta do **vanilla**.\n" +
                    "Wyłącza **tryb eksperta**.\n"
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
                    "  * Totalna magia WŁ. = **[ ✓ ]**\n" +
                    "  * Odpady są usuwane automatycznie - gotowe.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Tryb ręcznego zarządzania>\n" +
                    "  * Sterowanie odpadami = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki według uznania.\n" +
                    "  * Opcjonalnie: włącz zaawansowane suwaki (nie jest wymagane).\n" +
                    "  * Te same odpady w grze; lepiej zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Tryb statusu / vanilla>\n" +
                    "  * Totalna magia = WYŁ.\n" +
                    "  * Sterowanie odpadami = WYŁ.\n" +
                    "  * Tylko raport statusu.\n" +
                    "  * Garbage vanilla w grze bez zmian."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Ocena usług odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Prosta ocena zadowolenia z odpadów z gry.\n" +
                    "**0 = Świetnie**\n" +
                    "**-1** = Przyda się mała korekta. Gra często skacze między 0 a -1, więc można to zignorować (liczba jest zaokrąglona).\n" +
                    "**-2 do -4** = Trochę śmierdzi\n" +
                    "**-5 do -10** = Problem ze śmieciami\n" +
                    "**Pośrednie suwaki:** użyj <suwaków> Trash Boss, aby z czasem poprawić ten wynik przez zmniejszenie rzeczywistego nagromadzenia śmieci.\n" +
                    "**Bezpośrednie suwaki:** <Bazowy poziom zadowolenia z odpadów> + <Krok zadowolenia z odpadów> zmieniają, ile mieszkańcy tolerują, zanim staną się niezadowoleni.\n" +
                    "**Tempo narastania**: zmienia, jak szybko obsługiwane budynki produkują odpady. Używaj ostrożnie, bo balans jest ważny. Większość graczy nigdy nie musi tego ruszać.\n" +
                    "<Czas aktualizacji = ostatnie odświeżenie.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Budynki 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Liczba budynków produkujących odpady, które mają **7t / 7000** odpadów lub więcej.\n" +
                    "To mocno przeciążone budynki — włącz [x] Asysta priorytetu, aby lepiej je uprzywilejować.\n" +
                    "Użyj przycisku „Szczegółowy status do logu”, jeśli chcesz sprawdzić numery ID encji."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Odpady/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje bieżącą ilość odpadów w całym mieście i łączne tempo przetwarzania.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięczna produkcja odpadów jest znacznie wyższa.\n" +
                    "**Wyprodukowano** i **Przetworzono** są podawane w tonach na miesiąc."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Zgłoszenia odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Oczekujące** = aktywne zgłoszenia odbioru, które nie są jeszcze przypisane do ciężarówki ani trasy.\n" +
                    "**Przydzielone** = aktywne zgłoszenia odbioru już przypisane.\n" +
                    "**Łącznie** = liczba bieżących **aktywnych** encji zgłoszeń (w łańcuchu odpadów).\n" +
                    "\n" +
                    "Uwaga techniczna: to coś innego niż <Powyżej progu zgłoszenia>. Tu liczone są <zgłoszenia>, a nie budynki.\n" +
                    "Część oczekujących zgłoszeń zostanie przydzielona później; część może też zniknąć, jeśli vanilla uzna przy ponownej weryfikacji, że cel nie potrzebuje już usługi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ma odpady** = budynki, które obecnie trzymają jakiekolwiek odpady.\n" +
                    "**Łącznie** = wszystkie budynki produkujące odpady w mieście.\n" +
                    "**Powyżej progu zgłoszenia** = bieżąca liczba **budynków** z ilością odpadów wystarczającą do utworzenia zgłoszenia odbioru.\n" +
                    "W vanilla próg zgłoszenia wynosi **100** wewnętrznych jednostek odpadów.\n" +
                    "Opcje eksperta mogą nadpisać próg zgłoszenia i próg odbioru.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie policzonych obiektów odpadów.\n" +
                    "**Obiekty** = policzone budynki odpadów.\n" +
                    "**Śmieciarki** = zwykłe ciężarówki odbioru. W obiektach odpadów przemysłowych zbierają odpady przemysłowe zamiast zwykłych śmieci.\n" +
                    "**Ciężarówki Dump** = przewozy odpadów między obiektami.\n" +
                    "**Maks. pracownicy** = łączna pojemność pracowników w tych samych obiektach."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki odpadów" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**W ruchu** = ciężarówki aktualnie na mieście.\n" +
                    "**Wracają** = część jadących ciężarówek oznaczona do powrotu do obiektu.\n" +
                    "**Zaparkowane** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Łącznie** = liczba wszystkich śmieciarek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wyślij bardziej szczegółowy raport odpadów do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera krótką legendę, wartości referencyjne vanilla i wiele dodatkowych realnych statystyk odpadów z miasta."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwórz folder gry Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie wczytano jeszcze miasta." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Świetnie ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Przyda się mała korekta ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Trochę śmierdzi ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problem ze śmieciami ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} ponad 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t wyprodukowano | {1:N0} t przetworzono" },
                { "MG.Status.Row.Requests", "{1:N0} oczekujące | {2:N0} przydzielone | {0:N0} łącznie" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma odpady | {2:N0} powyżej progu zgłoszenia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiektów | {1:N0}/{2:N0} śmieci/Dump ciężarówki | {3:N0} pracownicy" },
                { "MG.Status.Row.Trucks", "{1:N0} w ruchu ({3:N0} wracają) | {2:N0} zaparkowane | {0:N0} łącznie" },
                { "MG.Status.Row.FacilitiesNone", "Brak jeszcze danych o obiektach." },

                // Log strings
                { "MG.Status.Log.Title", "Status odpadów ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Totalna magia={0}, Sterowanie odpadami={1}" },
                { "MG.Status.Log.SettingsHeader", "Bieżące ustawienia moda" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Suwaki Trash Boss (zapisane): ładowność ciężarówki={0:N0}% | magazyn obiektu={1:N0}% | przetwarzanie obiektu={2:N0}% | flota obiektu={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "Opcje eksperta (zapisane): włączone={0} | zgłoszenie={1:N0} | odbiór={2:N0} | baza zadowolenia={3:N0} | krok zadowolenia={4:N0} | tempo narastania={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Wyprodukowano/Przetworzono używa ton na miesiąc.\n" +
                    "- Wartości progów poniżej używają wewnętrznych jednostek odpadów, a nie ton.\n" +
                    "- Dla gracza gra przelicza 100 jednostek = 0.1t oraz 1 000 jednostek = 1t.\n" +
                    "- Ocena usług odpadów = miejski współczynnik zadowolenia z odpadów w grze.\n" +
                    "  - 0 = Świetnie\n" +
                    "  - -1 = Przyda się mała korekta lub można zignorować\n" +
                    "  - -2 do -4 = Trochę śmierdzi\n" +
                    "  - -5 do -10 = Problem ze śmieciami\n" +
                    "Suwaki progów:\n" +
                    "  - Próg odbioru = minimalna ilość odpadów, zanim ciężarówka odbierze je z budynku.\n" +
                    "  - Próg zgłoszenia = minimalna ilość odpadów, zanim gra utworzy lub utrzyma zgłoszenie odbioru.\n" +
                    "- Ikona ostrzeżenia = ilość odpadów, przy której nad budynkiem pojawia się ikona ostrzeżenia.\n" +
                    "- Twardy limit = maksymalna ilość odpadów, jaką może zgromadzić budynek.\n" +
                    "- Oczekujące = aktywne zgłoszenia, które nie są aktualnie przypisane do ciężarówki ani trasy.\n" +
                    "- Część oczekujących zgłoszeń zostanie przydzielona później; część może też zniknąć, jeśli vanilla uzna przy ponownej weryfikacji, że cel nie potrzebuje już usługi.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Progi gry (wewnętrzne jednostki odpadów): odbiór={1:N0}, zgłoszenie={0:N0}, ikona ostrzeżenia={2:N0}, twardy limit={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.GarbageProcessing", "Odpady: {0:N0} t/mies. | Przetwarzanie: {1:N0} t/mies." },
                { "MG.Status.Log.GarbageServiceRating", "Ocena usług odpadów: {0} | surowe={1:N2} | zaokrąglone={2:N0}" },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: oczekujące={1:N0}, przydzielone={2:N0}, łącznie={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Najwyższy oczekujący cel odpadów: {0:N0} ({1:N1}t) przy {2}" },
                { "MG.Status.Log.PendingPeakNone", "Najwyższy oczekujący cel odpadów: brak" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} ikon ostrzeżeń | {1:N0} łącznie | {2:N0} ma odpady | {3:N0} powyżej progu zgłoszenia " },
                { "MG.Status.Log.ProducerGarbageStats", "Odpady w budynkach (tylko niezerowe): śr.={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | maks.={4:N0} ({5:N1}t) przy {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko ikony ostrzeżenia (co najmniej {1:N0} jednostek / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} łącznie | {1:N0} śmieciarki | {2:N0} ciężarówki Dump ({3:N0} w ruchu) | {4:N0} pracownicy" },
                { "MG.Status.Log.Trucks", "Śmieciarki: {2:N0} w ruchu ({3:N0} wracają) | {1:N0} zaparkowane | {4:N0} wyłączone | {0:N0} łącznie" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: śmieciarki={1:N0} ({2:N0} w ruchu, {3:N0} zaparkowane) | ciężarówki Dump={4:N0} ({5:N0} w ruchu) | pracownicy={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Świetnie" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Przyda się mała korekta" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Trochę śmierdzi" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problem ze śmieciami" },

                { "MG.Status.Log.ThresholdsHeader", "Progi + usługa" },
                { "MG.Status.Log.RequestsHeader", "Zgłoszenia" },
                { "MG.Status.Log.BuildingsHeader", "Budynki" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Krytyczne budynki powyżej 7t" },

                { "MG.Status.Log.TransferProbeHeader", "Sonda transferu odpadów" },
                { "MG.Status.Log.TransferProbeNone", "Nie znaleziono obiektów magazynowo-transferowych odpadów." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | magazyn={1,7:N0} ({2,4:N1}t) | poj={3,7:N0} ({4,4:N1}t) | eksport={5,7:N0} ({6,4:N1}t) | niski={7,7:N0} ({8,4:N1}t) | min={9,7:N0} ({10,4:N1}t) | wyj/wej={11,6:N0}/{12,6:N0} | aktywne={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Ciężarówki" },

                { "MG.Status.Log.SettingsPriority", "Asysta priorytetu (zapisane): włączone={0} | próg={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "Asysta priorytetu" },
                { "MG.Status.Log.PriorityState", "Asysta priorytetu aktywna={0} | interwał={1:N0} klatek | ostatnio przeskanowane zgłoszenia={2:N0} | aktywne krytyczne cele zgłoszeń={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses", "Przebiegi priorytetu: podniesione={0:N0} | normalne={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "Najwyższy aktywny krytyczny cel: brak" },
                { "MG.Status.Log.PriorityPeak", "Najwyższy aktywny krytyczny cel: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "oczekujące" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "przydzielone" },

#if DEBUG
{ "MG.Status.Log.PriorityPerf", "Asysta priorytetu czas ostatniego skanu={0:N3} ms" },
#endif

                { "MG.Status.Log.CriticalBuildingsNone", "brak" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
