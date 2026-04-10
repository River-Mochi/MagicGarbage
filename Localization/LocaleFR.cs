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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gestion directe" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Mode expert" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Statut" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "UTILISATION" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magie totale" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n\n" +
                    "Quand **Magie totale** est ON :\n" +
                    "- Gestion déchets est forcée sur OFF.\n" +
                    "- Les curseurs de Gestion déchets ne sont pas appliqués (les valeurs sont gardées pour plus tard).\n" +
                    "- Quelques camions peuvent encore rouler à cause du timing de dispatch vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Gestion déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gère directement les systèmes de déchets ; la logique vanilla continue de tourner.\n\n" +
                    "- Quand **Gestion déchets** est ON [ ✓ ], Magie totale est forcée sur OFF.\n" +
                    "- Les curseurs s'appliquent seulement quand Gestion déchets est activée.\n" +
                    "- Magie totale + Gestion déchets peuvent être **OFF** toutes les deux si seul le **rapport de statut** est nécessaire.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité des camions" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "**100% = valeur normale** du jeu.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stockage des sites" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu'un site peut stocker.**\n" +
                    "**100% = stockage vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Vitesse de traitement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les sites traitent les déchets entrants.**\n" +
                    "**100% = vitesse de traitement vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Flotte des sites" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque site peut envoyer.**\n" +
                    "**100% = nombre vanilla** de camions.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**Recommandé** : applique les valeurs standard de Gestion déchets.\n" +
                    "Ne change pas les réglages du mode expert (séparés)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Remet les curseurs de Gestion déchets sur les **valeurs vanilla**.\n" +
                    "Ne change <pas> les réglages du mode expert.\n" +
                    "**Vanilla :**\n" +
                    "- Les curseurs en % reviennent à **100%**.\n" +
                    "- Le seuil de demande d'envoi revient à **100 unités**.\n" +
                    "- Le seuil de ramassage revient à **20 unités**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Options du mode expert" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Réglages avancés optionnels\n" +
                    "<Attention : PAS nécessaire> pour un bon service ; prévu pour les joueurs qui veulent tester ou mieux comprendre le système.\n" +
                    "Quand **OFF**, tous les réglages du mode expert **restent vanilla**.\n" +
                    "Quand **ON**, les **curseurs avancés apparaissent**.\n\n" +
                    "<--- Exemples de bonheur --->\n" +
                    " - <Vanilla> 100/65 = 1re pénalité à <165>.\n" +
                    " - Cliquez sur <Recommandé> pour 550/150 = 1re pénalité à <700>.\n" +
                    " - <Très doux> 950/200 = 1re pénalité déchets à <1150>.\n" +
                    "Pratique : les dernières valeurs des curseurs sont gardées quand cette option est OFF (si besoin plus tard)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Seuil de demande d'envoi" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Niveau de déchets d'un bâtiment avant qu'une demande d'envoi de camion soit créée ou gardée.**\n" +
                    "Vanilla = **100** unités de déchets.\n" +
                    "**100 unités de déchets = 0.1t**\n" +
                    "**1 000 unités de déchets = 1t**\n" +
                    "Gardez cette valeur au niveau du seuil de ramassage ou au-dessus.\n" +
                    "Cela augmente souvent le nombre de camions utilisés au lieu des camions garés."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Seuil de ramassage" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Niveau minimum de déchets dans un bâtiment avant qu'un camion puisse les ramasser.**\n" +
                    "Vanilla = **20** unités de déchets.\n" +
                    "Le curseur de ramassage <ne peut pas> être plus élevé que la Demande d'envoi (DR) ; il est limité pour éviter un bug de logique.\n" +
                    "Si un camion est envoyé vers un bâtiment et que la valeur de ramassage est plus élevée que la DR, le camion peut parfois ne pas pouvoir collecter dans ce bâtiment (le taux d'accumulation joue aussi).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base du bonheur déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Niveau de déchets d'un bâtiment avant le début des pénalités santé + bonheur.**\n" +
                    "**Vanilla = 100** unités de déchets.\n" +
                    "Base plus élevée = les bâtiments peuvent contenir plus de déchets avant la première pénalité.\n" +
                    "100 unités de déchets = 0.1t\n" +
                    "Aperçu :\n" +
                    "- <Threshold> = point de déclenchement du système\n" +
                    "- <Baseline> = point de départ de la formule de pénalité\n" +
                    "- <Step> = taille du palier dans la formule, donc vitesse de montée de la pénalité"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Palier du bonheur déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Quantité de déchets au-dessus de la base qui déclenche le début d'une pénalité de -1.**\n" +
                    "Vanilla = **65** unités de déchets.\n" +
                    "Palier plus élevé = croissance plus lente de la pénalité.\n" +
                    "Le jeu limite la pénalité déchets à **-10**.\n" +
                    "La première pénalité vanilla <-1 penalty> arrive à **165 déchets** (100 base + 65 palier)\n" +
                    "Modifier les seuils sans ajuster les curseurs de bonheur peut entraîner des pénalités plus fortes que la normale."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Taux d'accumulation des déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Met à l'échelle les valeurs de source de déchets des bâtiments pris en charge.**\n" +
                    "C'est un gros levier et changer ce taux affecte beaucoup de choses.\n" +
                    "Il est possible d'avoir un bon système sans l'utiliser.\n\n" +
                    "**100% = accumulation vanilla**.\n" +
                    "**20%** = accumulation bien plus lente.\n" +
                    "**200%** = taux doublé - énormément de déchets.\n" +
                    "À 20%, tous les cims font clairement du compost, donc moins de déchets ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Applique les valeurs **recommandées** du mode expert.\n" +
                    "Active le mode expert.\n" +
                    "La première pénalité déchets commence à **700** déchets (550 base + 150 palier).\n" +
                    "Le taux d'accumulation des déchets reste à **100%** vanilla sauf changement manuel."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Remet les valeurs du mode expert **sur vanilla**.\n" +
                    "Met le **mode expert** sur OFF.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nom affiché de ce mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Version actuelle du mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Ouvre la page Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Ouvre l'invitation Discord dans le navigateur." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<État nettoyage auto>\n" +
                    "  * Magie totale ON = **[ ✓ ]**\n" +
                    "  * Les déchets sont supprimés automatiquement - terminé.\n" +
                    " <-------------------------------------->\n\n" +
                    "<État gestion directe>\n" +
                    "  * Gestion déchets = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs comme voulu.\n" +
                    "  * Optionnel : activez les curseurs avancés (pas obligatoire).\n" +
                    "  * Même système de déchets du jeu ; camions/sites mieux gérés.\n" +
                    " <-------------------------------------->\n\n" +
                    "<État statut / vanilla>\n" +
                    "  * Magie totale = OFF\n" +
                    "  * Gestion déchets = OFF\n" +
                    "  * Rapport de statut uniquement.\n" +
                    "  * Le système de déchets vanilla ne change pas."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Utilisation" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Indice du service déchets" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Indice simple du bonheur déchets à l'échelle de la ville, fourni par le jeu.\n" +
                    "**0 = Excellent**\n" +
                    "**-1 = Petit ajustement utile** le jeu peut souvent osciller entre 0 et -1, donc cela peut être ignoré.\n" +
                    "**-2 à -4 = Un peu nauséabond**\n" +
                    "**-5 à -10 = Problème de déchets**\n" +
                    "**Réglages indirects :** les curseurs camions/sites/seuils peuvent améliorer cela avec le temps en réduisant l'accumulation réelle des déchets.\n" +
                    "**Réglages directs :** <Base du bonheur déchets> + <Palier du bonheur déchets> changent ce que les cims tolèrent avant d'être mécontents.\n" +
                    "**Réglage du rythme source :** <Taux d'accumulation des déchets> change la vitesse à laquelle les bâtiments pris en charge produisent des déchets.\n" +
                    "<Heure de mise à jour = dernier rafraîchissement.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la quantité actuelle de déchets dans toute la ville et le taux total de traitement.\n" +
                    "Augmentez le traitement si la quantité de déchets produite par mois est bien plus élevée.\n" +
                    "**Produit** et **Traité** utilisent des tonnes par mois.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**En attente** = demandes de collecte actives qui ne sont pas encore assignées à un camion ou à un trajet.\n" +
                    "**Envoyées** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = nombre de demandes **actives** actuelles (dans la chaîne déchets).\n\n" +
                    "Note technique : différent de <Au-dessus du seuil de demande>. Ici on compte des <demandes>, pas des bâtiments.\n" +
                    "Certaines demandes en attente seront assignées plus tard ; d'autres peuvent aussi disparaître si la revalidation vanilla décide que la cible n'a plus besoin du service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**A des déchets** = bâtiments qui contiennent actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets de la ville.\n" +
                    "**Au-dessus du seuil de demande** = nombre actuel de **bâtiments** ayant assez de déchets pour créer une demande de collecte.\n" +
                    "En vanilla, le seuil de demande est de **100** unités internes de déchets.\n" +
                    "Les options du mode expert peuvent remplacer les seuils de demande et de ramassage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Installations" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des installations de déchets comptées.\n" +
                    "**Installations** = bâtiments de déchets comptés.\n" +
                    "**Camions poubelles** = camions de collecte normaux. Dans les installations de déchets industriels, ils collectent les déchets industriels au lieu des déchets classiques.\n" +
                    "**Camions-bennes** = transferts de déchets entre installations.\n" +
                    "**Travailleurs max** = capacité totale de travailleurs sur ces mêmes installations."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Camions poubelles" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En mouvement** = camions actuellement dehors dans la ville.\n" +
                    "**Retour** = sous-ensemble des camions en mouvement marqués pour revenir à leur installation.\n" +
                    "**Garés** = camions garés dans une installation.\n" +
                    "**Total** = nombre de tous les camions poubelles."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Statut détaillé dans le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envoie un rapport déchets plus détaillé dans **Logs/MagicGarbage.log**.\n" +
                    "Inclut une petite légende, les valeurs vanilla de référence et beaucoup d'autres statistiques réelles de la ville."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre le dossier Logs/.. du jeu."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée pour le moment." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | maj {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Petit ajustement conseillé ({0:N0}) | maj {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Un peu nauséabond ({0:N0}) | maj {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problème de déchets ({0:N0}) | maj {1}" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {1:N0} t traitées" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} envoyées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ont des déchets | {2:N0} au-dessus du seuil" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} installations | {1:N0}/{2:N0} ordures/Dump camions | {3:N0} travailleurs" },
                { "MG.Status.Row.Trucks", "{1:N0} en route ({3:N0} retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Pas encore de données sur les installations." },

                // Log strings
                { "MG.Status.Log.Title", "Statut des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Magie totale={0}, Gestion déchets={1}" },
                { "MG.Status.Log.SettingsHeader", "Réglages actuels du mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Curseurs Gestion déchets (sauvegardés) : charge camion={0:N0}% | stockage site={1:N0}% | traitement site={2:N0}% | flotte site={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Mode expert (sauvegardé) : activé={0} | demande={1:N0} | ramassage={2:N0} | base bonheur={3:N0} | palier bonheur={4:N0} | taux d'accumulation={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- Produit/Traité utilise des tonnes par mois.\n" +
                    "- Les valeurs de seuil ci-dessous utilisent des unités internes de déchets, pas des tonnes.\n" +
                    "- Pour le joueur, le jeu convertit 100 unités = 0.1t et 1 000 unités = 1t.\n" +
                    "- Indice du service déchets = facteur de bonheur déchets de la ville dans le jeu.\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = Petit ajustement utile, ou à ignorer\n" +
                    "  - -2 à -4 = Un peu nauséabond\n" +
                    "  - -5 à -10 = Problème de déchets\n" +
                    "Curseurs de seuil :\n" +
                    "  - Seuil de ramassage = quantité minimale de déchets avant qu'un camion collecte dans un bâtiment.\n" +
                    "  - Seuil de demande = quantité minimale de déchets avant que le jeu crée ou garde une demande de collecte.\n" +
                    "- Icône d'alerte = quantité de déchets qui fait apparaître une icône d'alerte au-dessus d'un bâtiment.\n" +
                    "- Limite dure = quantité maximale de déchets qu'un bâtiment peut accumuler.\n" +
                    "- En attente = demandes actives qui ne sont pas encore assignées à un camion ou à un trajet.\n" +
                    "- Certaines demandes en attente seront assignées plus tard ; d'autres peuvent aussi disparaître si la revalidation vanilla décide que la cible n'a plus besoin du service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Seuils du jeu (unités internes de déchets) : ramassage={1:N0}, demande={0:N0}, icône d'alerte={2:N0}, limite dure={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData indisponible>" },
                { "MG.Status.Log.GarbageProcessing", "Déchets : {0:N0} t/mois | Traitement : {1:N0} t/mois" },
                { "MG.Status.Log.GarbageServiceRating", "Indice du service déchets : {0} | brut={1:N2} | arrondi={2:N0}" },
                { "MG.Status.Log.Requests", "Demandes de collecte : en attente={1:N0}, envoyées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Cible en attente la plus chargée : {0:N0} ({1:N1}t) à {2}" },
                { "MG.Status.Log.PendingPeakNone", "Cible en attente la plus chargée : aucune" },
                { "MG.Status.Log.Producers", "Bâtiments : {0:N0} icônes d'alerte | {1:N0} total | {2:N0} ont des déchets | {3:N0} au-dessus du seuil de demande " },
                { "MG.Status.Log.ProducerGarbageStats", "Déchets des bâtiments (non zéro seulement) : moy={0:N0} ({1:N1}t) | médiane={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) à {6}" },
                { "MG.Status.Log.NearWarning75", "Bâtiments proches de l'icône d'alerte (au moins {1:N0} unités / {2:N1}t) : {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Installations : {0:N0} total | {1:N0} camions poubelles | {2:N0} camions-bennes ({3:N0} en mouvement) | {4:N0} travailleurs" },
                { "MG.Status.Log.Trucks", "Camions poubelles : {2:N0} en mouvement ({3:N0} retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des installations" },
                { "MG.Status.Log.FacilityLine", "- Installation {0} : camions poubelles={1:N0} ({2:N0} en mouvement, {3:N0} garés) | camions-bennes={4:N0} ({5:N0} en mouvement) | travailleurs max={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Petit ajustement utile" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Un peu nauséabond" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problème de déchets" },
            };
        }

        public void Unload()
        {
        }
    }
}
