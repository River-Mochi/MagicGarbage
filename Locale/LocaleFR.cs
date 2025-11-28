// Locale/LocaleFR.cs
// French (fr-FR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleFR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleFR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "À propos" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Nettoyage automatique" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gestion manuelle"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Infos sur la mod"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens"                },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTES D’UTILISATION"  },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magie totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** supprime instantanément tous les déchets de la ville.\n" +
                    "Les bâtiments et camions de collecte deviennent surtout décoratifs.\n\n" +

                    "Quand **Magie totale** est ACTIVÉE :\n" +
                    "- La Semi-magie est automatiquement désactivée.\n" +
                    "- Tous les curseurs de Semi-magie sont ignorés.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gérez directement les systèmes de déchets ; la logique vanilla reste active.\n\n" +
                    "- Quand **Semi-magie est ACTIVÉE [ ✓ ]**, Magie totale est automatiquement désactivée.\n" +
                    "- Ajustez tous les camions et bâtiments de collecte.\n" +
                    "- Les curseurs n’ont d’effet que si la Semi-magie est activée [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacité de chargement des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "100% = valeur par défaut du jeu.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Nombre de camions par installation" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque installation peut envoyer.**\n" +
                    "100% = nombre de camions standard.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse de traitement des déchets par les installations.**\n" +
                    "100% = vitesse de traitement standard.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacité de stockage de l’installation" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu’une installation peut stocker.**\n" +
                    "100% = capacité de stockage standard.\n" +
                    "Des valeurs plus élevées = l’installation peut stocker plus de déchets.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Valeurs par défaut" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Rétablit tous les curseurs à **100%** (valeurs vanilla).\n" +
                    "Restaure le comportement normal du jeu."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applique les valeurs recommandées de Semi-magie :\n" +
                    "- Capacité des camions : **200%**\n" +
                    "- Nombre de camions par installation : **150%**\n" +
                    "- Vitesse de traitement : **200%**\n" +
                    "- Capacité de stockage : **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nom d’affichage de cette mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Version actuelle de la mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Ouvre la page **Paradox Mods** avec les mods de l’auteur."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Ouvre **Discord** dans votre navigateur pour le modding CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Mode de nettoyage automatique>\n" +
                    "  * Magie totale ACTIVÉE = **[ ✓ ]**\n" +
                    "  * Tous les déchets sont supprimés instantanément\n" +
                    " <-------------------------------------->\n\n" +
                    "<Mode de gestion manuelle>\n" +
                    "  * Activer la Semi-magie = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs [100 >> 500] comme vous voulez.\n" +
                    "  * Simulation vanilla avec des camions et installations plus puissants et configurables.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jeu vanilla normal>\n" +
                    "  * Semi-magie = **[ ✓ ]**\n" +
                    "  * Cliquez sur **[Valeurs par défaut]**\n" +
                    "  * Tous les curseurs à 100% (vanilla)\n" +
                    "  * Jeu standard.\n"
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
