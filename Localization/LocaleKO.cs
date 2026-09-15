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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "동작" },
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
                    "**활성화 [ ✓ ]** 하면 도시 전체를 깨끗하게 유지합니다.\n" +
                    "\n" +
                    "**Total Magic** 이 켜져 있는 동안:\n" +
                    "- Trash Boss는 강제로 꺼집니다.\n" +
                    "- Trash Boss 슬라이더는 적용되지 않습니다(값은 나중을 위해 저장됩니다).\n" +
                    "- 바닐라 dispatch 로직 타이밍 때문에 일부 트럭은 여전히 움직일 수 있습니다."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "바닐라 쓰레기 로직은 계속 실행하면서 쓰레기 시스템을 직접 관리합니다.\n" +
                    "\n" +
                    "- **Trash Boss가 켜짐 [ ✓ ]** 일 때 Total Magic은 강제로 꺼집니다.\n" +
                    "- 슬라이더는 Trash Boss가 활성화되어 있을 때만 적용됩니다.\n" +
                    "- Total Magic + Trash Boss를 둘 다 **OFF** 로 두면 바닐라 설정으로 사용할 수 있으며,\n" +
                    "  **상태 보고서** 는 계속 볼 수 있습니다. 이 보고서는 Options 메뉴에 들어갈 때만 갱신됩니다(가벼움)."
                },
                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 트럭이 실을 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = 일반** 게임 기본값(20t).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "시설 저장량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 저장할 수 있는 쓰레기 양입니다.**\n" +
                    "**100% = vanilla** 저장량.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "시설 처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 들어오는 쓰레기를 처리하는 속도입니다.**\n" +
                    "**100% = vanilla** 처리 속도.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설이 출동시킬 수 있는 트럭 수입니다.**\n" +
                    "**100% = vanilla** 트럭 수.\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "목표 용량 예약" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**트럭이 지정된 목표로 가는 동안 선택적 수거를 줄이기 시작하는 시점을 조정합니다.**\n" +
                    "부드러운 보호값이며 빈 적재 공간을 보장하지 않습니다. 기본값은 **10%**, 안전 범위는 10–25%입니다."
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "권장" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "균형 잡힌 값: 트럭 **200%**, 목표 보호 **15%**."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Trash Boss를 **vanilla 동작**으로 되돌립니다.\n" +
                    "**Vanilla:**\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- 목표 보호는 **10%** 로 돌아갑니다.\n" +
                    ""
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
                    "<자동 청소 상태>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * 쓰레기는 자동 제거됩니다 - 완료.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<직접 관리 상태>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 원하는 대로 슬라이더를 설정합니다.\n" +
                    "  * 선택: 고급 슬라이더를 켭니다(필수 아님).\n" +
                    "  * 같은 게임 쓰레기 시스템을 더 잘 관리되는 트럭/시설로 운영합니다.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<상태 / vanilla 상태>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * 상태 보고서만 표시.\n" +
                    "  * Vanilla 쓰레기 게임은 변경되지 않습니다."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "사용법" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "쓰레기 서비스 평가" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "게임의 간단한 쓰레기 행복도 평가입니다.\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= 약간 조정 필요. 게임은 0에서 -1 사이를 자주 오가며 무시해도 될 수 있습니다(숫자는 반올림됨).\n" +
                    "**-2 to -4** = 약간 냄새남\n" +
                    "**-5 to -10** = 쓰레기 문제\n" +
                    "**간접 조절:** <trash sliders> 를 사용해 시간이 지나며 쓰레기 축적을 줄여 개선합니다.\n" +
                    "**직접 조절:** Garbage Happiness Baseline + Garbage Happiness Step 은 Cims가 불만이 되기 전에<감당하는 수준>을 바꿉니다.\n" +
                    "**Garbage Accumulation Rate**: 지원 건물이 쓰레기를 생성하는 속도를 바꿉니다. 균형이 중요하므로 주의하세요. 대부분의 플레이어는 조정할 필요가 없습니다.\n" +
                    "<Update time = 마지막 새로고침 시간.>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t 이상 건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "쓰레기가 **7000 / 7t** 이상인 건물 수입니다.\n" +
                    "경고 아이콘이 나타나기 전에 서비스를 늘릴지 판단하는 고정 조기 지표입니다.\n" +
                    "상세 로그에는 Entity ID가 표시됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "도시 전체 쓰레기 생성량과 사용 가능한 처리 용량을 표시합니다.\n" +
                    "월간 생성량이 처리 용량보다 높으면 처리 용량을 늘리세요.\n" +
                    "두 값 모두 월간 톤 단위입니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "수거 요청" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 현재 트럭이나 경로에 배정되지 않은 활성 수거 요청입니다.\n" +
                    "**Dispatched** = 이미 배정된 활성 수거 요청입니다.\n" +
                    "**Total** = 현재 **active** request entity(쓰레기 파이프라인 안)를 셉니다.\n" +
                    "\n" +
                    "기술 메모: 이것은 <Above request threshold> 와 다릅니다. 건물이 아니라 <requests> 를 셉니다.\n" +
                    "일부 pending requests 는 나중에 배정됩니다. 바닐라 재검증이 대상에 더 이상 서비스가 필요 없다고 판단하면 나중에 사라질 수도 있습니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 현재 쓰레기를 보유한 건물.\n" +
                    "**Total** = 도시의 모든 쓰레기 생성 건물.\n" +
                    "**Above request threshold** = 수거 요청을 만들 만큼 쓰레기가 있는 **buildings** 의 현재 수.\n" +
                    "상세 로그에는 게임의 현재 요청 임계값이 표시됩니다.\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "시설" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "집계된 쓰레기 시설 요약입니다.\n" +
                    "**Facilities** = 집계된 쓰레기 건물.\n" +
                    "**Garbage trucks** = 일반 수거 트럭. Industrial Waste 시설에서는 쓰레기 대신 산업 폐기물을 수거합니다.\n" +
                    "**Dump trucks** = 시설 간 쓰레기 이동.\n" +
                    "**Max workers** = 같은 시설들의 총 노동자 수용량."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "쓰레기 트럭" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 현재 도시 밖으로 나가 활동 중인 트럭.\n" +
                    "**Returning** = moving trucks 중 시설로 돌아가도록 표시된 트럭.\n" +
                    "**Parked** = 시설에 주차된 트럭.\n" +
                    "**Total** = 모든 쓰레기 트럭 수."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "상세 상태를 로그로" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "더 자세한 쓰레기 보고서를 **Logs/MagicGarbage.log** 로 보냅니다.\n" +
                    "정리된 도시 쓰레기 통계를 포함합니다"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "로그 열기" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "**MagicGarbage.log** 를 엽니다. 아직 없으면 Logs 폴더를 엽니다." },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 도시가 로드되지 않았습니다." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "약간 조정 필요 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "약간 냄새남 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "쓰레기 문제 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.CriticalBuildings", "7t 이상 건물 {0:N0}개" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 생성 | {1:N0} t 처리 용량" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0}/{2:N0} garbage/dump trucks | {3:N0} workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "아직 시설 데이터가 없습니다." },

                // Log strings
                { "MG.Status.Log.Title", "쓰레기 상태 ({0})" },
                { "MG.Status.Log.City", "도시: {0}" },
                { "MG.Status.Log.Mode", "모드: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "현재 모드 설정" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss 슬라이더(저장됨): truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "범례:\n" +
                    "- Produced/Processed 는 tons per month 를 사용합니다.\n" +
                    "- 아래 threshold 값은 tons 가 아니라 internal garbage units 입니다.\n" +
                    "- 플레이어 표시에서는 게임이 100 units = 0.1t, 1,000 units = 1t 로 변환합니다.\n" +
                    "- Garbage Service Rating = 도시 쓰레기 행복도 계수.\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = 약간 조정 필요, 또는 무시 가능\n" +
                    "  - -2 to -4 = 약간 냄새남\n" +
                    "  - -5 to -10 = 쓰레기 문제\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = 트럭이 건물에서 수거하기 전 필요한 최소 쓰레기 양.\n" +
                    "  - Request threshold = 게임이 수거 요청을 만들거나 유지하기 전 필요한 최소 쓰레기 양.\n" +
                    "- Warning icon = 건물 위에 경고 아이콘이 뜨는 쓰레기 양.\n" +
                    "- Hard cap = 건물이 축적할 수 있는 최대 쓰레기 양.\n" +
                    "- Pending = 현재 트럭이나 경로에 배정되지 않은 활성 요청.\n" +
                    "- 일부 pending requests 는 나중에 배정됩니다. 바닐라 재검증이 대상에 서비스가 필요 없다고 판단하면 사라질 수도 있습니다.\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "게임 Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.AdaptiveMargin", "목표 보호: {0:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "쓰레기 생성: {0:N0} t/월 | 처리 용량: {1:N0} t/월" },
                { "MG.Status.Log.GarbageServiceRating", "쓰레기 서비스 평가: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "수거 요청: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "가장 높은 pending 대상 쓰레기: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "가장 높은 pending 대상 쓰레기: 없음" },
                { "MG.Status.Log.Producers", "건물: {0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "건물 쓰레기(0 초과만): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "경고 아이콘에 가까운 건물(at least {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "시설: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "쓰레기 트럭: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "시설 요약" },
                { "MG.Status.Log.FacilityLine",
                    "- 시설 {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "약간 조정 필요" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "약간 냄새남" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "쓰레기 문제" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Service" },
                { "MG.Status.Log.RequestsHeader", "요청" },
                { "MG.Status.Log.BuildingsHeader", "건물" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 이상 건물" },
                { "MG.Status.Log.LocalTransferProbeHeader", "로컬 쓰레기 이동 프로브" },
                { "MG.Status.Log.LocalTransferProbeNone", "로컬 쓰레기 시설을 찾을 수 없습니다." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "외부 연결 쓰레기 이동 프로브" },
                { "MG.Status.Log.OutsideTransferProbeNone", "외부 연결 쓰레기 시설을 찾을 수 없습니다." },

                { "MG.Status.Log.TransferProbeHeader", "쓰레기 이동 프로브" },
                { "MG.Status.Log.TransferProbeNone", "쓰레기 저장-이동 시설을 찾을 수 없습니다." },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "트럭" },
                { "MG.Status.Log.SettingsPriority", "적응형 경로(저장됨): 지원={0} | 기본 예약={1:N0}% | 긴급 예약={2:N0}%" },

                { "MG.Status.Log.PriorityState", "우선순위 지원={0} | 간격={1:N0} | 확인 요청={2:N0} | 위험 목표={3:N0} | 예약={4:N0}% -> {5:N0}%" },
                { "MG.Status.Log.PriorityPeak", "가장 높은 위험 건물: {0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "우선순위 지원" },
                { "MG.Status.Log.PriorityPasses", "우선순위 패스: raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "가장 높은 활성 위험 건물: 없음" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "우선순위 지원 마지막 스캔 시간={0:N3} ms" },
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
