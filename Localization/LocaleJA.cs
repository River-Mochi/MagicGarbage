// <copyright file="LocaleJA.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleJA.cs
// Japanese (ja-JP)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

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
                    "- バニラの配車ロジックのタイミングにより、少数のトラックがまだ動くことがあります。"
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

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "トラック積載量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**各トラックが運べるゴミの量です。**\n" +
                    "**100% = バニラ**のトラック容量 (20t)。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "施設保管量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**施設が保管できるゴミの量です。**\n" +
                    "**100% = バニラ**の保管量。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "施設処理速度" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**施設が流入したゴミを処理する速さです。**\n" +
                    "**100% = バニラ**の処理速度。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "施設車両数" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**各施設が出せるトラックの数です。**\n" +
                    "**100% = バニラ**のトラック数。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "目的地用の予約容量" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**割り当てられた建物へ向かう途中で、任意の回収をどのくらい早く選別し始めるかを設定します。**\n" +
                    "**10% はバニラ 1.6.2 の値です。**\n" +
                    "通常の 20t トラックの場合:\n" +
                    "- 10% は割り当て先のための保護を 2t 早く始めます。\n" +
                    "- 15% は 3t 早く始めます。\n" +
                    "- 25% は 5t 早く始めます。\n" +
                    "値を高くすると安全余裕が大きくなります。トラックは小さな回収をより早く見送り、割り当てられた建物のための空きを残しやすくなります。"
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "おすすめ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "混雑した都市向けのバランスのよい値を適用します。\n" +
                    "トラック積載量 **200%** | 保管量 **150%** | 処理速度 **250%**\n" +
                    "車両数 **100%** | 目的地用予約容量 **15%**。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "スライダーをリセット" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "標準の Trash Boss スライダーをリセットします。\n" +
                    "- パーセントスライダーは **100%** に戻ります。\n" +
                    "- 目的地用予約容量は **バニラの 10%** に戻ります。\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "この Mod の表示名。" },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "バージョン" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "現在の Mod バージョン。" },

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
                    "  * 同じゲームのゴミ処理を、トラック/施設でよりよく手動管理します。\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<ステータス / バニラ状態>\n" +
                    "  * Total Magic = OFF\n" +
                    "  * Trash Boss = OFF\n" +
                    "  * ステータスレポートのみ。\n" +
                    "  * バニラのゴミ処理は変更されません。"
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "使い方" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "ゴミサービス評価" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "ゲーム内の都市全体における平均的なゴミ幸福度への影響です。\n" +
                    "全体評価が良くても問題のある建物が少数残ることがあるため、**7t以上の建物**も確認してください。\n" +
                    "**0 = 全体的に良好**\n" +
                    "**-1 = 少し調整が必要**\n" +
                    "**-2 ～ -4 = 少し臭い**\n" +
                    "**-5 以下 = ゴミ問題**\n" +
                    "\n" +
                    "トラックと施設のスライダーでサービスを改善し、しばらく都市を動かしてからもう一度確認してください。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "7t以上の建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "ゴミを発生させる建物のうち、**7000 / 7t** 以上の建物数です。\n" +
                    "この固定の早期警戒指標により、建物がゲームの警告アイコン水準に達する前にサービスを増やすべきか判断できます。\n" +
                    "「詳細ステータスをログへ」で Entity ID を一覧表示できます。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "ゴミ/月" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "都市全体のゴミ発生量、現在の処理量、利用可能な施設処理能力を表示します。\n" +
                    "月間発生量が処理能力を上回る場合は、処理能力を増やしてください。\n" +
                    "すべての値は月あたりのトン数です。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "回収リクエスト" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**保留中** = 現在トラックや経路に割り当てられていない有効な回収リクエスト。\n" +
                    "**配車済み** = すでに割り当てられている有効な回収リクエスト。\n" +
                    "**合計** = ゴミ処理パイプライン内にある現在の **有効な** リクエストすべて。\n" +
                    "\n" +
                    "これは建物数を数える **リクエストしきい値超過** とは異なり、こちらはリクエスト数を数えます。\n" +
                    "保留中のリクエストの一部は後で割り当てられます。また、バニラの再検証で対象がサービス不要と判断された場合、後で消えることもあります。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "建物" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**ゴミあり** = 現在ゴミを保持している建物。\n" +
                    "**合計** = 都市内のすべてのゴミ発生建物。\n" +
                    "**リクエストしきい値超過** = 回収リクエストを作れるだけのゴミを持つ **建物** の現在数。\n" +
                    "詳細ステータスのログには、ゲームの現在のライブ・リクエストしきい値が表示されます。\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "施設" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "集計対象のゴミ施設の概要です。\n" +
                    "**施設** = 集計されたゴミ処理建物。\n" +
                    "**ゴミ収集車** = 通常の回収トラック。産業廃棄物施設では、通常のゴミではなく産業廃棄物を回収します。\n" +
                    "**ダンプトラック** = 施設間のゴミ移送。\n" +
                    "**最大労働者数** = 同じ施設全体の労働者定員合計。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "ゴミ収集車" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**走行中** = 現在街中に出ているトラック。\n" +
                    "**帰還中** = 走行中のうち、施設へ戻るよう指定されたトラック。\n" +
                    "**駐車中** = 施設に駐車しているトラック。\n" +
                    "**合計** = すべてのゴミ収集車の数。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "詳細ステータスをログへ" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "より詳細なゴミレポートを **Logs/MagicGarbage.log** に出力します。\n" +
                    "都市のゴミ統計を整理して記録します。"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "ログを開く" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "**MagicGarbage.log** を開きます。ファイルがない、または開けない場合は、代わりにゲームの Logs フォルダーを開きます。" },

                // Runtime status strings
                { "MG.Status.NoCity", "まだ都市が読み込まれていません。" },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "全体的に良好 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "少し調整が必要 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "少し臭い ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "ゴミ問題 ({0:N0}) | 更新 {1}" },
                { "MG.Status.Row.CriticalBuildings", "7t以上の建物 {0:N0} 件" },

                { "MG.Status.Row.GarbageProcessing", "発生 {0:N0} t | 処理中 {2:N0} t | 処理能力 {1:N0} t" },
                { "MG.Status.Row.Requests", "保留中 {1:N0} | 配車済み {2:N0} | 合計 {0:N0}" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} にゴミあり | リクエストしきい値超過 {2:N0}" },
                { "MG.Status.Row.FacilitiesSummary", "施設 {0:N0} | ゴミ収集車/ダンプ {1:N0}/{2:N0} | 労働者 {3:N0}" },
                { "MG.Status.Row.Trucks", "走行中 {1:N0}（帰還中 {3:N0}）| 駐車中 {2:N0} | 合計 {0:N0}" },
                { "MG.Status.Row.FacilitiesNone", "施設データはまだありません。" },

                // Log strings
                { "MG.Status.Log.Title", "ゴミステータス ({0})" },
                { "MG.Status.Log.City", "都市: {0}" },
                { "MG.Status.Log.Mode", "モード: Total Magic={0}, Trash Boss={1}" },
                { "MG.Status.Log.SettingsHeader", "現在の Mod 設定" },
                { "MG.Status.Log.SettingsTrashBoss", "Trash Boss スライダー（保存値）: トラック積載量={0:N0}% | 施設保管量={1:N0}% | 施設処理={2:N0}% | 施設車両数={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "凡例:\n" +
                    "- 発生量、現在の処理量、処理能力は月あたりのトン数です。\n" +
                    "- 以下のしきい値はトンではなく内部ゴミ単位を使用します。\n" +
                    "- プレイヤー向け表示では、ゲームは 100 単位 = 0.1t、1,000 単位 = 1t と換算します。\n" +
                    "- ゴミサービス評価 = ゲーム内の都市ゴミ幸福度係数。\n" +
                    "  - 0 = 全体的に良好\n" +
                    "  - -1 = 少し調整が必要\n" +
                    "  - -2 ～ -4 = 少し臭い\n" +
                    "  - -5 ～ -10 = ゴミ問題\n" +
                    "経路設定値:\n" +
                    "  - 回収しきい値はバニラの最低値です。目的地を考慮した経路設定では、目的地用の容量を守るためトラックごとに値を引き上げることがあります。\n" +
                    "  - リクエストしきい値は、ゲームが回収リクエストを作成または保持するために必要な最小ゴミ量です。\n" +
                    "- 建物のゴミが現在の警告水準を超えると警告アイコンが表示されます。\n" +
                    "- 上限 = 建物が蓄積できる最大ゴミ量。\n" +
                    "- 保留中 = 現在トラックや経路に割り当てられていない有効なリクエスト。\n" +
                    "- 保留中のリクエストの一部は後で割り当てられます。また、バニラの再検証で対象がサービス不要と判断された場合、後で消えることもあります。\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "ゲームしきい値（内部ゴミ単位）: 回収={1:N0}, リクエスト={0:N0}, 警告アイコン={2:N0}, 上限={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "しきい値: <GarbageParameterData を利用できません>" },
                { "MG.Status.Log.AdaptiveMargin", "目的地用予約容量: {0:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "ゴミ発生量: {0:N0} t/月 | 現在の処理量: {2:N0} t/月 | 処理能力: {1:N0} t/月" },
                { "MG.Status.Log.GarbageServiceRating", "ゴミサービス評価: {0} | 生値={1:N2} | 丸め={2:N0}" },
                { "MG.Status.Log.Requests", "回収リクエスト: 保留中={1:N0}, 配車済み={2:N0}, 合計={0:N0}" },
                { "MG.Status.Log.PendingPeak", "保留中の対象で最大のゴミ量: {0:N0} ({1:N1}t) 場所 {2}" },
                { "MG.Status.Log.PendingPeakNone", "保留中の対象で最大のゴミ量: なし" },
                { "MG.Status.Log.Producers", "建物: 警告水準超過 {0:N0} | 合計 {1:N0} | ゴミあり {2:N0} | リクエストしきい値超過 {3:N0}" },
                { "MG.Status.Log.ProducerGarbageStats", "建物のゴミ（0以外のみ）: 平均={0:N0} ({1:N1}t) | 中央値={2:N0} ({3:N1}t) | 最大={4:N0} ({5:N1}t) 場所 {6}" },
                { "MG.Status.Log.NearWarning75", "警告アイコン付近の建物（{1:N0} 単位 / {2:N1}t 以上）: {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "施設: 合計 {0:N0} | ゴミ収集車 {1:N0} | ダンプトラック {2:N0}（走行中 {3:N0}）| 労働者 {4:N0}" },
                { "MG.Status.Log.Trucks", "ゴミ収集車: 走行中 {2:N0}（帰還中 {3:N0}）| 駐車中 {1:N0} | 無効 {4:N0} | 合計 {0:N0}" },
                { "MG.Status.Log.FacilitiesHeader", "施設概要" },
                { "MG.Status.Log.FacilityLine", "- 施設 {0}: ゴミ収集車={1:N0}（走行中 {2:N0}, 駐車中 {3:N0}）| ダンプトラック={4:N0}（走行中 {5:N0}）| 最大労働者数={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "全体的に良好" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "少し調整が必要" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "少し臭い" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "ゴミ問題" },

                { "MG.Status.Log.ThresholdsHeader", "しきい値 + サービス" },
                { "MG.Status.Log.RequestsHeader", "リクエスト" },
                { "MG.Status.Log.BuildingsHeader", "建物" },

                { "MG.Status.Log.CriticalBuildingsHeader", "7t以上の建物" },
                { "MG.Status.Log.LocalTransferProbeHeader", "ローカル・ゴミ移送プローブ" },
                { "MG.Status.Log.LocalTransferProbeNone", "ローカルのゴミ施設が見つかりません。" },
                { "MG.Status.Log.OutsideTransferProbeHeader", "外部接続ゴミ移送プローブ" },
                { "MG.Status.Log.OutsideTransferProbeNone", "外部接続のゴミ施設が見つかりません。" },

                { "MG.Status.Log.TransferProbeHeader", "ゴミ移送プローブ" },
                { "MG.Status.Log.TransferProbeNone", "ゴミの保管・移送施設が見つかりません。" },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | 保管={1,7:N0} ({2,4:N1}t) / 容量={3,7:N0} ({4,4:N1}t) | 受入={5:N2} | 送出={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "トラック" },

                { "MG.Status.Log.CriticalBuildingsNone", "なし" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
