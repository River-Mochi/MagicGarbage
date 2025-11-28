// Locale/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_HANT : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_HANT(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "關於" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動清理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "自行管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 後，會立刻清除全城所有垃圾。\n" +
                    "垃圾處理建築與垃圾車幾乎只剩下裝飾用途。\n\n" +

                    "當 **完全魔法** 開啟時：\n" +
                    "- 半魔法模式會自動關閉。\n" +
                    "- 所有半魔法的滑桿設定都會被忽略。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "半魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "可直接調整垃圾系統，同時保留原版（vanilla）垃圾模擬邏輯。\n\n" +
                    "- 當 **半魔法為啟用 [ ✓ ]** 時，完全魔法會自動關閉。\n" +
                    "- 可調整所有垃圾車與垃圾處理設施的能力。\n" +
                    "- 只有在半魔法啟用 [ ✓ ] 時，滑桿才會生效。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "垃圾車載重容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛垃圾車可運載的垃圾量。**\n" +
                    "100% = 遊戲預設值。\n" +
                    "<100% = 20 噸>\n" +
                    "<500% = 100 噸。>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "每個設施可派出垃圾車數量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每座設施可以派出多少垃圾車。**\n" +
                    "100% = 原版預設數量。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**設施處理垃圾的速度。**\n" +
                    "100% = 原版處理速度。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "設施儲存容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施最多可以儲存多少垃圾。**\n" +
                    "100% = 原版儲存容量。\n" +
                    "數值越高 = 可以儲存更多垃圾。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "還原預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "將所有滑桿重設為 **100%**（原版數值）。\n" +
                    "恢復為正常的遊戲行為。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "推薦設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "套用推薦的半魔法數值：\n" +
                    "- 垃圾車載重容量：**200%**\n" +
                    "- 每設施垃圾車數量：**150%**\n" +
                    "- 處理速度：**200%**\n" +
                    "- 儲存容量：**150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此 Mod 的顯示名稱。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "目前的 Mod 版本。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "開啟作者在 **Paradox Mods** 上的 Mod 頁面。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在瀏覽器中開啟 **Discord**（CS2 Modding 伺服器）。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理模式>\n" +
                    "  * 完全魔法 開啟 = **[ ✓ ]**\n" +
                    "  * 全部垃圾會立刻被清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<自行管理模式>\n" +
                    "  * 啟用 半魔法 = **[ ✓ ]**\n" +
                    "  * 依喜好調整滑桿 [100 >> 500]。\n" +
                    "  * 保留原版風格的垃圾模擬，同時強化並可微調車輛與設施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<純原版玩法>\n" +
                    "  * 半魔法 = **[ ✓ ]**\n" +
                    "  * 點擊 **[還原預設]**\n" +
                    "  * 所有滑桿為 100%（原版）\n" +
                    "  * 完全等同標準遊戲體驗。\n"
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
