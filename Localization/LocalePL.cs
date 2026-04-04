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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Pełna Magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n\n" +
                    "Gdy **Pełna Magia** jest ON:\n" +
                    "- Zarządzanie Odpadami jest wymuszane na OFF.\n" +
                    "- Suwaki Zarządzania Odpadami nie są stosowane (wartości zostają zapisane na później).\n" +
                    "- Część ciężarówek może nadal jeździć przez timing dispatchu vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Zarządzanie Odpadami" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Pozwala bezpośrednio sterować systemem odpadów; logika śmieci vanilla dalej działa.\n\n" +
                    "- Gdy **Zarządzanie Odpadami jest ON [ ✓ ]**, Pełna Magia jest wymuszana na OFF.\n" +
                    "- Suwaki działają tylko wtedy, gdy Zarządzanie Odpadami jest włączone.\n" +
                    "- Zarówno Pełna Magia, jak i Zarządzanie Odpadami mogą być **OFF**, jeśli potrzebny jest tylko **raport statusu**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówek" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile odpadów może przewieźć każda ciężarówka.**\n" +
                    "**100% = normalna** wartość gry.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Magazyn obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile odpadów może przechować obiekt.**\n" +
                    "**100% = magazyn vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Szybkość przetwarzania obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają przychodzące odpady.**\n" +
                    "**100% = szybkość vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "**100% = liczba ciężarówek vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opcje zaawansowane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Opcjonalne zaawansowane strojenie progów + wpływu odpadów na zadowolenie.**\n" +
                    "Gdy **OFF**, progi odbioru/zgłoszenia i wpływ odpadów na zadowolenie **pozostają vanilla**.\n" +
                    "Gdy **ON**, pojawiają się **zaawansowane suwaki**.\n\n" +
                    "<--- Przykłady wpływu odpadów na zadowolenie --->\n" +
                    " - <Vanilla> 100/65 = 1. kara przy <165>.\n" +
                    " - <Polecane> 550/150 = 1. kara przy <700>.\n" +
                    " - <Bardzo łagodnie> 950/200 = 1. kara za odpady przy <1150>.\n" +
                    "Wygoda: ostatnie wartości suwaków zostają zapisane nawet wtedy, gdy ta opcja jest OFF."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Próg zgłoszenia dispatchu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Ilość odpadów w budynku potrzebna do utworzenia albo utrzymania zgłoszenia wysłania ciężarówki.**\n" +
                    "Vanilla = **100** jednostek odpadów.\n" +
                    "**100 jednostek odpadów = 0.1t**\n" +
                    "**1 000 jednostek odpadów = 1t**\n" +
                    "Trzymaj tę wartość na poziomie progu odbioru albo wyżej.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Próg odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimalna ilość odpadów w budynku, zanim ciężarówka będzie mogła je odebrać.**\n" +
                    "Vanilla = **20** jednostek odpadów.\n" +
                    "Próg odbioru nigdy nie może być wyższy niż próg zgłoszenia dispatchu.\n" +
                    "Trzymaj próg zgłoszenia dispatchu co najmniej na poziomie prawidłowej wartości odbioru, żeby uniknąć problemów logiki;" +
                    " jeśli ciężarówka zostanie wysłana do budynku, a wartość odbioru będzie wyższa, może nie być w stanie nic zabrać (tempo narastania też ma znaczenie).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Polecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Stosuje **polecane** standardowe wartości Zarządzania Odpadami.\n" +
                    "Nie zmienia ustawień Opcji zaawansowanych."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Wartości gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Przywraca suwaki Zarządzania Odpadami do **wartości vanilla**.\n" +
                    "Nie zmienia <not> ustawień Opcji zaawansowanych.\n" +
                    "**Vanilla:**\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Próg zgłoszenia dispatchu wraca do **100 units**.\n" +
                    "- Próg odbioru wraca do **20 units**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Baza wpływu odpadów na zadowolenie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Poziom odpadów w budynku, od którego zaczyna się kara do zdrowia + zadowolenia.**\n" +
                    "**Vanilla = 100** jednostek odpadów.\n" +
                    "Wyższa baza = budynki mogą znieść więcej odpadów, zanim zacznie się kara.\n" +
                    "100 jednostek odpadów = 0.1t\n" +
                    "Podgląd:\n" +
                    "- <Próg> = punkt uruchomienia zachowania systemu\n" +
                    "- <Baza> = punkt startowy wzoru kary\n" +
                    "- <Krok> = wielkość przyrostu we wzorze, czyli jak szybko rośnie kara"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Krok wpływu odpadów na zadowolenie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Dodatkowa ilość odpadów ponad bazę, która uruchamia karę -1.**\n" +
                    "Vanilla = **65** jednostek odpadów.\n" +
                    "Wyższy krok = wolniejszy wzrost kary.\n" +
                    "Gra ogranicza karę za odpady do **-10**.\n" +
                    "Pierwsza kara vanilla <-1 penalty> pojawia się przy **165 odpadach** (100 baseline + 65 step)\n" +
                    "Dopasuj zmiany progów do suwaków zadowolenia, bo inaczej kary mogą być mocniejsze niż normalnie."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Polecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Stosuje **polecane** wartości Opcji zaawansowanych.\n" +
                    "Włącza Opcje zaawansowane.\n" +
                    "Pierwsza kara za odpady zaczyna się przy **700 odpadach** (550 baseline + 150 step)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Wartości gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Przywraca wartości Opcji zaawansowanych do **vanilla**.\n" +
                    "Przełącza **Opcje zaawansowane na OFF**."
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
                    "<Tryb auto clean>\n" +
                    "  * Pełna Magia ON  = **[ ✓ ]**\n" +
                    "  * Odpady są usuwane automatycznie - gotowe.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb self manage>\n" +
                    "  * Zarządzanie Odpadami = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki jak chcesz.\n" +
                    "  * Opcjonalnie: włącz Opcje zaawansowane dla progów + wpływu odpadów na zadowolenie.\n" +
                    "  * Ten sam system odpadów co w grze, tylko lepiej ogarnięte ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Tryb status / vanilla>\n" +
                    "  * Pełna Magia = OFF\n" +
                    "  * Zarządzanie Odpadami = OFF\n" +
                    "  * Tylko raport statusu.\n" +
                    "  * Vanilla system odpadów pozostaje bez zmian."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Odpady/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje bieżącą ilość odpadów w całym mieście oraz łączną szybkość przetwarzania.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięczna produkcja odpadów jest dużo wyższa.\n" +
                    "**Wyprodukowano** i **Przetworzono** są w tonach na miesiąc.\n" +
                    "<Czas aktualizacji = ostatnie odświeżenie.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Zgłoszenia odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Oczekujące** = aktywne zgłoszenia odbioru, które nie są jeszcze przypisane do ciężarówki ani trasy.\n" +
                    "**Wysłane** = aktywne zgłoszenia odbioru już przypisane.\n" +
                    "**Łącznie** = liczba aktualnie **aktywnych** encji zgłoszeń (w łańcuchu odpadów).\n\n" +
                    "Uwaga techniczna: to coś innego niż <Powyżej progu zgłoszenia>. Tutaj liczone są <zgłoszenia>, a nie budynki.\n" +
                    "Część oczekujących zgłoszeń zostanie przypisana później; część może też zniknąć, jeśli ponowna walidacja vanilla uzna, że cel nie potrzebuje już obsługi."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Ma odpady** = budynki, które aktualnie mają odpady.\n" +
                    "**Łącznie** = wszystkie budynki produkujące odpady w mieście.\n" +
                    "**Powyżej progu zgłoszenia** = bieżąca liczba **budynków** z wystarczającą ilością odpadów, by utworzyć zgłoszenie odbioru.\n" +
                    "W vanilla próg zgłoszenia to **100** wewnętrznych jednostek odpadów.\n" +
                    "Opcje zaawansowane mogą nadpisać próg zgłoszenia i próg odbioru.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie liczonych obiektów odpadów.\n" +
                    "**Obiekty** = liczone budynki odpadów.\n" +
                    "**Śmieciarki** = zwykłe ciężarówki odbioru. W obiektach odpadów przemysłowych zbierają odpady przemysłowe zamiast zwykłych śmieci.\n" +
                    "**Dump trucks** = transfer odpadów między obiektami.\n" +
                    "**Maks. pracowników** = łączna pojemność pracowników tych samych obiektów."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**W ruchu** = ciężarówki aktualnie jeżdżące po mieście.\n" +
                    "**Wracają** = część jadących ciężarówek, które wracają do obiektu.\n" +
                    "**Zaparkowane** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Łącznie** = liczba wszystkich śmieciarek."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wysyła bardziej szczegółowy raport odpadów do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera krótką legendę, wartości referencyjne vanilla i wiele dodatkowych statystyk z prawdziwego miasta."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Otwiera folder gry Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie wczytano jeszcze miasta." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t wyprodukowano | {1:N0} t przetworzono | aktualizacja {2}" },
                { "MG.Status.Row.Requests", "{1:N0} oczekujące | {2:N0} wysłane | {0:N0} łącznie" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ma odpady | {2:N0} powyżej progu zgłoszenia" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} obiektów | {1:N0} śmieciarek | {2:N0} dump trucks | {3:N0} maks. pracowników" },
                { "MG.Status.Row.Trucks", "{1:N0} w ruchu ({3:N0} wraca) | {2:N0} zaparkowane | {0:N0} łącznie" },
                { "MG.Status.Row.FacilitiesNone", "Brak danych o obiektach." },

                // Log strings
                { "MG.Status.Log.Title", "Status odpadów ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Pełna Magia={0}, Zarządzanie Odpadami={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Wyprodukowano/Przetworzono używa ton na miesiąc.\n" +
                    "- Poniższe progi używają wewnętrznych jednostek odpadów, a nie ton.\n" +
                    "- Dla gracza gra przelicza 100 jednostek = 0.1t oraz 1 000 jednostek = 1t.\n" +
                    "Suwaki progów:\n" +
                    "  - Próg odbioru = minimalna ilość odpadów, zanim ciężarówka odbierze je z budynku.\n" +
                    "  - Próg zgłoszenia = minimalna ilość odpadów, zanim gra utworzy albo utrzyma zgłoszenie odbioru.\n" +
                    "- Ikona ostrzeżenia = ilość odpadów, przy której nad budynkiem pojawia się ostrzeżenie.\n" +
                    "- Twardy limit = maksymalna ilość odpadów, jaką budynek może zgromadzić.\n" +
                    "- Oczekujące = aktywne zgłoszenia, które nie są jeszcze przypisane do ciężarówki ani trasy.\n" +
                    "- Część oczekujących zgłoszeń zostanie przypisana później; część może też zniknąć, jeśli ponowna walidacja vanilla uzna, że cel nie potrzebuje już obsługi.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Progi gry (wewnętrzne jednostki odpadów): odbiór={1:N0}, zgłoszenie={0:N0}, ikona ostrzeżenia={2:N0}, twardy limit={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Progi: <GarbageParameterData niedostępne>" },
                { "MG.Status.Log.GarbageProcessing", "Odpady: {0:N0} t/mies. | Przetwarzanie: {1:N0} t/mies." },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: oczekujące={1:N0}, wysłane={2:N0}, łącznie={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Najwyższy oczekujący cel: {0:N0} ({1:N1}t) przy {2}" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} łącznie | {1:N0} ma odpady | {2:N0} powyżej progu zgłoszenia | {3:N0} na poziomie ostrzeżenia" },
                { "MG.Status.Log.ProducerGarbageStats", "Odpady w budynkach (tylko niezerowe): średnia={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | maksimum={4:N0} ({5:N1}t) przy {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko ostrzeżenia (co najmniej {1:N0} jednostek / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} łącznie | {1:N0} śmieciarek | {2:N0} dump trucks ({3:N0} w ruchu) | {4:N0} pracowników" },
                { "MG.Status.Log.Trucks", "Śmieciarki: {2:N0} w ruchu ({3:N0} wraca) | {1:N0} zaparkowane | {4:N0} wyłączone | {0:N0} łącznie" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine", "- Obiekt {0}: odpady={1:N0} ({2:N0} w ruchu, {3:N0} zaparkowane) | dump={4:N0} ({5:N0} w ruchu) | maks. pracowników={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
