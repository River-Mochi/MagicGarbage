// File: Locale/LocalePT_BR.cs
// Portuguese (pt-BR)

namespace MagicGarbage
{
    using Colossal;
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Ações" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Sobre" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza automática" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "NOTAS DE USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n\n" +
                    "Enquanto **Total Magic** estiver ON:\n" +
                    "- Trash Boss é forçado para OFF.\n" +
                    "- Os sliders do Trash Boss não são aplicados (os valores ficam salvos).\n"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gerencia o sistema de lixo diretamente, mantendo a lógica vanilla ativa.\n\n" +
                    "- Quando **Trash Boss está ON [ ✓ ]**, Total Magic é forçado para OFF.\n" +
                    "- Os sliders só valem quando Trash Boss está ativado.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade de carga dos caminhões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão consegue carregar.**\n" +
                    "100% = valor padrão do jogo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo recebido.**\n" +
                    "100% = velocidade vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Capacidade de armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação consegue armazenar.**\n" +
                    "100% = armazenamento vanilla.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "100% = número vanilla de caminhões.\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica os valores recomendados de Trash Boss:\n" +
                    "- Capacidade de carga dos caminhões: **200%**\n" +
                    "- Velocidade de processamento: **200%**\n" +
                    "- Capacidade de armazenamento: **160%**\n" +
                    "- Quantidade de caminhões da instalação: **140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Padrão do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Volta todos os sliders para **100%** (valores vanilla)."
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Nome exibido deste mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Versão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Versão atual do mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Abre a página do Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Abre o convite do Discord no navegador." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Modo limpeza automática>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * Todo o lixo é removido quase instantaneamente\n" +
                    " <-------------------------------------->\n\n" +
                    "<Modo gerenciar manualmente>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Ajuste os sliders como quiser.\n" +
                    "  * Lógica vanilla de lixo com melhor controle de caminhões/instalações.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Jogo vanilla normal>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Clique em **[Padrão do jogo]**\n" +
                    "  * Todos os sliders em 100% (vanilla)\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo na cidade inteira e a taxa total de processamento.\n" +
                    "Aumente o processamento se o Produced mensal estiver muito mais alto.\n" +
                    "**Produced** e **Processed** usam toneladas por mês.\n" +
                    "Hora da atualização = última atualização."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Pedidos de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = pedidos de coleta ativos ainda sem caminhão ou rota atribuída.\n" +
                    "**Dispatched** = pedidos de coleta ativos já atribuídos.\n" +
                    "**Total** = todos os pedidos ativos de coleta de lixo.\n" +
                    "Esse número pode ficar temporariamente maior que **Above request threshold**, porque pedidos antigos são limpos depois pela revalidação do jogo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = prédios que atualmente têm lixo.\n" +
                    "**Total** = todos os prédios que produzem lixo na cidade.\n" +
                    "**Above request threshold** = prédios com lixo suficiente para criar um pedido de coleta.\n" +
                    "No vanilla isso normalmente significa mais de <100> unidades de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contadas.\n" +
                    "**Facilities** = instalações de lixo contadas.\n" +
                    "**Trucks total** = todos os caminhões de lixo dessas instalações.\n" +
                    "**Max workers** = capacidade total máxima de trabalhadores dessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = caminhões atualmente rodando pela cidade.\n" +
                    "**Returning** = parte dos Moving que está voltando para a instalação.\n" +
                    "**Parked** = caminhões estacionados na instalação.\n" +
                    "**Total** = total de caminhões de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Escreve um relatório mais detalhado de lixo em **Logs/MagicGarbage.log**.\n" +
                    "Inclui uma legenda curta, limites atuais, caminhões desativados e o máximo de trabalhadores por instalação."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre a pasta Logs/."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Nenhuma cidade carregada ainda." },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {1:N0} t processadas | atualizado {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachados | total {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} têm lixo | {2:N0} acima do limite de pedido" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | total de caminhões {1:N0} | max trabalhadores {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} voltando) | {2:N0} estacionados | total {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "Ainda não há dados de instalações." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed usa toneladas por mês.\n" +
                    "- Os limites abaixo usam unidades internas de lixo, não toneladas.\n" +
                    "- Limite de coleta = lixo mínimo antes que um caminhão colete de um prédio.\n" +
                    "- Limite de pedido = lixo mínimo antes que o jogo crie ou mantenha um pedido de coleta.\n" +
                    "- Limite de aviso = quantidade de lixo em que o ícone de aviso pode aparecer sobre um prédio.\n" +
                    "- Teto máximo = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Voltando = parte dos em movimento.\n" +
                    "- A quantidade de pedidos ativos pode ficar temporariamente maior que a quantidade de prédios acima do limite, porque pedidos antigos são limpos depois pela revalidação vanilla.\n" +
                    "- Os números de trabalhadores abaixo mostram atualmente os **trabalhadores máximos** de cada instalação."
                },
                { "MG.Status.Log.Thresholds",
                    "Limites (unidades internas de lixo): coleta={1:N0}, pedido={0:N0}, aviso={2:N0}, teto máximo={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "Limites: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.GarbageProcessing", "Lixo: {0:N0} t/mês | Processamento: {1:N0} t/mês" },
                { "MG.Status.Log.Requests", "Pedidos de coleta: pendentes={1:N0}, despachados={2:N0}, total={0:N0}" },
                { "MG.Status.Log.Producers", "Prédios: total={0:N0} | com lixo={1:N0} | acima do limite de pedido={2:N0} | nível de aviso={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: total={0:N0} | total de caminhões={1:N0} | max trabalhadores={2:N0}" },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: em movimento={2:N0} ({3:N0} voltando) | estacionados={1:N0} | desativados={4:N0} | total={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: em movimento={2:N0}, estacionados={3:N0}, total={1:N0}, max trabalhadores={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
