// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleKO.cs
// Korean (ko-KR)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "자동 청소" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "직접 관리" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "상태" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "모드 정보" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용법" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**활성화 [ ✓ ]**하면 도시 전체를 깨끗하게 유지합니다.\n" +
                    "\n" +
                    "**Total Magic**이 켜져 있는 동안:\n" +
                    "- Trash Boss는 강제로 꺼집니다.\n" +
                    "- Trash Boss 슬라이더는 적용되지 않습니다(값은 나중을 위해 저장됩니다).\n" +
                    "- 바닐라 배차 로직의 타이밍 때문에 일부 트럭은 계속 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "바닐라 쓰레기 로직은 계속 실행하면서 쓰레기 시스템을 직접 관리합니다.\n" +
                    "\n" +
                    "- **Trash Boss가 켜짐 [ ✓ ]**이면 Total Magic은 강제로 꺼집니다.\n" +
                    "- 슬라이더는 Trash Boss가 활성화된 경우에만 적용됩니다.\n" +
                    "- Total Magic과 Trash Boss를 모두 **끔**으로 두면 바닐라 설정을 사용할 수 있으며,\n" +
                    "  이 상태에서도 **상태 보고서**를 볼 수 있습니다. 보고서는 옵션 메뉴에 들어갈 때만 갱신됩니다(가벼움)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 트럭이 운반할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = 바닐라** 트럭 용량(20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = 바닐라** 저장 용량.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "시설 처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 들어오는 쓰레기를 처리하는 속도입니다.**\n" +
                    "**100% = 바닐라** 처리 속도.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설이 배차할 수 있는 트럭 수입니다.**\n" +
                    "**100% = 바닐라** 트럭 수.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "목적지 예약 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**트럭이 배정된 건물로 가는 길에 선택적 수거를 얼마나 일찍 제한할지 정합니다.**\n" +
                    "**10%는 바닐라 1.6.2 값입니다.**\n" +
                    "일반 20t 트럭 기준:\n" +
                    "- 10%는 배정된 정차 지점을 2t 더 일찍 보호하기 시작합니다.\n" +
                    "- 15%는 3t 더 일찍 시작합니다.\n" +
                    "- 25%는 5t 더 일찍 시작합니다.\n" +
                    "값이 높을수록 안전 여유가 커집니다. 트럭이 작은 수거를 더 일찍 건너뛰어 배정된 건물을 위한 공간을 더 남길 수 있습니다."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "권장" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "혼잡한 도시에 균형 잡힌 값을 적용합니다.\n" +
                    "트럭 적재량 **200%** | 저장 **150%** | 처리 **250%**\n" +
                    "차량 수 **100%** | 목적지 예약 용량 **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "슬라이더 초기화" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "표준 Trash Boss 슬라이더를 초기화합니다.\n" +
                    "- 백분율 슬라이더는 **100%**로 돌아갑니다.\n" +
                    "- 목적지 예약 용량은 **바닐라 10%** 값으로 돌아갑니다.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "모드" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "이 모드의 표시 이름입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 모드 버전입니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods 페이지를 엽니다." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "브라우저에서 Discord 초대 링크를 엽니다." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<자동 청소 상태>\n" +
                    "  * Total Magic 켜짐 = **[ ✓ ]**\n" +
                    "  * 쓰레기가 자동으로 제거됩니다 - 완료.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<직접 관리 상태>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더를 설정합니다.\n" +
                    "  * 같은 게임 쓰레기 시스템을 트럭/시설로 더 잘 직접 관리합니다.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<상태 / 바닐라 상태>\n" +
                    "  * Total Magic = 끔\n" +
                    "  * Trash Boss = 끔\n" +
                    "  * 상태 보고서만 표시.\n" +
                    "  * 바닐라 쓰레기 게임은 변경되지 않습니다."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "사용법" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "쓰레기 서비스 평가" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "게임에서 계산한 도시 전체의 평균 쓰레기 행복도 효과입니다.\n" +
                    "전체 평가가 좋아도 일부 문제 건물이 남아 있을 수 있으므로 **7t+ 건물**도 확인하세요.\n" +
                    "**0 = 전체적으로 매우 좋음**\n" +
                    "**-1 = 약간 조정 필요**\n" +
                    "**-2 ~ -4 = 조금 냄새남**\n" +
                    "**-5 이하 = 쓰레기 문제**\n" +
                    "\n" +
                    "트럭 및 시설 슬라이더로 서비스를 개선한 뒤 도시를 잠시 진행시키고 다시 확인하세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "쓰레기를 발생시키는 건물 중 **7000 / 7t** 이상인 건물 수입니다.\n" +
                    "이 고정 조기 경고 지표를 사용하면 건물이 게임의 경고 아이콘 수준에 도달하기 전에 서비스를 늘릴지 판단할 수 있습니다.\n" +
                    "상세 상태를 로그로 보내 Entity ID를 확인할 수 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "도시 전체의 쓰레기 발생량, 현재 처리량, 사용 가능한 시설 처리 용량을 표시합니다.\n" +
                    "월간 발생량이 용량보다 높으면 처리량을 늘리세요.\n" +
                    "모든 값은 월당 톤 단위입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**대기 중** = 현재 트럭이나 경로에 배정되지 않은 활성 수거 요청입니다.\n" +
                    "**배차됨** = 이미 배정된 활성 수거 요청입니다.\n" +
                    "**합계** = 쓰레기 파이프라인에 있는 현재 **활성** 요청 전체입니다.\n" +
                    "\n" +
                    "이는 요청이 아니라 건물 수를 세는 **요청 임계값 초과**와 다릅니다.\n" +
                    "일부 대기 요청은 나중에 배정됩니다. 또한 바닐라 재검증에서 대상이 더 이상 서비스를 필요로 하지 않는다고 판단하면 나중에 사라질 수도 있습니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**쓰레기 있음** = 현재 쓰레기를 보유한 건물입니다.\n" +
                    "**합계** = 도시의 모든 쓰레기 발생 건물입니다.\n" +
                    "**요청 임계값 초과** = 수거 요청을 만들 만큼 쓰레기가 있는 **건물**의 현재 수입니다.\n" +
                    "상세 상태 로그에는 게임의 현재 실시간 요청 임계값이 표시됩니다.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약입니다.\n" +
                    "**시설** = 집계된 쓰레기 건물입니다.\n" +
                    "**쓰레기 트럭** = 일반 수거 트럭입니다. 산업 폐기물 시설에서는 일반 쓰레기 대신 산업 폐기물을 수거합니다.\n" +
                    "**덤프 트럭** = 시설 간 쓰레기 이송에 사용됩니다.\n" +
                    "**최대 작업자** = 같은 시설들의 총 작업자 수용량입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "쓰레기 트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**이동 중** = 현재 도시에서 운행 중인 트럭입니다.\n" +
                    "**복귀 중** = 이동 중인 트럭 가운데 시설로 돌아가도록 지정된 트럭입니다.\n" +
                    "**주차됨** = 시설에 주차된 트럭입니다.\n" +
                    "**합계** = 모든 쓰레기 트럭 수입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "더 자세한 쓰레기 보고서를 **Logs/MagicGarbage.log**에 기록합니다.\n" +
                    "정리된 도시 쓰레기 통계를 포함합니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "**MagicGarbage.log**를 엽니다. 파일이 없거나 열 수 없으면 대신 게임의 Logs 폴더를 엽니다." },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 불러온 도시가 없습니다." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "전체적으로 매우 좋음 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "약간 조정 필요 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "조금 냄새남 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "쓰레기 문제 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.CriticalBuildings", "7t+ 건물 {0:N0}개" },

                { "MG.Status.Row.GarbageProcessing", "발생 {0:N0} t | 처리 중 {2:N0} t | 용량 {1:N0} t" },
                { "MG.Status.Row.Requests", "대기 {1:N0} | 배차 {2:N0} | 합계 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 쓰레기 있음 | 요청 임계값 초과 {2:N0}" },
                { "MG.Status.Row.FacilitiesSummary", "시설 {0:N0} | 쓰레기/덤프 트럭 {1:N0}/{2:N0} | 작업자 {3:N0}" },
                { "MG.Status.Row.Trucks", "이동 {1:N0} (복귀 {3:N0}) | 주차 {2:N0} | 합계 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "아직 시설 데이터가 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "현재 모드 설정" },
                { "MG.Status.Log.SettingsTrashBoss", "Trash Boss 슬라이더(저장됨): 트럭 적재량={0:N0}% | 시설 저장={1:N0}% | 시설 처리={2:N0}% | 시설 차량 수={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- 발생량, 현재 처리량, 용량은 월당 톤 단위를 사용합니다.\n" +
                    "- 아래 임계값은 톤이 아니라 내부 쓰레기 단위를 사용합니다.\n" +
                    "- 플레이어 표시에서는 게임이 100 단위 = 0.1t, 1,000 단위 = 1t로 변환합니다.\n" +
                    "- 쓰레기 서비스 평가 = 게임의 도시 쓰레기 행복도 계수입니다.\n" +
                    "  - 0 = 전체적으로 매우 좋음\n" +
                    "  - -1 = 약간 조정 필요\n" +
                    "  - -2 ~ -4 = 조금 냄새남\n" +
                    "  - -5 ~ -10 = 쓰레기 문제\n" +
                    "경로 값:\n" +
                    "  - 수거 임계값은 바닐라 최소값이며, 목적지를 고려한 경로 설정은 목적지용 용량을 보호하기 위해 트럭별로 이를 높일 수 있습니다.\n" +
                    "  - 요청 임계값은 게임이 수거 요청을 만들거나 유지하기 전에 필요한 최소 쓰레기 양입니다.\n" +
                    "- 건물 쓰레기가 현재 경고 수준을 넘으면 경고 아이콘이 나타납니다.\n" +
                    "- 최대 한도 = 건물이 누적할 수 있는 최대 쓰레기 양입니다.\n" +
                    "- 대기 중 = 현재 트럭이나 경로에 배정되지 않은 활성 요청입니다.\n" +
                    "- 일부 대기 요청은 나중에 배정됩니다. 또한 바닐라 재검증에서 대상이 더 이상 서비스를 필요로 하지 않는다고 판단하면 나중에 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "게임 임계값(내부 쓰레기 단위): 수거={1:N0}, 요청={0:N0}, 경고 아이콘={2:N0}, 최대 한도={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "임계값: <GarbageParameterData 사용 불가>" },
                { "MG.Status.Log.AdaptiveMargin", "목적지 예약 용량: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "목적지 예약 용량: 현재={0:N0}% | 불러올 때 게임 기준값={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기 발생량: {0:N0} t/월 | 현재 처리량: {2:N0} t/월 | 처리 용량: {1:N0} t/월" },
                { "MG.Status.Log.GarbageServiceRating", "쓰레기 서비스 평가: {0} | 원시값={1:N2} | 반올림={2:N0}" },
                { "MG.Status.Log.Requests", "수거 요청: 대기={1:N0}, 배차={2:N0}, 합계={0:N0}" },
                { "MG.Status.Log.PendingPeak", "대기 대상 중 최고 쓰레기량: {0:N0} ({1:N1}t), 위치 {2}" },
                { "MG.Status.Log.PendingPeakNone", "대기 대상 중 최고 쓰레기량: 없음" },
                { "MG.Status.Log.Producers", "건물: 경고 수준 초과 {0:N0} | 합계 {1:N0} | 쓰레기 있음 {2:N0} | 요청 임계값 초과 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기(0이 아닌 값만): 평균={0:N0} ({1:N1}t) | 중앙값={2:N0} ({3:N1}t) | 최대={4:N0} ({5:N1}t), 위치 {6}" },
                { "MG.Status.Log.NearWarning75", "경고 아이콘 근처 건물(최소 {1:N0} 단위 / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: 합계 {0:N0} | 쓰레기 트럭 {1:N0} | 덤프 트럭 {2:N0} (이동 {3:N0}) | 작업자 {4:N0}" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: 이동 {2:N0} (복귀 {3:N0}) | 주차 {1:N0} | 비활성 {4:N0} | 합계 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine", "- 시설 {0}: 쓰레기 트럭={1:N0} (이동 {2:N0}, 주차 {3:N0}) | 덤프 트럭={4:N0} (이동 {5:N0}) | 최대 작업자={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "전체적으로 매우 좋음" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "약간 조정 필요" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "조금 냄새남" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "쓰레기 문제" },

                { "MG.Status.Log.ThresholdsHeader", "임계값 + 서비스" },
                { "MG.Status.Log.RequestsHeader", "요청" },
                { "MG.Status.Log.BuildingsHeader", "건물" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t+ 건물" },
                { "MG.Status.Log.LocalTransferProbeHeader", "로컬 쓰레기 이송 프로브" },
                { "MG.Status.Log.LocalTransferProbeNone", "로컬 쓰레기 시설을 찾지 못했습니다." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "외부 연결 쓰레기 이송 프로브" },
                { "MG.Status.Log.OutsideTransferProbeNone", "외부 연결 쓰레기 시설을 찾지 못했습니다." },

                { "MG.Status.Log.TransferProbeHeader", "쓰레기 이송 프로브" },
                { "MG.Status.Log.TransferProbeNone", "쓰레기 저장-이송 시설을 찾지 못했습니다." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | 저장={1,7:N0} ({2,4:N1}t) / 용량={3,7:N0} ({4,4:N1}t) | 수락={5:N2} | 전송={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "트럭" },

                { "MG.Status.Log.CriticalBuildingsNone", "없음" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
