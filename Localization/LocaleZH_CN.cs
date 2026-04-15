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


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "优先协助" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "用于帮助严重过载的垃圾目标（建筑）。\n" +
                    "**ON** 时，会检查是否有活动请求目标达到 **7000+**（**7t**）垃圾。\n" +
                    "目标：在需要时减少额外的顺路收集，让卡车更快到达严重目标。\n" +
                    "这是辅助，不是对 vanilla 路线逻辑的强制完全覆盖。\n" +
                    "轻量，无 Harmony 补丁。"
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

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "高级模式选项" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**可选的高级阈值 + 垃圾满意度 + 累积率调整。**\n" +
                    "当 **关闭** 时，收集/请求阈值、垃圾满意度和垃圾累积速率都会保持 **vanilla**。\n" +
                    "当 **开启** 时，会显示高级 **滑块**。\n\n" +
                    "<--- 垃圾满意度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第 1 次惩罚在 <165>。\n" +
                    " - <推荐> 550/150 = 第 1 次惩罚在 <700>。\n" +
                    " - <非常宽松> 950/200 = 第 1 次垃圾惩罚在 <1150>。\n" +
                    "方便：即使此项关闭，最后使用的滑块数值也会被保存（以后想启用时还能用）。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "派车请求阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建筑在创建或保留卡车派车请求之前所需的垃圾量。**\n" +
                    "Vanilla = **100** 垃圾单位。\n" +
                    "**100 垃圾单位 = 0.1t**\n" +
                    "**1,000 垃圾单位 = 1t**\n" +
                    "请把它保持在不低于收集阈值。\n" +
                    "通常这会让使用中的卡车变多，停着的卡车变少。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "收集阈值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡车可以从建筑收集垃圾之前所需的最小垃圾量。**\n" +
                    "Vanilla = **20** 垃圾单位。\n" +
                    "回收不能高于派车请求，超出时会被限制。\n" +
                    "请让派车请求保持在可回收阈值或更高，以避免逻辑问题；" +
                    " 如果卡车已派往某建筑而回收值更高，卡车可能无法回收该建筑的垃圾（累积速率也会影响）。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用 **垃圾管理** 的标准**推荐**数值。\n" +
                    "不会改动 **高级模式** 设置（两者分开）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "把 Trash Boss 滑块恢复到 **vanilla 数值**。\n" +
                    "不会<改变>高级模式设置。\n" +
                    "**Vanilla:**\n" +
                    "- 百分比滑块恢复到 **100%**。\n" +
                    "- 派车请求阈值恢复到 **100 单位**。\n" +
                    "- 收集阈值恢复到 **20 单位**。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾满意度基线" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建筑开始受到健康 + 满意度惩罚之前的垃圾水平。**\n" +
                    "**Vanilla = 100** 垃圾单位。\n" +
                    "基线越高 = 建筑在惩罚开始前能容忍更多垃圾。\n" +
                    "100 垃圾单位 = 0.1t\n" +
                    "说明:\n" +
                    "- <阈值> = 触发系统行为的点\n" +
                    "- <基线> = 惩罚公式的起点\n" +
                    "- <步长> = 公式中的增量大小，也就是惩罚开始后增长得有多快"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾满意度步长" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超过基线后，触发 -1 惩罚所需的额外垃圾量。**\n" +
                    "Vanilla = **65** 垃圾单位。\n" +
                    "步长越高 = 惩罚增长越慢。\n" +
                    "游戏把垃圾惩罚上限设为 **-10**。\n" +
                    "vanilla 的第一次 <-1 惩罚> 出现在 **165 垃圾**（基线 100 + 步长 65）\n" +
                    "如果修改阈值，也要配合调整满意度滑块，否则惩罚可能会比正常更重。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "累积速率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**缩放受支持建筑的垃圾来源数值。**\n" +
                    "注意：这是个影响很强的调节项，改动这个速率会影响很多东西。\n" +
                    "即使不用它，也可以做出一个不错的系统。\n\n" +
                    "**100% = vanilla** 累积率。\n" +
                    "**20%** = 累积慢很多。\n" +
                    "**200%** = 双倍速度——垃圾会非常多。\n" +
                    "在 20% 时，市民显然都在认真堆肥，所以垃圾累积率也低得多 ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "应用 **推荐** 的高级模式数值。\n" +
                    "会开启高级模式。\n" +
                    "第一次垃圾惩罚会在 **700** 垃圾时开始（基线 550 + 步长 150）。\n" +
                    "除非手动修改，否则累积速率会保持 **100%** vanilla。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "游戏默认" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "把所有高级模式数值都恢复为 **vanilla**。\n" +
                    "会关闭 **高级模式**。\n"
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
                    "游戏里的简单城市垃圾满意度评级。\n" +
                    "**0 = 优秀**\n" +
                    "**-1 = 需要稍微调一下** 游戏经常会在 0 到 -1 之间波动，可以忽略。\n" +
                    "**-2 到 -4 = 有点臭**\n" +
                    "**-5 到 -10 = 垃圾问题**\n" +
                    "**间接调节：** 卡车/设施/阈值滑块可以随着时间改善这一点，因为它们会减少真实垃圾堆积。\n" +
                    "**直接调节：** <垃圾满意度基线> + <垃圾满意度步长> 会改变市民在不高兴之前能容忍多少垃圾。\n" +
                    "**来源速率调节：** <累积率> 会改变受支持建筑产生垃圾的速度。"
                },



                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "达到或超过 **7t / 7000** 垃圾的产垃圾建筑数量。\n" +
                    "这些建筑已经严重过载，启用 [x] 优先协助 可更好地优先处理它们。\n" +
                    "如果要查看实体 ID 编号进行检查，请使用“将详细状态写入日志”按钮。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示当前全城垃圾量和总处理速率。\n" +
                    "如果每月产生的垃圾远高于处理量，就该提高处理能力。\n" +
                    "**已产生** 和 **已处理** 使用每月吨数。\n" +
                    "<更新时间 = 上次刷新。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**待处理** = 当前尚未分配给卡车或路径的活动收集请求。\n" +
                    "**已派出** = 已经分配出去的活动收集请求。\n" +
                    "**总计** = 当前 **活动** 请求实体的数量（在垃圾流程中）。\n\n" +
                    "技术说明：这和 <高于请求阈值> 不一样。这里统计的是 <请求>，不是建筑。\n" +
                    "有些待处理请求会在之后被分配；如果 vanilla 重新验证后认为目标已不需要服务，它们也可能会被清掉。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**有垃圾** = 当前持有垃圾的建筑。\n" +
                    "**总计** = 城市中所有产生垃圾的建筑。\n" +
                    "**高于请求阈值** = 当前拥有足够垃圾、可以创建收集请求的 **建筑** 数量。\n" +
                    "在 vanilla 中，请求阈值是 **100** 内部垃圾单位。\n" +
                    "高级模式选项可以覆盖请求阈值和收集阈值。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的摘要。\n" +
                    "**设施** = 已统计的垃圾建筑。\n" +
                    "**垃圾卡车** = 普通收集卡车。在工业废弃物设施中，它们收集的是工业废弃物，而不是普通垃圾。\n" +
                    "**Dump 卡车** = 设施之间转运垃圾的卡车。\n" +
                    "**最大工人** = 这些设施的总工人容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**移动中** = 当前正在城里行驶的卡车。\n" +
                    "**返回中** = 正在移动、且被标记为返回设施的那部分卡车。\n" +
                    "**停放中** = 停在设施内的卡车。\n" +
                    "**总计** = 全部垃圾卡车的数量。"
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
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 超过 7t" },

                { "MG.Status.Row.GarbageProcessing", "已产生 {0:N0} t | 已处理 {1:N0} t" },
                { "MG.Status.Row.Requests", "{1:N0} 待处理 | {2:N0} 已派出 | {0:N0} 总计" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} 有垃圾 | {2:N0} 高于请求阈值" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 个设施 | {1:N0}/{2:N0} 垃圾/Dump卡车 | {3:N0} 工人" },
                { "MG.Status.Row.Trucks", "{1:N0} 移动中 ({3:N0} 返回中) | {2:N0} 停放中 | {0:N0} 总计" },
                { "MG.Status.Row.FacilitiesNone", "还没有设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：终极魔法={0}，垃圾管理={1}" },
                { "MG.Status.Log.SettingsHeader", "当前模组设置" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss 滑块（已保存）：卡车载量={0:N0}% | 设施储量={1:N0}% | 设施处理={2:N0}% | 设施车队={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "高级模式选项（已保存）：启用={0} | 请求={1:N0} | 收集={2:N0} | 满意度基线={3:N0} | 满意度步长={4:N0} | 累积速率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "说明：\n" +
                    "- 已产生/已处理 使用每月吨数。\n" +
                    "- 下方阈值使用的是内部垃圾单位，不是吨。\n" +
                    "- 对玩家显示时，游戏会把 100 单位换算为 0.1t，把 1,000 单位换算为 1t。\n" +
                    "- 垃圾服务评级 = 游戏中的城市垃圾满意度系数。\n" +
                    "  - 0 = 优秀\n" +
                    "  - -1 = 需要稍微调一下，或者可以忽略\n" +
                    "  - -2 到 -4 = 有点臭\n" +
                    "  - -5 到 -10 = 垃圾问题\n" +
                    "阈值滑块：\n" +
                    "  - 回收阈值 = 卡车能从建筑回收垃圾之前所需的最小垃圾量。\n" +
                    "  - 请求阈值 = 游戏创建或保留回收请求之前所需的最小垃圾量。\n" +
                    "- 警告图标 = 会让建筑上方出现警告图标的垃圾量。\n" +
                    "- 上限 = 建筑可累积的最大垃圾量。\n" +
                    "- 待处理 = 当前尚未分配给卡车或路径的活动请求。\n" +
                    "- 有些待处理请求会在之后被分配；如果 vanilla 重新验证后认为目标已不需要服务，它们也可能会被清掉。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "游戏阈值（内部垃圾单位）：收集={1:N0}，请求={0:N0}，警告图标={2:N0}，上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "阈值：<GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 处理：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服务评级：{0} | 原始值={1:N2} | 四舍五入={2:N0}" },
                { "MG.Status.Log.Requests", "收集请求：待处理={1:N0}，已派出={2:N0}，总计={0:N0}" },
                { "MG.Status.Log.PendingPeak", "待处理目标中的最高垃圾量：{0:N0} ({1:N1}t) 位于 {2}" },
                { "MG.Status.Log.PendingPeakNone", "待处理目标中的最高垃圾量：无" },
                { "MG.Status.Log.Producers", "建筑：{0:N0} 警告图标 | {1:N0} 总计 | {2:N0} 有垃圾 | {3:N0} 高于请求阈值 " },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅非零值）：平均={0:N0} ({1:N1}t) | 中位数={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 位于 {6}" },
                { "MG.Status.Log.NearWarning75", "接近警告图标的建筑（至少 {1:N0} 单位 / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：{0:N0} 总计 | {1:N0} 垃圾卡车 | {2:N0} Dump卡车 ({3:N0} 移动中) | {4:N0} 工人" },
                { "MG.Status.Log.Trucks", "垃圾卡车：{2:N0} 移动中 ({3:N0} 返回中) | {1:N0} 停放中 | {4:N0} 已禁用 | {0:N0} 总计" },
                { "MG.Status.Log.FacilitiesHeader", "设施摘要" },
                { "MG.Status.Log.FacilityLine", "- 设施 {0}：垃圾卡车={1:N0} ({2:N0} 移动中，{3:N0} 停放中) | Dump卡车={4:N0} ({5:N0} 移动中) | 工人={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "优秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "稍微调一下更好" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有点臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾问题" },

                { "MG.Status.Log.ThresholdsHeader", "阈值 + 服务" },
                { "MG.Status.Log.RequestsHeader", "请求" },
                { "MG.Status.Log.BuildingsHeader", "建筑" },

                { "MG.Status.Log.CriticalBuildingsHeader", "超过 7t 的严重建筑" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾转运探针" },
                { "MG.Status.Log.TransferProbeNone", "未找到垃圾存储转运设施。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | 已存={1,7:N0} ({2,4:N1}t) | 容量={3,7:N0} ({4,4:N1}t) | 导出={5,7:N0} ({6,4:N1}t) | 低位={7,7:N0} ({8,4:N1}t) | 最小={9,7:N0} ({10,4:N1}t) | 出/入={11,6:N0}/{12,6:N0} | 活动={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "卡车" },

                { "MG.Status.Log.SettingsPriority",
                    "优先协助（已保存）：启用={0} | 触发值={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "优先协助" },
                { "MG.Status.Log.PriorityState",
                    "优先协助实时={0} | 间隔={1:N0} 帧 | 上次扫描请求数={2:N0} | 活动严重请求目标={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "优先处理轮次：提升={0:N0} | 普通={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "最高的活动严重目标：无" },
                { "MG.Status.Log.PriorityPeak",
                    "最高的活动严重目标：{0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "待处理" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "已派出" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "优先协助上次扫描耗时={0:N3} ms" },
#endif

                { "MG.Status.Log.CriticalBuildingsNone", "无" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },
            };
        }

        public void Unload()
        {
        }
    }
}
