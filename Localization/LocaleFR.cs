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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "À propos" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Nettoyage auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestion manuelle" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Avancé" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Statut" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UTILISATION" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n\n" +
                    "Quand **Total Magic** est ON :\n" +
                    "- Trash Boss est forcé sur OFF.\n" +
                    "- Les curseurs Trash Boss ne sont pas appliqués (les valeurs restent sauvegardées).\n" +
                    "- Quelques camions peuvent encore rouler à cause du timing d’envoi vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Permet de gérer directement le système des déchets ; la logique vanilla continue de tourner.\n\n" +
                    "- Quand **Trash Boss est ON [ ✓ ]**, Total Magic est forcé sur OFF.\n" +
                    "- Les curseurs ne s’appliquent que si Trash Boss est activé.\n" +
                    "- Total Magic + Trash Boss peuvent être **OFF** tous les deux si seul le **rapport de statut** est voulu.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "**100% = valeur normale** du jeu.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stockage du site" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu’un site peut stocker.**\n" +
                    "**100% = stockage vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les sites traitent les déchets entrants.**\n" +
                    "**100% = vitesse vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotte du site" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque site peut envoyer.**\n" +
                    "**100% = nombre vanilla** de camions.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Options avancées" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**Réglages avancés optionnels pour les seuils + le bonheur lié aux déchets.**\n" +
                    "Quand **OFF**, les seuils ramassage/demande et le bonheur des déchets **restent vanilla**.\n" +
                    "Quand **ON**, les **curseurs avancés apparaissent**.\n\n" +
                    "<--- Exemples de bonheur déchets --->\n"+
                    " - <Vanilla> 100/65 = 1re pénalité à <165>.\n" +
                    " - <Recommandé> 550/150 = 1re pénalité à <700>.\n" +
                    " - <Très doux> 950/200 = 1re pénalité à <1150>.\n" +
                    "Pratique : les dernières valeurs sont gardées quand cette option est OFF (si besoin plus tard)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Seuil de demande d’envoi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantité de déchets dans un bâtiment avant création ou maintien d’une demande d’envoi de camion.**\n" +
                    "Vanilla = **100** unités de déchets.\n" +
                    "**100 unités de déchets = 0.1t**\n" +
                    "**1 000 unités de déchets = 1t**\n" +
                    "Gardez cette valeur au moins égale au seuil de ramassage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Seuil de ramassage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantité minimale de déchets dans un bâtiment avant qu’un camion puisse les ramasser.**\n" +
                    "Vanilla = **20** unités de déchets.\n" +
                    "Le seuil de ramassage ne peut jamais dépasser le seuil de demande d’envoi.\n" +
                    "Gardez le seuil de demande au moins égal à la valeur de ramassage pour éviter une logique bancale ;" +
                    " si un camion est envoyé vers un bâtiment et que la valeur de ramassage est plus haute, il pourrait ne pas pouvoir ramasser (le taux d’accumulation joue aussi).\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applique les valeurs standard **recommandées** de Trash Boss.\n" +
                    "Ne change pas les réglages Power User."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Remet les curseurs Trash Boss sur les **valeurs vanilla**.\n" +
                    "Ne change <pas> les réglages Power User.\n" +
                    "**Vanilla :**\n" +
                    "- Les curseurs en % reviennent à **100%**.\n" +
                    "- Le seuil de demande revient à **100 unités**.\n" +
                    "- Le seuil de ramassage revient à **20 unités**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base bonheur déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Niveau de déchets d’un bâtiment avant le début des pénalités santé + bonheur.**\n" +
                    "**Vanilla = 100** unités de déchets.\n" +
                    "Base plus haute = les bâtiments peuvent contenir plus de déchets avant la pénalité.\n" +
                    "100 unités de déchets = 0.1t\n" +
                    "Aperçu :\n" +
                    "- <Seuil> = point de déclenchement du système\n" +
                    "- <Base> = point de départ de la formule de pénalité\n"+
                    "- <Pas> = taille d’incrément de la formule, donc vitesse de montée de la pénalité"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Pas bonheur déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Quantité de déchets au-dessus de la base qui déclenche une pénalité de -1.**\n" +
                    "Vanilla = **65** unités de déchets.\n" +
                    "Pas plus élevé = pénalité plus lente.\n" +
                    "Le jeu limite la pénalité déchets à **-10**.\n" +
                    "La première pénalité vanilla <-1 penalty> arrive à **165 déchets** (100 base + 65 pas)\n" +
                    "Ajustez les seuils avec les curseurs de bonheur sinon les pénalités peuvent devenir plus fortes que la normale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applique les valeurs Power User **recommandées**.\n" +
                    "Active Power User.\n" +
                    "La première pénalité déchets démarre à **700** déchets (550 base + 150 pas)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Remet les valeurs Power User **sur vanilla**.\n" +
                    "Désactive **Power User**."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nom affiché du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Ouvre la page Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Ouvre l’invitation Discord dans le navigateur." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<État nettoyage auto>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Les déchets sont supprimés auto - fini.\n" +
                    " <-------------------------------------->\n\n" +
                    "<État gestion manuelle>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs comme voulu.\n" +
                    "  * Optionnel : activez Power User pour les seuils + bonheur déchets.\n" +
                    "  * Même système de déchets du jeu ; camions/sites mieux gérés.\n" +
                    " <-------------------------------------->\n\n" +
                    "<État statut / vanilla>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * Rapport de statut uniquement.\n" +
                    "  * Le système vanilla des déchets reste inchangé."

                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Utilisation" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la quantité actuelle de déchets dans la ville et le taux total de traitement.\n" +
                    "Augmentez le traitement si les déchets produits par mois sont bien plus élevés.\n" +
                    "**Produit** et **Traité** sont en tonnes par mois.\n" +
                    "<Heure de mise à jour = dernier rafraîchissement.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**En attente** = demandes de collecte actives pas encore assignées à un camion ou à un trajet.\n" +
                    "**Envoyées** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = nombre actuel d’entités de demande **actives** (dans la chaîne déchets).\n\n" +
                    "Note technique : différent de <Au-dessus du seuil de demande>. Ici on compte des <demandes>, pas des bâtiments.\n" +
                    "Certaines demandes en attente seront assignées plus tard ; d’autres peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin du service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**A des déchets** = bâtiments qui ont actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets de la ville.\n" +
                    "**Au-dessus du seuil de demande** = nombre actuel de **bâtiments** avec assez de déchets pour créer une demande de collecte.\n" +
                    "En vanilla, le seuil de demande est de **100** unités internes de déchets.\n" +
                    "Power User peut remplacer les seuils de demande et de ramassage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Sites" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des sites de déchets comptés.\n" +
                    "**Sites** = bâtiments de déchets comptés.\n" +
                    "**Camions poubelles** = camions de collecte normaux. Dans les sites de déchets industriels, ils collectent les déchets industriels au lieu des déchets classiques.\n" +
                    "**Dump trucks** = transferts inter-sites de déchets.\n" +
                    "**Travailleurs max** = capacité totale de travailleurs pour ces mêmes sites."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En route** = camions actuellement dehors en ville.\n" +
                    "**Retour** = sous-partie des camions en route qui reviennent au site.\n" +
                    "**Garés** = camions garés sur un site.\n" +
                    "**Total** = nombre de tous les camions poubelles."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Statut détaillé dans le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envoie un rapport déchets plus détaillé dans **Logs/MagicGarbage.log**.\n" +
                    "Inclut une petite légende, les valeurs vanilla de référence et beaucoup d’autres stats réelles de la ville."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre le dossier Logs/.. du jeu."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {1:N0} t traitées | maj {2}" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} envoyées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ont des déchets | {2:N0} au-dessus du seuil" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} sites | {1:N0} camions poubelles | {2:N0} dump trucks | {3:N0} travailleurs max" },
                { "MG.Status.Row.Trucks", "{1:N0} en route ({3:N0} retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Pas encore de données de site." },

                // Log strings
                { "MG.Status.Log.Title", "Statut des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- Produit/Traité utilise des tonnes par mois.\n" +
                    "- Les seuils ci-dessous utilisent des unités internes de déchets, pas des tonnes.\n" +
                    "- Pour le joueur, le jeu convertit 100 unités = 0.1t et 1 000 unités = 1t.\n" +
                    "Curseurs de seuil :\n" +
                    "  - Seuil de ramassage = déchets minimum avant qu’un camion ramasse dans un bâtiment.\n" +
                    "  - Seuil de demande = déchets minimum avant que le jeu crée ou garde une demande de collecte.\n" +
                    "- Icône d’alerte = quantité de déchets qui fait apparaître une alerte au-dessus d’un bâtiment.\n" +
                    "- Limite dure = quantité max de déchets qu’un bâtiment peut accumuler.\n" +
                    "- En attente = demandes actives pas encore assignées à un camion ou un trajet.\n" +
                    "- Certaines demandes en attente seront assignées plus tard ; d’autres peuvent aussi disparaître si la revalidation vanilla décide que la cible n’a plus besoin du service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Seuils du jeu (unités internes de déchets) : ramassage={1:N0}, demande={0:N0}, icône d’alerte={2:N0}, limite dure={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData indisponible>" },
                { "MG.Status.Log.GarbageProcessing", "Déchets : {0:N0} t/mois | Traitement : {1:N0} t/mois" },
                { "MG.Status.Log.Requests", "Demandes de collecte : attente={1:N0}, envoyées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Cible en attente la plus chargée : {0:N0} ({1:N1}t) à {2}" },
                { "MG.Status.Log.Producers", "Bâtiments : {0:N0} total | {1:N0} ont des déchets | {2:N0} au-dessus du seuil | {3:N0} niveau alerte" },
                { "MG.Status.Log.ProducerGarbageStats", "Déchets des bâtiments (non zéro seulement) : moy={0:N0} ({1:N1}t) | médiane={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) à {6}" },
                { "MG.Status.Log.NearWarning75", "Bâtiments proches de l’alerte (au moins {1:N0} unités / {2:N1}t) : {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Sites : {0:N0} total | {1:N0} camions poubelles | {2:N0} dump trucks ({3:N0} en route) | {4:N0} travailleurs" },
                { "MG.Status.Log.Trucks", "Camions poubelles : {2:N0} en route ({3:N0} retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des sites" },
                { "MG.Status.Log.FacilityLine", "- Site {0} : garbage={1:N0} ({2:N0} en route, {3:N0} garés) | dump={4:N0} ({5:N0} en route) | travailleurs max={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
