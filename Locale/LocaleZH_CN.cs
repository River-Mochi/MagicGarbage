// Locale/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleZH_CN : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleZH_CN(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "关于" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自动清理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "自行管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "Mod 信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接"     },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用说明" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]** 后，会立刻清除全城所有垃圾。\n" +
                    "垃圾设施和垃圾车基本上只剩下观赏用途。\n\n" +

                    "当 **完全魔法** 处于开启状态时：\n" +
                    "- 半魔法模式会自动关闭。\n" +
                    "- 所有半魔法的滑块设置都会被忽略。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicEnabled)), "半魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicEnabled)),
                    "直接控制垃圾系统，同时保留原版（vanilla）垃圾模拟逻辑。\n\n" +
                    "- 当 **半魔法开启 [ ✓ ]** 时，完全魔法会自动关闭。\n" +
                    "- 可以调节所有垃圾车和垃圾处理建筑的性能。\n" +
                    "- 只有在半魔法启用 [ ✓ ] 时，滑块才会生效。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "垃圾车载重容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆垃圾车可以运载多少垃圾。**\n" +
                    "100% = 游戏默认值。\n" +
                    "<100% = 20 吨>\n" +
                    "<500% = 100 吨。>\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "每个设施可派出垃圾车数量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每座设施可以派出多少垃圾车。**\n" +
                    "100% = 原版默认数量。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理来垃圾的速度。**\n" +
                    "100% = 原版处理速度。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "设施存储容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施最多可以存放多少垃圾。**\n" +
                    "100% = 原版存储容量。\n" +
                    "更高的数值 = 可以存放更多垃圾。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "恢复默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "将所有滑块重置为 **100%**（原版数值）。\n" +
                    "恢复到正常的游戏行为。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "推荐设置" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "应用推荐的半魔法数值：\n" +
                    "- 垃圾车载重容量：**200%**\n" +
                    "- 每设施垃圾车数量：**150%**\n" +
                    "- 处理速度：**200%**\n" +
                    "- 存储容量：**150%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此 Mod 的显示名称。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "当前 Mod 版本。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "打开作者在 **Paradox Mods** 上的 Mod 页面。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开 **Discord**（CS2 Modding 服务器）。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理模式>\n" +
                    "  * 完全魔法 开启 = **[ ✓ ]**\n" +
                    "  * 所有垃圾会立刻被清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<自行管理模式>\n" +
                    "  * 启用 半魔法 = **[ ✓ ]**\n" +
                    "  * 按喜好调整 [100 >> 500] 的滑块。\n" +
                    "  * 保留原版风格的垃圾模拟，同时强化并可调节车辆和设施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<纯原版玩法>\n" +
                    "  * 半魔法 = **[ ✓ ]**\n" +
                    "  * 点击 **[恢复默认]**\n" +
                    "  * 所有滑块为 100%（原版）\n" +
                    "  * 完全等同于标准玩法。\n"
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
