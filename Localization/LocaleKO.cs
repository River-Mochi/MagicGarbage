// <copyright file="LocaleKO.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "파워 유저" },
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "우선순위 지원" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "심하게 과부하된 쓰레기 대상(건물)을 지원합니다.\n" +
                    "**ON** 이면 활성 요청 대상이 **7000+** (**7t**) 쓰레기에 도달했는지 확인합니다.\n" +
                    "목표: 필요 시 부가 수거 작업을 줄여 트럭이 심각한 대상에 더 빨리 도달하도록 합니다.\n" +
                    "이것은 약한 보조일 뿐이며, 바닐라 경로 로직을 강하게 완전히 덮어쓰는 기능이 아닙니다.\n" +
                    "가볍고 Harmony 패치가 없습니다."
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

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "권장" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "표준 Trash Boss **권장** 값을 적용합니다.\n" +
                    "Power User 설정(별도)은 변경하지 않습니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Trash Boss 슬라이더를 **vanilla 값** 으로 되돌립니다.\n" +
                    "Power User 설정은 <변경하지 않습니다>.\n" +
                    "**Vanilla:**\n" +
                    "- 퍼센트 슬라이더는 **100%** 로 돌아갑니다.\n" +
                    "- Dispatch Request Threshold는 **100 units** 로 돌아갑니다.\n" +
                    "- Pickup Threshold는 **20 units** 로 돌아갑니다.\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Power User 옵션" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "선택형 고급 설정\n" +
                    "<경고: 좋은 서비스에 필요하지 않음> 실험하거나 시스템 작동 방식을 더 알고 싶은 플레이어용입니다.\n" +
                    "**OFF** 일 때 Power User 항목은 일반 **vanilla** 게임처럼 동작합니다.\n" +
                    "**ON** 일 때 고급 **슬라이더가 나타납니다**.\n" +
                    "\n" +
                    "<--- 행복도 예시 --->\n" +
                    " - <Vanilla> 100/65 = 첫 페널티 <165>.\n" +
                    " - <권장> 클릭 시 550/150 = 첫 페널티 <700>.\n" +
                    " - <매우 완만> 950/200 = 첫 쓰레기 페널티 <1150>.\n" +
                    "편의: 이 옵션을 OFF 해도 마지막 슬라이더 값은 저장됩니다(나중에 다시 켤 때 사용)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**트럭 dispatch request가 생성되거나 유지되기 전에 건물에 필요한 쓰레기 양입니다.**\n" +
                    "Vanilla = **100** garbage units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "Pickup Threshold 이상으로 유지하세요.\n" +
                    "보통 주차된 트럭보다 사용 중인 트럭 수가 늘어납니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**트럭이 건물에서 수거할 수 있기 전의 최소 건물 쓰레기 양입니다.**\n" +
                    "Vanilla = **20** garbage units.\n" +
                    "Pickup 슬라이더는 Dispatch Request (DR)보다 높을 수 없습니다. 로직 문제를 막기 위해 제한됩니다.\n" +
                    "트럭이 건물로 출동했는데 pickup 값이 DR보다 높으면, 트럭이 그 건물에서 수거하지 못할 때가 있습니다(accumulation rate도 영향을 줍니다).\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "쓰레기 행복도 기준선" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**건강 + 행복도 페널티가 시작되기 전의 건물 쓰레기 수준입니다.**\n" +
                    "**Vanilla = 100** garbage units.\n" +
                    "기준선이 높을수록 페널티 시작 전까지 건물이 더 많은 쓰레기를 가질 수 있습니다.\n" +
                    "100 garbage units = 0.1t\n" +
                    "개요:\n" +
                    "- <Threshold> = 시스템 동작의 발동 지점\n" +
                    "- <Baseline> = 페널티 공식의 시작점\n" +
                    "- <Step> = 공식의 증가 크기, 시작 후 페널티가 얼마나 빨리 증가하는지"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "쓰레기 행복도 단계" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**기준선을 초과해 -1 페널티가 시작되는 추가 쓰레기 양입니다.**\n" +
                    "Vanilla = **65** garbage units.\n" +
                    "단계가 높을수록 페널티 증가가 느려집니다.\n" +
                    "게임은 쓰레기 페널티를 **-10** 으로 제한합니다.\n" +
                    "Vanilla의 첫 <-1 penalty> 는 **165 garbage** 에서 발생합니다(100 baseline + 65 step)\n" +
                    "행복도 슬라이더와 맞추지 않고 threshold를 변경하면 일반보다 더 큰 페널티가 생길 수 있습니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "축적률" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**지원되는 건물 쓰레기 생성 값을 조정합니다.**\n" +
                    "주의: 강력한 조절값이며, 변경하면 많은 요소에 영향을 줍니다.\n" +
                    "이 값을 쓰지 않아도 좋은 시스템을 만들 수 있습니다.\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate.\n" +
                    "**20%** = 훨씬 느린 축적.\n" +
                    "**200%** = 두 배 속도 - 아주 많은 쓰레기.\n" +
                    "20%에서는 모든 Cims가 분명히 퇴비화를 하고 있으므로 쓰레기 축적률이 훨씬 낮습니다 ;)\n" +
                    "\n" +
                    "기술 메모: 게임은 쓰레기를 하루 동안 조금씩 추가하며, 한 번에 모두 추가하지 않습니다."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "권장" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Power User **권장** 값을 적용합니다.\n" +
                    "Power User를 ON으로 켭니다.\n" +
                    "첫 쓰레기 페널티는 **700** garbage (550 baseline + 150 step)에서 시작됩니다.\n" +
                    "Garbage Accumulation Rate는 수동으로 변경하지 않는 한 **100%** vanilla 상태로 유지됩니다."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "모든 Power User 값을 **vanilla** 로 되돌립니다.\n" +
                    "**Power User OFF** 로 전환합니다.\n" +
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
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 건물" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "**7t / 7000** 이상의 쓰레기를 가진 쓰레기 생성 건물 수입니다.\n" +
                    "이 건물들은 심하게 과부하된 건물입니다. [x] Priority Assist 를 켜면 더 잘 우선 처리됩니다.\n" +
                    "Entity ID 번호를 확인하려면 Status to log 버튼을 사용하세요."
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "쓰레기/월" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "현재 도시 전체 쓰레기 양과 총 쓰레기 처리율을 표시합니다.\n" +
                    "월간 생성 쓰레기가 훨씬 높으면 처리량을 늘리세요.\n" +
                    "**Produced** 와 **Processed** 는 tons per month 를 사용합니다."
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
                    "Vanilla 에서 request threshold 는 **100** internal garbage units 입니다.\n" +
                    "Power User Options 는 request 와 pickup thresholds 를 덮어쓸 수 있습니다.\n" +
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
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "게임 Logs/.. 폴더를 엽니다." },

                // Runtime status strings
                { "MG.Status.NoCity", "아직 도시가 로드되지 않았습니다." },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "약간 조정 필요 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "약간 냄새남 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "쓰레기 문제 ({0:N0}) | 갱신 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0}개가 7t 초과" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
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
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User(저장됨): enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
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
                { "MG.Status.Log.GarbageProcessing", "쓰레기: {0:N0} t/월 | 처리: {1:N0} t/월" },
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

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 초과 위험 건물" },
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
                { "MG.Status.Log.SettingsPriority", "우선순위 시스템(저장됨): enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "우선순위 지원 live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}" },
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
