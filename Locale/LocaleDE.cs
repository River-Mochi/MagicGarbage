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
            return new Dictionary<string, string>
            {
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Über"   },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Selbst verwalten"  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod-Info"    },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "HINWEISE" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totale Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** entfernt sofort allen Müll in der Stadt.\n\n" +

                    "Solange **Totale Magie** AN ist:\n" +
                    "- Semi-Magie wird automatisch AUS geschaltet.\n" +
                    "- Semi-Magie-Schieberegler werden **nicht angewendet** (deine Werte bleiben für später gespeichert).\n" +
                    "- Ein paar Trucks können wegen der Spiel-Dispatch-Logik noch herumfahren (meist leer)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Müllsysteme direkt managen; die Vanilla-Mülllogik läuft weiter.\n\n" +
                    "- Wenn **Semi-Magie AN [ ✓ ]** ist, wird Totale Magie automatisch AUS geschaltet.\n" +
                    "- Schieberegler wirken nur, wenn Semi-Magie aktiviert ist [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Truck-Ladekapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Truck tragen kann.**\n" +
                    "100% = Standard im Spiel.\n" +
                    "<100%> = 20t\n" +
                    "<500%> = 100t\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Verarbeitungsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "100% = Vanilla-Verarbeitungsgeschwindigkeit.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Anlagen-Lagerkapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage speichern kann.**\n" +
                    "100% = Vanilla-Lagerung.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Anlagen-Truckanzahl"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Trucks jede Anlage aussenden kann.**\n" +
                    "100% = Vanilla-Anzahl der Trucks.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Empfohlene Semi-Magie-Werte anwenden:\n" +
                    "- Truck-Ladekapazität: **200%**\n" +
                    "- Verarbeitungsgeschwindigkeit: **200%**\n" +
                    "- Lagerkapazität: **160%**\n" +
                    "- Anlagen-Truckanzahl: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Spiel-Standard" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Setzt alle Schieberegler auf **100%** (Vanilla) zurück.\n" +
                    "Stellt normales Vanilla-Spielverhalten wieder her."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Anzeigename dieser Mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Aktuelle Mod-Version."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Öffnet die **Paradox Mods**-Seite mit den Mods des Autors."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet **Discord** im Browser zum CS2 Modding."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto Clean state>\n" +
                    "  * Totale Magie AN  = **[ ✓ ]**\n" +
                    "  * Aller Müll wird sofort entfernt\n" +
                    " <-------------------------------------->\n\n" +
                    "<Self-Manage state>\n" +
                    "  * Semi-Magie aktivieren = **[ ✓ ]**\n" +
                    "  * Schieberegler nach Wunsch einstellen.\n" +
                    "  * Vanilla-Mülllogik mit besser gemanagten Trucks/Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normal vanilla game>\n" +
                    "  * Semi-Magie aktivieren = **[ ✓ ]**\n" +
                    "  * **[Spiel-Standard]** klicken\n" +
                    "  * Alle Schieberegler auf 100% (Vanilla)\n"
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
