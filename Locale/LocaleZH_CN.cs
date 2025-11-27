// LocaleZH_CN.cs
// Chinese Simplified (zh-CN)

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
                // Options mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "关于" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "完全魔法" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "半魔法模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "模组信息"   },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接"       },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用说明"   },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**勾选 [X]** 时，城市里的所有垃圾会立刻被清除。\n" +
                    "垃圾处理建筑和垃圾车几乎只剩下视觉效果。\n\n" +

                    "当 **完全魔法** 处于开启状态时：\n" +
                    "- 半魔法模式会被自动关闭。\n" +
                    "- 所有半魔法的滑块设置都会被忽略。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic toggle (master switch for sliders)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagic)), "半魔法模式" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagic)),
                    "保持正常的垃圾系统玩法，但数值有所强化。\n" +
                    "- 不再是完全魔法，而是更强的垃圾车和处理设施。\n" +
                    "- 半魔法模式开启时，会自动关闭完全魔法。\n" +
                    "- 只有在半魔法模式开启时，下方滑块才会生效。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic sliders
                // -----------------------------------------------------------------

                // Truck load capacity (per vehicle)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "单车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆垃圾车能运走的垃圾量。**\n" +
                    "- 100% = 原版载量。\n" +
                    "- 数值越高，需要的往返次数越少。\n"
                },

                // Facility truck count (how many trucks can be dispatched)
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "每座设施的车辆数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个垃圾设施可以派出的垃圾车数量。**\n" +
                    "- 100% = 原版车辆数。\n" +
                    "- 最高 400% = 最多增加 300% 的车辆。\n"
                },

                // Facility processing speed
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**垃圾处理设施处理垃圾的速度。**\n" +
                    "- 100% = 原版速度。\n" +
                    "- 数值越高，垃圾烧毁/回收得越快。\n"
                },

                // Facility storage capacity
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "设施存储容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施在显示“已满”之前能存放的垃圾量。**\n" +
                    "- 100% = 原版容量。\n" +
                    "- 数值越高，显示已满之前的缓冲空间越大。\n"
                },

                // -----------------------------------------------------------------
                // Semi-Magic helper buttons (same row)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "恢复原版" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicDefaults)),
                    "将所有半魔法滑块重置为 **100%**（原版数值）。\n" +
                    "如果你只想安装模组、但不想改动垃圾服务数值，可以使用此选项。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "推荐设置" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.SemiMagicRecommended)),
                    "应用推荐的半魔法数值：\n" +
                    "- 单车载量：**200%**\n" +
                    "- 每设施车辆数：**150%**\n" +
                    "- 处理速度：**200%**\n" +
                    "- 存储容量：**200%**\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此模组在选项中的显示名称。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "打开作者在 Paradox Mods 上的模组页面。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开 CS2 模组 Discord 服务器。"
                },

                // -----------------------------------------------------------------
                // About -> USAGE NOTES (multiline text block)
                // -----------------------------------------------------------------
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<推荐默认状态>\n" +
                    "  * 完全魔法 开 = **[X]**\n" +
                    "  * 城市垃圾会立刻全部清理\n" +
                    " <-------------------------------------->\n\n" +
                    "<半魔法超级垃圾车状态>\n" +
                    "  * 完全魔法 关 = **[ ]**\n" +
                    "  * 半魔法 开 = **[X]**，然后将滑块调到你喜欢的 [100 >> 500] / [100 >> 400]。\n" +
                    "  * 保留原版风格的同时，垃圾车和设施更加强力。\n" +
                    " <-------------------------------------->\n\n" +
                    "<完全原版游戏>\n" +
                    "  * 完全魔法 关 = **[ ]**\n" +
                    "  * 半魔法 = **[X]**（点“恢复原版”按钮）\n" +
                    "  * 所有滑块 100%（原版上限）\n" +
                    "  * 完全与原版相同的玩法。\n"
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
