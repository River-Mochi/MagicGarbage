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
                    "Gerencia diretamente os sistemas de lixo; a lógica vanilla de lixo continua rodando.\n\n" +
                    "- Quando **Controle do lixo está ON [ ✓ ]**, Magia total fica forçada para OFF.\n" +
                    "- Os sliders só se aplicam quando Controle do lixo está ativado.\n" +
                    "- Tanto Magia total quanto Controle do lixo podem ficar **OFF** se só for preciso o **relatório de status**.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "Assistência de prioridade" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "Ajuda para alvos de lixo (prédios) muito sobrecarregados.\n" +
                    "Quando estiver **ON**, verifica se algum alvo de pedido ativo atingiu **7000+** (**7t**) de lixo.\n" +
                    "Objetivo: reduz coletas laterais extras quando necessário para que os caminhões cheguem mais rápido aos piores alvos.\n" +
                    "Isto é uma ajuda, não uma substituição rígida e completa da lógica vanilla de rotas.\n" +
                    "Leve, sem patch Harmony."
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
                    "Retorna os sliders do Trash Boss para os **valores vanilla**.\n" +
                    "Não <muda> as configurações do especialista.\n" +
                    "**Vanilla:**\n" +
                    "- Os sliders em porcentagem voltam para **100%**.\n" +
                    "- O Limite de solicitação de despacho volta para **100 unidades**.\n" +
                    "- O Limite de coleta volta para **20 unidades**.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Opções de especialista" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Configurações avançadas opcionais\n" +
                    "<Aviso: NÃO são necessárias> para um bom serviço; existem para jogadores que querem experimentar ou entender melhor como os sistemas funcionam.\n" +
                    "Quando estiver **DESLIGADO**, os itens do especialista se comportam como no jogo **vanilla** normal.\n" +
                    "Quando estiver **LIGADO**, os **sliders** avançados aparecem.\n\n" +
                    "<--- Exemplos de felicidade --->\n" +
                    " - <Vanilla> 100/65 = 1ª penalidade em <165>.\n" +
                    " - Clique em <Recomendado> para 550/150 = 1ª penalidade em <700>.\n" +
                    " - <Muito suave> 950/200 = 1ª penalidade de lixo em <1150>.\n" +
                    "Conveniência: os últimos valores dos sliders são salvos quando esta opção fica desligada (caso queira ativar depois)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Limite de solicitação de despacho" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Quantidade de lixo no prédio necessária antes que um pedido de despacho de caminhão seja criado ou mantido.**\n" +
                    "Vanilla = **100** unidades de lixo.\n" +
                    "**100 unidades de lixo = 0.1t**\n" +
                    "**1.000 unidades de lixo = 1t**\n" +
                    "Mantenha isso igual ou acima do Limite de coleta.\n" +
                    "Normalmente isso aumenta quantos caminhões ficam em uso em vez de parados."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Limite de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Quantidade mínima de lixo no prédio antes que um caminhão possa coletar.**\n" +
                    "Vanilla = **20** unidades de lixo.\n" +
                    "O slider de coleta <não pode> ser maior que a Solicitação de despacho (DR); ele é limitado para evitar problemas de lógica.\n" +
                    "Se um caminhão for despachado para um prédio e o valor de coleta for maior que o DR, às vezes ele não conseguirá coletar do prédio (a taxa de acúmulo também afeta isso).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Base de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Nível de lixo no prédio antes de começar a causar penalidade de saúde + felicidade.**\n" +
                    "**Vanilla = 100** unidades de lixo.\n" +
                    "Base mais alta = os prédios podem segurar mais lixo antes de a penalidade começar.\n" +
                    "100 unidades de lixo = 0.1t\n" +
                    "Visão geral:\n" +
                    "- <Limite> = ponto que dispara o comportamento do sistema\n" +
                    "- <Base> = ponto inicial da fórmula de penalidade\n" +
                    "- <Passo> = tamanho do incremento na fórmula, ou seja, quão rápido a penalidade cresce depois de começar"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Passo de felicidade do lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Lixo extra acima da base que faz a penalidade -1 começar.**\n" +
                    "Vanilla = **65** unidades de lixo.\n" +
                    "Passo maior = crescimento mais lento da penalidade.\n" +
                    "O jogo limita a penalidade de lixo a **-10**.\n" +
                    "A primeira penalidade vanilla <-1> acontece com **165 de lixo** (base 100 + passo 65)\n" +
                    "Se mudar os limites, também ajuste os sliders de felicidade ou as penalidades podem ficar mais pesadas que o normal."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Taxa de acúmulo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Escala os valores de origem de lixo dos prédios compatíveis.**\n" +
                    "Cuidado: isso é uma alavanca forte e mudar a taxa afeta muita coisa.\n" +
                    "É possível ter um bom sistema sem usar isso.\n\n" +
                    "**100% = taxa de acúmulo vanilla**.\n" +
                    "**20%** = acúmulo bem mais lento.\n" +
                    "**200%** = taxa dobrada - lixo demais.\n" +
                    "Com 20%, todos os cidadãos claramente estão compostando, então a taxa de acúmulo de lixo fica bem mais baixa ;)\n\n" +
                    "Nota técnica: o jogo adiciona lixo aos poucos ao longo do dia, não tudo de uma vez."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Recomendado" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Aplica os valores **recomendados** do especialista.\n" +
                    "Liga o especialista.\n" +
                    "A primeira penalidade de lixo começa em **700** de lixo (base 550 + passo 150).\n" +
                    "A Taxa de acúmulo fica em **100%** vanilla, a menos que seja mudada manualmente."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Padrões do jogo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Coloca todos os valores do especialista **de volta em vanilla**.\n" +
                    "Desliga o **especialista**.\n"
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
                    "  * O lixo vanilla do jogo não muda."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Uso" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Avaliação do serviço de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Valor simples de felicidade ligada ao lixo no jogo.\n" +
                    "**0 = Excelente**\n" +
                    "**-1** = Precisa de pequeno ajuste. O jogo costuma oscilar entre 0 e -1, então isso pode ser ignorado (o número é arredondado).\n" +
                    "**-2 a -4** = Um pouco fedido\n" +
                    "**-5 a -10** = Problema de lixo\n" +
                    "**Ajustes indiretos:** use os <sliders> do Trash Boss para melhorar isso com o tempo reduzindo o acúmulo real de lixo.\n" +
                    "**Ajustes diretos:** <Base de felicidade do lixo> + <Passo de felicidade do lixo> mudam o quanto os cidadãos toleram antes de ficarem infelizes.\n" +
                    "**Taxa de acúmulo**: muda a velocidade com que os prédios compatíveis produzem lixo. Use com cuidado, porque o equilíbrio é importante. A maioria dos jogadores nunca precisa mexer nisso.\n" +
                    "<Hora da atualização = última atualização.>"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Prédios 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Contagem de prédios produtores de lixo com **7t / 7000** de lixo ou mais.\n" +
                    "Esses prédios estão muito sobrecarregados; ative [x] Assistência de prioridade para priorizá-los melhor.\n" +
                    "Use o botão de status no log se quiser ver os números de ID de entidade para inspeção."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Lixo/mês" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Mostra a quantidade atual de lixo na cidade toda e a taxa total de processamento.\n" +
                    "Aumente o processamento se o lixo produzido por mês estiver muito acima disso.\n" +
                    "**Produzido** e **Processado** usam toneladas por mês."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Pedidos de coleta" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pendentes** = pedidos ativos de coleta que ainda não estão atribuídos a um caminhão ou rota.\n" +
                    "**Despachados** = pedidos ativos de coleta já atribuídos.\n" +
                    "**Total** = conta a entidade de pedido **ativa** atual (na cadeia do lixo).\n\n" +
                    "Nota técnica: isso é diferente de <Acima do limite de solicitação>. Aqui são contados <pedidos>, não prédios.\n" +
                    "Alguns pedidos pendentes serão atribuídos depois; alguns também podem sumir se a revalidação vanilla decidir que o alvo não precisa mais do serviço."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Prédios" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Tem lixo** = prédios que atualmente estão segurando lixo.\n" +
                    "**Total** = todos os prédios produtores de lixo da cidade.\n" +
                    "**Acima do limite de solicitação** = contagem atual de **prédios** com lixo suficiente para criar um pedido de coleta.\n" +
                    "No vanilla, o limite de solicitação é **100** unidades internas de lixo.\n" +
                    "As opções de especialista podem substituir os limites de solicitação e coleta.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Instalações" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Resumo das instalações de lixo contadas.\n" +
                    "**Instalações** = prédios de lixo contados.\n" +
                    "**Caminhões de lixo** = caminhões normais de coleta. Nas instalações de resíduos industriais, eles coletam resíduos industriais em vez de lixo comum.\n" +
                    "**Caminhões Dump** = transferências de lixo entre instalações.\n" +
                    "**Máx. trabalhadores** = capacidade total de trabalhadores nessas mesmas instalações."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Caminhões de lixo" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Em movimento** = caminhões atualmente pela cidade.\n" +
                    "**Retornando** = parte dos caminhões em movimento marcada para voltar à instalação.\n" +
                    "**Estacionados** = caminhões estacionados em uma instalação.\n" +
                    "**Total** = contagem de todos os caminhões de lixo."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Status detalhado no log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Envia um relatório de lixo mais detalhado para **Logs/MagicGarbage.log**.\n" +
                    "Inclui uma legenda curta, valores de referência vanilla e muitas estatísticas extras reais de lixo da cidade."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Abrir log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Abre a pasta do jogo Logs/.." },

                // Runtime status strings
                { "MG.Status.NoCity", "Ainda não há cidade carregada." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excelente ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Precisa de pequeno ajuste ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Um pouco fedido ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Problema de lixo ({0:N0}) | atualizado {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} acima de 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t produzidas | {1:N0} t processadas" },
                { "MG.Status.Row.Requests", "{1:N0} pendentes | {2:N0} despachados | {0:N0} total" },
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
                    "Sliders do Trash Boss (salvos): carga do caminhão={0:N0}% | armazenamento da instalação={1:N0}% | processamento da instalação={2:N0}% | frota da instalação={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "Opções de especialista (salvas): ativado={0} | solicitação={1:N0} | coleta={2:N0} | base de felicidade={3:N0} | passo de felicidade={4:N0} | taxa de acúmulo={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "Legenda:\n" +
                    "- Produzido/Processado usa toneladas por mês.\n" +
                    "- Os valores de limite abaixo usam unidades internas de lixo, não toneladas.\n" +
                    "- Para o jogador, o jogo" +
                    " converte 100 unidades = 0.1t e 1.000 unidades = 1t.\n" +
                    "- Valor do serviço de lixo = fator de felicidade do lixo da cidade no jogo.\n" +
                    "  - 0 = Excelente\n" +
                    "  - -1 = Precisa de pequeno ajuste, ou pode ser ignorado\n" +
                    "  - -2 a -4 = Um pouco fedido\n" +
                    "  - -5 a -10 = Problema de lixo\n" +
                    "Sliders de limite:\n" +
                    "  - Limite de coleta = lixo mínimo antes que um caminhão colete de um prédio.\n" +
                    "  - Limite de solicitação = lixo mínimo antes que o jogo crie ou mantenha um pedido de coleta.\n" +
                    "- Ícone de aviso = quantidade de lixo que faz aparecer um ícone de aviso acima de um prédio.\n" +
                    "- Limite duro = quantidade máxima de lixo que um prédio pode acumular.\n" +
                    "- Pendentes = pedidos ativos que ainda não estão atribuídos a um caminhão ou rota.\n" +
                    "- Alguns pedidos pendentes serão atribuídos depois; alguns também podem sumir se a revalidação vanilla decidir que o alvo não precisa mais do serviço.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "Limites do jogo (unidades internas de lixo): coleta={1:N0}, solicitação={0:N0}, ícone de aviso={2:N0}, limite duro={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Limites: <GarbageParameterData indisponível>" },
                { "MG.Status.Log.GarbageProcessing", "Lixo: {0:N0} t/mês | Processamento: {1:N0} t/mês" },
                { "MG.Status.Log.GarbageServiceRating", "Valor do serviço de lixo: {0} | bruto={1:N2} | arredondado={2:N0}" },
                { "MG.Status.Log.Requests", "Pedidos de coleta: pendentes={1:N0}, despachados={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Maior alvo pendente de lixo: {0:N0} ({1:N1}t) em {2}" },
                { "MG.Status.Log.PendingPeakNone", "Maior alvo pendente de lixo: nenhum" },
                { "MG.Status.Log.Producers", "Prédios: {0:N0} ícones de aviso | {1:N0} total | {2:N0} têm lixo | {3:N0} acima do limite de solicitação " },
                { "MG.Status.Log.ProducerGarbageStats", "Lixo nos prédios (apenas não zero): média={0:N0} ({1:N1}t) | mediana={2:N0} ({3:N1}t) | máx={4:N0} ({5:N1}t) em {6}" },
                { "MG.Status.Log.NearWarning75", "Prédios perto do ícone de aviso (pelo menos {1:N0} unidades / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Instalações: {0:N0} total | {1:N0} caminhões de lixo | {2:N0} caminhões Dump ({3:N0} em movimento) | {4:N0} trabalhadores" },
                { "MG.Status.Log.Trucks", "Caminhões de lixo: {2:N0} em movimento ({3:N0} retornando) | {1:N0} estacionados | {4:N0} desativados | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "Resumo das instalações" },
                { "MG.Status.Log.FacilityLine", "- Instalação {0}: caminhões de lixo={1:N0} ({2:N0} em movimento, {3:N0} estacionados) | caminhões Dump={4:N0} ({5:N0} em movimento) | trabalhadores={6:N0}" },


                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excelente" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Precisa de pequeno ajuste" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Um pouco fedido" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Problema de lixo" },

                { "MG.Status.Log.ThresholdsHeader", "Limites + serviço" },
                { "MG.Status.Log.RequestsHeader", "Pedidos" },
                { "MG.Status.Log.BuildingsHeader", "Prédios" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Prédios críticos acima de 7t" },

                { "MG.Status.Log.TransferProbeHeader", "Sonda de transferência de lixo" },
                { "MG.Status.Log.TransferProbeNone", "Nenhuma instalação de transferência/armazenamento de lixo encontrada." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | armazenado={1,7:N0} ({2,4:N1}t) | cap={3,7:N0} ({4,4:N1}t) | export={5,7:N0} ({6,4:N1}t) | baixo={7,7:N0} ({8,4:N1}t) | mín={9,7:N0} ({10,4:N1}t) | saída/entrada={11,6:N0}/{12,6:N0} | ativo={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Caminhões" },

                { "MG.Status.Log.SettingsPriority",
                    "Assistência de prioridade (salva): ativado={0} | gatilho={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "Assistência de prioridade" },
                { "MG.Status.Log.PriorityState",
                    "Assistência de prioridade ativa={0} | intervalo={1:N0} quadros | últimos pedidos verificados={2:N0} | alvos críticos de pedido ativos={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "Passes de prioridade: elevados={0:N0} | normais={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "Maior alvo crítico ativo: nenhum" },
                { "MG.Status.Log.PriorityPeak",
                    "Maior alvo crítico ativo: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "pendente" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "despachado" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Tempo da última verificação da assistência de prioridade={0:N3} ms" },
#endif

                { "MG.Status.Log.CriticalBuildingsNone", "nenhum" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },
            };
        }

        public void Unload()
        {
        }
    }
}
