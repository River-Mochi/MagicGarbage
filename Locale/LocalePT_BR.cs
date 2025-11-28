// Locale/LocalePT_BR.cs
// Portuguese (pt-BR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "Gerenciar sozinho"  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Info da mod"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links"             },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO"      },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** remove instantaneamente todo o lixo da cidade.\n" +
                    "Prédios e caminhões de lixo se tornam praticamente decorativos.\n\n" +

                    "Enquanto **Magia total** estiver ATIVADA:\n" +
                    "- Semi-Magia é desativada automaticamente.\n" +
                    "- Todos os controles deslizantes de Semi-Magia são ignorados.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "Semi-Magia" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "Gerencie diretamente os sistemas de lixo; a lógica vanilla continua rodando.\n\n" +
                    "- Quando **Semi-Magia está ATIVADA [ ✓ ]**, Magia total é desligada automaticamente.\n" +
                    "- Ajuste todos os caminhões e instalações de lixo.\n" +
                    "- Os deslizadores só têm efeito quando Semi-Magia está ativada [ ✓ ].\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "Capacidade de carga do caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "100% = padrão do jogo.\n" +
                    "<100% = 20 t>\n" +
                    "<500% = 100 t.>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "Caminhões por instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode enviar.**\n" +
                    "100% = quantidade padrão de caminhões.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "Velocidade de processamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo que chega.**\n" +
                    "100% = velocidade de processamento padrão.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "Capacidade de armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "100% = capacidade de armazenamento padrão.\n" +
                    "Valores maiores = a instalação pode guardar mais lixo.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "Retorna todos os deslizadores para **100%** (valores vanilla).\n" +
                    "Restaura o comportamento normal do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "Aplica os valores recomendados de Semi-Magia:\n" +
                    "- Capacidade do caminhão: **200%**\n" +
                    "- Caminhões por instalação: **150%**\n" +
                    "- Velocidade de processamento: **200%**\n" +
                    "- Capacidade de armazenamento: **150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "Nome exibido desta mod."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "Versão atual da mod."
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
                    "Abre o **Discord** no navegador para o modding de CS2."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Modo de limpeza automática>\n" +
                    "  * Magia total ATIVADA = **[ ✓ ]**\n" +
                    "  * Todo lixo é removido instantaneamente\n" +
                    " <-------------------------------------->\n\n" +
                    "<Modo de auto-gerenciamento>\n" +
                    "  * Ative Semi-Magia = **[ ✓ ]**\n" +
                    "  * Ajuste os deslizadores [100 >> 500] como quiser.\n" +
                    "  * Simulação vanilla com caminhões e instalações mais fortes e ajustáveis.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo vanilla normal>\n" +
                    "  * Semi-Magia = **[ ✓ ]**\n" +
                    "  * Clique em **[Padrões do jogo]**\n" +
                    "  * Todos os deslizadores em 100% (vanilla)\n" +
                    "  * Jogabilidade padrão.\n"
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
