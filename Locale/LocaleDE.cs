// Locale/LocaleDE.cs
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
            return new Dictionary<string, string>
            {
                // Options mod name (single source of truth from Mod.cs)
                { m_Setting.GetSettingsLocaleID(), Mod.ModName + " " + Mod.ModTag },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Aktionen" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Über"     },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Automatisches Aufräumen" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Selbst verwalten"        },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod-Info"               },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"                  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "HINWEISE"               },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Totale Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Aktiviert [ ✓ ]** entfernt sofort allen Müll in der Stadt.\n" +
                    "Müllgebäude und -fahrzeuge sind nur noch Dekoration, nicht nötig.\n\n" +

                    "Solange **Totale Magie** AKTIV ist:\n" +
                    "- Semi-Magie wird automatisch deaktiviert.\n" +
                    "- Alle Semi-Magie-Schieberegler werden ignoriert.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Verwalte Müllsysteme direkt; die normale Spiel-Logik bleibt aktiv.\n\n" +
                    "- Wenn **Semi-Magie AKTIV [ ✓ ]** ist, wird Totale Magie automatisch ausgeschaltet.\n" +
                    "- Passe alle Müllfahrzeuge und -anlagen an.\n" +
                    "- Schieberegler wirken nur, wenn Semi-Magie aktiviert ist [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Müllwagen-Kapazität" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Wie viel Müll jeder Wagen transportieren kann.**\n" +
                    "100% = normale Spieleinstellung.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Anzahl der Fahrzeuge pro Anlage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Wie viele Fahrzeuge jede Anlage aussenden kann.**\n" +
                    "100% = Standardanzahl der Fahrzeuge.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Verarbeitungsgeschwindigkeit" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Wie schnell Anlagen eingehenden Müll verarbeiten.**\n" +
                    "100% = Standard-Verarbeitungsgeschwindigkeit.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Lagervolumen der Anlage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Wie viel Müll eine Anlage lagern kann.**\n" +
                    "100% = Standard-Lagerung.\n" +
                    "Höhere Werte = Anlage kann mehr Müll aufnehmen.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Standardwerte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Setzt alle Schieberegler auf **100%** (Standardwerte) zurück.\n" +
                    "Stellt das normale Spielverhalten wieder her."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Empfohlen" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Wendet empfohlene Semi-Magie-Werte an:\n" +
                    "- Müllwagen-Kapazität: **200%**\n" +
                    "- Fahrzeuge pro Anlage: **150%**\n" +
                    "- Verarbeitungsgeschwindigkeit: **200%**\n" +
                    "- Lagervolumen: **150%**\n"
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
                    "Öffnet die **Paradox Mods**-Seite der Mods des Autors."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Öffnet **Discord** im Browser mit dem CS2-Modding-Server."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Auto-Clean-Modus>\n" +
                    "  * Totale Magie AN = **[ ✓ ]**\n" +
                    "  * Sämtlicher Müll wird sofort entfernt\n" +
                    " <-------------------------------------->\n\n" +
                    "<Selbstverwaltungs-Modus>\n" +
                    "  * Semi-Magie aktivieren = **[ ✓ ]**\n" +
                    "  * Schieberegler [100 >> 500] nach Wunsch einstellen.\n" +
                    "  * Vanilla-Müllsimulation mit anpassbaren, stärkeren Fahrzeugen und Anlagen.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Normales Vanilla-Spiel>\n" +
                    "  * Semi-Magie = **[ ✓ ]**\n" +
                    "  * Auf **[Standardwerte]** klicken\n" +
                    "  * Alle Schieberegler auf 100% (Standard)\n" +
                    "  * Genau das normale Spielverhalten.\n"
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
