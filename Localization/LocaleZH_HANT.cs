// File: Localization/LocaleZH_HANT.cs
// Traditional Chinese (zh-HANT)

namespace MagicGarbage
{
    using Colossal; // IDictionarySource, IDictionaryEntryError
    using System.Collections.Generic;

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
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "模組資訊" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "連結" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用說明" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**啟用 [ ✓ ]** 可立即清除全城所有垃圾。\n\n" +

                    "**完全魔法** 開啟時：\n" +
                    "- 半魔法 會被強制關閉。\n" +
                    "- 半魔法 的滑桿 **不會生效**（你的數值會保留，之後可繼續用）。\n" +
                    "- 由於遊戲的派遣邏輯，仍可能有少量垃圾車在路上（通常是空車）。"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "半魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "直接管理垃圾系統；原版垃圾邏輯仍會運作。\n\n" +
                    "- **半魔法 開啟 [ ✓ ]** 時，完全魔法會自動關閉。\n" +
                    "- 只有在 半魔法 開啟 [ ✓ ] 時，滑桿才會生效。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "垃圾車載重" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每輛車能裝多少垃圾。**\n" +
                    "100% = 遊戲預設。\n" +
                    "<100% = 20t>\n" +
                    "<500% = 100t>\n"
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
                    "**設施可存放的垃圾量。**\n" +
                    "100% = 原版容量。\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "設施出車數量"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每個設施最多可派出多少輛車。**\n" +
                    "100% = 原版數量。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)), "推薦" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "套用推薦的 Semi-Magic 數值：\n" +
                    "- 垃圾車載重：**200%**\n" +
                    "- 處理速度：**200%**\n" +
                    "- 儲存容量：**160%**\n" +
                    "- 設施出車數量：**140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)), "遊戲預設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "將所有滑桿恢復為 **100%**（原版數值）。\n" +
                    "恢復正常的原版遊戲行為。"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模組" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此模組的顯示名稱。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "目前模組版本。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "開啟作者在 **Paradox Mods** 的頁面。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在瀏覽器中開啟 **Discord**（CS2 Modding）。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動清理狀態>\n" +
                    "  * 完全魔法 開啟 = **[ ✓ ]**\n" +
                    "  * 全城垃圾立即清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理狀態>\n" +
                    "  * Semi-Magic 開啟 = **[ ✓ ]**\n" +
                    "  * 依需求調整滑桿。\n" +
                    "  * 原版邏輯 + 更好管理的車輛/設施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<一般原版遊戲>\n" +
                    "  * Semi-Magic 開啟 = **[ ✓ ]**\n" +
                    "  * 點擊 **[遊戲預設]**\n" +
                    "  * 所有滑桿 100%（原版）\n"
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
