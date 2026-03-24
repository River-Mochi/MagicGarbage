// File: Locale/LocaleZH_CN.cs
// Simplified Chinese (zh-HANS)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "操作" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "关于" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自动清理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手动管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状态" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使用说明" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]** 后可让整座城市保持干净。\n\n" +
                    "当 **Total Magic** 为 ON 时：\n" +
                    "- Trash Boss 会被强制设为 OFF。\n" +
                    "- Trash Boss 滑块不会生效（数值仍会保存）。\n"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "在保留原版垃圾系统逻辑的同时，直接调整垃圾系统。\n\n" +
                    "- 当 **Trash Boss 为 ON [ ✓ ]** 时，Total Magic 会被强制设为 OFF。\n" +
                    "- 只有启用 Trash Boss 时滑块才会生效。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "垃圾车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆垃圾车可运输的垃圾量。**\n" +
                    "100% = 游戏默认值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理流入垃圾的速度。**\n" +
                    "100% = 原版速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施存储容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施可储存的垃圾量。**\n" +
                    "100% = 原版容量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施可派出的垃圾车数量。**\n" +
                    "100% = 原版车辆数。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用推荐的 Trash Boss 数值：\n" +
                    "- 垃圾车载量：**200%**\n" +
                    "- 处理速度：**200%**\n" +
                    "- 存储容量：**160%**\n" +
                    "- 设施垃圾车数量：**140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "将所有滑块恢复为 **100%**（原版数值）。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打开 Paradox Mods 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在浏览器中打开 Discord 邀请链接。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理模式>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 垃圾几乎会被立刻清除\n" +
                    " <-------------------------------------->\n\n" +
                    "<手动管理模式>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 按喜好调整滑块。\n" +
                    "  * 保留原版垃圾逻辑，同时更好地管理车辆/设施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<普通原版模式>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 点击 **[游戏默认]**\n" +
                    "  * 所有滑块恢复到 100%（原版）\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), string.Empty },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示全城当前垃圾量和总处理速度。\n" +
                    "如果每月 Produced 远高于 Processed，就应该提高处理能力。\n" +
                    "**Produced** 和 **Processed** 使用每月吨数。\n" +
                    "更新时间 = 上次刷新时间。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 仍未分配垃圾车或路线的有效收集请求。\n" +
                    "**Dispatched** = 已经分配的有效收集请求。\n" +
                    "**Total** = 当前所有有效的垃圾收集请求。\n" +
                    "这个数字有时会暂时高于 **Above request threshold**，因为旧请求会在之后由游戏重新验证后清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 当前有垃圾的建筑。\n" +
                    "**Total** = 城市中所有会产生垃圾的建筑。\n" +
                    "**Above request threshold** = 垃圾量已经达到可创建收集请求条件的建筑。\n" +
                    "在原版中通常表示超过 <100> 垃圾单位。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的汇总信息。\n" +
                    "**Facilities** = 已统计的垃圾设施数量。\n" +
                    "**Trucks total** = 这些设施拥有的垃圾车总数。\n" +
                    "**Max workers** = 这些设施的最大员工容量总和。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 当前在城市中行驶的垃圾车。\n" +
                    "**Returning** = Moving 中正在返回设施的那部分车辆。\n" +
                    "**Parked** = 停在设施里的垃圾车。\n" +
                    "**Total** = 垃圾车总数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "将详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "将更详细的垃圾报告写入 **Logs/MagicGarbage.log**。\n" +
                    "包括简短说明、当前阈值、停用车辆以及每个设施的最大员工数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "打开 Logs/ 文件夹。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未加载城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} 吨已产生 | {1:N0} 吨已处理 | 更新于 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 待处理 | {2:N0} 已派发 | 总计 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 超过请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 个设施 | 垃圾车总计 {1:N0} | 最大员工 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 行驶中 ({3:N0} 返回中) | {2:N0} 停放中 | 总计 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "暂无设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市: {0}" },
                { "MG.Status.Log.Mode", "模式: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "说明:\n" +
                    "- Produced/Processed 使用每月吨数。\n" +
                    "- 下方阈值使用的是内部垃圾单位，不是吨。\n" +
                    "- 收集阈值 = 垃圾车会从建筑收集垃圾所需的最低垃圾量。\n" +
                    "- 请求阈值 = 游戏创建或保留收集请求所需的最低垃圾量。\n" +
                    "- 警告阈值 = 建筑上方可能出现警告图标的垃圾量。\n" +
                    "- 上限 = 建筑可累积的最大垃圾量。\n" +
                    "- 返回中 = 行驶中的一部分车辆。\n" +
                    "- 有效请求数量有时会暂时高于超过请求阈值的建筑数量，因为旧请求会在之后由原版重新验证后清除。\n" +
                    "- 下方员工数字目前显示的是每个设施的 **最大员工数**。"
                },
                { "MG.Status.Log.Thresholds",
                    "阈值 (内部垃圾单位): 收集={1:N0}, 请求={0:N0}, 警告={2:N0}, 上限={3:N0}"
                },
                { "MG.Status.Log.ThresholdsMissing", "阈值: <GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾: {0:N0} 吨/月 | 处理: {1:N0} 吨/月" },
                { "MG.Status.Log.Requests", "收集请求: 待处理={1:N0}, 已派发={2:N0}, 总计={0:N0}" },
                { "MG.Status.Log.Producers", "建筑: 总计={0:N0} | 有垃圾={1:N0} | 超过请求阈值={2:N0} | 警告等级={3:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施: 总计={0:N0} | 垃圾车总计={1:N0} | 最大员工={2:N0}" },
                { "MG.Status.Log.Trucks", "垃圾车: 行驶中={2:N0} ({3:N0} 返回中) | 停放中={1:N0} | 已停用={4:N0} | 总计={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "设施汇总" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}: 行驶中={2:N0}, 停放中={3:N0}, 总计={1:N0}, 最大员工={4:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
