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
                                        "**有効 [ ✓ ]** で街全体をきれいに保ちます。\n" +
                    "\n" +
                    "**完全クリーン** が ON の間:\n" +
                    "- ごみ管理は強制的に OFF になります。\n" +
                    "- ごみ管理のスライダーは適用されません（値は後で使えるよう保存されます）。\n" +
                    "- vanilla の配車ロジックのタイミングにより、少しだけトラックが動くことがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "ごみ管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                                        "ごみシステムを直接管理します。vanilla のごみロジックはそのまま動き続けます。\n" +
                    "\n" +
                    "- **ごみ管理が ON [ ✓ ]** のとき、完全クリーンは強制的に OFF になります。\n" +
                    "- スライダーはごみ管理が有効なときだけ適用されます。\n" +
                    "- **状態レポート** だけ欲しい場合は、完全クリーンとごみ管理の両方を **OFF** にできます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PrioritySystemEnabled)), "優先アシスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PrioritySystemEnabled)),
                                        "深刻に過負荷なごみ対象（建物）を補助します。\n" +
                    "**ON** のとき、アクティブなリクエスト対象が **7000+**（**7t**）のごみに達しているか確認します。\n" +
                    "目的: 必要に応じて余計な横道回収を減らし、トラックが深刻な対象へより早く到達できるようにします。\n" +
                    "これは軽い後押しであり、バニラの経路ロジックを強く完全上書きするものではありません。\n" +
                    "軽量で、Harmony パッチはありません。"
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
                                        "ごみ管理スライダーを **vanilla 値** に戻します。\n" +
                    "上級者設定は <変更しません>。\n" +
                    "**Vanilla:**\n" +
                    "- パーセントスライダーは **100%** に戻ります。\n" +
                    "- 配車要求しきい値は **100 単位** に戻ります。\n" +
                    "- 回収しきい値は **20 単位** に戻ります。\n"
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "上級者オプション" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                                        "任意の上級設定\n" +
                    "<警告: 必須ではありません>。良いサービスのために必要ではなく、試したい人や仕組みを知りたい人向けです。\n" +
                    "**オフ** のとき、上級者項目は通常の **vanilla** ゲームのように動作します。\n" +
                    "**オン** にすると、上級 **スライダーが表示** されます。\n" +
                    "\n" +
                    "<--- 幸福度の例 --->\n" +
                    " - <Vanilla> 100/65 = 1回目のペナルティは <165>。\n" +
                    " - <おすすめ> を押すと 550/150 = 1回目のペナルティは <700>。\n" +
                    " - <かなり緩い> 950/200 = 1回目のごみペナルティは <1150>。\n" +
                    "便利: この項目がオフでも最後のスライダー値は保存されます（後で有効にしたい場合のため）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "配車要求しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                                        "**建物でトラックの配車要求が作成または維持される前に必要なごみ量です。**\n" +
                    "Vanilla = **100** ごみ単位。\n" +
                    "**100 ごみ単位 = 0.1t**\n" +
                    "**1,000 ごみ単位 = 1t**\n" +
                    "回収しきい値以上に保ってください。\n" +
                    "通常、これを上げると駐車中より使用中のトラックが増えます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "回収しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                                        "**トラックが建物から回収できるようになる前に必要な最小ごみ量です。**\n" +
                    "Vanilla = **20** ごみ単位。\n" +
                    "回収スライダーは配車要求 (DR) より <高くできません>。ロジック不整合を防ぐため自動で制限されます。\n" +
                    "トラックが建物に派遣されても回収値が DR より高いと、建物から回収できないことがあります（蓄積率も影響します）。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "ごみ幸福度基準値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                                        "**建物のごみ量が健康 + 幸福度ペナルティを起こし始める前の基準値です。**\n" +
                    "**Vanilla = 100** ごみ単位。\n" +
                    "基準値が高いほど、ペナルティが始まる前に建物がより多くのごみを抱えられます。\n" +
                    "100 ごみ単位 = 0.1t\n" +
                    "概要:\n" +
                    "- <しきい値> = システム動作の発動地点\n" +
                    "- <基準値> = ペナルティ計算式の開始地点\n" +
                    "- <刻み> = 計算式の増分サイズ、つまり開始後にペナルティがどれだけ速く増えるか"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "ごみ幸福度刻み" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                                        "**基準値を超えた追加ごみ量で -1 ペナルティが始まります。**\n" +
                    "Vanilla = **65** ごみ単位。\n" +
                    "刻みが高いほどペナルティの増え方は遅くなります。\n" +
                    "ゲームではごみペナルティは **-10** で上限です。\n" +
                    "vanilla の最初の <-1 penalty> は **165 ごみ** で発生します（基準値 100 + 刻み 65）\n" +
                    "しきい値を変えるなら幸福度スライダーも合わせて調整しないと、通常より重いペナルティになることがあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "蓄積率" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                                        "**対応している建物のごみ発生値をスケーリングします。**\n" +
                    "注意: これは強いレバーで、率を変えると多くのものに影響します。\n" +
                    "これを使わなくても良いシステムにすることは可能です。\n" +
                    "\n" +
                    "**100% = vanilla** の蓄積率。\n" +
                    "**20%** = かなりゆっくり蓄積。\n" +
                    "**200%** = 2倍の速度 - ごみがかなり増えます。\n" +
                    "20% なら、市民全員が明らかにコンポストしているので、ごみ蓄積率もかなり低いわけです ;)\n" +
                    "\n" +
                    "技術メモ: ゲームは1日の中で少しずつごみを追加し、一度に全部は追加しません。"
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                                        "**おすすめ** の上級者値を適用します。\n" +
                    "上級者をオンにします。\n" +
                    "最初のごみペナルティは **700** ごみで始まります（基準値 550 + 刻み 150）。\n" +
                    "蓄積率は手動で変えない限り **100%** vanilla のままです。"
                },


                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "ゲーム既定値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                                        "上級者の値をすべて **vanilla** に戻します。\n" +
                    "上級者を **オフ** にします。\n"
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
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<手動管理状態>\n" +
                    "  * ごみ管理 = **[ ✓ ]**\n" +
                    "  * 好みに合わせてスライダーを設定します。\n" +
                    "  * 任意: 上級スライダーを使うために ON にします（必須ではありません）。\n" +
                    "  * ゲームのごみ自体は同じで、トラック/施設をより良く手動管理できます。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
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
                                        "ゲームのシンプルなごみ幸福度評価です。\n" +
                    "**0 = 優秀**\n" +
                    "**-1** = 少し調整推奨。ゲームでは 0 と -1 を行き来することが多く、無視してよい場合もあります（数値は丸め表示です）。\n" +
                    "**-2 ～ -4** = やや臭い\n" +
                    "**-5 ～ -10** = ごみ問題\n" +
                    "**間接的な調整:** Trash Boss の <スライダー> を使い、実際のごみ蓄積を減らして時間とともに改善します。\n" +
                    "**直接的な調整:** <ごみ幸福度基準値> + <ごみ幸福度刻み> は、市民が不満になる前にどこまで耐えるかを変えます。\n" +
                    "**蓄積率**: 対応建物がどれだけ速くごみを出すかを変えます。バランスが大事なので注意して使ってください。ほとんどのプレイヤーは調整不要です。\n" +
                    "<更新時刻 = 最終更新。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t+ 建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                                        "**7t / 7000** 以上のごみを抱えたごみ発生建物の数です。\n" +
                    "深刻に過負荷な建物です。[x] 優先アシスト を有効にすると、これらをより優先しやすくなります。\n" +
                    "Entity ID 番号を確認したい場合は、「詳細状態をログへ」ボタンを使ってください。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ごみ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                                        "都市全体の現在のごみ量と総処理率を表示します。\n" +
                    "月間のごみ生産量がかなり多いなら処理能力を上げてください。\n" +
                    "**生産量** と **処理量** は月あたりトンです。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                                        "**保留中** = 現在トラックや経路に割り当てられていない有効な回収要求。\n" +
                    "**派遣済み** = すでに割り当て済みの有効な回収要求。\n" +
                    "**合計** = 現在の **有効な** 要求エンティティ数（ごみパイプライン内）。\n" +
                    "\n" +
                    "技術メモ: これは <要求しきい値超え> とは別です。ここで数えるのは <要求> であって、建物ではありません。\n" +
                    "保留中の一部は後で割り当てられます。vanilla の再検証で対象にサービスが不要と判断されれば消えることもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                                        "**ごみあり** = 現在ごみを保持している建物。\n" +
                    "**合計** = 都市内のすべてのごみ発生建物。\n" +
                    "**要求しきい値超え** = 回収要求を作るのに十分なごみを持つ **建物** の現在数。\n" +
                    "vanilla では要求しきい値は **100** 内部ごみ単位です。\n" +
                    "上級者オプションで要求しきい値と回収しきい値を上書きできます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                                        "集計されたごみ施設の概要です。\n" +
                    "**施設数** = 集計されたごみ建物。\n" +
                    "**ごみトラック** = 通常の回収トラック。産業廃棄物施設では通常ごみではなく産業廃棄物を回収します。\n" +
                    "**Dump トラック** = 施設間でごみを移送するトラック。\n" +
                    "**最大作業員数** = 同じ施設群の総作業員容量。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "ごみトラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                                        "**移動中** = 現在都市内を走っているトラック。\n" +
                    "**戻り中** = 移動中のうち施設へ戻るフラグが付いたトラック。\n" +
                    "**駐車中** = 施設に駐車しているトラック。\n" +
                    "**合計** = すべてのごみトラック数。"
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

                { "MG.Status.Row.GarbageServiceRating.Excellent", "優秀 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "少し調整推奨 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "やや臭い ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "ごみ問題 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} 件が 7t 超え" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 生産 | {1:N0} t 処理" },
                { "MG.Status.Row.Requests", "{1:N0} 保留中 | {2:N0} 派遣済み | {0:N0} 合計" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} ごみあり | {2:N0} 要求しきい値超え" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 施設 | {1:N0}/{2:N0} ごみ/Dumpトラック | {3:N0} 作業員" },
                { "MG.Status.Row.Trucks", "{1:N0} 移動中 ({3:N0} 戻り中) | {2:N0} 駐車中 | {0:N0} 合計" },
                { "MG.Status.Row.FacilitiesNone", "まだ施設データはありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ごみ状態 ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: 完全クリーン={0}, ごみ管理={1}" },
                { "MG.Status.Log.SettingsHeader", "現在の mod 設定" },
                { "MG.Status.Log.SettingsTrashBoss",
                    "ごみ管理スライダー (保存値): トラック積載={0:N0}% | 施設保管={1:N0}% | 施設処理={2:N0}% | 施設台数={3:N0}%"
                },
                
                { "MG.Status.Log.SettingsPowerUser",
                    "上級者オプション (保存値): 有効={0} | 要求={1:N0} | 回収={2:N0} | 幸福度基準値={3:N0} | 幸福度刻み={4:N0} | 蓄積率={5:N0}%"
                },

                { "MG.Status.Log.Legend",
                                        "凡例:\n" +
                    "- 生産量/処理量 は月あたりトンです。\n" +
                    "- 下のしきい値はトンではなく内部ごみ単位です。\n" +
                    "- プレイヤー向け表示では、ゲームは 100 単位 = 0.1t、1,000 単位 = 1t に変換します。\n" +
                    "- ごみサービス評価 = ゲームの都市ごみ幸福度係数。\n" +
                    "  - 0 = 優秀\n" +
                    "  - -1 = 少し調整推奨、または無視可\n" +
                    "  - -2 ～ -4 = やや臭い\n" +
                    "  - -5 ～ -10 = ごみ問題\n" +
                    "しきい値スライダー:\n" +
                    "  - 回収しきい値 = トラックが建物から回収する前に必要な最小ごみ量。\n" +
                    "  - 要求しきい値 = ゲームが回収要求を作成または維持する前に必要な最小ごみ量。\n" +
                    "- 警告アイコン = 建物の上に警告アイコンが出るごみ量。\n" +
                    "- 上限 = 建物が蓄積できる最大ごみ量。\n" +
                    "- 保留中 = 現在トラックや経路に割り当てられていない有効な要求。\n" +
                    "- 保留中の一部は後で割り当てられます。vanilla の再検証で不要になれば消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds",
                    "ゲームしきい値 (内部ごみ単位): 回収={1:N0}, 要求={0:N0}, 警告アイコン={2:N0}, 上限={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData を利用できません>" },
                { "MG.Status.Log.GarbageProcessing", "ごみ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "ごみサービス評価: {0} | 生値={1:N2} | 丸め={2:N0}" },
                { "MG.Status.Log.Requests", "回収要求: 保留中={1:N0}, 派遣済み={2:N0}, 合計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "保留中で最も高い対象ごみ: {0:N0} ({1:N1}t) 場所 {2}" },
                { "MG.Status.Log.PendingPeakNone", "保留中で最も高い対象ごみ: なし" },
                { "MG.Status.Log.Producers", "建物: {0:N0} 警告アイコン | {1:N0} 合計 | {2:N0} ごみあり | {3:N0} 要求しきい値超え " },
                { "MG.Status.Log.ProducerGarbageStats", "建物ごみ (0以外のみ): 平均={0:N0} ({1:N1}t) | 中央値={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 場所 {6}" },
                { "MG.Status.Log.NearWarning75", "警告アイコンに近い建物 (少なくとも {1:N0} 単位 / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: {0:N0} 合計 | {1:N0} ごみトラック | {2:N0} Dumpトラック ({3:N0} 移動中) | {4:N0} 作業員" },
                { "MG.Status.Log.Trucks", "ごみトラック: {2:N0} 移動中 ({3:N0} 戻り中) | {1:N0} 駐車中 | {4:N0} 無効 | {0:N0} 合計" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: ごみトラック={1:N0} ({2:N0} 移動中, {3:N0} 駐車中) | Dumpトラック={4:N0} ({5:N0} 移動中) | 作業員={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "優秀" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "少し調整推奨" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "やや臭い" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "ごみ問題" },

                { "MG.Status.Log.ThresholdsHeader", "しきい値 + サービス" },
                { "MG.Status.Log.RequestsHeader", "要求" },
                { "MG.Status.Log.BuildingsHeader", "建物" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t 超の重大建物" },

                { "MG.Status.Log.TransferProbeHeader", "ごみ転送プローブ" },
                { "MG.Status.Log.TransferProbeNone", "ごみ保管・転送施設は見つかりませんでした。" },
                { "MG.Status.Log.TransferProbeLine",
                    "- {0,-20} | 保管={1,7:N0} ({2,4:N1}t) | 容量={3,7:N0} ({4,4:N1}t) | 輸出={5,7:N0} ({6,4:N1}t) | 低値={7,7:N0} ({8,4:N1}t) | 最小={9,7:N0} ({10,4:N1}t) | 出/入={11,6:N0}/{12,6:N0} | 有効={13} | {14}"
                },

                { "MG.Status.Log.TrucksHeader", "トラック" },

                { "MG.Status.Log.SettingsPriority",
                    "優先アシスト（保存値）: 有効={0} | 発動値={1:N0} ({2:N1}t)"
                },

                { "MG.Status.Log.PriorityHeader", "優先アシスト" },
                { "MG.Status.Log.PriorityState",
                    "優先アシスト 稼働={0} | 間隔={1:N0} フレーム | 前回スキャン要求数={2:N0} | アクティブな重大要求対象={3:N0}"
                },
                { "MG.Status.Log.PriorityPasses",
                    "優先パス: 引き上げ={0:N0} | 通常={1:N0}"
                },
                { "MG.Status.Log.PriorityPeakNone", "最も高いアクティブ重大対象: なし" },
                { "MG.Status.Log.PriorityPeak",
                    "最も高いアクティブ重大対象: {0:N0} ({1:N1}t) | {2} | {3}"
                },
                { "MG.Status.Log.PriorityPeakState.Pending", "保留中" },
                { "MG.Status.Log.PriorityPeakState.Dispatched", "派遣済み" },

#if DEBUG
{ "MG.Status.Log.PriorityPerf", "優先アシスト 最終スキャン時間={0:N3} ms" },
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
