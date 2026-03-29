// File: Localization/LocaleZH_CN.cs
// Chinese Simplified (zh-HANS)

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
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]** 可让整座城市保持清洁。\n\n" +
                    "当 **Total Magic** 为 ON 时：\n" +
                    "- Trash Boss 会被强制设为 OFF。\n" +
                    "- Trash Boss 滑块不会生效（数值会保留下来，之后再用）。\n" +
                    "- 由于原版调度时机，一些卡车仍可能会移动。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系统；原版垃圾逻辑仍会继续运行。\n\n" +
                    "- 当 **Trash Boss 为 ON [ ✓ ]** 时，Total Magic 会被强制设为 OFF。\n" +
                    "- 滑块只有在启用 Trash Boss 时才会生效。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡车装载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆卡车能运多少垃圾。**\n" +
                    "100% = normal game default.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施存储量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施能储存多少垃圾。**\n" +
                    "100% = vanilla storage.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "设施处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理流入垃圾的速度。**\n" +
                    "100% = vanilla processing speed.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施能派出多少辆卡车。**\n" +
                    "100% = vanilla number of trucks.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchThresholdScale)), "建筑阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchThresholdScale)),
                    "可选：提高建筑获得垃圾收集服务所需达到的**阈值**。 \n" +
                    "提高它可以减少垃圾车交通；但太高会减少收运次数。\n" +
                    "大多数人<不>需要调整这个。在加入此选项之前模组就已经运行良好，这只是给实验用的额外选项。\n"+
                    "--------------------------------\n" +
                    "- **派车请求阈值 (R)** = 建筑需要达到的垃圾量，才能触发 <卡车派车请求>。\n" +
                    "- **拾取阈值 (P)** = 卡车能从建筑收集垃圾前所需的最低垃圾量。\n" +
                    "**1x** = 原版 (100 R, 20 P)。注意：**1,000** 垃圾单位通常等于 **1t**。\n" +
                    "<---------- Example ------------------------------------------>\n\n" +
                    "当滑块为 **20x** 时，建筑的 **R** 必须达到 >= **2,000 (2t)** 单位，卡车才会收到 <派车请求>；\n" +
                    "原版游戏中，如果卡车不是空的，它在前往/返回 <dispatch> 建筑途中也会在其他建筑停靠；在 20x 时，沿途建筑需要超过 **400 垃圾**（20 x 原版 P = 20）。\n" +
                    "平衡建议：调整此值时，请经常查看详细日志报告按钮。\n" +
                    "如果把阈值调得很高，房屋会在呼叫卡车前囤积垃圾更久，因此可能也需要提高卡车容量。"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用推荐的 Trash Boss 数值：\n" +
                    "- 卡车装载量：**200%**\n" +
                    "- 派车阈值：**5x**\n" +
                    "- 处理速度：**200%**\n" +
                    "- 存储容量：**150%**\n" +
                    "- 设施卡车数量：**140%**"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "将所有 Trash Boss 滑块恢复为原版数值。\n" +
                    "- 百分比滑块恢复到 **100%**。\n" +
                    "- 派车阈值恢复到 **1x**。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模组的显示名称。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Version" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打开 Paradox Mods 页面。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在浏览器中打开 Discord 邀请。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理状态>\n" +
                    "  * Total Magic ON  = **[ ✓ ]**\n" +
                    "  * 垃圾会自动清除 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手动管理状态>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 按自己需要设置滑块。\n" +
                    "  * 游戏垃圾机制不变；只是更适合手动管理的卡车/设施。\n" +
                    " <-------------------------------------->\n\n" +
                    "<普通原版游戏>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Click **[Game Defaults]**\n" +
                    "  * 所有滑块都为原版数值\n"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示当前全城垃圾量和总处理速率。\n" +
                    "如果月垃圾产量明显更高，请提高处理能力。\n" +
                    "**Produced** 和 **Processed** 使用每月吨数。\n" +
                    "<更新时间 = 上次刷新。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 当前尚未分配给卡车或路径的有效收集请求。\n" +
                    "**Dispatched** = 已经分配的有效收集请求。\n" +
                    "**Total** = 当前**有效**请求实体总数（在垃圾流程中）。\n\n" +
                    "技术说明：这和 <超过请求阈值> 不同。这里统计的是 <请求>，不是建筑。\n" +
                    "一些 Pending 请求之后会被分配；如果原版重新验证后认为目标已不再需要服务，也有一些会在之后被清除。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 当前持有垃圾的建筑。\n" +
                    "**Total** = 城市中所有会产生垃圾的建筑。\n" +
                    "**超过请求阈值** = 当前垃圾足够生成收集请求的**建筑**数量。\n" +
                    "原版中，请求阈值为 **100** 内部垃圾单位。\n" +
                    "Trash Boss 的 **派车阈值** 会同时提高拾取阈值和请求阈值。\n" +
                    "这会降低垃圾车交通，因为 <超过请求阈值> 的建筑数量和 <已派发> 总量都会下降。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的汇总。\n" +
                    "**Facilities** = 已统计的垃圾建筑。\n" +
                    "**Trucks total** = 这些设施拥有的垃圾车总数。\n" +
                    "**Max workers** = 这些设施的总最大工人数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 当前在城市中运行的卡车。\n" +
                    "**Returning** = 正在移动且被标记为返回设施的卡车子集。\n" +
                    "**Parked** = 停在设施中的卡车。\n" +
                    "**Total** = 所有垃圾车总数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "将详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "把更详细的垃圾报告写入 **Logs/MagicGarbage.log**。\n" +
                    "包括简短图例、原版参考值，以及很多当前城市垃圾统计数据。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "打开游戏的 Logs/.. 文件夹。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未加载城市。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} 吨已产生 | {1:N0} 吨已处理 | 更新于 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 个待处理 | {2:N0} 个已派遣 | 共 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高于请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 座设施 | 卡车总数 {1:N0} | 最大工人数 {2:N0}" },
                { "MG.Status.Row.Trucks", "{1:N0} 辆移动中（{3:N0} 辆返程中） | {2:N0} 辆已停放 | 共 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "暂无设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.Legend",
                    "说明：\n" +
                    "- 产生/处理 使用每月吨数。\n" +
                    "- 下方阈值使用内部垃圾单位，而不是吨。\n" +
                    "- 面向玩家显示时，游戏会将 1,000 单位换算为 1t。\n" +
                    "派遣阈值滑块：\n" +
                    "  - 收集阈值 = 卡车可以从建筑收集垃圾前所需的最小垃圾量。\n" +
                    "  - 请求阈值 = 游戏创建或保留收集请求前所需的最小垃圾量。\n" +
                    "- 警告图标 = 会让建筑上方出现警告图标的垃圾量。\n" +
                    "- 硬上限 = 建筑可累积的最大垃圾量。\n" +
                    "- 待处理 = 当前尚未分配给卡车或路径的活动请求。\n" +
                    "- 一些待处理请求稍后会被分配；如果 vanilla 重新校验后认为目标不再需要服务，另一些稍后也可能被清除。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "游戏阈值（内部垃圾单位）：收集={1:N0}，请求={0:N0}，警告图标={2:N0}，硬上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "阈值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 处理：{1:N0} t/月" },
                { "MG.Status.Log.Requests", "收集请求：待处理={1:N0}，已派遣={2:N0}，总计={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待处理目标最高垃圾量：{0:N0}（{1:N1}t）位置 {2}" },
                { "MG.Status.Log.Producers", "建筑：总计 {0:N0} | 有垃圾 {1:N0} | 高于请求阈值 {2:N0} | 警告级别 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅非零）：平均={0:N0}（{1:N1}t） | 中位数={2:N0}（{3:N1}t） | 最大={4:N0}（{5:N1}t）位置 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告的建筑（>= {1:N0} 单位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：总计 {0:N0} | 卡车总数 {1:N0} | 最大工人数 {2:N0}" },
                { "MG.Status.Log.Trucks", "垃圾卡车：移动中 {2:N0}（返程中 {3:N0}） | 已停放 {1:N0} | 已禁用 {4:N0} | 总计 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "设施摘要" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}：移动中={2:N0}，已停放={3:N0}，总计={1:N0}，最大工人数={4:N0}" },

            };
        }

        public void Unload()
        {
        }
    }
}
