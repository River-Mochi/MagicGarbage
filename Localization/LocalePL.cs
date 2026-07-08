// <copyright file="LocalePL.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Samodzielne zarządzanie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Informacje o modzie" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Linki" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UŻYCIE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Włączone [ ✓ ]** utrzymuje całe miasto w czystości.\n" +
                    "\n" +
                    "Gdy **Total Magic** jest włączone:\n" +
                    "- Trash Boss jest wymuszone na OFF.\n" +
                    "- Suwaki Trash Boss nie są stosowane (wartości są zapisane na później).\n" +
                    "- Kilka ciężarówek może nadal jeździć z powodu timingu logiki vanilla dispatch."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Bezpośrednio zarządza systemami śmieci, pozostawiając działającą logikę vanilla.\n" +
                    "\n" +
                    "- Gdy **Trash Boss jest ON [ ✓ ]**, Total Magic jest wymuszone na OFF.\n" +
                    "- Suwaki działają tylko, gdy Trash Boss jest włączony.\n" +
                    "- Total Magic + Trash Boss mogą być **OFF**, aby wrócić do ustawień vanilla,\n" +
                    "  a nadal można widzieć **raport statusu**, który aktualizuje się tylko po wejściu do menu Options (lekki)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Asysta priorytetu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Pomoc dla mocno przeciążonych celów śmieci (budynków).\n" +
                    "Gdy **ON**, sprawdza, czy aktywny cel zgłoszenia osiąga **7000+** (**7t**) śmieci.\n" +
                    "Cel: w razie potrzeby ogranicza dodatkowe poboczne odbiory, aby ciężarówki szybciej docierały do złych celów.\n" +
                    "To tylko lekka pomoc, a nie twarde pełne nadpisanie logiki tras vanilla.\n" +
                    "Lekki, bez patcha Harmony."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Ładowność ciężarówki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Ile śmieci może zabrać każda ciężarówka.**\n" +
                    "**100% = normalna** domyślna wartość gry (20t).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Magazyn obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Ile śmieci może przechować obiekt.**\n" +
                    "**100% = magazyn vanilla**.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Szybkość przetwarzania obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Jak szybko obiekty przetwarzają napływające śmieci.**\n" +
                    "**100% = szybkość przetwarzania vanilla**.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flota obiektu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Ile ciężarówek może wysłać każdy obiekt.**\n" +
                    "**100% = liczba ciężarówek vanilla**.\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Zastosowano standardowe **zalecane** wartości Trash Boss.\n" +
                    "Nie zmienia ustawień Power User (osobne)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Przywraca suwaki Trash Boss do **wartości vanilla**.\n" +
                    "<Nie> zmienia ustawień Power User.\n" +
                    "**Vanilla:**\n" +
                    "- Suwaki procentowe wracają do **100%**.\n" +
                    "- Dispatch Request Threshold wraca do **100 units**.\n" +
                    "- Pickup Threshold wraca do **20 units**.\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opcje Power User" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Opcjonalne ustawienia zaawansowane\n" +
                    "<Ostrzeżenie: NIE są potrzebne> do dobrej obsługi; są dla graczy, którzy chcą eksperymentować albo lepiej poznać działanie systemów.\n" +
                    "Gdy **OFF**, elementy Power User zachowują się jak normalna gra **vanilla**.\n" +
                    "Gdy **ON**, pojawiają się zaawansowane **suwaki**.\n" +
                    "\n" +
                    "<--- Przykłady szczęścia --->\n" +
                    " - <Vanilla> 100/65 = pierwsza kara przy <165>.\n" +
                    " - Kliknij <Zalecane> dla 550/150 = pierwsza kara przy <700>.\n" +
                    " - <Bardzo łagodnie> 950/200 = pierwsza kara za śmieci przy <1150>.\n" +
                    "Wygoda: ostatnie wartości suwaków są zapisane, gdy ta opcja jest OFF (na wypadek ponownego włączenia później)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Ilość śmieci w budynku potrzebna, zanim zostanie utworzone lub utrzymane zgłoszenie wysłania ciężarówki.**\n" +
                    "Vanilla = **100** garbage units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "Trzymaj to na poziomie Pickup Threshold albo wyżej.\n" +
                    "Zwykle zwiększa liczbę używanych ciężarówek względem zaparkowanych."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Minimalna ilość śmieci w budynku, zanim ciężarówka może je odebrać.**\n" +
                    "Vanilla = **20** garbage units.\n" +
                    "Suwak Pickup <nie może> być wyższy niż Dispatch Request (DR); jest ograniczany, aby zapobiec problemom logiki.\n" +
                    "Jeśli ciężarówka zostanie wysłana do budynku, a wartość pickup jest wyższa niż DR, czasem może nie być w stanie zebrać śmieci z budynku (accumulation rate też ma wpływ).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Bazowy poziom szczęścia śmieci" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Poziom śmieci w budynku, zanim zacznie powodować karę zdrowia + szczęścia.**\n" +
                    "**Vanilla = 100** garbage units.\n" +
                    "Wyższa baza = budynki mogą trzymać więcej śmieci, zanim zacznie się kara.\n" +
                    "100 garbage units = 0.1t\n" +
                    "Przegląd:\n" +
                    "- <Threshold> = punkt wyzwalania zachowania systemu\n" +
                    "- <Baseline> = punkt startu wzoru kary\n" +
                    "- <Step> = wielkość przyrostu we wzorze, czyli jak szybko rośnie kara po rozpoczęciu"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Krok szczęścia śmieci" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Dodatkowe śmieci ponad bazę, które uruchamiają karę -1.**\n" +
                    "Vanilla = **65** garbage units.\n" +
                    "Wyższy krok = wolniejszy wzrost kary.\n" +
                    "Gra ogranicza karę za śmieci do **-10**.\n" +
                    "Pierwsza kara vanilla <-1 penalty> pojawia się przy **165 garbage** (100 baseline + 65 step)\n" +
                    "Zmiana threshold bez dopasowania suwaków szczęścia może powodować cięższe niż normalnie kary."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tempo nagromadzania" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaluje obsługiwane wartości źródłowe śmieci budynków.**\n" +
                    "Uwaga: to mocna dźwignia i zmiana tempa wpływa na wiele rzeczy.\n" +
                    "Dobry system da się uzyskać bez używania tego.\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate.\n" +
                    "**20%** = dużo wolniejsze narastanie.\n" +
                    "**200%** = podwójne tempo - bardzo dużo śmieci.\n" +
                    "Przy 20% wszyscy Cims najwyraźniej kompostują, więc tempo nagromadzania śmieci jest znacznie niższe ;)\n" +
                    "\n" +
                    "Notka techniczna: gra dodaje śmieci stopniowo w ciągu dnia, nie wszystko naraz."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Zalecane" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Zastosuj **zalecane** wartości Power User.\n" +
                    "Włącza Power User.\n" +
                    "Pierwsza kara za śmieci zaczyna się przy **700** garbage (550 baseline + 150 step).\n" +
                    "Garbage Accumulation Rate zostaje na **100%** vanilla, chyba że zmienisz ręcznie."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Domyślne gry" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Ustawia wszystkie wartości Power User **z powrotem na vanilla**.\n" +
                    "Wyłącza **Power User**.\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nazwa wyświetlana tego moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Wersja" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Obecna wersja moda." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Otwórz stronę Paradox Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Otwórz zaproszenie Discord w przeglądarce." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Stan Auto Clean>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * Śmieci są automatycznie usuwane - gotowe.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stan Self-Manage>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ustaw suwaki według potrzeb.\n" +
                    "  * Opcjonalnie: włącz zaawansowane suwaki (nie wymagane).\n" +
                    "  * Te same śmieci w grze; lepiej samodzielnie zarządzane ciężarówki/obiekty.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Stan Status / vanilla>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Tylko raport statusu.\n" +
                    "  * Vanilla gra śmieci pozostaje bez zmian."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Użycie" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Ocena obsługi śmieci" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Prosta ocena szczęścia śmieci z gry.\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= Warto drobno dostroić. Gra często przechodzi między 0 i -1 i można to ignorować (liczba jest zaokrąglona).\n" +
                    "**-2 to -4** = Lekko śmierdzi\n" +
                    "**-5 to -10** = Problem ze śmieciami\n" +
                    "**Pośrednie pokrętła:** użyj <trash sliders>, aby z czasem poprawić to przez zmniejszenie nagromadzenia śmieci.\n" +
                    "**Bezpośrednie pokrętła:** Garbage Happiness Baseline + Garbage Happiness Step zmieniają <co Cims tolerują>, zanim będą niezadowoleni.\n" +
                    "**Garbage Accumulation Rate**: zmienia, jak szybko obsługiwane budynki produkują śmieci. Używaj ostrożnie, bo balans jest ważny. Większość graczy nigdy nie musi tego ruszać.\n" +
                    "<Update time = ostatnio odświeżono.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Budynki 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Liczba budynków produkujących śmieci na poziomie **7t / 7000** albo wyżej.\n" +
                    "To mocno przeciążone budynki; włącz [x] Priority Assist, aby lepiej je priorytetyzować.\n" +
                    "Użyj przycisku Status to log, jeśli chcesz numery Entity ID do sprawdzenia."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Śmieci/mies." },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Pokazuje obecną ilość śmieci w mieście i całkowite tempo przetwarzania śmieci.\n" +
                    "Zwiększ przetwarzanie, jeśli miesięczna produkcja śmieci jest dużo wyższa.\n" +
                    "**Produced** i **Processed** używają ton na miesiąc."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Zgłoszenia odbioru" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = aktywne zgłoszenia odbioru nieprzypisane obecnie do ciężarówki lub ścieżki.\n" +
                    "**Dispatched** = aktywne zgłoszenia odbioru już przypisane.\n" +
                    "**Total** = liczy obecne **active** request entity (w pipeline śmieci).\n" +
                    "\n" +
                    "Notka techniczna: to różni się od <Above request threshold>. Liczy <requests>, nie budynki.\n" +
                    "Niektóre pending requests zostaną przypisane później; część może też zniknąć, jeśli vanilla revalidation uzna, że cel nie potrzebuje już obsługi."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Budynki" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = budynki aktualnie trzymające jakiekolwiek śmieci.\n" +
                    "**Total** = wszystkie budynki produkujące śmieci w mieście.\n" +
                    "**Above request threshold** = obecna liczba **buildings** z wystarczającą ilością śmieci, aby utworzyć zgłoszenie odbioru.\n" +
                    "W vanilla request threshold to **100** internal garbage units.\n" +
                    "Power User Options mogą nadpisać request i pickup thresholds.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Obiekty" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Podsumowanie policzonych obiektów śmieci.\n" +
                    "**Facilities** = policzone budynki śmieci.\n" +
                    "**Garbage trucks** = normalne ciężarówki odbioru. W Industrial Waste facilities odbierają odpady przemysłowe zamiast śmieci.\n" +
                    "**Dump trucks** = transfery śmieci między obiektami.\n" +
                    "**Max workers** = łączna pojemność pracowników w tych samych obiektach."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Ciężarówki śmieci" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = ciężarówki aktualnie w mieście.\n" +
                    "**Returning** = część jadących ciężarówek oznaczona do powrotu do obiektu.\n" +
                    "**Parked** = ciężarówki zaparkowane przy obiekcie.\n" +
                    "**Total** = liczba wszystkich ciężarówek śmieci."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Szczegółowy status do logu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Wyślij bardziej szczegółowy raport śmieci do **Logs/MagicGarbage.log**.\n" +
                    "Zawiera uporządkowane statystyki śmieci miasta"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Otwórz log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Otwórz folder gry Logs/.." },

                // Runtime status strings
                { "MG.Status.NoCity", "Nie załadowano jeszcze miasta." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Wymaga drobnego dostrojenia ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Lekko śmierdzi ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problem ze śmieciami ({0:N0}) | aktualizacja {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} powyżej 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0}/{2:N0} garbage/dump trucks | {3:N0} workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Brak jeszcze danych obiektów." },

                // Log strings
                { "MG.Status.Log.Title", "Status śmieci ({0})" },
                { "MG.Status.Log.City", "Miasto: {0}" },
                { "MG.Status.Log.Mode", "Tryb: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Obecne ustawienia moda" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Suwaki Trash Boss (zapisane): truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (zapisane): enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed używa ton na miesiąc.\n" +
                    "- Wartości threshold poniżej używają internal garbage units, nie ton.\n" +
                    "- Dla gracza gra przelicza 100 units = 0.1t oraz 1,000 units = 1t.\n" +
                    "- Garbage Service Rating = miejski współczynnik szczęścia od śmieci.\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = wymaga drobnego dostrojenia albo można ignorować\n" +
                    "  - -2 to -4 = lekko śmierdzi\n" +
                    "  - -5 to -10 = problem ze śmieciami\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = minimalna ilość śmieci, zanim ciężarówka odbierze z budynku.\n" +
                    "  - Request threshold = minimalna ilość śmieci, zanim gra utworzy lub utrzyma zgłoszenie odbioru.\n" +
                    "- Warning icon = ilość śmieci, która powoduje ikonę ostrzeżenia nad budynkiem.\n" +
                    "- Hard cap = maksymalna ilość śmieci, jaką budynek może zgromadzić.\n" +
                    "- Pending = aktywne zgłoszenia nieprzypisane obecnie do ciężarówki lub ścieżki.\n" +
                    "- Niektóre pending requests zostaną przypisane później; część może też zniknąć, jeśli vanilla revalidation uzna, że cel nie potrzebuje już obsługi.\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "Progi gry (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.GarbageProcessing", "Śmieci: {0:N0} t/mies. | Przetwarzanie: {1:N0} t/mies." },
                { "MG.Status.Log.GarbageServiceRating", "Ocena obsługi śmieci: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Zgłoszenia odbioru: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Najwyższy pending cel śmieci: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "Najwyższy pending cel śmieci: brak" },
                { "MG.Status.Log.Producers", "Budynki: {0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "Śmieci budynków (tylko niezerowe): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "Budynki blisko ikony ostrzeżenia (at least {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Obiekty: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Ciężarówki śmieci: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Podsumowanie obiektów" },
                { "MG.Status.Log.FacilityLine",
                    "- Obiekt {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Wymaga drobnego dostrojenia" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Lekko śmierdzi" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problem ze śmieciami" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Service" },
                { "MG.Status.Log.RequestsHeader", "Zgłoszenia" },
                { "MG.Status.Log.BuildingsHeader", "Budynki" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Krytyczne budynki powyżej 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Lokalna sonda transferu śmieci" },
                { "MG.Status.Log.LocalTransferProbeNone", "Nie znaleziono lokalnych obiektów śmieci." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Sonda transferu śmieci połączenia zewnętrznego" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Nie znaleziono obiektów śmieci połączenia zewnętrznego." },

                { "MG.Status.Log.TransferProbeHeader", "Sonda transferu śmieci" },
                { "MG.Status.Log.TransferProbeNone", "Nie znaleziono obiektów magazynowania-transferu śmieci." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Ciężarówki" },
                { "MG.Status.Log.SettingsPriority", "System priorytetu (zapisany): enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "Asysta priorytetu live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}" },
                { "MG.Status.Log.PriorityPeak", "Najwyższy krytyczny budynek: {0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "Asysta priorytetu" },
                { "MG.Status.Log.PriorityPasses", "Przebiegi priorytetu: raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Najwyższy aktywny krytyczny budynek: brak" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Ostatni czas skanu asysty priorytetu={0:N3} ms" },
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
