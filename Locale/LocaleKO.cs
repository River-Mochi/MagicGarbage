// LocaleKO.cs
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
            return new Dictionary<string, string>
            {
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "설정" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "정보" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "토탈 매직" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "세미 매직" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 정보"  },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "링크"      },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "사용 안내"  },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "토탈 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**체크 [X]** 시 도시의 모든 쓰레기가 즉시 제거됩니다.\n" +
                    "쓰레기 처리 시설과 청소 차량은 거의 장식용이 됩니다.\n\n" +

                    "**토탈 매직** 이 켜져 있는 동안:\n" +
                    "- 세미 매직은 자동으로 꺼집니다.\n" +
                    "- 세미 매직 슬라이더 설정은 모두 무시됩니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "세미 매직" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "기본적인 쓰레기 시스템은 유지하면서 성능을 강화합니다.\n" +
                    "- 완전 마법 대신 더 강한 차량과 시설을 사용합니다.\n" +
                    "- 세미 매직이 켜지면 토탈 매직은 자동으로 꺼집니다.\n" +
                    "- 아래 슬라이더는 세미 매직이 켜져 있을 때만 적용됩니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "트럭 적재 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**각 쓰레기 트럭이 실을 수 있는 양.**\n" +
                    "- 100% = 기본 적재량.\n" +
                    "- 값을 높일수록 필요한 운행 횟수가 줄어듭니다.\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "시설 차량 수" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**각 시설에서 운행할 수 있는 트럭 수.**\n" +
                    "- 100% = 기본 차량 수.\n" +
                    "- 최대 400% = 최대 300% 더 많은 차량이 투입됩니다.\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "처리 속도" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**시설이 쓰레기를 처리하는 속도.**\n" +
                    "- 100% = 기본 처리 속도.\n" +
                    "- 값을 높이면 쓰레기가 더 빠르게 소각/재활용됩니다.\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "시설 보관 용량" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**시설이 꽉 찼다고 표시되기 전까지 저장할 수 있는 양.**\n" +
                    "- 100% = 기본 용량.\n" +
                    "- 값을 높이면 '가득 참' 경고가 뜨기 전까지 더 많이 저장할 수 있습니다.\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "게임 기본값" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "모든 세미 매직 슬라이더를 **100%**(바닐라 값)로 되돌립니다.\n" +
                    "Mod 는 유지하면서 쓰레기 서비스 수치는 그대로 두고 싶을 때 사용하세요."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "추천 설정" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "추천 세미 매직 값을 적용합니다:\n" +
                    "- 트럭 적재 용량: **200%**\n" +
                    "- 시설 차량 수: **150%**\n" +
                    "- 처리 속도: **200%**\n" +
                    "- 보관 용량: **200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "이 Mod 의 표시 이름입니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "버전" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "현재 Mod 버전입니다." },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "제작자의 다른 Mod 를 볼 수 있는 Paradox Mods 페이지를 엽니다."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "브라우저에서 CS2 모딩 Discord 를 엽니다."
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<추천 기본 상태>\n" +
                    "  * 토탈 매직 ON = **[X]**\n" +
                    "  * 도시의 모든 쓰레기가 즉시 제거됩니다\n" +
                    " <-------------------------------------->\n\n" +
                    "<세미 매직 슈퍼 트럭 상태>\n" +
                    "  * 토탈 매직 OFF = **[ ]**\n" +
                    "  * 세미 매직 ON = **[X]** 로 하고, 슬라이더 [100 >> 500] / [100 >> 400] 를 취향대로 조정하세요.\n" +
                    "  * 바닐라 느낌을 유지하면서 트럭과 시설만 강화됩니다.\n" +
                    " <-------------------------------------->\n\n" +
                    "<완전 바닐라 게임>\n" +
                    "  * 토탈 매직 OFF = **[ ]**\n" +
                    "  * 세미 매직 = **[X]** (\"게임 기본값\" 버튼 클릭)\n" +
                    "  * 모든 슬라이더가 100% (바닐라 한계)\n" +
                    "  * 완전히 기본과 같은 게임 플레이.\n"
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
