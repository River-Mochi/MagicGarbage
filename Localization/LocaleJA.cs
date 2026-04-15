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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "アクション" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "情報" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "自動クリーン" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "セルフ管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "上級者" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "トータルマジック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると街全体をきれいに保ちます。\n\n" +
                    "**トータルマジック** が ON の間:\n" +
                    "- Trash Boss は強制的に OFF になります。\n" +
                    "- Trash Boss のスライダーは適用されません（値は後で使えるよう保存されます）。\n" +
                    "- バニラの配車ロジックのタイミングにより、少数のトラックはまだ動くことがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "ごみシステムを直接管理します。バニラのごみロジックはそのまま動作します。\n\n" +
                    "- **Trash Boss** が ON [ ✓ ] のとき、トータルマジックは強制的に OFF になります。\n" +
                    "- スライダーは Trash Boss が有効なときだけ適用されます。\n" +
                    "- トータルマジックと Trash Boss を両方 **OFF** にするとバニラ設定に戻せます。\n" +
                    "  その状態でも **ステータスレポート** は確認でき、更新はオプションメニューを開いたときだけ行われます（軽量）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "優先アシスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                    "深刻に過負荷なごみ対象（建物）への補助です。\n" +
                    "**ON** のとき、アクティブなリクエスト対象が **7000+**（**7t**）のごみに達しているか確認します。\n" +
                    "目的: 必要に応じて余計な寄り道回収を減らし、トラックが深刻な対象へ早く到達できるようにします。\n" +
                    "これは後押しであり、バニラの経路ロジックを完全に強制上書きするものではありません。\n" +
                    "軽量で、Harmony パッチは使いません。"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるごみ量です。**\n" +
                    "**100% = 通常** のゲーム既定値（20t）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設保管量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるごみ量です。**\n" +
                    "**100% = バニラ** の保管量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が搬入されたごみを処理する速さです。**\n" +
                    "**100% = バニラ** の処理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラック数です。**\n" +
                    "**100% = バニラ** の台数。\n"
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "推奨" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**推奨** の標準 Trash Boss 値を適用します。\n" +
                    "上級者設定は変更しません（別扱い）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Trash Boss のスライダーを **バニラ値** に戻します。\n" +
                    "上級者設定は <変更しません>。\n" +
                    "**バニラ:**\n" +
                    "- パーセント系スライダーは **100%** に戻ります。\n" +
                    "- Dispatch Request Threshold は **100 units** に戻ります。\n" +
                    "- Pickup Threshold は **20 units** に戻ります。\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "上級者オプション" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "任意の高度な設定\n" +
                    "<警告: 良いサービスに必須ではありません>。実験したい、あるいは仕組みをもっと知りたいプレイヤー向けです。\n" +
                    "**OFF** のとき、上級者項目は通常の **バニラ** ゲームと同じ動作になります。\n" +
                    "**ON** のとき、**高度なスライダーが表示** されます。\n\n" +
                    "<--- 幸福度の例 --->\n" +
                    " - <Vanilla> 100/65 = 最初のペナルティは <165>。\n" +
                    " - <推奨> を押すと 550/150 = 最初のペナルティは <700>。\n" +
                    " - <とても緩い> 950/200 = 最初のごみペナルティは <1150>。\n" +
                    "便利機能: このオプションが OFF でも最後のスライダー値は保存されるため、後で再度有効化できます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Dispatch Request Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**トラック dispatch リクエストが作成または維持される前に建物に必要なごみ量です。**\n" +
                    "Vanilla = **100** garbage units.\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "この値は Pickup Threshold 以上にしてください。\n" +
                    "通常、駐車中よりも使用中のトラック数が増えやすくなります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Pickup Threshold" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**トラックが回収できるようになる前に建物に必要な最小ごみ量です。**\n" +
                    "Vanilla = **20** garbage units.\n" +
                    "Pickup スライダーは Dispatch Request（DR）より高く <できません>。ロジック破綻を防ぐため制限されます。\n" +
                    "トラックが建物へ dispatch されても pickup 値が DR より高いと、その建物から回収できない場合があります（蓄積率も影響します）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "ごみ幸福度ベースライン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**健康 + 幸福度ペナルティが始まる前の建物ごみ量です。**\n" +
                    "**Vanilla = 100** garbage units.\n" +
                    "ベースラインが高いほど、建物はペナルティ開始前により多くのごみを抱えられます。\n" +
                    "100 garbage units = 0.1t\n" +
                    "概要:\n" +
                    "- <Threshold> = システム挙動の発動点\n" +
                    "- <Baseline> = ペナルティ計算式の開始点\n" +
                    "- <Step> = 計算式の増分サイズ。開始後にどれだけ速くペナルティが強くなるか"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "ごみ幸福度ステップ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**ベースラインを超えた追加ごみ量で -1 ペナルティが始まります。**\n" +
                    "Vanilla = **65** garbage units.\n" +
                    "ステップが高いほど、ペナルティの増加は遅くなります。\n" +
                    "ゲーム内のごみペナルティ上限は **-10** です。\n" +
                    "Vanilla の最初の <-1 ペナルティ> は **165 garbage**（100 baseline + 65 step）で発生します\n" +
                    "幸福度スライダーを調整せずに threshold を変えると、通常より重いペナルティになることがあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "蓄積率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**対応する建物のごみ発生値をスケールします。**\n" +
                    "注意: これは強力な調整項目で、変更すると多くの要素に影響します。\n" +
                    "これを使わなくても良いシステムにすることは可能です。\n\n" +
                    "**100% = バニラ** の蓄積率。\n" +
                    "**20%** = 蓄積がかなり遅くなります。\n" +
                    "**200%** = 2倍の速度 - ごみが大量に出ます。\n" +
                    "20% では、全市民が明らかにコンポストしている感じなので、ごみ蓄積率はかなり低くなります ;)\n\n" +
                    "技術メモ: ゲームはごみを一度に追加せず、1日の中で徐々に追加します。"
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "推奨" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**推奨** の上級者値を適用します。\n" +
                    "上級者を ON にします。\n" +
                    "最初のごみペナルティは **700** garbage（550 baseline + 150 step）から始まります。\n" +
                    "Garbage Accumulation Rate は手動変更しない限り **100%** vanilla のままです。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "すべての上級者値を **バニラに戻します**。\n" +
                    "**上級者** を OFF にします。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この mod の表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の mod バージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods ページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "ブラウザで Discord 招待を開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * トータルマジック ON = **[ ✓ ]**\n" +
                    "  * ごみは自動で除去されます - 完了。\n" +
                    " <-------------------------------------->\n\n" +
                    "<セルフ管理状態>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * 好きなようにスライダーを設定します。\n" +
                    "  * 必要なら高度なスライダーを ON（必須ではありません）。\n" +
                    "  * ゲームのごみ自体は同じ。トラック/施設をよりよく自主管理します。\n" +
                    " <-------------------------------------->\n\n" +
                    "<ステータス / バニラ状態>\n" +
                    "  * トータルマジック = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * ステータスレポートのみ。\n" +
                    "  * バニラのごみゲームは変更されません。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "ごみサービス評価" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "ゲーム内のシンプルなごみ幸福度評価です。\n" +
                    "**0 = Excellent**\n" +
                    "**-1 **= 少し調整が必要。ゲームでは 0 と -1 の間をよく行き来するため、無視してもよい場合があります（数値は丸め表示）。\n" +
                    "**-2 to -4** = 少し臭う\n" +
                    "**-5 to -10** = ごみ問題\n" +
                    "**間接的な調整:** <ごみスライダー> を使ってごみ蓄積を減らし、時間とともに改善します。\n" +
                    "**直接的な調整:** Garbage Happiness Baseline + Garbage Happiness Step は、不満になる前に <市民がどこまで耐えられるか> を変えます。\n" +
                    "**Garbage Accumulation Rate**: 対応建物がどれだけ速くごみを出すかを変えます。バランスが重要なので注意して使ってください。ほとんどのプレイヤーは調整不要です。\n" +
                    "<Update time = 最終更新時刻>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "**7t / 7000** 以上のごみを抱えたごみ発生建物の数です。\n" +
                    "深刻に過負荷な建物です。[x] Priority System を有効にするとより優先されます。\n" +
                    "Entity ID 番号を確認したい場合は、Status to log ボタンを使ってください。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ごみ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "現在の都市全体のごみ量と総処理速度を表示します。\n" +
                    "月間の発生量がかなり高いなら、処理能力を上げてください。\n" +
                    "**Produced** と **Processed** は 1か月あたりのトン数です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 現在まだトラックや経路に割り当てられていないアクティブな回収リクエスト。\n" +
                    "**Dispatched** = すでに割り当て済みのアクティブな回収リクエスト。\n" +
                    "**Total** = 現在の **アクティブな** リクエスト entity 数です（ごみパイプライン内）。\n\n" +
                    "技術メモ: これは <Above request threshold> とは別物です。ここでは建物ではなく <requests> を数えます。\n" +
                    "Pending の一部は後で割り当てられます。また、バニラ再検証によって対象にサービス不要と判断された場合は後で消えることもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Has garbage** = 現在ごみを持っている建物。\n" +
                    "**Total** = 都市内のすべてのごみ発生建物。\n" +
                    "**Above request threshold** = 回収リクエストを作れるだけのごみを持つ **建物** の現在数。\n" +
                    "バニラの request threshold は **100** internal garbage units です。\n" +
                    "上級者オプションで request と pickup threshold を上書きできます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "数えられたごみ施設の概要です。\n" +
                    "**Facilities** = 数えられたごみ施設建物。\n" +
                    "**Garbage trucks** = 通常の回収トラック。産業廃棄物施設では通常ごみではなく産業廃棄物を回収します。\n" +
                    "**Dump trucks** = 施設間のごみ移送。\n" +
                    "**Max workers** = それら施設の総労働者容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Garbage Trucks" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Moving** = 現在街に出ているトラック。\n" +
                    "**Returning** = 施設へ戻るフラグが付いた移動中トラックの一部。\n" +
                    "**Parked** = 施設に駐車中のトラック。\n" +
                    "**Total** = 全 garbage truck 数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細ステータスをログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳細なごみレポートを **Logs/MagicGarbage.log** に出力します。\n" +
                    "整理された都市ごみ統計を含みます"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "ゲームの Logs/.. フォルダーを開きます。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Excellent ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "少し調整が必要 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "少し臭う ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "ごみ問題 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 件が 7t 超え" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t Produced | {1:N0} t Processed" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} has garbage | {2:N0} above request threshold" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} facilities | {1:N0}/{2:N0} garbage/dump trucks | {3:N0} workers" },
                { "MG.Status.Row.Trucks", "{1:N0} moving ({3:N0} returning) | {2:N0} parked | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "まだ施設データはありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ごみステータス ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: トータルマジック={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "現在の mod 設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "Trash Boss スライダー（保存値）: トラック積載量={0:N0}% | 施設保管量={1:N0}% | 施設処理={2:N0}% | 施設車両数={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "上級者（保存値）: enabled={0} | request={1:N0} | pickup={2:N0} | happiness baseline={3:N0} | happiness step={4:N0} | accumulation rate={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- Produced/Processed は 1か月あたりのトン数です。\n" +
                    "- 下の threshold 値はトンではなく internal garbage units を使います。\n" +
                    "- プレイヤー向け表示では、ゲームは 100 units = 0.1t、1,000 units = 1t に変換します。\n" +
                    "- Garbage Service Rating = ゲーム内の都市ごみ幸福度係数。\n" +
                    "  - 0 = Excellent\n" +
                    "  - -1 = 少し調整が必要、または無視可\n" +
                    "  - -2 to -4 = 少し臭う\n" +
                    "  - -5 to -10 = ごみ問題\n" +
                    "Threshold sliders:\n" +
                    "  - Pickup threshold = 建物から回収する前に必要な最小ごみ量。\n" +
                    "  - Request threshold = ゲームが回収リクエストを作成または維持する前に必要な最小ごみ量。\n" +
                    "- Warning icon = 建物上に警告アイコンが出るごみ量。\n" +
                    "- Hard cap = 建物が蓄積できる最大ごみ量。\n" +
                    "- Pending = 現在トラックや経路に割り当てられていないアクティブなリクエスト。\n" +
                    "- Pending の一部は後で割り当てられ、一部はバニラ再検証で不要と判断されると後で消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "ゲーム threshold（internal garbage units）: pickup={1:N0}, request={0:N0}, warning icon={2:N0}, hard cap={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "Thresholds: <GarbageParameterData が利用不可>" },
                { "MG.Status.Log.GarbageProcessing", "ごみ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "ごみサービス評価: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "回収リクエスト: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最も高い pending 対象ごみ量: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "最も高い pending 対象ごみ量: なし" },
                { "MG.Status.Log.Producers", "建物: 警告アイコン={0:N0} | total={1:N0} | has garbage={2:N0} | above request threshold={3:N0} " },
                { "MG.Status.Log.ProducerGarbageStats", "建物ごみ（0超のみ）: avg={0:N0} ({1:N1}t) | median={2:N0} ({3:N1}t) | max={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "警告アイコン近い建物（少なくとも {1:N0} units / {2:N1}t）: {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: total={0:N0} | garbage trucks={1:N0} | dump trucks={2:N0} ({3:N0} moving) | workers={4:N0}" },
                { "MG.Status.Log.Trucks", "Garbage trucks: moving={2:N0} ({3:N0} returning) | parked={1:N0} | disabled={4:N0} | total={0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine", "- Facility {0}: garbage trucks={1:N0} ({2:N0} moving, {3:N0} parked) | dump trucks={4:N0} ({5:N0} moving) | max workers={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Excellent" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "少し調整が必要" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "少し臭う" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "ごみ問題" },

                { "MG.Status.Log.ThresholdsHeader", "Thresholds + Service" },
                { "MG.Status.Log.RequestsHeader", "Requests" },
                { "MG.Status.Log.BuildingsHeader", "Buildings" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 超の重大建物" },

                { "MG.Status.Log.TransferProbeHeader", "ごみ転送プローブ" },
                { "MG.Status.Log.TransferProbeNone", "ごみ保管・転送施設は見つかりませんでした。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | stored={1,7:N0} ({2,4:N1}t) | cap={3,7:N0} ({4,4:N1}t) | export={5,7:N0} ({6,4:N1}t) | low={7,7:N0} ({8,4:N1}t) | min={9,7:N0} ({10,4:N1}t) | out/in={11,6:N0}/{12,6:N0} | active={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "Trucks" },

                { "MG.Status.Log.SettingsPriority",
                    "Priority System（保存値）: enabled={0} | trigger={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "優先アシスト" },
                { "MG.Status.Log.PriorityState",
                    "Priority assist live={0} | interval={1:N0} frames | last scanned requests={2:N0} | active critical request targets={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "Priority passes: raised={0:N0} | normal={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "最も高いアクティブ重大対象: なし" },
                { "MG.Status.Log.PriorityPeak",
                    "最も高いアクティブ重大対象: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "pending" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "dispatched" },

#if DEBUG
                { "MG.Status.Log.PriorityPerf", "Priority assist 最終スキャン時間={0:N3} ms" },
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
