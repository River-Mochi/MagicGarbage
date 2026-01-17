// File: Localization/LocaleFR.cs
// French (fr-FR)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Infos mod"             },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens"                 },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTES D’UTILISATION"   },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magie totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** supprime instantanément tous les déchets de la ville.\n\n" +

                    "Quand **Magie totale** est ACTIVÉE :\n" +
                    "- La Semi-magie est forcée sur OFF.\n" +
                    "- Les curseurs de Semi-magie **ne sont pas appliqués** (vos valeurs sont conservées).\n" +
                    "- Quelques camions peuvent encore rouler à cause de la logique de dispatch du jeu (souvent à vide)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-magie" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gérez directement les systèmes de déchets ; la logique vanilla reste active.\n\n" +
                    "- Quand **Semi-magie est ACTIVÉE [ ✓ ]**, Magie totale est automatiquement désactivée.\n" +
                    "- Les curseurs ne s’appliquent que si la Semi-magie est activée [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacité de chargement du camion" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "100% = valeur normale du jeu.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les installations traitent les déchets.**\n" +
                    "100% = vitesse vanilla.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacité de stockage de l’installation" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu’une installation peut stocker.**\n" +
                    "100% = stockage vanilla.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Camions par installation"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque installation peut envoyer.**\n" +
                    "100% = nombre vanilla.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Applique les valeurs recommandées de Semi-magie :\n" +
                    "- Capacité de chargement du camion : **200%**\n" +
                    "- Vitesse de traitement : **200%**\n" +
                    "- Capacité de stockage : **160%**\n" +
                    "- Camions par installation : **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Remet tous les curseurs à **100%** (valeurs vanilla).\n" +
                    "Restaure le comportement normal du jeu."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nom affiché de cette mod."
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
                    "<État : Nettoyage automatique>\n" +
                    "  * Magie totale ACTIVÉE = **[ ✓ ]**\n" +
                    "  * Tous les déchets sont supprimés instantanément\n" +
                    " <-------------------------------------->\n\n" +
                    "<État : Gestion manuelle>\n" +
                    "  * Activer la Semi-magie = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs comme vous voulez.\n" +
                    "  * Logique vanilla avec camions/installations améliorés.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jeu vanilla normal>\n" +
                    "  * Activer la Semi-magie = **[ ✓ ]**\n" +
                    "  * Cliquez sur **[Valeurs du jeu]**\n" +
                    "  * Tous les curseurs à 100% (vanilla)\n"
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
