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
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "手動管理" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "上級者" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "状態" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "MOD情報" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "リンク" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "使い方" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全クリーン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** で街全体をきれいに保ちます。\n\n" +
                    "**完全クリーン** が ON の間:\n" +
                    "- ごみ管理は強制的に OFF になります。\n" +
                    "- ごみ管理のスライダーは適用されません（値は後で使えるよう保存されます）。\n" +
                    "- vanilla の配車ロジックのタイミングにより、少しだけトラックが動くことがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "ごみ管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "ごみシステムを直接管理します。vanilla のごみロジックはそのまま動き続けます。\n\n" +
                    "- **ごみ管理が ON [ ✓ ]** のとき、完全クリーンは強制的に OFF になります。\n" +
                    "- スライダーはごみ管理が有効なときだけ適用されます。\n" +
                    "- **状態レポート** だけ欲しい場合は、完全クリーンとごみ管理の両方を **OFF** にできます。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるごみの量です。**\n" +
                    "**100% = 通常の** ゲーム既定値。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設保管量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるごみの量です。**\n" +
                    "**100% = vanilla の** 保管量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入したごみを処理する速さです。**\n" +
                    "**100% = vanilla の** 処理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラックの数です。**\n" +
                    "**100% = vanilla の** トラック数。\n"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "**おすすめ** の標準ごみ管理値を適用します。\n" +
                    "上級者設定は変更しません（別です）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "ごみ管理のスライダーを **vanilla 値** に戻します。\n" +
                    "上級者設定は <変更しません>。\n" +
                    "**Vanilla:**\n" +
                    "- パーセント系スライダーは **100%** に戻ります。\n" +
                    "- Dispatch Request Threshold は **100 units** に戻ります。\n" +
                    "- Pickup Threshold は **20 units** に戻ります。\n"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "上級者オプション" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "任意の上級設定\n" +
                    "<注意: 必須ではありません>。良いサービスのために必要ではなく、試したい人や仕組みをもっと知りたい人向けです。\n" +
                    "**OFF** のとき、上級者設定はすべて **vanilla のまま** です。\n" +
                    "**ON** にすると、上級 **スライダーが表示** されます。\n\n" +
                    "<--- 幸福度の例 --->\n" +
                    " - <Vanilla> 100/65 = 1回目のペナルティは <165>。\n" +
                    " - <おすすめ> を押すと 550/150 = 1回目のペナルティは <700>。\n" +
                    " - <かなり緩い> 950/200 = 1回目のごみペナルティは <1150>。\n" +
                    "便利機能: このオプションが OFF でも最後のスライダー値は保存されます（あとで有効にしたい場合のため）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "配車要求しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**トラックの配車要求が作成または維持される前に、建物に必要なごみ量です。**\n" +
                    "Vanilla = **100** ごみ units。\n" +
                    "**100 garbage units = 0.1t**\n" +
                    "**1,000 garbage units = 1t**\n" +
                    "これは Pickup Threshold 以上にしてください。\n" +
                    "通常、これを上げると駐車中より出動中のトラックが増えます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "回収しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**トラックが回収できるようになる前に建物に必要な最低ごみ量です。**\n" +
                    "Vanilla = **20** ごみ units。\n" +
                    "回収スライダーは Dispatch Request (DR) より <高くできません>。ロジック不整合を防ぐため自動で制限されます。\n" +
                    "トラックが建物へ dispatch されても回収値が DR より高いと、建物から回収できないことがあります（蓄積率も影響します）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "ごみ幸福度ベース" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建物のごみ量が健康 + 幸福度ペナルティを起こし始める前の基準値です。**\n" +
                    "**Vanilla = 100** ごみ units。\n" +
                    "ベースが高いほど、ペナルティが始まる前に建物がより多くのごみを抱えられます。\n" +
                    "100 garbage units = 0.1t\n" +
                    "概要:\n" +
                    "- <Threshold> = システム動作の発動地点\n" +
                    "- <Baseline> = ペナルティ計算式の開始地点\n" +
                    "- <Step> = 計算式の増分サイズ、つまり開始後にペナルティがどれだけ速く増えるか"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "ごみ幸福度ステップ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**ベースを超えた追加ごみ量で -1 ペナルティが始まります。**\n" +
                    "Vanilla = **65** ごみ units。\n" +
                    "ステップが高いほどペナルティの増え方は遅くなります。\n" +
                    "ゲームではごみペナルティは **-10** で上限です。\n" +
                    "vanilla の最初の <-1 penalty> は **165 garbage** で発生します（ベース 100 + ステップ 65）\n" +
                    "しきい値を変えるなら幸福度スライダーも合わせて調整しないと、通常より重いペナルティになることがあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "ごみ蓄積率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**対応している建物のごみ発生値をスケーリングします。**\n" +
                    "これは強いレバーで、この率を変えると多くのものに影響します。\n" +
                    "これを使わなくても良いシステムにすることは可能です。\n\n" +
                    "**100% = vanilla の** 蓄積。\n" +
                    "**20%** = かなりゆっくり蓄積。\n" +
                    "**200%** = 2倍の速度 - ごみがかなり多くなります。\n" +
                    "20% なら、Cims 全員が明らかにコンポストしているので、ごみ蓄積率も低いわけです ;)"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**おすすめ** の上級者値を適用します。\n" +
                    "上級者を ON にします。\n" +
                    "最初のごみペナルティは **700** ごみで始まります（ベース 550 + ステップ 150）。\n" +
                    "ごみ蓄積率は手動で変えない限り **100%** vanilla のままです。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "上級者の値を **vanilla** に戻します。\n" +
                    "**上級者を OFF** にします。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この mod の表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の mod バージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods ページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "ブラウザーで Discord 招待を開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * 完全クリーン ON = **[ ✓ ]**\n" +
                    "  * ごみは自動で除去されます - 完了。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理状態>\n" +
                    "  * ごみ管理 = **[ ✓ ]**\n" +
                    "  * 好みに合わせてスライダーを設定します。\n" +
                    "  * 任意: 上級スライダーを使うために ON にします（必須ではありません）。\n" +
                    "  * ゲームのごみ自体は同じで、トラック/施設をより良く手動管理できます。\n" +
                    " <-------------------------------------->\n\n" +
                    "<状態 / vanilla 状態>\n" +
                    "  * 完全クリーン = OFF\n" +
                    "  * ごみ管理 = OFF\n" +
                    "  * 状態レポートのみ。\n" +
                    "  * vanilla のごみゲームは変わりません。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "ごみサービス評価" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "ゲーム内の都市全体のごみ幸福度のシンプルな評価です。\n" +
                    "**0 = 最高**\n" +
                    "**-1 = 軽い調整が必要** ゲームでは 0 と -1 を行き来しやすく、無視してもよい場合があります。\n" +
                    "**-2 ～ -4 = 少し臭い**\n" +
                    "**-5 ～ -10 = ごみ問題**\n" +
                    "**間接的な調整:** トラック/施設/しきい値スライダーで実際のごみ蓄積を減らし、時間とともに改善できます。\n" +
                    "**直接的な調整:** <ごみ幸福度ベース> + <ごみ幸福度ステップ> で cims が不満になる前にどこまで耐えるかを変えます。\n" +
                    "**発生率の調整:** <ごみ蓄積率> で対応建物がどれだけ速くごみを出すかを変えます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ごみ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "都市全体の現在のごみ量と総処理率を表示します。\n" +
                    "月間のごみ生産量がかなり高いなら処理能力を上げてください。\n" +
                    "**Produced** と **Processed** は月あたりトンです。\n" +
                    "<更新時刻 = 最終更新。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Pending** = 現在トラックや経路に割り当てられていない有効な回収リクエスト。\n" +
                    "**Dispatched** = すでに割り当て済みの有効な回収リクエスト。\n" +
                    "**Total** = 現在の **active** なリクエスト entity 数（ごみパイプライン内）。\n\n" +
                    "技術メモ: これは <要求しきい値超え> とは別です。ここで数えるのは建物ではなく <リクエスト> です。\n" +
                    "Pending の一部は後で割り当てられますし、vanilla の再検証で対象にサービスが不要と判断されれば消えることもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**ごみあり** = 現在ごみを保持している建物。\n" +
                    "**Total** = 都市内のすべてのごみ発生建物。\n" +
                    "**要求しきい値超え** = 回収リクエストを作るのに十分なごみを持つ **建物** の現在数。\n" +
                    "vanilla では要求しきい値は **100** internal garbage units です。\n" +
                    "上級者オプションで要求しきい値と回収しきい値を上書きできます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "集計されたごみ施設の概要です。\n" +
                    "**施設** = 集計されたごみ建物。\n" +
                    "**ごみトラック** = 通常の回収トラック。産業廃棄物施設では通常のごみではなく産業廃棄物を回収します。\n" +
                    "**ダンプトラック** = 施設間のごみ移送。\n" +
                    "**最大作業員数** = それら施設の総作業員容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "ごみトラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**移動中** = 現在街に出ているトラック。\n" +
                    "**帰還中** = 施設へ戻るフラグが立った移動中トラックの一部。\n" +
                    "**駐車中** = 施設に駐車しているトラック。\n" +
                    "**Total** = すべてのごみトラック数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細状態をログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳しいごみレポートを **Logs/MagicGarbage.log** に出力します。\n" +
                    "短い凡例、vanilla の基準値、そして街の現在のごみ統計を多数含みます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "ゲームの Logs/.. フォルダーを開きます。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "最高 ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "軽い調整が必要 ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "少し臭い ({0:N0})" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "ごみ問題 ({0:N0})" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 生産 | {1:N0} t 処理 | 更新 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} pending | {2:N0} dispatched | {0:N0} total" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} がごみあり | {2:N0} が要求しきい値超え" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 施設 | {1:N0} ごみトラック | {2:N0} ダンプトラック | {3:N0} 最大作業員数" },
                { "MG.Status.Row.Trucks", "{1:N0} 移動中 ({3:N0} 帰還中) | {2:N0} 駐車中 | {0:N0} total" },
                { "MG.Status.Row.FacilitiesNone", "まだ施設データがありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ごみ状態 ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: 完全クリーン={0}, ごみ管理={1}" },
                { "MG.Status.Log.SettingsHeader", "現在の mod 設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "ごみ管理スライダー（保存値）: トラック積載量={0:N0}% | 施設保管量={1:N0}% | 施設処理速度={2:N0}% | 施設車両数={3:N0}%"
                },

                { "MG.Status.Log.SettingsPowerUser",
                    "上級者（保存値）: 有効={0} | 要求={1:N0} | 回収={2:N0} | 幸福度ベース={3:N0} | 幸福度ステップ={4:N0} | 蓄積率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- Produced/Processed は月あたりトンです。\n" +
                    "- 以下のしきい値はトンではなく internal garbage units を使います。\n" +
                    "- プレイヤー向け表示では、ゲームは 100 units = 0.1t、1,000 units = 1t に変換します。\n" +
                    "- ごみサービス評価 = ゲーム内の都市ごみ幸福度係数。\n" +
                    "  - 0 = 最高\n" +
                    "  - -1 = 軽い調整が必要、または無視でも可\n" +
                    "  - -2 ～ -4 = 少し臭い\n" +
                    "  - -5 ～ -10 = ごみ問題\n" +
                    "しきい値スライダー:\n" +
                    "  - 回収しきい値 = トラックが建物から回収する前に必要な最小ごみ量。\n" +
                    "  - 要求しきい値 = ゲームが回収リクエストを作成または維持する前に必要な最小ごみ量。\n" +
                    "- 警告アイコン = 建物の上に警告アイコンが表示されるごみ量。\n" +
                    "- 上限 = 建物が蓄積できる最大ごみ量。\n" +
                    "- Pending = 現在トラックや経路に割り当てられていない active なリクエスト。\n" +
                    "- Pending の一部は後で割り当てられ、vanilla の再検証で不要になれば消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "ゲームしきい値（internal garbage units）: 回収={1:N0}, 要求={0:N0}, 警告アイコン={2:N0}, 上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData がありません>" },
                { "MG.Status.Log.GarbageProcessing", "ごみ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "ごみサービス評価: {0} | raw={1:N2} | rounded={2:N0}" },
                { "MG.Status.Log.Requests", "回収リクエスト: pending={1:N0}, dispatched={2:N0}, total={0:N0}" },
                { "MG.Status.Log.PendingPeak", "最も多い pending 対象ごみ: {0:N0} ({1:N1}t) at {2}" },
                { "MG.Status.Log.PendingPeakNone", "最も多い pending 対象ごみ: なし" },
                { "MG.Status.Log.Producers", "建物: {0:N0} 警告アイコン | {1:N0} total | {2:N0} ごみあり | {3:N0} 要求しきい値超え " },
                { "MG.Status.Log.ProducerGarbageStats", "建物ごみ（0 以外のみ）: 平均={0:N0} ({1:N1}t) | 中央値={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) at {6}" },
                { "MG.Status.Log.NearWarning75", "警告アイコンに近い建物（少なくとも {1:N0} units / {2:N1}t）: {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: {0:N0} total | {1:N0} ごみトラック | {2:N0} ダンプトラック ({3:N0} moving) | {4:N0} 作業員" },
                { "MG.Status.Log.Trucks", "ごみトラック: {2:N0} moving ({3:N0} returning) | {1:N0} parked | {4:N0} disabled | {0:N0} total" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: ごみトラック={1:N0} ({2:N0} moving, {3:N0} parked) | ダンプトラック={4:N0} ({5:N0} moving) | 最大作業員数={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "最高" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "軽い調整が必要" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "少し臭い" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "ごみ問題" },
            };
        }

        public void Unload()
        {
        }
    }
}
