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
                    "**활성화 [ ✓ ]** 하면 도시 전체를 깨끗하게 유지합니다.\n\n" +
                    "**완전 정리** 가 ON 인 동안:\n" +
                    "- 쓰레기 관리는 강제로 OFF 됩니다.\n" +
                    "- 쓰레기 관리 슬라이더는 적용되지 않습니다(값은 나중을 위해 저장됨).\n" +
                    "- vanilla 배차 로직 타이밍 때문에 일부 트럭은 여전히 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "쓰레기 관리" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "쓰레기 시스템을 직접 관리하며, vanilla 쓰레기 로직은 계속 작동합니다.\n\n" +
                    "- **쓰레기 관리가 ON [ ✓ ]** 이면 완전 정리는 강제로 OFF 됩니다.\n" +
                    "- 슬라이더는 쓰레기 관리가 활성화된 경우에만 적용됩니다.\n" +
                    "- **상태 보고서** 만 필요하다면 완전 정리와 쓰레기 관리 둘 다 **OFF** 로 둘 수 있습니다.\n"
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
                    "쓰레기 관리 슬라이더를 **vanilla 값** 으로 되돌립니다.\n" +
                    "고급 사용자 설정은 <변경하지 않습니다>.\n" +
                    "**Vanilla:**\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- Dispatch Request Threshold 는 **100 units** 로 돌아갑니다.\n" +
                    "- Pickup Threshold 는 **20 units** 로 돌아갑니다.\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "고급 사용자 옵션" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "선택형 고급 설정\n" +
                    "<주의: 꼭 필요하지 않음> 좋은 서비스를 위해 필수는 아니며, 실험해 보거나 시스템 작동 방식을 더 알고 싶은 플레이어용입니다.\n" +
                    "**OFF** 일 때는 모든 고급 사용자 설정이 **vanilla 그대로** 유지됩니다.\n" +
                    "**ON** 이면 고급 **슬라이더가 표시됩니다**.\n\n" +
                    "<--- 행복도 예시 --->\n" +
                    " - <Vanilla> 100/65 = 첫 페널티는 <165> 에서 시작.\n" +
                    " - <권장값> 버튼을 누르면 550/150 = 첫 페널티는 <700>.\n" +
                    " - <매우 느슨함> 950/200 = 첫 쓰레기 페널티는 <1150>.\n" +
                    "편의 기능: 이 옵션이 OFF 여도 마지막 슬라이더 값은 저장됩니다(나중에 다시 켜고 싶을 때 대비)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "배차 요청 기준치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**트럭 배차 요청이 생성되거나 유지되기 전에 건물에 필요한 쓰레기량입니다.**\n" +
                    "Vanilla = **100** 쓰레기 units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "이 값은 Pickup Threshold 이상으로 유지하세요.\n" +
                    "보통 이 값을 올리면 주차된 트럭보다 실제로 쓰이는 트럭 수가 늘어납니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "수거 기준치" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**트럭이 건물에서 수거할 수 있게 되기 전에 필요한 최소 쓰레기량입니다.**\n" +
                    "Vanilla = **20** 쓰레기 units.\n" +
                    "수거 슬라이더는 Dispatch Request (DR) 보다 <높을 수 없으며>, 로직 문제를 막기 위해 자동으로 제한됩니다.\n" +
                    "트럭이 건물로 dispatch 되었는데 수거값이 DR 보다 높으면, 때로는 그 건물에서 수거하지 못할 수 있습니다(축적 속도도 영향을 줍니다).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "쓰레기 행복도 기준값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**건물의 쓰레기량이 건강 + 행복도 페널티를 주기 시작하기 전 기준값입니다.**\n" +
                    "**Vanilla = 100** 쓰레기 units.\n" +
                    "기준값이 높을수록 건물은 페널티가 시작되기 전에 더 많은 쓰레기를 버틸 수 있습니다.\n" +
                    "100 garbage units = 0.1t\n" +
                    "개요:\n" +
                    "- <Threshold> = 시스템 동작이 시작되는 지점\n" +
                    "- <Baseline> = 페널티 공식이 시작되는 기준점\n" +
                    "- <Step> = 공식의 증가량, 즉 시작 후 페널티가 얼마나 빨리 커지는지"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "쓰레기 행복도 단계값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**기준값을 넘는 추가 쓰레기량으로 -1 페널티가 시작됩니다.**\n" +
                    "Vanilla = **65** 쓰레기 units.\n" +
                    "단계값이 높을수록 페널티 증가가 느려집니다.\n" +
                    "게임은 쓰레기 페널티를 **-10** 에서 제한합니다.\n" +
                    "vanilla 첫 <-1 penalty> 는 **165 garbage** 에서 발생합니다 (기준값 100 + 단계값 65)\n" +
                    "기준치를 바꾸면 행복도 슬라이더도 함께 맞추지 않으면 평소보다 더 무거운 페널티가 생길 수 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "쓰레기 축적 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**지원되는 건물의 쓰레기 발생값을 조정합니다.**\n" +
                    "이건 강한 레버라서, 이 속도를 바꾸면 많은 것에 영향을 줍니다.\n" +
                    "이걸 쓰지 않아도 좋은 시스템을 만들 수 있습니다.\n\n" +
                    "**100% = vanilla** 축적 속도.\n" +
                    "**20%** = 훨씬 느리게 쌓임.\n" +
                    "**200%** = 두 배 속도 - 쓰레기가 엄청 많아집니다.\n" +
                    "20% 면 모든 Cims 가 분명히 퇴비화를 하는 중이니, 쓰레기 축적 속도도 낮은 거겠죠 ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "권장값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**권장값** 고급 사용자 값을 적용합니다.\n" +
                    "고급 사용자를 ON 으로 켭니다.\n" +
                    "첫 쓰레기 페널티는 **700** 쓰레기에서 시작합니다 (기준값 550 + 단계값 150).\n" +
                    "쓰레기 축적 속도는 수동으로 바꾸지 않는 한 **100%** vanilla 로 유지됩니다."
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "고급 사용자 값을 **vanilla** 로 되돌립니다.\n" +
                    "**고급 사용자 OFF** 로 전환합니다.\n"
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
                    " <-------------------------------------->\n\n" +
                    "<직접 관리 상태>\n" +
                    "  * 쓰레기 관리 = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더를 설정.\n" +
                    "  * 선택 사항: 고급 슬라이더를 쓰려면 켜기(필수 아님).\n" +
                    "  * 게임의 쓰레기는 그대로, 트럭/시설만 더 잘 직접 관리.\n" +
                    " <-------------------------------------->\n\n" +
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
                    "게임이 보여주는 도시 전체 쓰레기 행복도의 간단한 평가입니다.\n" +
                    "**0 = 최고**\n" +
                    "**-1 = 약간의 조정 필요** 게임이 0 과 -1 사이를 자주 오갈 수 있으니 무시해도 될 때가 있습니다.\n" +
                    "**-2 ~ -4 = 약간 냄새남**\n" +
                    "**-5 ~ -10 = 쓰레기 문제**\n" +
                    "**간접 조절:** 트럭/시설/기준치 슬라이더로 실제 쓰레기 축적을 줄여 시간이 지나며 개선할 수 있습니다.\n" +
                    "**직접 조절:** <쓰레기 행복도 기준값> + <쓰레기 행복도 단계값> 으로 cims 가 불만을 느끼기 전까지 얼마나 버티는지 바꿉니다.\n" +
                    "**발생 속도 조절:** <쓰레기 축적 속도> 로 지원 건물이 쓰레기를 얼마나 빨리 만드는지 바꿉니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "현재 도시 전체 쓰레기량과 총 처리 속도를 보여줍니다.\n" +
                    "월간 생산 쓰레기가 훨씬 많다면 처리량을 올리세요.\n" +
                    "**Produced** 와 **Processed** 는 월당 톤 단위입니다.\n" +
                    "<업데이트 시간 = 마지막 갱신 시각.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 현재 트럭이나 경로에 배정되지 않은 활성 수거 요청.\n" +
                    "**Dispatched** = 이미 배정된 활성 수거 요청.\n" +
                    "**Total** = 현재 **active** 요청 entity 수(쓰레기 파이프라인 안).\n\n" +
                    "기술 메모: 이것은 <요청 기준치 초과> 와 다릅니다. 여기서는 건물이 아니라 <요청> 을 셉니다.\n" +
                    "일부 pending 요청은 나중에 배정되고, vanilla 재검증에서 대상에 서비스가 더 이상 필요 없다고 판단되면 사라질 수도 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**쓰레기 있음** = 현재 쓰레기를 보유한 건물.\n" +
                    "**Total** = 도시의 모든 쓰레기 생산 건물.\n" +
                    "**요청 기준치 초과** = 수거 요청을 만들 만큼 충분한 쓰레기가 있는 **건물** 의 현재 수.\n" +
                    "vanilla 에서 요청 기준치는 **100** internal garbage units 입니다.\n" +
                    "고급 사용자 옵션은 요청/수거 기준치를 덮어쓸 수 있습니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약입니다.\n" +
                    "**시설** = 집계된 쓰레기 건물.\n" +
                    "**쓰레기 트럭** = 일반 수거 트럭. 산업 폐기물 시설에서는 일반 쓰레기 대신 산업 폐기물을 수거합니다.\n" +
                    "**덤프트럭** = 시설 간 쓰레기 이동.\n" +
                    "**최대 작업자 수** = 같은 시설들의 총 작업자 수용량."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "쓰레기 트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**이동 중** = 현재 도시를 돌아다니는 트럭.\n" +
                    "**복귀 중** = 자기 시설로 돌아가도록 표시된 이동 중 트럭 일부.\n" +
                    "**주차 중** = 시설에 주차된 트럭.\n" +
                    "**Total** = 모든 쓰레기 트럭 수."
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

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 생성 | {1:N0} t 처리" },
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
                    "쓰레기 관리 슬라이더(저장됨): 트럭 적재 용량={0:N0}% | 시설 저장량={1:N0}% | 시설 처리 속도={2:N0}% | 시설 차량 수={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "고급 사용자(저장됨): 활성={0} | 요청={1:N0} | 수거={2:N0} | 행복도 기준값={3:N0} | 행복도 단계값={4:N0} | 축적 속도={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- Produced/Processed 는 월당 톤 단위입니다.\n" +
                    "- 아래 기준치 값은 톤이 아니라 internal garbage units 를 사용합니다.\n" +
                    "- 플레이어 표시용으로 게임은 100 units = 0.1t, 1,000 units = 1t 로 변환합니다.\n" +
                    "- 쓰레기 서비스 평가는 게임 내 도시 쓰레기 행복도 계수입니다.\n" +
                    "  - 0 = 최고\n" +
                    "  - -1 = 약간의 조정 필요, 또는 무시 가능\n" +
                    "  - -2 ~ -4 = 약간 냄새남\n" +
                    "  - -5 ~ -10 = 쓰레기 문제\n" +
                    "기준치 슬라이더:\n" +
                    "  - 수거 기준치 = 트럭이 건물에서 수거하기 전에 필요한 최소 쓰레기량.\n" +
                    "  - 요청 기준치 = 게임이 수거 요청을 생성하거나 유지하기 전에 필요한 최소 쓰레기량.\n" +
                    "- 경고 아이콘 = 건물 위에 경고 아이콘이 뜨게 하는 쓰레기량.\n" +
                    "- 상한선 = 건물이 축적할 수 있는 최대 쓰레기량.\n" +
                    "- Pending = 현재 트럭이나 경로에 배정되지 않은 활성 요청.\n" +
                    "- 일부 pending 요청은 나중에 배정되고, vanilla 재검증에서 대상이 더 이상 서비스가 필요 없으면 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "게임 기준치 (internal garbage units): 수거={1:N0}, 요청={0:N0}, 경고 아이콘={2:N0}, 상한선={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "기준치: <GarbageParameterData 를 사용할 수 없음>" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0} t/월 | 처리: {1:N0} t/월" },
                { "MG.Status.Log.GarbageServiceRating", "쓰레기 서비스 평가: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "수거 요청: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "가장 높은 pending 대상 쓰레기량: {0:N0} ({1:N1}t) 위치 {2}" },
                { "MG.Status.Log.PendingPeakNone", "가장 높은 pending 대상 쓰레기량: 없음" },
                { "MG.Status.Log.Producers", "건물: {0:N0} 경고 아이콘 | {1:N0} total | {2:N0} 쓰레기 있음 | {3:N0} 요청 기준치 초과 " },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기(0 제외): 평균={0:N0} ({1:N1}t) | 중앙값={2:N0} ({3:N1}t) | 최대={4:N0} ({5:N1}t) 위치 {6}" },
                { "MG.Status.Log.NearWarning75", "경고 아이콘에 가까운 건물(최소 {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: {0:N0} total | {1:N0} 쓰레기 트럭 | {2:N0} 덤프트럭 ({3:N0} moving) | {4:N0} 작업자" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 쓰레기 트럭={1:N0} ({2:N0} moving, {3:N0} parked) | 덤프트럭={4:N0} ({5:N0} moving) | 최대 작업자 수={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "최고" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "약간의 조정 필요" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "약간 냄새남" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "쓰레기 문제" },
            };
        }

        public void Unload()
        {
        }
    }
}
