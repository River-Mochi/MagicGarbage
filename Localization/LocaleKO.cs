// File: Localization/LocaleKO.cs
// Korean (ko-KR)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleKO : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleKO(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "작업" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "정보" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 정리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "직접 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "고급 사용자" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "상태" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용법" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "완전 정리" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                                        "**활성화 [ ✓ ]** 하면 도시 전체를 깨끗하게 유지합니다.\n" +
                    "\n" +
                    "**완전 정리** 가 ON 인 동안:\n" +
                    "- 쓰레기 관리는 강제로 OFF 됩니다.\n" +
                    "- 쓰레기 관리 슬라이더는 적용되지 않습니다(값은 나중을 위해 저장됨).\n" +
                    "- vanilla 배차 로직 타이밍 때문에 일부 트럭은 여전히 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "쓰레기 관리" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                                        "쓰레기 시스템을 직접 관리하며, vanilla 쓰레기 로직은 계속 작동합니다.\n" +
                    "\n" +
                    "- **쓰레기 관리가 ON [ ✓ ]** 이면 완전 정리는 강제로 OFF 됩니다.\n" +
                    "- 슬라이더는 쓰레기 관리가 활성화된 경우에만 적용됩니다.\n" +
                    "- **상태 보고서** 만 필요하다면 완전 정리와 쓰레기 관리 둘 다 **OFF** 로 둘 수 있습니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "우선순위 보조" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                                        "심하게 과부하된 쓰레기 대상(건물)을 돕는 기능입니다.\n" +
                    "**ON** 일 때 활성 요청 대상이 **7000+** (**7t**) 쓰레기에 도달했는지 확인합니다.\n" +
                    "목표: 필요할 때 추가 옆길 수거를 줄여 트럭이 심각한 대상에 더 빨리 도달하게 합니다.\n" +
                    "이것은 약한 보조일 뿐이며, 바닐라 경로 로직을 강하게 완전히 덮어쓰는 기능이 아닙니다.\n" +
                    "가볍고 Harmony 패치가 없습니다."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                                        "**각 트럭이 실을 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = 일반** 게임 기본값.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                                        "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = vanilla** 저장량.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "시설 처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                                        "**시설이 들어오는 쓰레기를 처리하는 속도입니다.**\n" +
                    "**100% = vanilla** 처리 속도.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                                        "**각 시설이 출동시킬 수 있는 트럭 수입니다.**\n" +
                    "**100% = vanilla** 트럭 수.\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "권장값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                                        "**권장값** 쓰레기 관리 기본값을 적용합니다.\n" +
                    "고급 사용자 설정은 바꾸지 않습니다(별도)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                                        "Trash Boss 슬라이더를 **vanilla 값** 으로 되돌립니다.\n" +
                    "고급 사용자 설정은 <바꾸지 않습니다>.\n" +
                    "**Vanilla:**\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- 배차 요청 임계값은 **100 단위** 로 돌아갑니다.\n" +
                    "- 수거 임계값은 **20 단위** 로 돌아갑니다.\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "고급 사용자 옵션" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                                        "선택형 고급 설정\n" +
                    "<주의: 꼭 필요하지 않음> 좋은 서비스를 위해 필수는 아니며, 실험해 보거나 시스템이 어떻게 돌아가는지 더 알고 싶은 플레이어용입니다.\n" +
                    "**OFF** 일 때는 고급 사용자 항목이 일반 **vanilla** 게임처럼 동작합니다.\n" +
                    "**ON** 이면 고급 **슬라이더가 표시** 됩니다.\n" +
                    "\n" +
                    "<--- 행복도 예시 --->\n" +
                    " - <Vanilla> 100/65 = 첫 페널티는 <165>.\n" +
                    " - <추천> 을 누르면 550/150 = 첫 페널티는 <700>.\n" +
                    " - <매우 완화> 950/200 = 첫 쓰레기 페널티는 <1150>.\n" +
                    "편의 기능: 이 옵션이 OFF 여도 마지막 슬라이더 값은 저장됩니다 (나중에 다시 켜고 싶을 때 대비)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "배차 요청 기준치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                                        "**건물에 트럭 배차 요청이 생성되거나 유지되기 전에 필요한 쓰레기량입니다.**\n" +
                    "Vanilla = **100** 쓰레기 단위.\n" +
                    "**100 쓰레기 단위 = 0.1t**\n" +
                    "**1,000 쓰레기 단위 = 1t**\n" +
                    "이 값은 수거 임계값 이상으로 유지하세요.\n" +
                    "보통 이 값을 올리면 주차된 트럭보다 사용 중인 트럭 수가 늘어납니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "수거 기준치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                                        "**트럭이 건물에서 수거할 수 있게 되기 전에 필요한 최소 쓰레기량입니다.**\n" +
                    "Vanilla = **20** 쓰레기 단위.\n" +
                    "수거 슬라이더는 배차 요청 (DR) 보다 <높을 수 없으며> 로직 문제를 막기 위해 자동으로 제한됩니다.\n" +
                    "트럭이 건물로 배차되었는데 수거 값이 DR 보다 높으면, 그 건물에서 수거하지 못할 때가 있습니다 (누적률도 여기에 영향을 줍니다).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "쓰레기 행복도 기준값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                                        "**건물의 쓰레기량이 건강 + 행복도 페널티를 주기 시작하기 전의 기준값입니다.**\n" +
                    "**Vanilla = 100** 쓰레기 단위.\n" +
                    "기준값이 높을수록 건물은 페널티가 시작되기 전에 더 많은 쓰레기를 버틸 수 있습니다.\n" +
                    "100 쓰레기 단위 = 0.1t\n" +
                    "개요:\n" +
                    "- <임계값> = 시스템 동작이 시작되는 지점\n" +
                    "- <기준값> = 페널티 공식이 시작되는 기준점\n" +
                    "- <단계값> = 공식의 증가량, 즉 시작 후 페널티가 얼마나 빨리 커지는지"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "쓰레기 행복도 단계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                                        "**기준값을 넘은 추가 쓰레기량이 -1 페널티를 시작하게 합니다.**\n" +
                    "Vanilla = **65** 쓰레기 단위.\n" +
                    "단계값이 높을수록 페널티가 더 천천히 커집니다.\n" +
                    "게임에서 쓰레기 페널티는 **-10** 까지입니다.\n" +
                    "vanilla 에서 첫 <-1 penalty> 는 **165 쓰레기** 에서 발생합니다 (기준값 100 + 단계값 65)\n" +
                    "임계값을 바꾸면 행복도 슬라이더도 같이 조절해야, 평소보다 더 큰 페널티가 생기지 않습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "누적률" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                                        "**지원되는 건물의 쓰레기 발생 값을 조정합니다.**\n" +
                    "주의: 이것은 영향이 큰 조절값이며, 비율을 바꾸면 많은 것이 달라집니다.\n" +
                    "이 값을 건드리지 않아도 좋은 시스템을 만들 수 있습니다.\n" +
                    "\n" +
                    "**100% = vanilla** 누적률.\n" +
                    "**20%** = 훨씬 느리게 쌓임.\n" +
                    "**200%** = 2배 속도 - 쓰레기가 아주 많아짐.\n" +
                    "20% 라면 시민들이 전부 퇴비화 중인 게 분명하니, 쓰레기 누적률도 훨씬 낮겠죠 ;)\n" +
                    "\n" +
                    "기술 메모: 게임은 하루 동안 쓰레기를 조금씩 추가하며, 한 번에 전부 더하지는 않습니다."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "권장값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                                        "**추천** 고급 사용자 값을 적용합니다.\n" +
                    "고급 사용자 옵션을 ON 으로 켭니다.\n" +
                    "첫 쓰레기 페널티는 **700** 쓰레기에서 시작합니다 (기준값 550 + 단계값 150).\n" +
                    "누적률은 직접 바꾸지 않는 한 **100%** vanilla 로 유지됩니다."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                                        "고급 사용자 값을 모두 **vanilla** 로 되돌립니다.\n" +
                    "고급 사용자 옵션을 **OFF** 로 끕니다.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 Discord 초대를 엽니다." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                                        "<자동 정리 상태>\n" +
                    "  * 완전 정리 ON = **[ ✓ ]**\n" +
                    "  * 쓰레기는 자동으로 제거됨 - 끝.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<직접 관리 상태>\n" +
                    "  * 쓰레기 관리 = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더를 설정.\n" +
                    "  * 선택 사항: 고급 슬라이더를 쓰려면 켜기(필수 아님).\n" +
                    "  * 게임의 쓰레기는 그대로, 트럭/시설만 더 잘 직접 관리.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<상태 / vanilla 상태>\n" +
                    "  * 완전 정리 = OFF\n" +
                    "  * 쓰레기 관리 = OFF\n" +
                    "  * 상태 보고서만 표시.\n" +
                    "  * vanilla 쓰레기 게임은 바뀌지 않습니다."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "사용법" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "쓰레기 서비스 평가" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                                        "게임의 단순한 쓰레기 행복도 평가입니다.\n" +
                    "**0 = 아주 좋음**\n" +
                    "**-1** = 조금만 조정하면 됩니다. 게임은 0과 -1 사이를 자주 오가므로 무시해도 될 때가 많습니다 (숫자는 반올림됨).\n" +
                    "**-2 ~ -4** = 조금 냄새남\n" +
                    "**-5 ~ -10** = 쓰레기 문제\n" +
                    "**간접 조절:** Trash Boss <슬라이더>를 사용하면 실제 쓰레기 누적을 줄여 시간이 지나며 개선할 수 있습니다.\n" +
                    "**직접 조절:** <쓰레기 행복도 기준값> + <쓰레기 행복도 단계값>은 시민이 불만족해지기 전에 얼마나 버티는지 바꿉니다.\n" +
                    "**누적률**: 지원되는 건물이 쓰레기를 생산하는 속도를 바꿉니다. 밸런스가 중요하므로 주의해서 사용하세요. 대부분의 플레이어는 이것을 조절할 필요가 없습니다.\n" +
                    "<업데이트 시간 = 마지막 갱신.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                                        "**7t / 7000** 이상의 쓰레기를 가진 쓰레기 생산 건물 수입니다.\n" +
                    "심하게 과부하된 건물입니다. [x] 우선순위 보조를 켜면 이런 건물을 더 잘 우선 처리합니다.\n" +
                    "Entity ID 번호를 확인하려면 \"상세 상태를 로그에\" 버튼을 사용하세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                                        "도시 전체의 현재 쓰레기량과 총 처리 속도를 보여줍니다.\n" +
                    "월간 쓰레기 생산량이 훨씬 많다면 처리 능력을 늘리세요.\n" +
                    "**생산량** 과 **처리량** 은 월당 톤 단위입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                                        "**대기 중** = 현재 트럭이나 경로에 배정되지 않은 활성 수거 요청.\n" +
                    "**배정됨** = 이미 배정된 활성 수거 요청.\n" +
                    "**전체** = 현재 **활성** 요청 엔티티 수(쓰레기 파이프라인 안).\n" +
                    "\n" +
                    "기술 메모: 이것은 <요청 임계값 초과> 와 다릅니다. 여기서 세는 것은 건물이 아니라 <요청> 입니다.\n" +
                    "대기 중인 요청 일부는 나중에 배정됩니다. vanilla 재검증에서 대상에 서비스가 더 이상 필요 없다고 판단되면 사라질 수도 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                                        "**쓰레기 있음** = 현재 쓰레기를 보유한 건물.\n" +
                    "**전체** = 도시의 모든 쓰레기 생산 건물.\n" +
                    "**요청 임계값 초과** = 수거 요청을 만들 만큼 충분한 쓰레기가 있는 **건물** 의 현재 수.\n" +
                    "vanilla 에서 요청 임계값은 **100** 내부 쓰레기 단위입니다.\n" +
                    "고급 사용자 옵션은 요청 및 수거 임계값을 덮어쓸 수 있습니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                                        "집계된 쓰레기 시설 요약입니다.\n" +
                    "**시설** = 집계된 쓰레기 건물.\n" +
                    "**쓰레기 트럭** = 일반 수거 트럭. 산업 폐기물 시설에서는 일반 쓰레기 대신 산업 폐기물을 수거합니다.\n" +
                    "**Dump 트럭** = 시설 간 쓰레기 이동 트럭.\n" +
                    "**최대 작업자** = 같은 시설들의 총 작업자 수용량."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "쓰레기 트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                                        "**이동 중** = 현재 도시 안을 돌아다니는 트럭.\n" +
                    "**복귀 중** = 이동 중인 트럭 중 시설로 돌아가도록 표시된 하위 집합.\n" +
                    "**주차됨** = 시설에 주차된 트럭.\n" +
                    "**전체** = 모든 쓰레기 트럭 수."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그에" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                                        "더 자세한 쓰레기 보고서를 **Logs/MagicGarbage.log** 로 보냅니다.\n" +
                    "짧은 범례, vanilla 기준값, 그리고 실제 도시의 추가 쓰레기 통계를 많이 포함합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "게임의 Logs/.. 폴더를 엽니다."
                },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 도시가 로드되지 않았습니다." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "아주 좋음 ({0:N0}) | 업데이트 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "조금만 조정하면 됨 ({0:N0}) | 업데이트 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "조금 냄새남 ({0:N0}) | 업데이트 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "쓰레기 문제 ({0:N0}) | 업데이트 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0}개가 7t 초과" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 생산 | {1:N0} t 처리" },
                { "MG.Status.Row.Requests", "{1:N0} 대기 중 | {2:N0} 배정됨 | {0:N0} 전체" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 쓰레기 있음 | {2:N0} 요청 임계값 초과" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 시설 | {1:N0}/{2:N0} 쓰레기/Dump 트럭 | {3:N0} 작업자" },
                { "MG.Status.Row.Trucks", "{1:N0} 이동 중 ({3:N0} 복귀 중) | {2:N0} 주차됨 | {0:N0} 전체" },
                { "MG.Status.Row.FacilitiesNone", "아직 시설 데이터가 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: 완전 정리={0}, 쓰레기 관리={1}" },
                { "MG.Status.Log.SettingsHeader", "현재 모드 설정" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss 슬라이더 (저장값): 트럭 적재량={0:N0}% | 시설 저장량={1:N0}% | 시설 처리량={2:N0}% | 시설 차량 수={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "고급 사용자 옵션 (저장값): 활성={0} | 요청={1:N0} | 수거={2:N0} | 행복도 기준값={3:N0} | 행복도 단계값={4:N0} | 누적률={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                                        "범례:\n" +
                    "- 생산량/처리량 은 월당 톤 단위입니다.\n" +
                    "- 아래 임계값은 톤이 아니라 내부 쓰레기 단위를 사용합니다.\n" +
                    "- 플레이어 표시에서는 게임이 100 단위 = 0.1t, 1,000 단위 = 1t 로 변환합니다.\n" +
                    "- 쓰레기 서비스 평점 = 게임의 도시 쓰레기 행복도 계수.\n" +
                    "  - 0 = 아주 좋음\n" +
                    "  - -1 = 조금만 조정하면 됨, 또는 무시 가능\n" +
                    "  - -2 ~ -4 = 조금 냄새남\n" +
                    "  - -5 ~ -10 = 쓰레기 문제\n" +
                    "임계값 슬라이더:\n" +
                    "  - 수거 임계값 = 트럭이 건물에서 수거하기 전에 필요한 최소 쓰레기량.\n" +
                    "  - 요청 임계값 = 게임이 수거 요청을 만들거나 유지하기 전에 필요한 최소 쓰레기량.\n" +
                    "- 경고 아이콘 = 건물 위에 경고 아이콘이 나타나게 하는 쓰레기량.\n" +
                    "- 상한 = 건물이 쌓을 수 있는 최대 쓰레기량.\n" +
                    "- 대기 중 = 현재 트럭이나 경로에 배정되지 않은 활성 요청.\n" +
                    "- 대기 중인 요청 일부는 나중에 배정됩니다. vanilla 재검증에서 필요 없다고 판단되면 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "게임 임계값 (내부 쓰레기 단위): 수거={1:N0}, 요청={0:N0}, 경고 아이콘={2:N0}, 상한={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "임계값: <GarbageParameterData 를 사용할 수 없음>" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0} t/월 | 처리: {1:N0} t/월" },
                { "MG.Status.Log.GarbageServiceRating", "쓰레기 서비스 평점: {0} | 원값={1:N2} | 반올림={2:N0}" },
                { "MG.Status.Log.Requests", "수거 요청: 대기 중={1:N0}, 배정됨={2:N0}, 전체={0:N0}" },
                { "MG.Status.Log.PendingPeak", "가장 높은 대기 대상 쓰레기량: {0:N0} ({1:N1}t) 위치 {2}" },
                { "MG.Status.Log.PendingPeakNone", "가장 높은 대기 대상 쓰레기량: 없음" },
                { "MG.Status.Log.Producers", "건물: {0:N0} 경고 아이콘 | {1:N0} 전체 | {2:N0} 쓰레기 있음 | {3:N0} 요청 임계값 초과 " },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기 (0 제외): 평균={0:N0} ({1:N1}t) | 중앙값={2:N0} ({3:N1}t) | 최대={4:N0} ({5:N1}t) 위치 {6}" },
                { "MG.Status.Log.NearWarning75", "경고 아이콘에 가까운 건물 (최소 {1:N0} 단위 / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: {0:N0} 전체 | {1:N0} 쓰레기 트럭 | {2:N0} Dump 트럭 ({3:N0} 이동 중) | {4:N0} 작업자" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: {2:N0} 이동 중 ({3:N0} 복귀 중) | {1:N0} 주차됨 | {4:N0} 비활성 | {0:N0} 전체" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 쓰레기 트럭={1:N0} ({2:N0} 이동 중, {3:N0} 주차됨) | Dump 트럭={4:N0} ({5:N0} 이동 중) | 작업자={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "아주 좋음" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "조금만 조정하면 됨" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "조금 냄새남" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "쓰레기 문제" },

                { "MG.Status.Log.ThresholdsHeader", "임계값 + 서비스" },
                { "MG.Status.Log.RequestsHeader", "요청" },
                { "MG.Status.Log.BuildingsHeader", "건물" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 초과 심각 건물" },

                { "MG.Status.Log.TransferProbeHeader", "쓰레기 전송 프로브" },
                { "MG.Status.Log.TransferProbeNone", "쓰레기 저장/전송 시설을 찾지 못했습니다." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | 저장={1,7:N0} ({2,4:N1}t) | 용량={3,7:N0} ({4,4:N1}t) | 내보냄={5,7:N0} ({6,4:N1}t) | 낮음={7,7:N0} ({8,4:N1}t) | 최소={9,7:N0} ({10,4:N1}t) | 출/입={11,6:N0}/{12,6:N0} | 활성={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "트럭" },

                { "MG.Status.Log.SettingsPriority",
                    "우선순위 보조(저장됨): 활성={0} | 발동값={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "우선순위 보조" },
                { "MG.Status.Log.PriorityState",
                    "우선순위 보조 활성={0} | 간격={1:N0} 프레임 | 마지막 스캔 요청 수={2:N0} | 활성 심각 요청 대상={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "우선순위 패스: 상승={0:N0} | 일반={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "가장 높은 활성 심각 대상: 없음" },
                { "MG.Status.Log.PriorityPeak",
                    "가장 높은 활성 심각 대상: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "대기 중" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "배정됨" },

#if DEBUG
{ "MG.Status.Log.PriorityPerf", "우선순위 보조 마지막 스캔 시간={0:N3} ms" },
#endif

                { "MG.Status.Log.CriticalBuildingsNone", "없음" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }
        public void Unload()
        {
        }
    }
}
