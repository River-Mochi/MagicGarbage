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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Actions" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "About" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Auto Clean" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Self Manage" },
                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Power User" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Status" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Mod info" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Links" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "USAGE" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "完全自動クリーン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**有効 [ ✓ ]** にすると街全体をきれいに保ちます。\n\n" +
                    "**完全自動クリーン** が ON の間：\n" +
                    "- ごみ管理 は強制的に OFF になります。\n" +
                    "- ごみ管理 のスライダーは適用されません（値は後で使えるよう保存されます）。\n" +
                    "- vanilla の配車タイミングの都合で、一部の車両はまだ走ることがあります。"
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "ごみ管理" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "ゴミ処理システムを直接調整します。vanilla のゴミ処理ロジックはそのまま動きます。\n\n" +
                    "- **ごみ管理 が ON [ ✓ ]** のとき、完全自動クリーン は強制的に OFF になります。\n" +
                    "- スライダーは ごみ管理 が有効なときだけ適用されます。\n" +
                    "- **ステータス報告** だけ見たいなら、完全自動クリーン と ごみ管理 を両方 **OFF** にできます。\n"
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるゴミの量です。**\n" +
                    "**100% = 通常の** ゲーム既定値です。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設ストレージ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるゴミの量です。**\n" +
                    "**100% = vanilla の** ストレージ量です。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入ゴミを処理する速さです。**\n" +
                    "**100% = vanilla の** 処理速度です。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設フリート" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラック数です。**\n" +
                    "**100% = vanilla の** トラック台数です。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "上級設定" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "**しきい値 + ゴミ幸福度の上級チューニングです。必要な人だけ使えばOKです。**\n" +
                    "**OFF** のとき、回収/要求しきい値とゴミ幸福度は **vanilla のまま** です。\n" +
                    "**ON** にすると、上級 **スライダーが表示** されます。\n\n" +
                    "<--- ゴミ幸福度の例 --->\n" +
                    " - <Vanilla> 100/65 = 1回目のペナルティは <165>。\n" +
                    " - <おすすめ> 550/150 = 1回目のペナルティは <700>。\n" +
                    " - <かなり緩め> 950/200 = 1回目のゴミペナルティは <1150>。\n" +
                    "便利機能：このオプションが OFF でも、最後に使ったスライダー値は保存されます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "配車要求しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**建物内のゴミがこの量になると、トラック配車要求が作成または維持されます。**\n" +
                    "Vanilla = **100** ゴミユニット。\n" +
                    "**100 ゴミユニット = 0.1t**\n" +
                    "**1,000 ゴミユニット = 1t**\n" +
                    "この値は回収しきい値以上にしてください。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "回収しきい値" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**トラックが回収できるようになる建物ゴミ量の最低値です。**\n" +
                    "Vanilla = **20** ゴミユニット。\n" +
                    "回収しきい値は配車要求しきい値を超えられません。\n" +
                    "ロジック不整合を避けるため、配車要求しきい値は有効な回収値以上にしてください;" +
                    " 建物へトラックが dispatch されても、回収値のほうが高いと回収できない場合があります（蓄積速度も影響）。\n"
                },

                // Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "ごみ管理 の**おすすめ**標準値を適用します。\n" +
                    "上級設定 の値は変更しません。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "ゲーム標準" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "ごみ管理 のスライダーを **vanilla 値** に戻します。\n" +
                    "上級設定 の値は <not> 変更しません。\n" +
                    "**Vanilla:**\n" +
                    "- パーセント系スライダーは **100%** に戻ります。\n" +
                    "- 配車要求しきい値は **100 units** に戻ります。\n" +
                    "- 回収しきい値は **20 units** に戻ります。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "ゴミ幸福度ベース" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**建物のゴミ量が健康 + 幸福度ペナルティを受け始める前の基準値です。**\n" +
                    "**Vanilla = 100** ゴミユニット。\n" +
                    "ベースが高いほど、建物はペナルティ開始前により多くのゴミを抱えられます。\n" +
                    "100 ゴミユニット = 0.1t\n" +
                    "概要:\n" +
                    "- <しきい値> = システム挙動の発動ポイント\n" +
                    "- <ベース> = ペナルティ計算式の開始点\n" +
                    "- <ステップ> = 計算式内の増分サイズ、つまりペナルティの増え方"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "ゴミ幸福度ステップ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**ベースを超えた追加ゴミ量で -1 ペナルティが始まります。**\n" +
                    "Vanilla = **65** ゴミユニット。\n" +
                    "ステップが高いほど、ペナルティの増え方は遅くなります。\n" +
                    "ゲーム内のゴミペナルティは **-10** で打ち止めです。\n" +
                    "vanilla の最初の <-1 penalty> は **165 ゴミ** で発生します（100 baseline + 65 step）\n" +
                    "しきい値変更は幸福度スライダーと一緒に調整しないと、通常より重いペナルティになることがあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "**おすすめ** の上級設定値を適用します。\n" +
                    "上級設定 を ON にします。\n" +
                    "最初のゴミペナルティは **700** ゴミで始まります（550 baseline + 150 step）。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "ゲーム標準" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "上級設定 の値を **vanilla** に戻します。\n" +
                    "**上級設定 を OFF** にします。"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この Mod の表示名です。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の Mod バージョンです。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods のページを開きます。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Discord 招待をブラウザで開きます。" },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<自動クリーン状態>\n" +
                    "  * 完全自動クリーン ON  = **[ ✓ ]**\n" +
                    "  * ゴミは自動で消去 - 完了。\n" +
                    " <-------------------------------------->\n\n" +
                    "<手動管理状態>\n" +
                    "  * ごみ管理 = **[ ✓ ]**\n" +
                    "  * 好きなようにスライダーを調整。\n" +
                    "  * 必要なら 上級設定 を ON にして、しきい値 + ゴミ幸福度を調整。\n" +
                    "  * ゲーム本来のゴミシステムのまま、トラック/施設をより自分好みに管理できます。\n" +
                    " <-------------------------------------->\n\n" +
                    "<ステータス / vanilla 状態>\n" +
                    "  * 完全自動クリーン = OFF\n" +
                    "  * ごみ管理 = OFF\n" +
                    "  * ステータス報告だけ使う状態です。\n" +
                    "  * vanilla のゴミ処理ゲーム部分は変わりません。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ゴミ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "街全体の現在のゴミ量と総処理率を表示します。\n" +
                    "月間のゴミ生産量が大きく上回るなら、処理能力を上げてください。\n" +
                    "**Produced** と **Processed** は月あたりトンです。\n" +
                    "<更新時刻 = 最後に更新した時刻。>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収要求" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**保留中** = まだトラックや経路に割り当てられていない有効な回収要求です。\n" +
                    "**配車済み** = すでに割り当て済みの有効な回収要求です。\n" +
                    "**合計** = 現在の **有効な** 要求エンティティ数です（ゴミパイプライン内）。\n\n" +
                    "技術メモ：これは <要求しきい値超え> とは別です。ここでは建物ではなく <要求> を数えます。\n" +
                    "保留中の一部はあとで割り当てられますし、vanilla の再検証でサービス不要と判断されれば消えることもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**ゴミあり** = 現在ゴミを持っている建物です。\n" +
                    "**合計** = 街中のすべてのゴミ発生建物です。\n" +
                    "**要求しきい値超え** = 回収要求を作れるだけのゴミがある **建物** の現在数です。\n" +
                    "vanilla では要求しきい値は **100** 内部ゴミユニットです。\n" +
                    "上級設定 で要求/回収しきい値を上書きできます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "集計対象になっているゴミ施設の概要です。\n" +
                    "**施設** = 集計対象のゴミ施設数です。\n" +
                    "**ゴミトラック** = 通常の回収トラックです。産業廃棄物施設では通常ゴミではなく産業廃棄物を集めます。\n" +
                    "**Dump trucks** = 施設間のゴミ移送です。\n" +
                    "**最大労働者数** = それらの施設の総最大労働者数です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "トラック" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**走行中** = 現在街を走っているトラックです。\n" +
                    "**帰還中** = 走行中のうち、施設へ戻っているものです。\n" +
                    "**駐車中** = 施設に駐車中のトラックです。\n" +
                    "**合計** = すべてのゴミトラック数です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細ステータスをログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳細なゴミレポートを **Logs/MagicGarbage.log** に出力します。\n" +
                    "短い凡例、vanilla 参照値、街のいろいろな現在統計が入ります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)),
                    "ゲームの Logs/.. フォルダを開きます。"
                },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t 生産 | {1:N0} t 処理 | 更新 {2}" },
                { "MG.Status.Row.Requests", "{1:N0} 保留中 | {2:N0} 配車済み | {0:N0} 合計" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} がゴミあり | {2:N0} が要求しきい値超え" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} 施設 | {1:N0} ゴミトラック | {2:N0} dump trucks | {3:N0} 最大労働者" },
                { "MG.Status.Row.Trucks", "{1:N0} 走行中 ({3:N0} 帰還中) | {2:N0} 駐車中 | {0:N0} 合計" },
                { "MG.Status.Row.FacilitiesNone", "まだ施設データがありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ゴミステータス ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: 完全自動クリーン={0}, ごみ管理={1}" },
                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- Produced/Processed は月あたりトンです。\n" +
                    "- 下のしきい値はトンではなく内部ゴミユニットを使います。\n" +
                    "- プレイヤー向けには 100 units = 0.1t、1,000 units = 1t に換算されます。\n" +
                    "しきい値スライダー:\n" +
                    "  - 回収しきい値 = 建物から回収できるようになる最低ゴミ量。\n" +
                    "  - 要求しきい値 = ゲームが回収要求を作成または維持する最低ゴミ量。\n" +
                    "- 警告アイコン = 建物上に警告アイコンが出るゴミ量。\n" +
                    "- 上限値 = 建物が溜められるゴミ量の上限。\n" +
                    "- 保留中 = まだトラックや経路に割り当てられていない有効要求。\n" +
                    "- 保留中の一部はあとで割り当てられますし、vanilla の再検証で不要と判断されれば消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },
                { "MG.Status.Log.Thresholds",
                    "ゲームしきい値 (内部ゴミユニット): 回収={1:N0}, 要求={0:N0}, 警告アイコン={2:N0}, 上限値={3:N0}"
                },

                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData がありません>" },
                { "MG.Status.Log.GarbageProcessing", "ゴミ: {0:N0} t/月 | 処理: {1:N0} t/月" },
                { "MG.Status.Log.Requests", "回収要求: 保留中={1:N0}, 配車済み={2:N0}, 合計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "もっとも高い保留中目標: {0:N0} ({1:N1}t) 位置 {2}" },
                { "MG.Status.Log.Producers", "建物: {0:N0} 合計 | {1:N0} がゴミあり | {2:N0} が要求しきい値超え | {3:N0} が警告レベル" },
                { "MG.Status.Log.ProducerGarbageStats", "建物ゴミ (0以外のみ): 平均={0:N0} ({1:N1}t) | 中央値={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 位置 {6}" },
                { "MG.Status.Log.NearWarning75", "警告に近い建物 (少なくとも {1:N0} ユニット / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: {0:N0} 合計 | {1:N0} ゴミトラック | {2:N0} dump trucks ({3:N0} 走行中) | {4:N0} 労働者" },
                { "MG.Status.Log.Trucks", "ゴミトラック: {2:N0} 走行中 ({3:N0} 帰還中) | {1:N0} 駐車中 | {4:N0} 無効 | {0:N0} 合計" },
                { "MG.Status.Log.FacilitiesHeader", "施設サマリー" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: ゴミ={1:N0} ({2:N0} 走行中, {3:N0} 駐車中) | dump={4:N0} ({5:N0} 走行中) | 最大労働者={6:N0}" },
            };
        }

        public void Unload()
        {
        }
    }
}
