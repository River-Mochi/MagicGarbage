// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// German (de-DE)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleDE : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleDE(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Info" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Automatisch reinigen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Selbst verwalten" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Stadtweite Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n" +
                    "\n" +
                    "Während **Stadtweite Magie** AN ist:\n" +
                    "- Müllmeister wird auf AUS gezwungen.\n" +
                    "- Müllmeister-Schieberegler werden nicht angewendet (Werte werden für später gespeichert).\n" +
                    "- Einige Lkw können sich wegen des Timings der Vanilla-Dispatch-Logik trotzdem noch bewegen."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Müllmeister" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Verwaltet die Müllsysteme direkt; die Vanilla-Mülllogik läuft weiter.\n" +
                    "\n" +
                    "- Wenn **Müllmeister AN [ ✓ ]** ist, wird Stadtweite Magie auf AUS gezwungen.\n" +
                    "- Schieberegler gelten nur, wenn Müllmeister aktiviert ist.\n" +
                    "- Stadtweite Magie + Müllmeister können beide **AUS** sein, um die Vanilla-Einstellungen zu verwenden,\n" +
                    "  und du kannst weiterhin den **Statusbericht** sehen, der nur beim Öffnen des Optionen-Menüs aktualisiert wird (leichtgewichtig)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Lkw-Ladekapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Lkw transportieren kann.**\n" +
                    "**100% = Vanilla**-Lkw-Kapazität (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenlager" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "**100% = Vanilla**-Lagerung.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Verarbeitungsgeschwindigkeit der Anlage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "**100% = Vanilla**-Verarbeitungsgeschwindigkeit.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagenflotte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Lkw jede Anlage entsenden kann.**\n" +
                    "**100% = Vanilla**-Anzahl der Lkw.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Zielreserve" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Legt fest, wie früh Lkw bei optionalen Abholungen auf dem Weg zu ihrem zugewiesenen Gebäude wählerischer werden.**\n" +
                    "**10% ist der Vanilla-Wert in 1.6.2.**\n" +
                    "Für einen normalen 20t-Lkw:\n" +
                    "- 10% schützt den zugewiesenen Stopp 2t früher.\n" +
                    "- 15% beginnt 3t früher.\n" +
                    "- 25% beginnt 5t früher.\n" +
                    "Höhere Werte geben einen größeren Sicherheitspuffer. Lkw überspringen kleine Abholungen früher und lassen so mehr Platz für das zugewiesene Gebäude."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Wendet ausgewogene Werte für stark ausgelastete Städte an.\n" +
                    "Lkw-Ladung **200%** | Lagerung **150%** | Verarbeitung **250%**\n" +
                    "Flotte **100%** | Zielreserve **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Schieberegler zurücksetzen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt die normalen Müllmeister-Schieberegler zurück.\n" +
                    "- Prozent-Schieberegler kehren auf **100%** zurück.\n" +
                    "- Die Zielreserve kehrt auf den **Vanilla-Wert von 10%** zurück.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Anzeigename dieses Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktuelle Mod-Version." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Öffnet die Paradox-Mods-Seite." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Öffnet die Discord-Einladung im Browser." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Automatisch-reinigen-Status>\n" +
                    "  * Stadtweite Magie AN = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - erledigt.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Selbstverwaltungs-Status>\n" +
                    "  * Müllmeister = **[ ✓ ]**\n" +
                    "  * Schieberegler wie gewünscht einstellen.\n" +
                    "  * Gleicher Spielmüll; besser selbst verwaltete Lkw/Anlagen.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Status-/Vanilla-Status>\n" +
                    "  * Stadtweite Magie = AUS\n" +
                    "  * Müllmeister = AUS\n" +
                    "  * Nur Statusbericht.\n" +
                    "  * Vanilla-Müllspiel unverändert."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Müllservice-Wertung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Der stadtweite durchschnittliche Müll-Zufriedenheitseffekt des Spiels.\n" +
                    "Eine gute Gesamtwertung kann trotzdem einige Problemgebäude enthalten, also prüfe auch die **Gebäude ab 7t**.\n" +
                    "**0 = Insgesamt ausgezeichnet**\n" +
                    "**-1 = Kleine Anpassung sinnvoll**\n" +
                    "**-2 bis -4 = Etwas stinkig**\n" +
                    "**-5 oder niedriger = Müllproblem**\n" +
                    "\n" +
                    "Verbessere den Service mit den Lkw- und Anlagen-Schiebereglern und lass die Stadt danach etwas laufen, bevor du erneut prüfst."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Gebäude ab 7t" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Anzahl der müllproduzierenden Gebäude mit mindestens **7000 / 7t**.\n" +
                    "Dieser feste Frühwarnindikator hilft dir zu entscheiden, ob du den Service erhöhen solltest, bevor Gebäude die Warnsymbol-Stufe des Spiels erreichen.\n" +
                    "Mit „Detaillierten Status ins Log“ kannst du ihre Entity-IDs auflisten."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die stadtweite Müllproduktion, die aktuelle Verarbeitung und die verfügbare Verarbeitungskapazität der Anlagen.\n" +
                    "Erhöhe die Verarbeitung, wenn die monatliche Produktion höher als die Kapazität ist.\n" +
                    "Alle Werte sind Tonnen pro Monat."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Ausstehend** = aktive Abholanfragen, die derzeit keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "**Entsandt** = aktive Abholanfragen, die bereits zugewiesen sind.\n" +
                    "**Gesamt** = alle derzeit **aktiven** Anfragen in der Müll-Pipeline.\n" +
                    "\n" +
                    "Dies unterscheidet sich von **Über Anfrageschwelle**, wo Gebäude statt Anfragen gezählt werden.\n" +
                    "Einige ausstehende Anfragen werden später zugewiesen; andere können später auch verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr benötigt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die derzeit Müll enthalten.\n" +
                    "**Gesamt** = alle müllproduzierenden Gebäude in der Stadt.\n" +
                    "**Über Anfrageschwelle** = aktuelle Anzahl von **Gebäuden** mit genug Müll, um eine Abholanfrage zu erstellen.\n" +
                    "Der detaillierte Status im Log zeigt die aktuelle Live-Anfrageschwelle des Spiels.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Anlagen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Zusammenfassung der gezählten Müllanlagen.\n" +
                    "**Anlagen** = gezählte Müllgebäude.\n" +
                    "**Müll-Lkw** = normale Sammel-Lkw. Bei Industrieabfallanlagen sammeln sie Industrieabfall statt Müll.\n" +
                    "**Muldenkipper** = Mülltransfers zwischen Anlagen.\n" +
                    "**Max. Arbeiter** = gesamte Arbeiterkapazität dieser Anlagen."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Müll-Lkw" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Fahrend** = Lkw, die derzeit in der Stadt unterwegs sind.\n" +
                    "**Rückkehrend** = Teilmenge der fahrenden Lkw, die zur Anlage zurückkehren sollen.\n" +
                    "**Geparkt** = Lkw, die an einer Anlage geparkt sind.\n" +
                    "**Gesamt** = Anzahl aller Müll-Lkw."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Detaillierten Status ins Log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Schreibt einen detaillierteren Müllbericht in **Logs/MagicGarbage.log**.\n" +
                    "Enthält übersichtlich organisierte Müllstatistiken der Stadt."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnet **MagicGarbage.log**. Wenn die Datei fehlt oder nicht geöffnet werden kann, wird stattdessen der Logs-Ordner des Spiels geöffnet." },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Insgesamt ausgezeichnet ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Kleine Anpassung sinnvoll ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Etwas stinkig ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Müllproblem ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} Gebäude ab 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {2:N0} t Verarbeitung | {1:N0} t Kapazität" },
                { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} entsandt | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hat Müll | {2:N0} über Anfrageschwelle" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0}/{2:N0} Müll-/Muldenkipper | {3:N0} Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} fahrend ({3:N0} rückkehrend) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten." },

                // Log strings
                { "MG.Status.Log.Title", "Müllstatus ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Stadtweite Magie={0}, Müllmeister={1}" },
                { "MG.Status.Log.SettingsHeader", "Aktuelle Mod-Einstellungen" },
                { "MG.Status.Log.SettingsTrashBoss", "Müllmeister-Schieberegler (gespeichert): Lkw-Ladung={0:N0}% | Anlagenlager={1:N0}% | Anlagenverarbeitung={2:N0}% | Anlagenflotte={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produktion, aktuelle Verarbeitung und Kapazität werden in Tonnen pro Monat angegeben.\n" +
                    "- Die Schwellenwerte unten verwenden interne Mülleinheiten, keine Tonnen.\n" +
                    "- Für die Spieleranzeige rechnet das Spiel 100 Einheiten = 0.1t und 1,000 Einheiten = 1t.\n" +
                    "- Müllservice-Wertung = Müll-Zufriedenheitsfaktor der Stadt im Spiel.\n" +
                    "  - 0 = Insgesamt ausgezeichnet\n" +
                    "  - -1 = Kleine Anpassung sinnvoll\n" +
                    "  - -2 bis -4 = Etwas stinkig\n" +
                    "  - -5 bis -10 = Müllproblem\n" +
                    "Routing-Werte:\n" +
                    "  - Die Abholschwelle ist das Vanilla-Minimum; zielbewusstes Routing kann sie pro Lkw erhöhen, um Kapazität für dessen Ziel zu schützen.\n" +
                    "  - Die Anfrageschwelle ist die Mindestmüllmenge, bevor das Spiel eine Abholanfrage erstellt oder beibehält.\n" +
                    "- Das Warnsymbol erscheint, wenn der Gebäudemüll die aktuelle Warnstufe überschreitet.\n" +
                    "- Hartes Limit = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Ausstehend = aktive Anfragen, die derzeit keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "- Einige ausstehende Anfragen werden später zugewiesen; andere können später auch verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr benötigt.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Spielschwellen (interne Mülleinheiten): Abholung={1:N0}, Anfrage={0:N0}, Warnsymbol={2:N0}, hartes Limit={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Schwellen: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.AdaptiveMargin", "Zielreserve: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Zielreserve: aktuell={0:N0}% | Spielbasiswert beim Laden={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Müllproduktion: {0:N0} t/Monat | Aktuelle Verarbeitung: {2:N0} t/Monat | Verarbeitungskapazität: {1:N0} t/Monat" },
                { "MG.Status.Log.GarbageServiceRating", "Müllservice-Wertung: {0} | roh={1:N2} | gerundet={2:N0}" },
                { "MG.Status.Log.Requests", "Abholanfragen: ausstehend={1:N0}, entsandt={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Höchster ausstehender Zielmüll: {0:N0} ({1:N1}t) bei {2}" },
                { "MG.Status.Log.PendingPeakNone", "Höchster ausstehender Zielmüll: keiner" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} über Warnstufe | {1:N0} gesamt | {2:N0} hat Müll | {3:N0} über Anfrageschwelle" },
                { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur Werte über null): Ø={0:N0} ({1:N1}t) | Median={2:N0} ({3:N1}t) | Max={4:N0} ({5:N1}t) bei {6}" },
                { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnsymbol (mindestens {1:N0} Einheiten / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Müll-Lkw | {2:N0} Muldenkipper ({3:N0} fahrend) | {4:N0} Arbeiter" },
                { "MG.Status.Log.Trucks", "Müll-Lkw: {2:N0} fahrend ({3:N0} rückkehrend) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine", "- Anlage {0}: Müll-Lkw={1:N0} ({2:N0} fahrend, {3:N0} geparkt) | Muldenkipper={4:N0} ({5:N0} fahrend) | max. Arbeiter={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Insgesamt ausgezeichnet" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Kleine Anpassung sinnvoll" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Etwas stinkig" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Müllproblem" },

                { "MG.Status.Log.ThresholdsHeader", "Schwellen + Service" },
                { "MG.Status.Log.RequestsHeader", "Anfragen" },
                { "MG.Status.Log.BuildingsHeader", "Gebäude" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Gebäude ab 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Lokale Mülltransfer-Prüfung" },
                { "MG.Status.Log.LocalTransferProbeNone", "Keine lokalen Müllanlagen gefunden." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Mülltransfer-Prüfung für Außenverbindung" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Keine Müllanlagen für Außenverbindungen gefunden." },

                { "MG.Status.Log.TransferProbeHeader", "Mülltransfer-Prüfung" },
                { "MG.Status.Log.TransferProbeNone", "Keine Müll-Lagertransferanlagen gefunden." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | gelagert={1,7:N0} ({2,4:N1}t) / Kap={3,7:N0} ({4,4:N1}t) | Annahme={5:N2} | Senden={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Lkw" },

                { "MG.Status.Log.CriticalBuildingsNone", "keine" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
