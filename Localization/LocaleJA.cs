// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Japanese (ja-JP)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

    public sealed class LocaleJA : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleJA(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "情報" },
                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動クリーン" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "パワーユーザー" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "ステータス" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod 情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると街全体をきれいに保ちます。\n" +
                    "\n" +
                    "**Total Magic** が ON の間:\n" +
                    "- Trash Boss は強制的に OFF になります。\n" +
                    "- Trash Boss のスライダーは適用されません（値は後で使うため保存されます）。\n" +
                    "- バニラの dispatch ロジックのタイミングにより、少数のトラックがまだ動くことがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "バニラのゴミ処理ロジックを動かしたまま、ゴミシステムを直接管理します。\n" +
                    "\n" +
                    "- **Trash Boss が ON [ ✓ ]** のとき、Total Magic は強制的に OFF になります。\n" +
                    "- スライダーは Trash Boss が有効なときだけ適用されます。\n" +
                    "- Total Magic と Trash Boss の両方を **OFF** にするとバニラ設定に戻せます。\n" +
                    "  その状態でも **ステータスレポート** は表示でき、Options メニューを開いたときだけ更新されます（軽量）。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "優先アシスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "ひどく過負荷になったゴミ対象（建物）を補助します。\n" +
                    "**ON** のとき、アクティブなリクエスト対象が **7000+**（**7t**）のゴミに達しているか確認します。\n" +
                    "目的: 必要に応じて余分な寄り道回収を減らし、トラックが問題の大きい対象へ早く向かえるようにします。\n" +
                    "これは軽い後押しであり、バニラの経路ロジックを強く完全上書きするものではありません。\n" +
                    "軽量で、Harmony パッチはありません。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるゴミの量です。**\n" +
                    "**100% = 通常の** ゲーム既定値 (20t)。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設保管量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるゴミの量です。**\n" +
                    "**100% = vanilla の** 保管量。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入したゴミを処理する速さです。**\n" +
                    "**100% = vanilla の** 処理速度。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラックの数です。**\n" +
                    "**100% = vanilla の** トラック数。\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "標準の Trash Boss **おすすめ** 値を適用します。\n" +
                    "Power User 設定（別枠）は変更しません。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Trash Boss スライダーを **vanilla 値** に戻します。\n" +
                    "Power User 設定は<変更しません>。\n" +
                    "**Vanilla:**\n" +
                    "- パーセントスライダーは **100%** に戻ります。\n" +
                    "- Dispatch Request Threshold は **100 units** に戻ります。\n" +
                    "- Pickup Threshold は **20 units** に戻ります。\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Power User オプション" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "任意の上級設定\n" +
                    "<警告: 良いサービスには不要> です。試したい人やシステムの仕組みを学びたい人向けです。\n" +
                    "**OFF** のとき、Power User 項目は通常の **vanilla** ゲームのように動作します。\n" +
                    "**ON** のとき、上級 **スライダーが表示** されます。\n" +
                    "\n" +
                    "<--- 幸福度の例 --->\n" +
                    " - <Vanilla> 100/65 = 最初のペナルティは <165>。\n" +
                    " - <おすすめ> を押すと 550/150 = 最初のペナルティは <700>。\n" +
                    " - <とても緩い> 950/200 = 最初のゴミペナルティは <1150>。\n" +
                    "便利機能: このオプションを OFF にしても最後のスライダー値は保存されます（後で再有効化したい場合）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**トラックの dispatch request が作成または維持される前に建物に必要なゴミ量です。**\n" +
                    "Vanilla = **100** garbage units。\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "Pickup Threshold 以上にしてください。\n" +
                    "通常、駐車中よりも使用されるトラック数が増えます。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**トラックが建物から回収できるようになる前の最低ゴミ量です。**\n" +
                    "Vanilla = **20** garbage units。\n" +
                    "Pickup スライダーは Dispatch Request (DR) より高くできません。ロジックの問題を防ぐためにクランプされます。\n" +
                    "トラックが建物へ派遣され、pickup 値が DR より高い場合、その建物から回収できないことがあります（accumulation rate も影響します）。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "ゴミ幸福度ベースライン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**健康 + 幸福度ペナルティが始まる前の建物ゴミ量です。**\n" +
                    "**Vanilla = 100** garbage units。\n" +
                    "ベースラインが高いほど、ペナルティ開始前に建物がより多くのゴミを保持できます。\n" +
                    "100 garbage units = 0.1t\n" +
                    "概要:\n" +
                    "- <Threshold> = システム動作の発動点\n" +
                    "- <Baseline> = ペナルティ式の開始点\n" +
                    "- <Step> = 式の増分サイズ。開始後にペナルティがどれだけ早く増えるか"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "ゴミ幸福度ステップ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**ベースラインを超えて -1 ペナルティが始まる追加ゴミ量です。**\n" +
                    "Vanilla = **65** garbage units。\n" +
                    "ステップが高いほど、ペナルティの増加は遅くなります。\n" +
                    "ゲームはゴミペナルティを **-10** で上限にします。\n" +
                    "Vanilla の最初の <-1 penalty> は **165 garbage** で発生します (100 baseline + 65 step)\n" +
                    "幸福度スライダーと合わせずに threshold を変更すると、通常より重いペナルティになることがあります。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "蓄積率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**対応している建物のゴミ発生源値をスケールします。**\n" +
                    "注意: これは強力なレバーで、変更すると多くの要素に影響します。\n" +
                    "これを使わなくても良いシステムにできます。\n" +
                    "\n" +
                    "**100% = vanilla** accumulation rate。\n" +
                    "**20%** = かなり遅い蓄積。\n" +
                    "**200%** = 2倍、かなり大量のゴミ。\n" +
                    "20% では全住民が明らかに堆肥化しているので、ゴミ蓄積率がとても低くなります ;)\n" +
                    "\n" +
                    "技術メモ: ゲームはゴミを一度にではなく、1日を通して少しずつ追加します。"
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Power User の **おすすめ** 値を適用します。\n" +
                    "Power User を ON にします。\n" +
                    "最初のゴミペナルティは **700** garbage (550 baseline + 150 step) で始まります。\n" +
                    "Garbage Accumulation Rate は手動で変更しない限り **100%** vanilla のままです。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "すべての Power User 値を **vanilla** に戻します。\n" +
                    "**Power User を OFF** にします。\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この mod の表示名。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の mod バージョン。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods ページを開きます。" },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "ブラウザーで Discord 招待を開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * Total Magic ON = **[ ✓ ]**\n" +
                    "  * ゴミは自動で削除されます - 完了。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<手動管理状態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 好きなようにスライダーを設定します。\n" +
                    "  * 任意: 上級スライダーを使う場合は ON（必須ではありません）。\n" +
                    "  * 同じゲームのゴミ処理を、トラック/施設でよりよく手動管理します。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<ステータス / vanilla 状態>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * ステータスレポートのみ。\n" +
                    "  * Vanilla のゴミゲームは変更されません。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "ゴミサービス評価" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "ゲームからのシンプルなゴミ幸福度評価です。\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= 少し調整が必要。ゲームは 0 から -1 の間になることが多く、無視してもよい場合があります（数値は丸め）。\n" +
                    "**-2 to -4** = 少し臭い\n" +
                    "**-5 to -10** = ゴミ問題\n" +
                    "**間接的な調整:** <trash sliders> を使い、時間をかけてゴミ蓄積を減らして改善します。\n" +
                    "**直接的な調整:** Garbage Happiness Baseline + Garbage Happiness Step は、Cim が不満になる前に<許容する量>を変えます。\n" +
                    "**Garbage Accumulation Rate**: 対応建物がゴミを出す速さを変えます。バランスが大事なので注意。ほとんどのプレイヤーは調整不要です。\n" +
                    "<Update time = 最終更新時刻。>"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "**7t / 7000** 以上のゴミを持つゴミ発生建物の数です。\n" +
                    "これらはひどく過負荷の建物です。[x] Priority Assist を有効にすると優先しやすくなります。\n" +
                    "Entity ID 番号を調べたい場合は Status to log ボタンを使ってください。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ゴミ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "現在の都市全体のゴミ量と合計ゴミ処理率を表示します。\n" +
                    "月間のゴミ発生量が大きく上回る場合は、処理能力を増やしてください。\n" +
                    "**Produced** と **Processed** は tons per month を使います。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 現在トラックや経路に割り当てられていないアクティブな回収リクエスト。\n" +
                    "**Dispatched** = すでに割り当て済みのアクティブな回収リクエスト。\n" +
                    "**Total** = 現在の **active** request entity（ゴミパイプライン内）を数えます。\n" +
                    "\n" +
                    "技術メモ: これは <Above request threshold> とは違います。建物ではなく <requests> を数えます。\n" +
                    "一部の pending requests は後で割り当てられます。バニラの再検証で対象がもうサービス不要と判断された場合、後で消えることもあります。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 現在ゴミを保持している建物。\n" +
                    "**Total** = 都市内のすべてのゴミ発生建物。\n" +
                    "**Above request threshold** = 回収リクエストを作れるだけのゴミを持つ **buildings** の現在数。\n" +
                    "Vanilla では request threshold は **100** internal garbage units です。\n" +
                    "Power User Options は request と pickup thresholds を上書きできます。\n" +
                    ""
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "数えたゴミ施設の概要です。\n" +
                    "**Facilities** = 数えたゴミ建物。\n" +
                    "**Garbage trucks** = 通常の回収トラック。Industrial Waste 施設では、ゴミではなく産業廃棄物を回収します。\n" +
                    "**Dump trucks** = 施設間のゴミ転送。\n" +
                    "**Max workers** = 同じ施設全体の労働者定員合計。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "ゴミ収集車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 現在都市内に出ているトラック。\n" +
                    "**Returning** = moving trucks のうち、施設へ戻るフラグが付いたもの。\n" +
                    "**Parked** = 施設に駐車中のトラック。\n" +
                    "**Total** = すべてのゴミ収集車の数。"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細ステータスをログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳細なゴミレポートを **Logs/MagicGarbage.log** に送ります。\n" +
                    "整理された都市ゴミ統計を含みます"
                },
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "ゲームの Logs/.. フォルダーを開きます。" },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },
                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "少し調整が必要 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "少し臭い ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "ゴミ問題 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} が 7t 超え" },
                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0}/{2:N0} garbage/dump trucks | {3:N0} workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "まだ施設データがありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ゴミステータス ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "現在の mod 設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss スライダー (保存値): truck load={0:N0}% | facility storage={1:N0}% | facility process={2:N0}% | facility fleet={3:N0}%"
                },
                { "MG.Status.Log.SettingsPowerUser",
                    "Power User (保存値): enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- Produced/Processed は tons per month を使います。\n" +
                    "- 下の threshold 値は tons ではなく internal garbage units です。\n" +
                    "- プレイヤー表示では、ゲームは 100 units = 0.1t、1,000 units = 1t に変換します。\n" +
                    "- Garbage Service Rating = 都市のゴミ幸福度係数。\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = 少し調整が必要、または無視可\n" +
                    "  - -2 to -4 = 少し臭い\n" +
                    "  - -5 to -10 = ゴミ問題\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = トラックが建物から回収する前の最低ゴミ量。\n" +
                    "  - Request threshold = ゲームが回収リクエストを作成または維持する前の最低ゴミ量。\n" +
                    "- Warning icon = 建物の上に警告アイコンが出るゴミ量。\n" +
                    "- Hard cap = 建物が蓄積できる最大ゴミ量。\n" +
                    "- Pending = 現在トラックや経路に割り当てられていないアクティブなリクエスト。\n" +
                    "- 一部の pending requests は後で割り当てられます。バニラの再検証で対象が不要と判断されると消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "ゲーム Thresholds (internal garbage units): pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}" },
                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData not available>" },
                { "MG.Status.Log.GarbageProcessing", "ゴミ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "ゴミサービス評価: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "回収リクエスト: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最大 pending 対象ゴミ: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "最大 pending 対象ゴミ: なし" },
                { "MG.Status.Log.Producers", "建物: {0:N0} warning icons | {1:N0} total | {2:N0} has garbage | {3:N0} above request threshold " },
                { "MG.Status.Log.ProducerGarbageStats", "建物ゴミ (非ゼロのみ): avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "警告アイコン付近の建物 (at least {1:N0} units / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: {0:N0} total | {1:N0} garbage trucks | {2:N0} dump trucks ({3:N0} moving) | {4:N0} workers" },
                { "MG.Status.Log.Trucks", "ゴミ収集車: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine",
                    "- 施設 {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}"
                },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "少し調整が必要" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "少し臭い" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "ゴミ問題" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Service" },
                { "MG.Status.Log.RequestsHeader", "リクエスト" },
                { "MG.Status.Log.BuildingsHeader", "建物" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 超えの危険建物" },
                { "MG.Status.Log.LocalTransferProbeHeader", "ローカルゴミ転送プローブ" },
                { "MG.Status.Log.LocalTransferProbeNone", "ローカルゴミ施設が見つかりません。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部接続ゴミ転送プローブ" },
                { "MG.Status.Log.OutsideTransferProbeNone", "外部接続ゴミ施設が見つかりません。" },

                { "MG.Status.Log.TransferProbeHeader", "ゴミ転送プローブ" },
                { "MG.Status.Log.TransferProbeNone", "ゴミ保管転送施設が見つかりません。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) / cap={3,7:N0} ({4,4:N1}t) | accept={5:N2} | send={6:N2} | inReq={7} | outReq={8} | {9}"
                },

                { "MG.Status.Log.TrucksHeader", "トラック" },
                { "MG.Status.Log.SettingsPriority", "優先システム (保存値): enabled={0} | trigger={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "優先アシスト live={0} | interval={1:N0} frames | last scanned buildings={2:N0} | critical buildings={3:N0}" },
                { "MG.Status.Log.PriorityPeak", "最大危険建物: {0:N0} ({1:N1}t) | {2} | request={3}" },

                { "MG.Status.Log.PriorityHeader", "優先アシスト" },
                { "MG.Status.Log.PriorityPasses", "優先パス: raised={0:N0} | normal={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "最大アクティブ危険建物: なし" },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "優先アシスト最終スキャン時間={0:N3} ms" },
#endif
                { "MG.Status.Log.CriticalBuildingsNone", "なし" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },

            };
        }

        public void Unload()
        {
        }
    }
}
