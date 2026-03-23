// File: Localization/LocalePT_BR.cs
// Portuguese (Brazil) pt-BR

namespace MagicGarbage
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

    public sealed class LocalePT_BR : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocalePT_BR(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "Sobre" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia Total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** remove instantaneamente todo o lixo da cidade.\n\n" +

                    "Enquanto **Magia Total** estiver LIGADA:\n" +
                    "- Semi Magic é forçado a DESLIGAR.\n" +
                    "- Os sliders do Semi Magic **não são aplicados** (seus valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem circular por causa da lógica de despacho do jogo (geralmente vazios)."
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gerencie o sistema de lixo diretamente; a lógica vanilla continua rodando.\n\n" +
                    "- Quando **Semi Magic estiver LIGADO [ ✓ ]**, Magia Total é desligada automaticamente.\n" +
                    "- Os sliders só valem quando Semi Magic estiver ligado [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacidade do caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "100% = padrão do jogo.\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidade de processamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo.**\n" +
                    "100% = velocidade vanilla.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidade de armazenamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "100% = armazenamento vanilla.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Quantidade de caminhões na instalação"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "100% = quantidade vanilla.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica valores recomendados do Semi-Magic:\n" +
                    "- Capacidade do caminhão: **200%**\n" +
                    "- Velocidade de processamento: **200%**\n" +
                    "- Armazenamento: **160%**\n" +
                    "- Caminhões na instalação: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "Padrão do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Volta todos os sliders para **100%** (valores vanilla).\n" +
                    "Restaura o comportamento normal do jogo."
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome exibido deste mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versão atual do mod."
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Abre a página do autor no **Paradox Mods**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "Abre o **Discord** no navegador (CS2 Modding)."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Estado de limpeza automática>\n" +
                    "  * Magia Total LIGADA = **[ ✓ ]**\n" +
                    "  * Todo o lixo é removido instantaneamente\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de gerenciamento manual>\n" +
                    "  * Semi-Magic LIGADO = **[ ✓ ]**\n" +
                    "  * Ajuste os sliders como quiser.\n" +
                    "  * Lógica vanilla + caminhões/instalações melhor gerenciados.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo vanilla normal>\n" +
                    "  * Semi-Magic LIGADO = **[ ✓ ]**\n" +
                    "  * Clique em **[Padrão do jogo]**\n" +
                    "  * Todos os sliders em 100% (vanilla)\n"
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
