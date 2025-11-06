// Locale/LocaleZH_CN.cs

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
                // Options -> mod name
                { m_Setting.GetSettingsLocaleID(), "Magic Garbage Truck [MGT]" },

                // Tabs
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab),   "关于" },

                // Groups (row headers)
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "完全魔法" },
                { m_Setting.GetOptionGroupLocaleID(Setting.SemiMagicGrp),  "半魔法模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp),  "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接" },

                // -----------------------------------------------------------------
                // Total Magic section
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.MagicGarbage)),
                    "魔法垃圾"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.MagicGarbage)),
                    "**启用 [x]** 会立即清除全城的所有垃圾。\n" +
                    "- 除非你只是喜欢这些建筑的外观，否则不再需要任何垃圾处理建筑。\n\n" +

                    "<请只使用这个 **完全魔法** 选项，或者下面的 **半魔法** 选项之一——不要两个一起用。>\n" +
                    "- 即使两个都勾选了也不会出错，只是没有额外效果。"
                },

                // -----------------------------------------------------------------
                // Semi-Magic section (slider only)
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "垃圾车容量"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**半魔法** 超级垃圾车模式。\n" +
                    "- 如果你只是想让垃圾更容易处理，而不是彻底删除：\n" +
                    "- 魔法垃圾 = **[OFF] 关闭**\n" +
                    "- 然后使用滑块 **[100 >> 500]** 提高每辆垃圾车的容量。\n\n" +

                    "**---------------------------------------**\n" +
                    " 滑块根据原版游戏数值按比例调整容量。\n" +
                    "**100% = 每车 20 吨**（原版默认）\n" +
                    "**500% = 每车 100 吨**\n\n" +
                    " 额外效果：卸载速度会随容量一起放大，因此车辆在垃圾设施卸货不会花更长时间。\n\n" +
                    "**---------------------------------------**\n\n" +
                    "如果想完全恢复原版体验，只需关闭魔法垃圾，并把滑块调回 100%。\n"
                },

                // -----------------------------------------------------------------
                // About info
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)),
                    "模组"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)),
                    "此模组在菜单中显示的名称。"
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)),
                    "版本"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)),
                    "当前模组版本。"
                },

                // -----------------------------------------------------------------
                // About links
                // -----------------------------------------------------------------
                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)),
                    "Paradox Mods 页面"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)),
                    "在浏览器中打开 Magic Garbage Truck 的 Paradox Mods 页面。"
                },

                {
                    m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)),
                    "Discord"
                },
                {
                    m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)),
                    "在浏览器中打开 CS2 Modding Discord 服务器。"
                },
            };
        }

        public void Unload()
        {
        }
    }
}
