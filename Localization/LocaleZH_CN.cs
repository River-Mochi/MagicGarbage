// File: Localization/LocaleZH_CN.cs
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
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "高级模式" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状态" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "终极魔法" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**已启用 [ ✓ ]** 可让整座城市保持清洁。\n\n" +
                    "当 **终极魔法** 为 ON 时：\n" +
                    "- **垃圾管理** 会被强制设为 OFF。\n" +
                    "- **垃圾管理** 的滑块不会生效（数值会保留，供之后使用）。\n" +
                    "- 由于 vanilla 调度逻辑的时机问题，仍可能有少量卡车继续移动。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "垃圾管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系统；vanilla 的垃圾逻辑仍会继续运行。\n\n" +
                    "- 当 **垃圾管理为 ON [ ✓ ]** 时，**终极魔法** 会被强制设为 OFF。\n" +
                    "- 只有启用 **垃圾管理** 时，滑块才会生效。\n" +
                    "- 如果只想看 **状态报告**，**终极魔法** 和 **垃圾管理** 都可以保持 **OFF**。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆卡车能运多少垃圾。**\n" +
                    "**100% = 正常** 游戏默认值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施存储量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施可存放多少垃圾。**\n" +
                    "**100% = vanilla** 存储量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "设施处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理输入垃圾的速度。**\n" +
                    "**100% = vanilla** 处理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施能派出多少辆卡车。**\n" +
                    "**100% = vanilla** 卡车数量。\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用 **垃圾管理** 的标准**推荐**数值。\n" +
                    "不会改动 **高级模式** 设置（两者分开）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "将 **垃圾管理** 的滑块恢复为 **vanilla 数值**。\n" +
                    "<不会> 改动 **高级模式** 设置。\n" +
                    "**Vanilla：**\n" +
                    "- 百分比滑块会回到 **100%**。\n" +
                    "- Dispatch Request Threshold 会回到 **100 units**。\n" +
                    "- Pickup Threshold 会回到 **20 units**。\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "高级模式选项" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "可选高级设置\n" +
                    "<警告：并非必需>，照样可以获得良好服务；这是给想要试验或更了解系统运作方式的玩家准备的。\n" +
                    "当 **OFF** 时，所有 **高级模式** 设置都会**保持 vanilla**。\n" +
                    "当 **ON** 时，会出现**高级滑块**。\n\n" +
                    "<--- 满意度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第一次惩罚在 <165>。\n" +
                    " - 点击 <推荐> 可使用 550/150 = 第一次惩罚在 <700>。\n" +
                    " - <非常宽松> 950/200 = 第一次垃圾惩罚在 <1150>。\n" +
                    "方便之处：当此选项为 OFF 时，滑块上次的数值会被保存（以后想启用时还能继续用）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建筑在创建或保留卡车调度请求前所需的垃圾量。**\n" +
                    "Vanilla = **100** units garbage.\n" +
                    "**100 units garbage = 0.1t**\n" +
                    "**1,000 units garbage = 1t**\n" +
                    "请保持此值等于或高于 Pickup Threshold。\n" +
                    "这通常会让更多卡车处于使用中，而不是停放中。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡车可从建筑收集垃圾前，建筑至少需要达到的垃圾量。**\n" +
                    "Vanilla = **20** units garbage.\n" +
                    "拾取滑块 <不能> 高于 Dispatch Request (DR)；系统会自动限制，以防逻辑出错。\n" +
                    "如果卡车已经被派往某建筑，而拾取值又高于 DR，那么这辆卡车有时可能无法从该建筑收集垃圾（垃圾累积速率也会影响这一点）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾满意度基线" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建筑垃圾量在开始造成健康 + 满意度惩罚前的基准值。**\n" +
                    "**Vanilla = 100** units garbage.\n" +
                    "基线越高 = 建筑在惩罚开始前能容纳更多垃圾。\n" +
                    "100 units garbage = 0.1t\n" +
                    "概览：\n" +
                    "- <Threshold> = 系统行为触发点\n" +
                    "- <Baseline> = 惩罚公式的起点\n" +
                    "- <Step> = 公式中的增量大小，也就是惩罚开始后增长得有多快"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾满意度步进" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超过基线后，开始触发 -1 惩罚所需的额外垃圾量。**\n" +
                    "Vanilla = **65** units garbage.\n" +
                    "步进越高 = 惩罚增长越慢。\n" +
                    "游戏会将垃圾惩罚上限限制为 **-10**。\n" +
                    "Vanilla 的第一次 <-1 penalty> 出现在 **165 garbage**（100 baseline + 65 step）\n" +
                    "调整阈值时，最好也一起平衡满意度滑块，否则惩罚可能会比正常更重。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "垃圾累积速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**缩放受支持建筑的垃圾来源数值。**\n" +
                    "这是个很强的杠杆，改动这个速率会影响很多东西。\n" +
                    "就算不用它，也可以得到一个不错的系统。\n\n" +
                    "**100% = vanilla** 累积速率。\n" +
                    "**20%** = 累积得慢很多。\n" +
                    "**200%** = 双倍速率 - 垃圾会非常多。\n" +
                    "在 20% 下，所有 Cims 显然都在堆肥，所以垃圾累积自然更低；)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "应用 **高级模式** 的**推荐**数值。\n" +
                    "会将 **高级模式** 设为 ON。\n" +
                    "第一次垃圾惩罚会从 **700** garbage 开始（550 baseline + 150 step）。\n" +
                    "除非手动更改，否则垃圾累积速率会保持 **100%** vanilla。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "将 **高级模式** 的数值恢复为 **vanilla**。\n" +
                    "会将 **高级模式** 设为 **OFF**。\n"
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
                    "<自动清理状态>\n" +
                    "  * 终极魔法 ON = **[ ✓ ]**\n" +
                    "  * 垃圾会被自动移除 - 完成。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手动管理状态>\n" +
                    "  * 垃圾管理 = **[ ✓ ]**\n" +
                    "  * 按需要调整滑块。\n" +
                    "  * 可选：启用高级滑块（不是必须）。\n" +
                    "  * 还是同样的游戏垃圾系统；但卡车/设施可自行管理得更好。\n" +
                    " <-------------------------------------->\n\n" +
                    "<状态 / vanilla 状态>\n" +
                    "  * 终极魔法 = OFF\n" +
                    "  * 垃圾管理 = OFF\n" +
                    "  * 仅显示状态报告。\n" +
                    "  * 游戏的 vanilla 垃圾系统不变。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服务评分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "游戏中的全城垃圾满意度简易评分。\n" +
                    "**0 = 优秀**\n" +
                    "**-1 = 需要小调整** 游戏经常会在 0 到 -1 之间波动，可以忽略。\n" +
                    "**-2 到 -4 = 有点臭**\n" +
                    "**-5 到 -10 = 垃圾问题严重**\n" +
                    "**间接调节：** 卡车/设施/阈值滑块可以随着时间推移减少实际垃圾堆积，从而改善这个评分。\n" +
                    "**直接调节：** <垃圾满意度基线> + <垃圾满意度步进> 会改变市民在不满前能容忍多少垃圾。\n" +
                    "**来源速率调节：** <垃圾累积速率> 会改变受支持建筑产生垃圾的速度。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示当前全城垃圾量与总垃圾处理速率。\n" +
                    "如果每月产生的垃圾远高于处理量，就该提高处理能力。\n" +
                    "**Produced** 和 **Processed** 以每月吨数显示。\n" +
                    "<更新时间 = 上次刷新时间。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 当前尚未分配给卡车或路径的活动收集请求。\n" +
                    "**Dispatched** = 已经分配出去的活动收集请求。\n" +
                    "**Total** = 当前 **active** 请求实体的数量（在 garbage 流程中）。\n\n" +
                    "技术说明：这和 <高于请求阈值> 不一样。这里统计的是 <请求>，不是建筑。\n" +
                    "有些待处理请求稍后会被分配；如果 vanilla 重新验证后认为目标已不再需要服务，有些请求也会在之后被清掉。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 当前持有任意垃圾的建筑。\n" +
                    "**Total** = 城市中所有产生垃圾的建筑。\n" +
                    "**高于请求阈值** = 当前拥有足够垃圾、可生成收集请求的**建筑**数量。\n" +
                    "在 vanilla 中，请求阈值是 **100** internal units garbage。\n" +
                    "**高级模式选项** 可以覆盖请求阈值和拾取阈值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的汇总。\n" +
                    "**设施** = 已统计的垃圾建筑。\n" +
                    "**Garbage trucks** = 普通收集卡车。在工业废弃物设施中，它们收集的是工业废弃物，而不是普通垃圾。\n" +
                    "**Dump trucks** = 垃圾在设施之间的转运卡车。\n" +
                    "**Max workers** = 这些设施的总工人容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 当前正在城里行驶的卡车。\n" +
                    "**Returning** = 正在移动、且被标记为返回设施的那部分卡车。\n" +
                    "**Parked** = 停在设施内的卡车。\n" +
                    "**Total** = 全部 garbage trucks 的数量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "将详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "将更详细的 garbage 报告写入 **Logs/MagicGarbage.log**。\n" +
                    "包含简短图例、vanilla 参考值，以及很多额外的真实城市垃圾统计。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "打开游戏的 Logs/.. 文件夹。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "还没有加载城市。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "优秀 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "稍微调一下更好 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "有点臭 ({0:N0}) | 更新于 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾问题 ({0:N0}) | 更新于 {1}" },

                { "MG.Status.Row.GarbageProcessing", "已产生 {0:N0} t | 已处理 {1:N0} t" },
                { "MG.Status.Row.Requests", "{1:N0} 待处理 | {2:N0} 已派出 | {0:N0} 总计" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高于请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 个设施 | {1:N0}/{2:N0} 垃圾/Dump卡车 | {3:N0} 工人" },
                { "MG.Status.Row.Trucks", "{1:N0} 行驶中 ({3:N0} 返回中) | {2:N0} 停放 | {0:N0} 总计" },
                { "MG.Status.Row.FacilitiesNone", "还没有设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：终极魔法={0}，垃圾管理={1}" },
                { "MG.Status.Log.SettingsHeader", "当前模组设置" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "垃圾管理滑块（已保存）：卡车载量={0:N0}% | 设施存储量={1:N0}% | 设施处理速度={2:N0}% | 设施车队={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "高级模式（已保存）：enabled={0} | request={1:N0} | pickup={2:N0} | 满意度基线={3:N0} | 满意度步进={4:N0} | 累积速率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "图例：\n" +
                    "- Produced/Processed 使用每月吨数。\n" +
                    "- 下方阈值使用的是 internal units garbage，不是吨。\n" +
                    "- 对玩家显示时，游戏会把 100 units = 0.1t，1,000 units = 1t。\n" +
                    "- 垃圾服务评分 = 游戏中的城市垃圾满意度系数。\n" +
                    "  - 0 = 优秀\n" +
                    "  - -1 = 需要小调整，或者也可以忽略\n" +
                    "  - -2 到 -4 = 有点臭\n" +
                    "  - -5 到 -10 = 垃圾问题严重\n" +
                    "阈值滑块：\n" +
                    "  - Pickup threshold = 卡车可从建筑收集前所需的最小垃圾量。\n" +
                    "  - Request threshold = 游戏创建或保留收集请求前所需的最小垃圾量。\n" +
                    "- Warning icon = 会让建筑上方出现警告图标的垃圾量。\n" +
                    "- Hard cap = 建筑可累积的最大垃圾量。\n" +
                    "- Pending = 当前尚未分配给卡车或路径的活动请求。\n" +
                    "- 有些待处理请求稍后会被分配；如果 vanilla 重验证认为目标已不再需要服务，有些请求也会在之后被清掉。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "游戏阈值（internal units garbage）：pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "阈值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "Garbage：{0:N0} t/月 | Processing：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服务评分：{0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "收集请求：pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待处理目标中的最高垃圾量：{0:N0} ({1:N1}t) 于 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待处理目标中的最高垃圾量：无" },
                { "MG.Status.Log.Producers", "建筑：{0:N0} warning icons | {1:N0} total | {2:N0} 有垃圾 | {3:N0} 高于请求阈值 " },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅非零）：avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) 于 {6}" },
                { "MG.Status.Log.NearWarning75", "接近 warning icon 的建筑（至少 {1:N0} units / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：{0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "Garbage trucks：{2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "设施汇总" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}：garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "优秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小调整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有点臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾问题严重" },
            };
        }

        public void Unload()
        {
        }
    }
}
