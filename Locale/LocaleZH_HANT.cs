// LocaleZH_HANT.cs
// Chinese Traditional (zh-HANT)

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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "關於" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "完全魔法" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "半魔法模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "模組資訊"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明"   },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**勾選 [X]** 時，城市中所有垃圾會立刻被清除。\n" +
                    "垃圾處理建築與垃圾車幾乎只剩下視覺裝飾。\n\n" +

                    "當 **完全魔法** 開啟時：\n" +
                    "- 半魔法模式會自動關閉。\n" +
                    "- 所有半魔法滑桿設定都會被忽略。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "半魔法模式" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "維持一般垃圾玩法，但強化相關數值。\n" +
                    "- 不使用完全魔法，而是強化垃圾車與處理設施。\n" +
                    "- 半魔法模式開啟時，完全魔法會自動關閉。\n" +
                    "- 只有啟用半魔法模式，下方滑桿才會生效。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "每車載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛垃圾車可運送的垃圾量。**\n" +
                    "- 100% = 原版載量。\n" +
                    "- 數值越高，需要的往返次數越少。\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "每座設施車輛數" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個垃圾設施可以派出的垃圾車數量。**\n" +
                    "- 100% = 原版車輛數。\n" +
                    "- 最高 400% = 最多可增加 300% 的車輛。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "處理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**垃圾處理設施處理垃圾的速度。**\n" +
                    "- 100% = 原版速度。\n" +
                    "- 數值越高，垃圾燒除 / 回收越快。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "設施儲存容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**設施在顯示「已滿」之前能儲存的垃圾量。**\n" +
                    "- 100% = 原版容量。\n" +
                    "- 數值越高，在顯示滿載之前可容納的垃圾越多。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "恢復原版" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "將所有半魔法滑桿重設為 **100%**（原版數值）。\n" +
                    "若只想安裝模組、但不想變更垃圾服務數值，可以使用此選項。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "推薦設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "套用推薦的半魔法數值：\n" +
                    "- 每車載量：**200%**\n" +
                    "- 每設施車輛數：**150%**\n" +
                    "- 處理速度：**200%**\n" +
                    "- 儲存容量：**200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此模組在選項中顯示的名稱。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "目前模組版本。" },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "開啟作者在 Paradox Mods 上的模組頁面。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在瀏覽器中開啟 CS2 模組 Discord 伺服器。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<建議預設狀態>\n" +
                    "  * 完全魔法 開 = **[X]**\n" +
                    "  * 城市垃圾會立刻全部清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<半魔法超級垃圾車狀態>\n" +
                    "  * 完全魔法 關 = **[ ]**\n" +
                    "  * 半魔法 開 = **[X]**，再將滑桿調整到喜歡的 [100 >> 500] / [100 >> 400]。\n" +
                    "  * 保留原版風格，但垃圾車與設施更加強力。\n" +
                    " <-------------------------------------->\n\n" +
                    "<完全原版遊戲>\n" +
                    "  * 完全魔法 關 = **[ ]**\n" +
                    "  * 半魔法 = **[X]**（按下「恢復原版」按鈕）\n" +
                    "  * 所有滑桿為 100%（原版上限）\n" +
                    "  * 完全與原版一樣的遊戲體驗。\n"
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
