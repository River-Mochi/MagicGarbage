// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (C) 2026 River-Mochi.
// Licensed under the GNU General Public License v3.0 or later,
// with the Cities: Skylines II Linking Exception.
// See LICENSE and LICENSE-EXCEPTION in the project root.
// Copyright and license notices MUST be preserved.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Vietnamese (vi-VN)

namespace MagicGarbage
{
    using System.Collections.Generic;
    using Colossal;

    public sealed class LocaleVI : IDictionarySource
    {
        private readonly Setting m_Setting;

        public LocaleVI(Setting setting)
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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Thao tác" },
                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Giới thiệu" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Tự động dọn sạch" },
                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Tự quản lý" },
                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Trạng thái" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Thông tin mod" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liên kết" },
                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "CÁCH DÙNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Phép thuật toàn thành phố" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Bật [ ✓ ]** để giữ toàn bộ thành phố sạch sẽ.\n" +
                    "\n" +
                    "Khi **Phép thuật toàn thành phố** đang BẬT:\n" +
                    "- Quản lý rác bị buộc TẮT.\n" +
                    "- Các thanh trượt Quản lý rác không được áp dụng (giá trị vẫn được lưu để dùng sau).\n" +
                    "- Một số xe vẫn có thể di chuyển do thời điểm hoạt động của logic điều phối vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Quản lý rác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Quản lý trực tiếp hệ thống rác trong khi vẫn để logic rác vanilla hoạt động.\n" +
                    "\n" +
                    "- Khi **Quản lý rác BẬT [ ✓ ]**, Phép thuật toàn thành phố bị buộc TẮT.\n" +
                    "- Thanh trượt chỉ áp dụng khi Quản lý rác được bật.\n" +
                    "- Có thể TẮT cả Phép thuật toàn thành phố + Quản lý rác để dùng thiết lập vanilla,\n" +
                    "  và bạn vẫn có thể xem **báo cáo trạng thái**, chỉ cập nhật khi mở menu Tùy chọn (nhẹ)."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Sức chứa xe rác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Lượng rác mỗi xe có thể chở.**\n" +
                    "**100% = sức chứa vanilla** của xe (20t).\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Sức chứa kho của cơ sở" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Lượng rác một cơ sở có thể lưu trữ.**\n" +
                    "**100% = sức chứa vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Tốc độ xử lý của cơ sở" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Tốc độ cơ sở xử lý rác đi vào.**\n" +
                    "**100% = tốc độ xử lý vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Đội xe của cơ sở" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Số xe mỗi cơ sở có thể điều đi.**\n" +
                    "**100% = số xe vanilla**.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AdaptiveReservationMargin)), "Dung lượng dành cho điểm đến" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AdaptiveReservationMargin)),
                    "**Quy định xe bắt đầu chọn lọc các điểm nhặt tùy chọn sớm đến mức nào khi đang đi tới tòa nhà được giao.**\n" +
                    "**10% là giá trị vanilla của phiên bản 1.6.2.**\n" +
                    "Với xe 20t thông thường:\n" +
                    "- 10% bắt đầu bảo vệ điểm được giao sớm hơn 2t.\n" +
                    "- 15% bắt đầu sớm hơn 3t.\n" +
                    "- 25% bắt đầu sớm hơn 5t.\n" +
                    "Giá trị cao hơn tạo biên an toàn lớn hơn. Xe sẽ bỏ qua các lượt nhặt nhỏ sớm hơn, giúp chừa nhiều chỗ hơn cho tòa nhà được giao."
                },


                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Khuyến nghị" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Áp dụng các giá trị cân bằng cho thành phố bận rộn.\n" +
                    "Tải xe **200%** | lưu trữ **150%** | xử lý **250%**\n" +
                    "Đội xe **100%** | dung lượng dành cho điểm đến **15%**."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Đặt lại thanh trượt" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Đặt lại các thanh trượt Quản lý rác tiêu chuẩn.\n" +
                    "- Thanh trượt phần trăm trở về **100%**.\n" +
                    "- Dung lượng dành cho điểm đến trở về giá trị **vanilla 10%**.\n"
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Phiên bản" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Phiên bản mod hiện tại." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Mở trang Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Mở lời mời Discord trong trình duyệt." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Trạng thái Tự động dọn sạch>\n" +
                    "  * Phép thuật toàn thành phố BẬT = **[ ✓ ]**\n" +
                    "  * Rác được tự động xóa - xong.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Trạng thái Tự quản lý>\n" +
                    "  * Quản lý rác = **[ ✓ ]**\n" +
                    "  * Đặt các thanh trượt theo ý muốn.\n" +
                    "  * Vẫn là hệ thống rác của game; xe/cơ sở được tự quản lý tốt hơn.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Trạng thái / vanilla>\n" +
                    "  * Phép thuật toàn thành phố = TẮT\n" +
                    "  * Quản lý rác = TẮT\n" +
                    "  * Chỉ báo cáo trạng thái.\n" +
                    "  * Hệ thống rác vanilla không thay đổi."
                },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Cách dùng" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Đánh giá dịch vụ rác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Mức ảnh hưởng trung bình của rác tới hạnh phúc trên toàn thành phố theo game.\n" +
                    "Đánh giá tổng thể tốt vẫn có thể có vài tòa nhà gặp vấn đề, vì vậy hãy kiểm tra cả **tòa nhà 7t+**.\n" +
                    "**0 = Nhìn chung xuất sắc**\n" +
                    "**-1 = Cần chỉnh nhẹ**\n" +
                    "**-2 đến -4 = Hơi có mùi**\n" +
                    "**-5 hoặc thấp hơn = Vấn đề rác**\n" +
                    "\n" +
                    "Cải thiện dịch vụ bằng các thanh trượt xe và cơ sở, rồi để thành phố chạy một lúc trước khi kiểm tra lại."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Tòa nhà 7t+" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Số tòa nhà tạo rác có lượng rác từ **7000 / 7t** trở lên.\n" +
                    "Chỉ báo cảnh báo sớm cố định này giúp bạn quyết định có nên tăng dịch vụ trước khi tòa nhà đạt mức biểu tượng cảnh báo của game hay không.\n" +
                    "Dùng Trạng thái chi tiết vào log để liệt kê Entity ID của chúng."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rác/tháng" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Hiển thị lượng rác phát sinh toàn thành phố, lượng xử lý hiện tại và công suất xử lý khả dụng của các cơ sở.\n" +
                    "Tăng xử lý nếu lượng phát sinh hàng tháng cao hơn công suất.\n" +
                    "Tất cả giá trị dùng đơn vị tấn mỗi tháng."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Yêu cầu thu gom" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Đang chờ** = yêu cầu thu gom đang hoạt động nhưng hiện chưa được gán cho xe hoặc đường đi.\n" +
                    "**Đã điều xe** = yêu cầu thu gom đang hoạt động đã được gán.\n" +
                    "**Tổng** = tất cả yêu cầu **đang hoạt động** hiện có trong luồng xử lý rác.\n" +
                    "\n" +
                    "Khác với **Trên ngưỡng yêu cầu**, mục đó đếm tòa nhà thay vì yêu cầu.\n" +
                    "Một số yêu cầu đang chờ sẽ được gán sau; một số khác cũng có thể biến mất nếu việc kiểm tra lại của vanilla xác định mục tiêu không còn cần dịch vụ."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Tòa nhà" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Có rác** = tòa nhà hiện đang chứa bất kỳ lượng rác nào.\n" +
                    "**Tổng** = tất cả tòa nhà tạo rác trong thành phố.\n" +
                    "**Trên ngưỡng yêu cầu** = số **tòa nhà** hiện có đủ rác để tạo yêu cầu thu gom.\n" +
                    "Log Trạng thái chi tiết cho biết ngưỡng yêu cầu đang hoạt động hiện tại của game.\n"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Cơ sở" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Tóm tắt các cơ sở rác được tính.\n" +
                    "**Cơ sở** = các tòa nhà rác được tính.\n" +
                    "**Xe rác** = xe thu gom thông thường. Ở cơ sở Chất thải Công nghiệp, chúng thu gom chất thải công nghiệp thay vì rác thường.\n" +
                    "**Xe ben** = chuyển rác giữa các cơ sở.\n" +
                    "**Tối đa công nhân** = tổng sức chứa công nhân của chính các cơ sở đó."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Xe rác" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Đang chạy** = xe hiện đang hoạt động ngoài thành phố.\n" +
                    "**Đang quay về** = nhóm xe đang chạy được đánh dấu quay về cơ sở.\n" +
                    "**Đang đỗ** = xe đỗ tại cơ sở.\n" +
                    "**Tổng** = số lượng tất cả xe rác."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Trạng thái chi tiết vào log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Gửi báo cáo rác chi tiết hơn vào **Logs/MagicGarbage.log**.\n" +
                    "Bao gồm các thống kê rác của thành phố được sắp xếp rõ ràng."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },
                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Mở **MagicGarbage.log**. Nếu tệp bị thiếu hoặc không thể mở, thay vào đó sẽ mở thư mục Logs của game." },

                // Runtime status strings
                { "MG.Status.NoCity", "Chưa tải thành phố nào." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Nhìn chung xuất sắc ({0:N0}) | cập nhật {1}" },
                { "MG.Status.Row.GarbageServiceRating.Minor", "Cần chỉnh nhẹ ({0:N0}) | cập nhật {1}" },
                { "MG.Status.Row.GarbageServiceRating.Stinky", "Hơi có mùi ({0:N0}) | cập nhật {1}" },
                { "MG.Status.Row.GarbageServiceRating.Problem", "Vấn đề rác ({0:N0}) | cập nhật {1}" },
                { "MG.Status.Row.CriticalBuildings", "{0:N0} tòa nhà 7t+" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t phát sinh | {2:N0} t đang xử lý | {1:N0} t công suất" },
                { "MG.Status.Row.Requests", "{1:N0} đang chờ | {2:N0} đã điều xe | {0:N0} tổng" },
                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} có rác | {2:N0} trên ngưỡng yêu cầu" },
                { "MG.Status.Row.FacilitiesSummary", "{0:N0} cơ sở | {1:N0}/{2:N0} xe rác/xe ben | {3:N0} công nhân" },
                { "MG.Status.Row.Trucks", "{1:N0} đang chạy ({3:N0} đang quay về) | {2:N0} đang đỗ | {0:N0} tổng" },
                { "MG.Status.Row.FacilitiesNone", "Chưa có dữ liệu cơ sở." },

                // Log strings
                { "MG.Status.Log.Title", "Trạng thái rác ({0})" },
                { "MG.Status.Log.City", "Thành phố: {0}" },
                { "MG.Status.Log.Mode", "Chế độ: Phép thuật toàn thành phố={0}, Quản lý rác={1}" },
                { "MG.Status.Log.SettingsHeader", "Thiết lập mod hiện tại" },
                { "MG.Status.Log.SettingsTrashBoss", "Thanh trượt Quản lý rác (đã lưu): tải xe={0:N0}% | lưu trữ cơ sở={1:N0}% | xử lý cơ sở={2:N0}% | đội xe cơ sở={3:N0}%" },
                
                { "MG.Status.Log.Legend",
                    "Chú giải:\n" +
                    "- Lượng phát sinh, lượng xử lý hiện tại và công suất dùng đơn vị tấn mỗi tháng.\n" +
                    "- Các giá trị ngưỡng bên dưới dùng đơn vị rác nội bộ, không phải tấn.\n" +
                    "- Khi hiển thị cho người chơi, game quy đổi 100 đơn vị = 0.1t và 1,000 đơn vị = 1t.\n" +
                    "- Đánh giá dịch vụ rác = hệ số hạnh phúc do rác của thành phố trong game.\n" +
                    "  - 0 = Nhìn chung xuất sắc\n" +
                    "  - -1 = Cần chỉnh nhẹ\n" +
                    "  - -2 đến -4 = Hơi có mùi\n" +
                    "  - -5 đến -10 = Vấn đề rác\n" +
                    "Giá trị định tuyến:\n" +
                    "  - Ngưỡng thu gom là mức tối thiểu vanilla; định tuyến có xét điểm đến có thể tăng ngưỡng theo từng xe để bảo vệ dung lượng cho điểm đến.\n" +
                    "  - Ngưỡng yêu cầu là lượng rác tối thiểu trước khi game tạo hoặc giữ một yêu cầu thu gom.\n" +
                    "- Biểu tượng cảnh báo xuất hiện khi rác của tòa nhà vượt mức cảnh báo đang hoạt động.\n" +
                    "- Giới hạn cứng = lượng rác tối đa một tòa nhà có thể tích lũy.\n" +
                    "- Đang chờ = yêu cầu đang hoạt động nhưng hiện chưa được gán cho xe hoặc đường đi.\n" +
                    "- Một số yêu cầu đang chờ sẽ được gán sau; một số khác cũng có thể biến mất nếu việc kiểm tra lại của vanilla xác định mục tiêu không còn cần dịch vụ.\n" +
                    "-----------------------------------------------------------------------------\n"
                },

                { "MG.Status.Log.Thresholds", "Ngưỡng game (đơn vị rác nội bộ): thu gom={1:N0}, yêu cầu={0:N0}, biểu tượng cảnh báo={2:N0}, giới hạn cứng={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Ngưỡng: <GarbageParameterData không khả dụng>" },
                { "MG.Status.Log.AdaptiveMargin", "Dung lượng dành cho điểm đến: {0:N0}%" },
                { "MG.Status.Log.AdaptiveMarginWithBaseline", "Dung lượng dành cho điểm đến: hiện tại={0:N0}% | giá trị gốc của trò chơi khi tải={1:N0}%" },
                { "MG.Status.Log.GarbageProcessing", "Rác phát sinh: {0:N0} t/tháng | Xử lý hiện tại: {2:N0} t/tháng | Công suất xử lý: {1:N0} t/tháng" },
                { "MG.Status.Log.GarbageServiceRating", "Đánh giá dịch vụ rác: {0} | thô={1:N2} | làm tròn={2:N0}" },
                { "MG.Status.Log.Requests", "Yêu cầu thu gom: đang chờ={1:N0}, đã điều xe={2:N0}, tổng={0:N0}" },
                { "MG.Status.Log.PendingPeak", "Lượng rác cao nhất ở mục tiêu đang chờ: {0:N0} ({1:N1}t) tại {2}" },
                { "MG.Status.Log.PendingPeakNone", "Lượng rác cao nhất ở mục tiêu đang chờ: không có" },
                { "MG.Status.Log.Producers", "Tòa nhà: {0:N0} trên mức cảnh báo | {1:N0} tổng | {2:N0} có rác | {3:N0} trên ngưỡng yêu cầu" },
                { "MG.Status.Log.ProducerGarbageStats", "Rác trong tòa nhà (chỉ giá trị khác 0): TB={0:N0} ({1:N1}t) | trung vị={2:N0} ({3:N1}t) | tối đa={4:N0} ({5:N1}t) tại {6}" },
                { "MG.Status.Log.NearWarning75", "Tòa nhà gần biểu tượng cảnh báo (ít nhất {1:N0} đơn vị / {2:N1}t): {0:N0}" },
                { "MG.Status.Log.FacilitiesSummary", "Cơ sở: {0:N0} tổng | {1:N0} xe rác | {2:N0} xe ben ({3:N0} đang chạy) | {4:N0} công nhân" },
                { "MG.Status.Log.Trucks", "Xe rác: {2:N0} đang chạy ({3:N0} đang quay về) | {1:N0} đang đỗ | {4:N0} bị vô hiệu | {0:N0} tổng" },
                { "MG.Status.Log.FacilitiesHeader", "Tóm tắt cơ sở" },
                { "MG.Status.Log.FacilityLine", "- Cơ sở {0}: xe rác={1:N0} ({2:N0} đang chạy, {3:N0} đang đỗ) | xe ben={4:N0} ({5:N0} đang chạy) | tối đa công nhân={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Nhìn chung xuất sắc" },
                { "MG.Status.Log.GarbageServiceRating.Minor", "Cần chỉnh nhẹ" },
                { "MG.Status.Log.GarbageServiceRating.Stinky", "Hơi có mùi" },
                { "MG.Status.Log.GarbageServiceRating.Problem", "Vấn đề rác" },

                { "MG.Status.Log.ThresholdsHeader", "Ngưỡng + Dịch vụ" },
                { "MG.Status.Log.RequestsHeader", "Yêu cầu" },
                { "MG.Status.Log.BuildingsHeader", "Tòa nhà" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Tòa nhà 7t+" },
                { "MG.Status.Log.LocalTransferProbeHeader", "Dò chuyển rác nội bộ" },
                { "MG.Status.Log.LocalTransferProbeNone", "Không tìm thấy cơ sở rác nội bộ." },
                { "MG.Status.Log.OutsideTransferProbeHeader", "Dò chuyển rác qua kết nối bên ngoài" },
                { "MG.Status.Log.OutsideTransferProbeNone", "Không tìm thấy cơ sở rác cho kết nối bên ngoài." },

                { "MG.Status.Log.TransferProbeHeader", "Dò chuyển rác" },
                { "MG.Status.Log.TransferProbeNone", "Không tìm thấy cơ sở lưu trữ-chuyển rác." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | lưu={1,7:N0} ({2,4:N1}t) / công suất={3,7:N0} ({4,4:N1}t) | nhận={5:N2} | gửi={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Xe" },

                { "MG.Status.Log.CriticalBuildingsNone", "không có" },
                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
