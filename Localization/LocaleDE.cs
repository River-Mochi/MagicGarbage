// <copyright file="LocaleDE.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleDE.cs
// German (de-DE)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Profi" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod-Info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NUTZUNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** hält die ganze Stadt sauber.\n" +
                    "\n" +
                    "Während **Total Magic** AN ist:\n" +
                    "- Trash Boss wird auf AUS gezwungen.\n" +
                    "- Trash-Boss-Schieberegler werden nicht angewendet (Werte werden für später gespeichert).\n" +
                    "- Ein paar Lkw können wegen des Timings der Vanilla-Dispatch-Logik trotzdem noch fahren."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Verwaltet Müllsysteme direkt; die Vanilla-Mülllogik läuft weiter.\n" +
                    "\n" +
                    "- Wenn **Trash Boss AN [ ✓ ]** ist, wird Total Magic auf AUS gezwungen.\n" +
                    "- Schieberegler gelten nur, wenn Trash Boss aktiviert ist.\n" +
                    "- Total Magic + Trash Boss können beide **AUS** sein, um Vanilla-Einstellungen zu erhalten,\n" +
                    "  und du kannst trotzdem den **Statusbericht** sehen, der nur beim Öffnen des Optionen-Menüs aktualisiert wird (leichtgewichtig)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Prioritätsassistenz" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Assistenz für stark überlastete Müllziele (Gebäude).\n" +
                    "Wenn **AN**, wird geprüft, ob ein aktives Anfrageziel **7000+** (**7t**) Müll erreicht.\n" +
                    "Ziel: reduziert bei Bedarf zusätzliche Neben-Abholungen, damit Lkw schlechte Ziele schneller erreichen.\n" +
                    "Das ist ein Anschub, keine harte vollständige Überschreibung der Vanilla-Routenlogik.\n" +
                    "Leichtgewichtig, ohne Harmony-Patch."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Lkw-Ladekapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Lkw transportieren kann.**\n" +
                    "**100% = normaler** Spielstandard (20t).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Anlagenlagerung" },
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
                    "**100% = Vanilla**-Anzahl an Lkw.\n"
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Empfohlene** Standardwerte für Trash Boss werden angewendet.\n" +
                    "Ändert keine Power-User-Einstellungen (separat)."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Setzt Trash-Boss-Schieberegler auf **Vanilla-Werte** zurück.\n" +
                    "Ändert Power-User-Einstellungen <nicht>.\n" +
                    "**Vanilla:**\n" +
                    "- Prozent-Schieberegler kehren auf **100%** zurück.\n" +
                    "- Dispatch-Request-Schwelle kehrt auf **100 Einheiten** zurück.\n" +
                    "- Abholschwelle kehrt auf **20 Einheiten** zurück.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Power-User-Optionen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Optionale erweiterte Einstellungen\n" +
                    "<Warnung: NICHT nötig> für guten Service; für Spieler gedacht, die experimentieren oder besser lernen wollen, wie die Systeme funktionieren.\n" +
                    "Wenn **AUS**, verhalten sich Power-User-Elemente wie das normale **Vanilla**-Spiel.\n" +
                    "Wenn **AN**, erscheinen die erweiterten **Schieberegler**.\n" +
                    "\n" +
                    "<--- Zufriedenheitsbeispiele --->\n" +
                    " - <Vanilla> 100/65 = 1. Malus bei <165>.\n" +
                    " - Klicke <Empfohlen> für 550/150 = 1. Malus bei <700>.\n" +
                    " - <Sehr weich> 950/200 = 1. Müllmalus bei <1150>.\n" +
                    "Praktisch: Die letzten Schiebereglerwerte werden gespeichert, wenn diese Option AUS ist (falls du sie später aktivieren möchtest)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch-Request-Schwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Gebäudemüll, der nötig ist, bevor eine Lkw-Dispatch-Anfrage erstellt oder behalten wird.**\n" +
                    "Vanilla = **100** Mülleinheiten.\n" +
                    "**100 Mülleinheiten = 0.1t**\n" +
                    "**1,000 Mülleinheiten = 1t**\n" +
                    "Halte dies mindestens auf Höhe der Abholschwelle.\n" +
                    "Das erhöht normalerweise, wie viele Lkw genutzt werden statt geparkt zu bleiben."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Abholschwelle" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Mindestmenge an Gebäudemüll, bevor ein Lkw ihn einsammeln kann.**\n" +
                    "Vanilla = **20** Mülleinheiten.\n" +
                    "Der Abholregler <kann nicht> höher als Dispatch Request (DR) sein; er wird begrenzt, um Logikprobleme zu vermeiden.\n" +
                    "Wird ein Lkw zu einem Gebäude geschickt und der Abholwert ist höher als DR, kann der Lkw dort manchmal nichts einsammeln (die Ansammlungsrate wirkt ebenfalls mit).\n"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Müll-Zufriedenheitsbasis" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Gebäudemüllstand, bevor Gesundheits- + Zufriedenheitsmalus beginnt.**\n" +
                    "**Vanilla = 100** Mülleinheiten.\n" +
                    "Höhere Basis = Gebäude können mehr Müll halten, bevor der Malus beginnt.\n" +
                    "100 Mülleinheiten = 0.1t\n" +
                    "Überblick:\n" +
                    "- <Schwellenwert> = Auslösepunkt für Systemverhalten\n" +
                    "- <Basis> = Startpunkt der Malusformel\n" +
                    "- <Schritt> = Inkrementgröße in der Formel, also wie schnell der Malus nach Beginn ansteigt"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Müll-Zufriedenheitsschritt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Zusätzlicher Müll über der Basis, der einen -1-Malus auslöst.**\n" +
                    "Vanilla = **65** Mülleinheiten.\n" +
                    "Höherer Schritt = langsameres Anwachsen des Malus.\n" +
                    "Das Spiel begrenzt den Müllmalus auf **-10**.\n" +
                    "Der erste Vanilla-Malus <-1> tritt bei **165 Müll** auf (100 Basis + 65 Schritt)\n" +
                    "Werden Schwellenwerte mit Zufriedenheitsschiebereglern geändert, können stärkere als normale Mali entstehen."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Ansammlungsrate" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Skaliert unterstützte Müllquellwerte von Gebäuden.**\n" +
                    "Vorsicht: Das ist ein starker Hebel, und Änderungen an der Rate beeinflussen viele Dinge.\n" +
                    "Ein gutes System ist auch ohne diese Einstellung möglich.\n" +
                    "\n" +
                    "**100% = Vanilla**-Ansammlungsrate.\n" +
                    "**20%** = viel langsamerer Aufbau.\n" +
                    "**200%** = doppelte Rate - sehr viel Müll.\n" +
                    "Bei 20% kompostieren offensichtlich alle Cims, daher eine viel niedrigere Müllansammlungsrate ;)\n" +
                    "\n" +
                    "Technischer Hinweis: Das Spiel fügt Müll schrittweise über den Tag hinzu, nicht alles auf einmal."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Wendet **empfohlene** Power-User-Werte an.\n" +
                    "Schaltet Power User AN.\n" +
                    "Der erste Müllmalus beginnt bei **700** Müll (550 Basis + 150 Schritt).\n" +
                    "Die Müllansammlungsrate bleibt bei **100%** Vanilla, sofern sie nicht manuell geändert wird."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Spielstandard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Setzt alle Power-User-Werte **auf Vanilla** zurück.\n" +
                    "Schaltet **Power User AUS**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Anzeigename dieses Mods." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Aktuelle Mod-Version." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox-Mods-Seite öffnen." },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Discord-Einladung im Browser öffnen." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Automatisch-reinigen-Status>\n" +
                    "  * Total Magic AN = **[ ✓ ]**\n" +
                    "  * Müll wird automatisch entfernt - erledigt.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Selbstverwaltungs-Status>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Schieberegler wie gewünscht einstellen.\n" +
                    "  * Optional: für erweiterte Schieberegler aktivieren (nicht erforderlich).\n" +
                    "  * Gleicher Spielmüll; besser selbst verwaltete Lkw/Anlagen.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Status-/Vanilla-Status>\n" +
                    "  * Total Magic = AUS\n" +
                    "  * Trash Boss = AUS\n" +
                    "  * Nur Statusbericht.\n" +
                    "  * Vanilla-Müllspiel unverändert."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Nutzung" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Müllservice-Wertung" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Einfache Müll-Zufriedenheitswertung aus dem Spiel.\n" +
                    "**0 = Ausgezeichnet**\n" +
                    "**-1 **= Kleine Anpassung sinnvoll. Das Spiel schwankt oft zwischen 0 und -1 und das kann ignoriert werden (Zahl ist gerundet).\n" +
                    "**-2 bis -4** = Etwas stinkig\n" +
                    "**-5 bis -10** = Müllproblem\n" +
                    "**Indirekte Regler:** Nutze <Müll-Schieberegler>, um dies mit der Zeit durch weniger Müllaufbau zu verbessern.\n" +
                    "**Direkte Regler:** Müll-Zufriedenheitsbasis + Müll-Zufriedenheitsschritt ändern, <was Cims tolerieren>, bevor sie unzufrieden werden.\n" +
                    "**Müllansammlungsrate**: ändert, wie schnell unterstützte Gebäude Müll produzieren. Mit Vorsicht verwenden, da Balance wichtig ist. Die meisten Spieler müssen das nie anpassen.\n" +
                    "<Aktualisierungszeit = zuletzt aktualisiert.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+-Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Anzahl der müllproduzierenden Gebäude bei oder über **7t / 7000** Müll.\n" +
                    "Das sind stark überlastete Gebäude; aktiviere [x] Prioritätsassistenz, um sie besser zu priorisieren.\n" +
                    "Nutze den Status-zu-Log-Button, wenn du Entity-ID-Nummern zum Prüfen möchtest."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Müll/Monat" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Zeigt die aktuelle stadtweite Müllmenge und die gesamte Müllverarbeitungsrate.\n" +
                    "Erhöhe die Verarbeitung, wenn der monatlich produzierte Müll deutlich höher ist.\n" +
                    "**Produziert** und **Verarbeitet** nutzen Tonnen pro Monat."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Abholanfragen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Ausstehend** = aktive Abholanfragen, die derzeit keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "**Entsandt** = aktive Abholanfragen, die bereits zugewiesen sind.\n" +
                    "**Gesamt** = zählt aktuelle **aktive** Anfrage-Entities (in der Müll-Pipeline).\n" +
                    "\n" +
                    "Technischer Hinweis: Das ist anders als <Über Anfrageschwelle>. Dies zählt <Anfragen>, nicht Gebäude.\n" +
                    "Einige ausstehende Anfragen werden später zugewiesen; andere können verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Gebäude" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Hat Müll** = Gebäude, die aktuell Müll enthalten.\n" +
                    "**Gesamt** = alle müllproduzierenden Gebäude in der Stadt.\n" +
                    "**Über Anfrageschwelle** = aktuelle Anzahl von **Gebäuden** mit genug Müll, um eine Abholanfrage zu erstellen.\n" +
                    "In Vanilla liegt die Anfrageschwelle bei **100** internen Mülleinheiten.\n" +
                    "Power-User-Optionen können Anfrage- und Abholschwellen überschreiben.\n"
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
                    "Enthält organisierte Müllstatistiken der Stadt"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Log öffnen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Öffnet den Logs/..-Ordner des Spiels." },

                // Runtime status strings
                { "MG.Status.NoCity", "Noch keine Stadt geladen." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Ausgezeichnet ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Kleine Anpassung sinnvoll ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Etwas stinkig ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Müllproblem ({0:N0}) | aktualisiert {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} über 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produziert | {1:N0} t verarbeitet" },
                { "MG.Status.Row.Requests", "{1:N0} ausstehend | {2:N0} entsandt | {0:N0} gesamt" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} hat Müll | {2:N0} über Anfrageschwelle" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} Anlagen | {1:N0}/{2:N0} Müll-Lkw/Muldenkipper | {3:N0} Arbeiter" },
                { "MG.Status.Row.Trucks", "{1:N0} fahrend ({3:N0} rückkehrend) | {2:N0} geparkt | {0:N0} gesamt" },
                { "MG.Status.Row.FacilitiesNone", "Noch keine Anlagendaten." },

                // Log strings
                { "MG.Status.Log.Title", "Müllstatus ({0})" },
                { "MG.Status.Log.City", "Stadt: {0}" },
                { "MG.Status.Log.Mode", "Modus: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "Aktuelle Mod-Einstellungen" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash-Boss-Schieberegler (gespeichert): Lkw-Ladung={0:N0}% | Anlagenlager={1:N0}% | Anlagenverarbeitung={2:N0}% | Anlagenflotte={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (gespeichert): aktiviert={0} | Anfrage={1:N0} | Abholung={2:N0} | Zufriedenheitsbasis={3:N0} | Zufriedenheitsschritt={4:N0} | Ansammlungsrate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legende:\n" +
                    "- Produziert/Verarbeitet nutzt Tonnen pro Monat.\n" +
                    "- Die Schwellenwerte unten nutzen interne Mülleinheiten, keine Tonnen.\n" +
                    "- Für Spieleranzeige rechnet das Spiel 100 Einheiten = 0.1t und 1,000 Einheiten = 1t.\n" +
                    "- Müllservice-Wertung = Müll-Zufriedenheitsfaktor der Stadt.\n" +
                    "  - 0 = Ausgezeichnet\n" +
                    "  - -1 = Kleine Anpassung sinnvoll oder ignorieren\n" +
                    "  - -2 bis -4 = Etwas stinkig\n" +
                    "  - -5 bis -10 = Müllproblem\n" +
                    "Schwellen-Schieberegler:\n" +
                    "  - Abholschwelle = Mindestmüll, bevor ein Lkw von einem Gebäude sammelt.\n" +
                    "  - Anfrageschwelle = Mindestmüll, bevor das Spiel eine Abholanfrage erstellt oder behält.\n" +
                    "- Warnsymbol = Müllmenge, die ein Warnsymbol über einem Gebäude auslöst.\n" +
                    "- Hartes Limit = maximale Müllmenge, die ein Gebäude ansammeln kann.\n" +
                    "- Ausstehend = aktive Anfragen, die derzeit keinem Lkw oder Pfad zugewiesen sind.\n" +
                    "- Einige ausstehende Anfragen werden später zugewiesen; andere können verschwinden, wenn die Vanilla-Neuprüfung entscheidet, dass das Ziel keinen Service mehr braucht.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Spielschwellen (interne Mülleinheiten): Abholung={1:N0}, Anfrage={0:N0}, Warnsymbol={2:N0}, hartes Limit={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Schwellen: <GarbageParameterData nicht verfügbar>" },
                { "MG.Status.Log.GarbageProcessing", "Müll: {0:N0} t/Monat | Verarbeitung: {1:N0} t/Monat" },
                { "MG.Status.Log.GarbageServiceRating", "Müllservice-Wertung: {0} | roh={1:N2} | gerundet={2:N0}" },
                { "MG.Status.Log.Requests", "Abholanfragen: ausstehend={1:N0}, entsandt={2:N0}, gesamt={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Höchstes ausstehendes Ziel: {0:N0} ({1:N1}t) bei {2}" },
                { "MG.Status.Log.PendingPeakNone", "Höchstes ausstehendes Ziel: keines" },
                { "MG.Status.Log.Producers", "Gebäude: {0:N0} Warnsymbole | {1:N0} gesamt | {2:N0} hat Müll | {3:N0} über Anfrageschwelle " },
                { "MG.Status.Log.ProducerGarbageStats", "Gebäudemüll (nur Nicht-Null): Ø={0:N0} ({1:N1}t) | Median={2:N0} ({3:N1}t) | Max={4:N0} ({5:N1}t) bei {6}" },
                { "MG.Status.Log.NearWarning75", "Gebäude nahe Warnsymbol (mindestens {1:N0} Einheiten / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Anlagen: {0:N0} gesamt | {1:N0} Müll-Lkw | {2:N0} Muldenkipper ({3:N0} fahrend) | {4:N0} Arbeiter" },
                { "MG.Status.Log.Trucks", "Müll-Lkw: {2:N0} fahrend ({3:N0} rückkehrend) | {1:N0} geparkt | {4:N0} deaktiviert | {0:N0} gesamt" },
                { "MG.Status.Log.FacilitiesHeader", "Anlagenübersicht" },
                { "MG.Status.Log.FacilityLine",
                    "- Anlage {0}: Müll-Lkw={1:N0} ({2:N0} fahrend, {3:N0} geparkt) | Muldenkipper={4:N0} ({5:N0} fahrend) | max. Arbeiter={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Ausgezeichnet" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Kleine Anpassung sinnvoll" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Etwas stinkig" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Müllproblem" },

                { "MG.Status.Log.ThresholdsHeader", "Schwellen + Service" },
                { "MG.Status.Log.RequestsHeader", "Anfragen" },
                { "MG.Status.Log.BuildingsHeader", "Gebäude" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Kritische Gebäude über 7t" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Lokale Mülltransfer-Prüfung" },
                { "MG.Status.Log.LocalTransferProbeNone", "Keine lokalen Müllanlagen gefunden." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Mülltransfer-Prüfung für Außenverbindung" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Keine Müllanlagen für Außenverbindungen gefunden." },

                { "MG.Status.Log.TransferProbeHeader", "Mülltransfer-Prüfung" },
                { "MG.Status.Log.TransferProbeNone", "Keine Müll-Lagertransferanlagen gefunden." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | gelagert={1,7:N0} ({2,4:N1}t) / Kap={3,7:N0} ({4,4:N1}t) | Annahme={5:N2} | Senden={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "Lkw" },
                { "MG.Status.Log.SettingsPriority", "Prioritätssystem (gespeichert): aktiviert={0} | Auslöser={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "Prioritätsassistenz aktiv={0} | Intervall={1:N0} Frames | zuletzt gescannte Gebäude={2:N0} | kritische Gebäude={3:N0}" },
                { "MG.Status.Log.PriorityPeak", "Höchstes kritisches Gebäude: {0:N0} ({1:N1}t) | {2} | Anfrage={3}" },

                { "MG.Status.Log.PriorityHeader", "Prioritätsassistenz" },
                { "MG.Status.Log.PriorityPasses", "Prioritätsdurchläufe: erhöht={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Höchstes aktives kritisches Gebäude: keines" },
                { "MG.Status.Log.PriorityPeakState.Pending", "ausstehend" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "entsandt" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Letzte Scanzeit der Prioritätsassistenz={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "keine" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
