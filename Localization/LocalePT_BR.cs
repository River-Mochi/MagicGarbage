// File: Localization/LocalePT_BR.cs
// Portuguese (Brazil) (pt-BR)

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Limpeza auto" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Gerenciar manualmente" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Especialista" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Info do mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USO" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Magia total" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Ativado [ ✓ ]** mantém a cidade inteira limpa.\n\n" +
                    "Enquanto **Magia total** estiver ON:\n" +
                    "- Controle do lixo fica forçado para OFF.\n" +
                    "- Os sliders de Controle do lixo não são aplicados (os valores ficam salvos para depois).\n" +
                    "- Alguns caminhões ainda podem se mover por causa do timing da lógica vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Controle do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Gerencia diretamente os sistemas de lixo; a lógica de garbage vanilla continua rodando.\n\n" +
                    "- Quando **Controle do lixo está ON [ ✓ ]**, Magia total fica forçada para OFF.\n" +
                    "- Os sliders só se aplicam quando Controle do lixo está ativado.\n" +
                    "- Tanto Magia total quanto Controle do lixo podem ficar **OFF** se só for preciso o **relatório de status**.\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Capacidade de carga do caminhão" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Quanto lixo cada caminhão pode carregar.**\n" +
                    "**100% = normal** padrão do jogo.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Armazenamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Quanto lixo uma instalação pode armazenar.**\n" +
                    "**100% = armazenamento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Velocidade de processamento da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Quão rápido as instalações processam o lixo que entra.**\n" +
                    "**100% = velocidade de processamento vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Frota da instalação" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Quantos caminhões cada instalação pode despachar.**\n" +
                    "**100% = quantidade vanilla** de caminhões.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Aplica os valores padrão **recomendados** de Controle do lixo.\n" +
                    "Não muda as configurações de Especialista (separadas)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Volta os sliders de Controle do lixo para os **valores vanilla**.\n" +
                    "<Não> muda as configurações de Especialista.\n" +
                    "**Vanilla:**\n" +
                    "- Os sliders em porcentagem voltam para **100%**.\n" +
                    "- Dispatch Request Threshold volta para **100 units**.\n" +
                    "- Pickup Threshold volta para **20 units**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opções de especialista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Configurações avançadas opcionais\n" +
                    "<Aviso: NÃO são necessárias> para um bom serviço; estão aqui para quem quiser experimentar ou entender melhor como os sistemas funcionam.\n" +
                    "Quando estiver **OFF**, todas as configurações de Especialista **ficam vanilla**.\n" +
                    "Quando estiver **ON**, os **sliders avançados** aparecem.\n\n" +
                    "<--- Exemplos de felicidade --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalidade em <165>.\n" +
                    " - Clique em <Recomendado> para 550/150 = 1ª penalidade em <700>.\n" +
                    " - <Bem suave> 950/200 = 1ª penalidade de lixo em <1150>.\n" +
                    "Conveniência: os últimos valores dos sliders ficam salvos quando esta opção está OFF (caso queira ativar depois)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantidade de lixo no prédio necessária para criar ou manter um pedido de despacho de caminhão.**\n" +
                    "Vanilla = **100** units garbage.\n" +
                    "**100 units garbage = 0.1t**\n" +
                    "**1,000 units garbage = 1t**\n" +
                    "Mantenha isso no mesmo valor ou acima do Pickup Threshold.\n" +
                    "Normalmente isso aumenta quantos caminhões ficam em uso em vez de parados."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantidade mínima de lixo em um prédio antes que um caminhão possa coletar.**\n" +
                    "Vanilla = **20** units garbage.\n" +
                    "O slider de coleta <não pode> ficar acima do Dispatch Request (DR); ele é limitado para evitar falha de lógica.\n" +
                    "Se um caminhão for despachado para um prédio e o valor de coleta estiver acima do DR, às vezes ele pode não conseguir coletar do prédio (a taxa de acúmulo também afeta isso).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nível de lixo no prédio antes de começar a causar penalidade de saúde + felicidade.**\n" +
                    "**Vanilla = 100** units garbage.\n" +
                    "Base mais alta = os prédios podem segurar mais lixo antes de começar a penalidade.\n" +
                    "100 units garbage = 0.1t\n" +
                    "Visão geral:\n" +
                    "- <Threshold> = ponto de gatilho do comportamento do sistema\n" +
                    "- <Baseline> = ponto inicial da fórmula de penalidade\n" +
                    "- <Step> = tamanho do incremento na fórmula, ou seja, quão rápido a penalidade sobe depois que começa"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Passo de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Lixo extra acima da base que faz começar a penalidade de -1.**\n" +
                    "Vanilla = **65** units garbage.\n" +
                    "Passo mais alto = crescimento mais lento da penalidade.\n" +
                    "O jogo limita a penalidade de lixo a **-10**.\n" +
                    "A primeira penalidade vanilla <-1 penalty> acontece em **165 garbage** (100 baseline + 65 step)\n" +
                    "Equilibre mudanças de threshold com os sliders de felicidade ou as penalidades podem ficar mais fortes que o normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Taxa de acúmulo de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala os valores de fonte de lixo dos prédios compatíveis.**\n" +
                    "Isso é uma alavanca forte, e mudar essa taxa afeta muita coisa.\n" +
                    "Dá para ter um bom sistema sem usar isso.\n\n" +
                    "**100% = acúmulo vanilla**.\n" +
                    "**20%** = acúmulo bem mais lento.\n" +
                    "**200%** = taxa dobrada - lixo pra valer.\n" +
                    "Com 20%, todos os Cims claramente estão compostando, então o lixo acumula menos ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica os valores **recomendados** de Especialista.\n" +
                    "Liga o modo Especialista.\n" +
                    "A primeira penalidade de lixo começa em **700** garbage (550 baseline + 150 step).\n" +
                    "A Taxa de acúmulo de lixo fica em **100%** vanilla, a menos que seja mudada manualmente."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Volta os valores de Especialista **para vanilla**.\n" +
                    "Coloca **Especialista em OFF**.\n"
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
                    "<Estado de limpeza auto>\n" +
                    "  * Magia total ON = **[ ✓ ]**\n" +
                    "  * O lixo é removido automaticamente - pronto.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de gerenciamento manual>\n" +
                    "  * Controle do lixo = **[ ✓ ]**\n" +
                    "  * Ajuste os sliders como quiser.\n" +
                    "  * Opcional: ligue os sliders avançados (não é obrigatório).\n" +
                    "  * Mesmo lixo do jogo; caminhões/instalações melhores para gerenciar manualmente.\n" +
                    " <-------------------------------------->\n\n" +
                    "<Estado de status / vanilla>\n" +
                    "  * Magia total = OFF\n" +
                    "  * Controle do lixo = OFF\n" +
                    "  * Só relatório de status.\n" +
                    "  * O garbage vanilla do jogo não muda."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Avaliação do serviço de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Avaliação simples da felicidade do lixo na cidade inteira, vinda do jogo.\n" +
                    "**0 = Excelente**\n" +
                    "**-1 = Precisa de pequeno ajuste** o jogo pode ficar indo entre 0 e -1 com frequência, e isso pode ser ignorado.\n" +
                    "**-2 a -4 = Meio fedido**\n" +
                    "**-5 a -10 = Problema de lixo**\n" +
                    "**Ajustes indiretos:** sliders de caminhão/instalação/threshold podem melhorar isso ao longo do tempo, reduzindo o acúmulo real de lixo.\n" +
                    "**Ajustes diretos:** <Base de felicidade do lixo> + <Passo de felicidade do lixo> mudam o quanto os cims toleram antes de ficarem infelizes.\n" +
                    "**Ajuste da fonte:** <Taxa de acúmulo de lixo> muda a velocidade com que os prédios compatíveis produzem lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo na cidade inteira e a taxa total de processamento de lixo.\n" +
                    "Aumente o processamento se o lixo produzido por mês for muito maior.\n" +
                    "**Produced** e **Processed** usam toneladas por mês.\n" +
                    "<Hora da atualização = última atualização.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Pedidos de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = pedidos de coleta ativos que ainda não estão atribuídos a um caminhão ou rota.\n" +
                    "**Dispatched** = pedidos de coleta ativos já atribuídos.\n" +
                    "**Total** = conta a entidade de pedido **ativa** atual (na pipeline de garbage).\n\n" +
                    "Nota técnica: isso é diferente de <Acima do threshold de pedido>. Aqui contamos <pedidos>, não prédios.\n" +
                    "Alguns pedidos pendentes serão atribuídos depois; outros também podem ser limpos depois se a revalidação vanilla decidir que o alvo não precisa mais de serviço."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tem lixo** = prédios que atualmente guardam qualquer quantidade de lixo.\n" +
                    "**Total** = todos os prédios que produzem lixo na cidade.\n" +
                    "**Acima do threshold de pedido** = contagem atual de **prédios** com lixo suficiente para criar um pedido de coleta.\n" +
                    "No vanilla, o threshold de pedido é **100** internal units garbage.\n" +
                    "As Opções de especialista podem sobrescrever os thresholds de pedido e coleta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de garbage contadas.\n" +
                    "**Instalações** = prédios de lixo contados.\n" +
                    "**Garbage trucks** = caminhões normais de coleta. Em instalações de resíduos industriais, eles coletam resíduos industriais em vez de lixo comum.\n" +
                    "**Dump trucks** = transferências de lixo entre instalações.\n" +
                    "**Max workers** = capacidade total de trabalhadores nessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = caminhões atualmente pela cidade.\n" +
                    "**Returning** = parte dos caminhões em movimento marcada para voltar à instalação.\n" +
                    "**Parked** = caminhões estacionados numa instalação.\n" +
                    "**Total** = contagem de todos os garbage trucks."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório de garbage mais detalhado para **Logs/MagicGarbage.log**.\n" +
                    "Inclui uma legenda curta, valores de referência vanilla e muitas estatísticas extras reais de lixo da cidade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "Abre a pasta do jogo Logs/.."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "Ainda não há cidade carregada." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Precisa de pequeno ajuste ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Um pouco fedido ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de lixo ({0:N0}) | atualizado {1}" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {1:N0} t processadas" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachadas | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} têm lixo | {2:N0} acima do limite" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} instalações | {1:N0}/{2:N0} lixo/Dump caminhões | {3:N0} trabalhadores" },
                { "MG.Status.Row.Trucks", "{1:N0} em movimento ({3:N0} retornando) | {2:N0} estacionados | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "Ainda não há dados das instalações." },

                // Log strings
                { "MG.Status.Log.Title", "Status do lixo ({0})" },
                { "MG.Status.Log.City", "Cidade: {0}" },
                { "MG.Status.Log.Mode", "Modo: Magia total={0}, Controle do lixo={1}" },
                { "MG.Status.Log.SettingsHeader", "Configurações atuais do mod" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Sliders de Controle do lixo (salvos): carga do caminhão={0:N0}% | armazenamento da instalação={1:N0}% | processamento da instalação={2:N0}% | frota da instalação={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "Especialista (salvo): enabled={0} | request={1:N0} | pickup={2:N0} | base de felicidade={3:N0} | passo de felicidade={4:N0} | taxa de acúmulo={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produced/Processed usa toneladas por mês.\n" +
                    "- Os valores de threshold abaixo usam internal units garbage, não toneladas.\n" +
                    "- Para o jogador, o jogo converte 100 units = 0.1t e 1,000 units = 1t.\n" +
                    "- Avaliação do serviço de lixo = fator de felicidade do lixo da cidade no jogo.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = Precisa de pequeno ajuste, ou pode ignorar\n" +
                    "  - -2 a -4 = Meio fedido\n" +
                    "  - -5 a -10 = Problema de lixo\n" +
                    "Sliders de threshold:\n" +
                    "  - Pickup threshold = lixo mínimo antes que um caminhão colete de um prédio.\n" +
                    "  - Request threshold = lixo mínimo antes que o jogo crie ou mantenha um pedido de coleta.\n" +
                    "- Warning icon = quantidade de lixo que faz aparecer um ícone de aviso acima de um prédio.\n" +
                    "- Hard cap = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pending = pedidos ativos que ainda não estão atribuídos a um caminhão ou rota.\n" +
                    "- Alguns pedidos pendentes serão atribuídos depois; outros também podem sumir depois se a revalidação vanilla decidir que o alvo já não precisa de serviço.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Thresholds do jogo (internal units garbage): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage: {0:N0} t/mês | Processing: {1:N0} t/mês" },
                { "MG.Status.Log.GarbageServiceRating", "Avaliação do serviço de lixo: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "Pedidos de coleta: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior alvo pendente de lixo: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.PendingPeakNone", "Maior alvo pendente de lixo: nenhum" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} warning icons | {1:N0} total | {2:N0} têm lixo | {3:N0} acima do threshold de pedido " },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo nos prédios (só valores não zero): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do warning icon (pelo menos {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Precisa de pequeno ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Meio fedido" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de lixo" },
            };
        }

        public void Unload()
        {
        }
    }
}
