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
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Infos du mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liens" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Activé [ ✓ ]** garde toute la ville propre.\n\n" +
                    "Quand **Total Magic** est activé :\n" +
                    "- Trash Boss est forcé sur OFF.\n" +
                    "- Les curseurs Trash Boss ne sont pas appliqués (les valeurs sont conservées pour plus tard).\n" +
                    "- Quelques camions peuvent encore bouger à cause du timing de répartition vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gère directement les systèmes de déchets ; laisse la logique vanilla tourner.\n\n" +
                    "- Quand **Trash Boss est activé [ ✓ ]**, Total Magic est forcé sur OFF.\n" +
                    "- Les curseurs ne s'appliquent que lorsque Trash Boss est activé.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacité de chargement" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quantité de déchets que chaque camion peut transporter.**\n" +
                    "100% = valeur normale du jeu.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Stockage du site" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quantité de déchets qu'un site peut stocker.**\n" +
                    "100% = stockage vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Vitesse de traitement du site" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Vitesse à laquelle les sites traitent les déchets entrants.**\n" +
                    "100% = vitesse de traitement vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Facility Fleet" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Nombre de camions que chaque site peut envoyer.**\n" +
                    "100% = nombre de camions vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "Seuils des bâtiments" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "Optionnel : augmente les **seuils** qu'un bâtiment doit atteindre pour obtenir une collecte des déchets. \n" +
                    "Augmenter ceci peut aider à réduire le trafic des camions-poubelles ; mais trop haut réduit les trajets de collecte.\n" +
                    "La plupart des gens n'ont <pas> besoin d'ajuster ceci. Le mod fonctionnait bien avant cette option ; c'est juste un bonus pour les essais.\n"+
                    "--------------------------------\n" +
                    "- **Seuil de demande d'envoi (R)** = quantité de déchets nécessaire pour appeler une <demande d'envoi de camion>.\n" +
                    "- **Seuil de ramassage (P)** = quantité minimale de déchets avant qu'un camion puisse les ramasser.\n" +
                    "**1x** = vanilla (100 R, 20 P). Remarque : **1 000** unités de déchets = généralement **1 t**.\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "Avec le curseur sur **20x**, le **R** du bâtiment doit atteindre >= **2 000 (2t)** unités avant qu'un camion reçoive une <demande d'envoi> ;\n" +
                    "Le jeu vanilla fait aussi arrêter les camions aux bâtiments à l'aller/retour du bâtiment de <dispatch> si le camion n'est pas vide ; à 20x, les bâtiments sur la route doivent avoir plus de **400 déchets** (20 x P vanilla = 20).\n" +
                    "Équilibrage conseillé : regardez souvent le bouton de rapport détaillé dans le journal pendant les réglages.\n" +
                    "Il peut falloir augmenter la capacité des camions si vous montez beaucoup ce seuil, car les maisons gardent les déchets bien plus longtemps avant d'appeler un camion."
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recommandé" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Applique les valeurs recommandées de Trash Boss :\n" +
                    "- Capacité de chargement : **200%**\n" +
                    "- Seuil d'envoi : **5x**\n" +
                    "- Vitesse de traitement : **200%**\n" +
                    "- Capacité de stockage : **150%**\n" +
                    "- Nombre de camions du site : **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Valeurs du jeu" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Remet tous les curseurs Trash Boss aux valeurs vanilla.\n" +
                    "- Les curseurs en pourcentage reviennent à **100%**.\n" +
                    "- Le seuil d'envoi revient à **1x**."
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
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Les déchets sont supprimés automatiquement - Terminé.\n" +
                    " <-------------------------------------->\n\n" +
                    "<État gestion manuelle>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Réglez les curseurs comme voulu.\n" +
                    "  * Même système de déchets du jeu ; meilleurs camions/sites gérés manuellement.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jeu vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * Tous les curseurs sont aux valeurs vanilla\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Utilisation" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Déchets/mois" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Affiche la quantité actuelle de déchets dans toute la ville et le taux total de traitement.\n" +
                    "Augmentez le traitement si les déchets produits par mois sont bien plus élevés.\n" +
                    "**Produit** et **Traité** utilisent des tonnes par mois.\n" +
                    "<Heure de mise à jour = dernier rafraîchissement.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Demandes de collecte" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**En attente** = demandes de collecte actives qui ne sont pas actuellement assignées à un camion ou à un trajet.\n" +
                    "**Envoyées** = demandes de collecte actives déjà assignées.\n" +
                    "**Total** = compte les entités de demande **actives** actuelles (dans la chaîne de déchets).\n\n" +
                    "Note technique : c'est différent de <Au-dessus du seuil de demande>. Ici on compte des <demandes>, pas des bâtiments.\n" +
                    "Certaines demandes en attente seront assignées plus tard ; d'autres peuvent aussi disparaître plus tard si la revalidation vanilla décide que la cible n'a plus besoin de service."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Buildings" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**A des déchets** = bâtiments qui contiennent actuellement des déchets.\n" +
                    "**Total** = tous les bâtiments producteurs de déchets de la ville.\n" +
                    "**Au-dessus du seuil de demande** = nombre actuel de **bâtiments** avec assez de déchets pour créer une demande de collecte.\n" +
                    "En vanilla, le seuil de demande est de **100** unités internes de déchets.\n" +
                    "Le **seuil d'envoi** de Trash Boss augmente ensemble les seuils de ramassage et de demande.\n" +
                    "Cela réduit le trafic des camions-poubelles car cela baisse le total de bâtiments <au-dessus du seuil de demande> et le total <envoyé>."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Sites" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Résumé des sites de déchets comptés.\n" +
                    "**Sites** = bâtiments de déchets comptés.\n" +
                    "**Camions totaux** = camions-poubelles appartenant à ces sites.\n" +
                    "**Travailleurs max** = capacité totale de travailleurs sur ces mêmes sites."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**En mouvement** = camions actuellement dans la ville.\n" +
                    "**Retour** = sous-ensemble des camions en mouvement marqués pour rentrer au site.\n" +
                    "**Garés** = camions garés sur un site.\n" +
                    "**Total** = nombre de tous les camions-poubelles."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Statut détaillé dans le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envoie un rapport plus détaillé sur les déchets dans **Logs/MagicGarbage.log**.\n" +
                    "Inclut une courte légende, des valeurs de référence vanilla et beaucoup de statistiques réelles supplémentaires sur les déchets de la ville."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Ouvrir le journal" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Ouvre le dossier Logs/.. du jeu."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Aucune ville chargée pour le moment." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produites | {1:N0} t traitées | maj {2}" },
                { "MG.Status.Row.Requests", "{1:N0} en attente | {2:N0} envoyées | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ont des déchets | {2:N0} au-dessus du seuil de demande" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} installations | {1:N0} camions au total | {2:N0} employés max" },
                { "MG.Status.Row.Trucks", "{1:N0} en circulation ({3:N0} en retour) | {2:N0} garés | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Aucune donnée d'installation pour le moment." },

                // Log strings
                { "MG.Status.Log.Title", "État des déchets ({0})" },
                { "MG.Status.Log.City", "Ville : {0}" },
                { "MG.Status.Log.Mode", "Mode : Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Légende :\n" +
                    "- Produit/Traité utilise des tonnes par mois.\n" +
                    "- Les valeurs de seuil ci-dessous utilisent des unités internes de déchets, pas des tonnes.\n" +
                    "- Pour l'affichage joueur, le jeu convertit 1 000 unités = 1t.\n" +
                    "Curseur de seuil de dispatch :\n" +
                    "  - Seuil de ramassage = quantité minimale de déchets avant qu'un camion collecte dans un bâtiment.\n" +
                    "  - Seuil de demande = quantité minimale de déchets avant que le jeu crée ou garde une demande de collecte.\n" +
                    "- Icône d'avertissement = quantité de déchets qui fait apparaître une icône d'avertissement au-dessus d'un bâtiment.\n" +
                    "- Plafond max = quantité maximale de déchets qu'un bâtiment peut accumuler.\n" +
                    "- En attente = demandes actives qui ne sont actuellement assignées à aucun camion ni trajet.\n" +
                    "- Certaines demandes en attente seront assignées plus tard ; d'autres peuvent aussi disparaître plus tard si la revalidation vanilla décide que la cible n'a plus besoin de service.\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "Seuils du jeu (unités internes de déchets) : ramassage={1:N0}, demande={0:N0}, icône d'avertissement={2:N0}, plafond max={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Seuils : <GarbageParameterData non disponible>" },
                { "MG.Status.Log.GarbageProcessing", "Déchets : {0:N0} t/mois | Traitement : {1:N0} t/mois" },
                { "MG.Status.Log.Requests", "Demandes de collecte : en attente={1:N0}, envoyées={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Plus grande cible en attente : {0:N0} ({1:N1}t) à {2}" },
                { "MG.Status.Log.Producers", "Bâtiments : {0:N0} total | {1:N0} ont des déchets | {2:N0} au-dessus du seuil de demande | {3:N0} au niveau d'avertissement" },
                { "MG.Status.Log.ProducerGarbageStats", "Déchets des bâtiments (non nuls seulement) : moy={0:N0} ({1:N1}t) | médiane={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) à {6}" },
                { "MG.Status.Log.NearWarning75", "Bâtiments proches de l'avertissement (>= {1:N0} unités / {2:N1}t) : {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Installations : {0:N0} total | {1:N0} camions au total | {2:N0} employés max" },
                { "MG.Status.Log.Trucks", "Camions-bennes : {2:N0} en circulation ({3:N0} en retour) | {1:N0} garés | {4:N0} désactivés | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Résumé des installations" },
                { "MG.Status.Log.FacilityLine", "- Installation {0} : en circulation={2:N0}, garés={3:N0}, total={1:N0}, employés max={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
