// <copyright file="LocaleZH_CN.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "自行管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "高级用户" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状态" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "模组信息" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "链接" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "用法" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**启用 [ ✓ ]** 会保持整座城市干净。\n" +
                    "\n" +
                    "当 **Total Magic** 开启时：\n" +
                    "- Trash Boss 会被强制关闭。\n" +
                    "- Trash Boss 滑块不会应用（数值会保存以便之后使用）。\n" +
                    "- 由于 vanilla 调度逻辑的时机，少量卡车仍可能移动。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "直接管理垃圾系统；vanilla 垃圾逻辑仍会运行。\n" +
                    "\n" +
                    "- 当 **Trash Boss 开启 [ ✓ ]** 时，Total Magic 会被强制关闭。\n" +
                    "- 滑块只在 Trash Boss 启用时生效。\n" +
                    "- Total Magic + Trash Boss 都可以 **关闭** 以使用 vanilla 设置，\n" +
                    "  同时仍可查看 **状态报告**；它只在进入选项菜单时更新（轻量）。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "优先协助" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "协助严重超载的垃圾目标（建筑）。\n" +
                    "当 **开启** 时，会检查是否有活动请求目标达到 **7000+**（**7t**）垃圾。\n" +
                    "目标：按需减少额外的顺路收集，让卡车更快到达严重目标。\n" +
                    "这是轻度辅助，不是对 vanilla 路线逻辑的强制完整覆盖。\n" +
                    "轻量，无 Harmony 补丁。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "卡车载量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**每辆卡车能运多少垃圾。**\n" +
                    "**100% = 正常** 游戏默认值 (20t)。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "设施存储量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**设施可存放多少垃圾。**\n" +
                    "**100% = vanilla** 存储量。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "设施处理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**设施处理进入垃圾的速度。**\n" +
                    "**100% = vanilla** 处理速度。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "设施车队" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**每个设施可派出多少辆卡车。**\n" +
                    "**100% = vanilla** 卡车数量。\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "应用 **推荐** 的标准 Trash Boss 数值。\n" +
                    "不会更改高级用户设置（单独设置）。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "将 Trash Boss 滑块恢复为 **vanilla 数值**。\n" +
                    "<不会> 更改高级用户设置。\n" +
                    "**Vanilla:**\n" +
                    "- 百分比滑块恢复为 **100%**。\n" +
                    "- Dispatch Request Threshold 恢复为 **100 units**。\n" +
                    "- Pickup Threshold 恢复为 **20 units**。\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "高级用户选项" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "可选高级设置\n" +
                    "<警告：良好服务不需要>；提供给想实验或了解系统运作的玩家。\n" +
                    "当 **关闭** 时，高级用户项目会像普通 **vanilla** 游戏一样运行。\n" +
                    "当 **开启** 时，高级 **滑块会显示**。\n" +
                    "\n" +
                    "<--- 幸福度示例 --->\n" +
                    " - <Vanilla> 100/65 = 第一次惩罚在 <165>。\n" +
                    " - 点击 <推荐>，550/150 = 第一次惩罚在 <700>。\n" +
                    " - <很宽松> 950/200 = 第一次垃圾惩罚在 <1150>。\n" +
                    "方便：关闭此选项时会保存最后的滑块数值（方便之后再启用）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建筑在创建或保留卡车调度请求前所需的垃圾量。**\n" +
                    "Vanilla = **100** garbage units。\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "请保持等于或高于 Pickup Threshold。\n" +
                    "这通常会让更多卡车被使用，而不是停放。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**卡车可以从建筑收集前所需的最低建筑垃圾量。**\n" +
                    "Vanilla = **20** garbage units。\n" +
                    "Pickup 滑块<不能>高于 Dispatch Request (DR)；会被限制以避免逻辑问题。\n" +
                    "如果卡车被派往建筑，而 pickup 值高于 DR，卡车有时可能无法从该建筑收集（accumulation rate 也会影响）。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "垃圾幸福度基线" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**开始造成健康 + 幸福度惩罚前的建筑垃圾量。**\n" +
                    "**Vanilla = 100** garbage units。\n" +
                    "较高基线 = 建筑可在惩罚开始前容纳更多垃圾。\n" +
                    "100 garbage units = 0.1t\n" +
                    "概览：\n" +
                    "- <Threshold> = 系统行为触发点\n" +
                    "- <Baseline> = 惩罚公式起点\n" +
                    "- <Step> = 公式中的增量大小，也就是惩罚开始后增长速度"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "垃圾幸福度步进" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**超过基线后使 -1 惩罚开始的额外垃圾量。**\n" +
                    "Vanilla = **65** garbage units。\n" +
                    "Step 越高 = 惩罚增长越慢。\n" +
                    "游戏把垃圾惩罚上限设为 **-10**。\n" +
                    "Vanilla 第一次 <-1 penalty> 出现在 **165 garbage**（100 baseline + 65 step）\n" +
                    "更改 threshold 时若不配合幸福度滑块，可能会产生比正常更重的惩罚。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "累积率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**缩放受支持建筑的垃圾来源值。**\n" +
                    "注意：这是强力杠杆，改变该比例会影响很多东西。\n" +
                    "不使用它也可以获得良好系统。\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate。\n" +
                    "**20%** = 积累慢很多。\n" +
                    "**200%** = 双倍速度——大量垃圾。\n" +
                    "20% 时，所有 Cims 显然都在堆肥，所以垃圾累积率低得多 ;)\n" +
                    "\n" +
                    "技术说明：游戏会在一天中逐步增加垃圾，不是一次性增加。"
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推荐" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "应用 **推荐** 的高级用户数值。\n" +
                    "开启高级用户。\n" +
                    "第一次垃圾惩罚从 **700** garbage（550 baseline + 150 step）开始。\n" +
                    "除非手动更改，Garbage Accumulation Rate 保持 **100%** vanilla。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "游戏默认值" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "将所有高级用户数值 **恢复为 vanilla**。\n" +
                    "关闭 **高级用户**。\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "模组" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "此模组的显示名称。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "版本" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "当前模组版本。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "打开 Paradox Mods 页面。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "在浏览器中打开 Discord 邀请。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自动清理状态>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * 垃圾会自动移除 - 完成。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<自行管理状态>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 按需要设置滑块。\n" +
                    "  * 可选：开启高级滑块（非必需）。\n" +
                    "  * 同样的游戏垃圾系统；更好地自行管理卡车/设施。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<状态 / vanilla 状态>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * 仅显示状态报告。\n" +
                    "  * Vanilla 垃圾游戏不变。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "用法" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "垃圾服务评分" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "来自游戏的简单垃圾幸福度评分。\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= 需要小幅调整。游戏经常在 0 到 -1 之间，可以忽略（数值已四舍五入）。\n" +
                    "**-2 to -4** = 有点臭\n" +
                    "**-5 to -10** = 垃圾问题\n" +
                    "**间接调节：** 使用 <trash sliders> 随时间减少垃圾累积来改善。\n" +
                    "**直接调节：** Garbage Happiness Baseline + Garbage Happiness Step 会改变 Cims 不开心前<能容忍的量>。\n" +
                    "**Garbage Accumulation Rate**：改变受支持建筑产生垃圾的速度。请谨慎使用，因为平衡很重要。多数玩家不需要调整。\n" +
                    "<Update time = 最后刷新时间。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "达到或超过 **7t / 7000** 垃圾的垃圾生产建筑数量。\n" +
                    "这些是严重超载建筑，启用 [x] Priority Assist 可更好地优先处理。\n" +
                    "如果想查看 Entity ID 编号，请使用 Status to log 按钮。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "垃圾/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "显示当前全城垃圾量和总垃圾处理率。\n" +
                    "如果每月产生的垃圾高出很多，请提高处理能力。\n" +
                    "**Produced** 和 **Processed** 使用吨/月。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "收集请求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 尚未分配给卡车或路径的活动收集请求。\n" +
                    "**Dispatched** = 已分配的活动收集请求。\n" +
                    "**Total** = 当前垃圾流程中的 **active** request entity 数量。\n" +
                    "\n" +
                    "技术说明：这不同于 <Above request threshold>。这里统计 <requests>，不是建筑。\n" +
                    "一些 pending requests 稍后会被分配；如果 vanilla 重新验证认为目标不再需要服务，也可能稍后清除。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建筑" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 当前持有任何垃圾的建筑。\n" +
                    "**Total** = 城市中所有垃圾生产建筑。\n" +
                    "**Above request threshold** = 当前有足够垃圾创建收集请求的 **buildings** 数量。\n" +
                    "Vanilla 中，request threshold 是 **100** internal garbage units。\n" +
                    "Power User Options 可覆盖 request 和 pickup thresholds。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "设施" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "已统计垃圾设施的摘要。\n" +
                    "**Facilities** = 统计到的垃圾建筑。\n" +
                    "**Garbage trucks** = 普通收集卡车。在 Industrial Waste 设施中，它们收集工业废物而不是垃圾。\n" +
                    "**Dump trucks** = 设施之间的垃圾转运。\n" +
                    "**Max workers** = 这些相同设施的总工人容量。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "垃圾卡车" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 当前在城市中行驶的卡车。\n" +
                    "**Returning** = moving trucks 中被标记返回设施的子集。\n" +
                    "**Parked** = 停在设施的卡车。\n" +
                    "**Total** = 所有垃圾卡车数量。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "详细状态写入日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "将更详细的垃圾报告写入 **Logs/MagicGarbage.log**。\n" +
                    "包括整理好的城市垃圾统计"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "打开日志" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "打开游戏 Logs/.. 文件夹。" },

                // Runtime status strings
                { "MG.Status.NoCity", "尚未加载城市。" },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "需要小幅调整 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "有点臭 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "垃圾问题 ({0:N0}) | 已更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 超过 7t" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 设施 | {1:N0}/{2:N0} 垃圾/自卸卡车 | {3:N0} 工人" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "暂无设施数据。" },

                // Log strings
                { "MG.Status.Log.Title", "垃圾状态 ({0})" },
                { "MG.Status.Log.City", "城市：{0}" },
                { "MG.Status.Log.Mode", "模式：Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "当前模组设置" },
                { "MG.Status.Log.SettingsTrashBoss", "Trash Boss 滑块（已保存）：truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%" },
                { "MG.Status.Log.SettingsPowerUser",
                    "高级用户（已保存）：enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "图例：\n" +
                    "- Produced/Processed 使用吨/月。\n" +
                    "- 下面的 threshold 值使用 internal garbage units，不是吨。\n" +
                    "- 面向玩家显示时，游戏会把 100 units = 0.1t，1,000 units = 1t。\n" +
                    "- Garbage Service Rating = 游戏城市垃圾幸福度系数。\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = 需要小幅调整，或可忽略\n" +
                    "  - -2 to -4 = 有点臭\n" +
                    "  - -5 to -10 = 垃圾问题\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = 卡车从建筑收集前所需的最低垃圾量。\n" +
                    "  - Request threshold = 游戏创建或保留收集请求前所需的最低垃圾量。\n" +
                    "- Warning icon = 会在建筑上方出现警告图标的垃圾量。\n" +
                    "- Hard cap = 建筑可累积的最大垃圾量。\n" +
                    "- Pending = 尚未分配给卡车或路径的活动请求。\n" +
                    "- 一些 pending requests 稍后会被分配；如果 vanilla 重新验证认为目标不再需要服务，也可能清除。\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "游戏 Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData 不可用>" },
                { "MG.Status.Log.GarbageProcessing", "垃圾：{0:N0} t/月 | 处理：{1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "垃圾服务评分：{0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "收集请求：pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最高 pending 目标垃圾：{0:N0} ({1:N1}t) 于 {2}" },
                { "MG.Status.Log.PendingPeakNone", "最高 pending 目标垃圾：无" },
                { "MG.Status.Log.Producers", "建筑：{0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "建筑垃圾（仅非零）：avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) 于 {6}" },
                { "MG.Status.Log.NearWarning75", "接近 warning icon 的建筑（至少 {1:N0} units / {2:N1}t）：{0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "设施：{0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "垃圾卡车：{2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "设施摘要" },
                { "MG.Status.Log.FacilityLine",
                    "- 设施 {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "需要小幅调整" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "有点臭" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "垃圾问题" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + 服务" },
                { "MG.Status.Log.RequestsHeader", "请求" },
                { "MG.Status.Log.BuildingsHeader", "建筑" },

                { "MG.Status.Log.CriticalBuildingsHeader", "超过 7t 的严重建筑" },
                { "MG.Status.Log.LocalTransferProbeHeader", "本地垃圾转运探测" },
                { "MG.Status.Log.LocalTransferProbeNone", "未找到本地垃圾设施。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部连接垃圾转运探测" },
                { "MG.Status.Log.OutsideTransferProbeNone", "未找到外部连接垃圾设施。" },

                { "MG.Status.Log.TransferProbeHeader", "垃圾转运探测" },
                { "MG.Status.Log.TransferProbeNone", "未找到垃圾存储-转运设施。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "卡车" },
                { "MG.Status.Log.SettingsPriority", "优先系统（已保存）：enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "优先协助 live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}" },
                { "MG.Status.Log.PriorityPeak", "最高严重建筑：{0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "优先协助" },
                { "MG.Status.Log.PriorityPasses", "优先轮次：raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "最高活动严重建筑：无" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "优先协助上次扫描时间={0:N3} ms" },
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
