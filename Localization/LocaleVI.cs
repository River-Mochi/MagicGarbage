// <copyright file="LocaleVI.cs" company="River-Mochi">
// Copyright (c) 2026 River-Mochi. All rights reserved.
// Licensed under the MIT License. You may not use this file except in compliance with this License.
// See LICENSE file in the project root for full license information.
// This notice and the MIT License notice must be kept with
// all copies or substantial portions of this code.
// ================= </copyright> ======================

// File: Localization/LocaleVI.cs
// Vietnamese (vi-VN)

namespace MagicGarbage
{
    using Colossal;
    using System.Collections.Generic;

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
                { m_Setting.GetOptionTabLocaleID(Setting.ActionsTab), "Hành động" },

                { m_Setting.GetOptionTabLocaleID(Setting.AboutTab), "Giới thiệu" },

                // Groups
                { m_Setting.GetOptionGroupLocaleID(Setting.TotalMagicGrp), "Tự động dọn sạch" },

                { m_Setting.GetOptionGroupLocaleID(Setting.TrashBossGrp), "Tự quản lý" },

                { m_Setting.GetOptionGroupLocaleID(Setting.PowerUserGrp), "Người dùng nâng cao" },

                { m_Setting.GetOptionGroupLocaleID(Setting.StatusGrp), "Trạng thái" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutInfoGrp), "Thông tin mod" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutLinksGrp), "Liên kết" },

                { m_Setting.GetOptionGroupLocaleID(Setting.AboutUsageGrp), "CÁCH DÙNG" },

                // Total Magic
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TotalMagic)), "Total Magic" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TotalMagic)),
                    "**Bật [ ✓ ]** giữ cho toàn bộ thành phố sạch sẽ.\n" +
                    "\n" +
                    "Khi **Total Magic** đang BẬT:\n" +
                    "- Trash Boss bị buộc TẮT.\n" +
                    "- Các thanh trượt Trash Boss không được áp dụng (giá trị vẫn được lưu để dùng sau).\n" +
                    "- Một vài xe tải vẫn có thể di chuyển do thời điểm xử lý của logic điều phối vanilla."
                },

                // Trash Boss
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossEnabled)), "Trash Boss" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossEnabled)),
                    "Quản lý trực tiếp hệ thống rác; logic rác vanilla vẫn chạy.\n" +
                    "\n" +
                    "- Khi **Trash Boss đang BẬT [ ✓ ]**, Total Magic bị buộc TẮT.\n" +
                    "- Các thanh trượt chỉ được áp dụng khi Trash Boss được bật.\n" +
                    "- Total Magic và Trash Boss đều có thể **TẮT** để dùng thiết lập vanilla,\n" +
                    "  và bạn vẫn có thể xem **báo cáo Trạng thái**, chỉ cập nhật khi bạn mở menu Tùy chọn (nhẹ)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PriorityAssistEnabled)), "Hỗ trợ ưu tiên" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PriorityAssistEnabled)),
                    "Hỗ trợ cho các mục tiêu rác (tòa nhà) bị quá tải nặng.\n" +
                    "Khi **BẬT**, kiểm tra xem có mục tiêu yêu cầu đang hoạt động nào đạt **7000+** (**7t**) rác hay không.\n" +
                    "Mục tiêu: giảm các lượt ghé thu gom phụ khi cần, để xe tải tới các mục tiêu nghiêm trọng sớm hơn.\n" +
                    "Đây là một cú nhắc nhẹ, không phải ghi đè cứng và toàn bộ logic tuyến đường vanilla.\n" +
                    "Nhẹ, không dùng Harmony patch."
                },

                // Sliders
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)), "Sức chứa xe chở rác" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageTruckCapacityMultiplier)),
                    "**Lượng rác mỗi xe tải có thể chở.**\n" +
                    "**100% = bình thường** mặc định của game (20t).\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)), "Sức chứa cơ sở" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityStorageMultiplier)),
                    "**Lượng rác một cơ sở có thể lưu trữ.**\n" +
                    "**100% = sức chứa vanilla**.\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)), "Tốc độ xử lý của cơ sở" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityProcessingMultiplier)),
                    "**Tốc độ các cơ sở xử lý rác đi vào.**\n" +
                    "**100% = tốc độ xử lý vanilla**.\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)), "Đội xe của cơ sở" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageFacilityVehicleMultiplier)),
                    "**Số xe tải mỗi cơ sở có thể điều động.**\n" +
                    "**100% = số xe tải vanilla**.\n" +
                    ""
                },

                // Trash Boss Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossRecommended)), "Khuyến nghị" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossRecommended)),
                    "Áp dụng các giá trị Trash Boss chuẩn **khuyến nghị**.\n" +
                    "Không thay đổi thiết lập Người dùng nâng cao (riêng biệt)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.TrashBossDefaults)), "Mặc định game" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.TrashBossDefaults)),
                    "Đưa các thanh trượt Trash Boss về **giá trị vanilla**.\n" +
                    "<Không> thay đổi thiết lập Người dùng nâng cao.\n" +
                    "**Vanilla:**\n" +
                    "- Các thanh trượt phần trăm trở về **100%**.\n" +
                    "- Ngưỡng yêu cầu điều xe trở về **100 đơn vị**.\n" +
                    "- Ngưỡng thu gom trở về **20 đơn vị**.\n" +
                    ""
                },

                // Power User Options
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserOptions)), "Tùy chọn nâng cao" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserOptions)),
                    "Thiết lập nâng cao tùy chọn\n" +
                    "<Cảnh báo: KHÔNG cần thiết> để có dịch vụ tốt; dành cho người chơi muốn thử nghiệm hoặc hiểu rõ hơn cách các hệ thống hoạt động.\n" +
                    "Khi **TẮT**, các mục Người dùng nâng cao hoạt động như game **vanilla** bình thường.\n" +
                    "Khi **BẬT**, các **thanh trượt** nâng cao sẽ xuất hiện.\n" +
                    "\n" +
                    "<--- Ví dụ về hạnh phúc --->\n" +
                    " - <Vanilla> 100/65 = phạt lần đầu ở <165>.\n" +
                    " - Nhấn <Khuyến nghị> để dùng 550/150 = phạt lần đầu ở <700>.\n" +
                    " - <Rất nhẹ> 950/200 = phạt rác lần đầu ở <1150>.\n" +
                    "Tiện lợi: các giá trị thanh trượt cuối cùng được lưu khi tùy chọn này TẮT (phòng khi bạn muốn bật lại sau)."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)), "Ngưỡng yêu cầu điều xe" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageDispatchRequestThreshold)),
                    "**Lượng rác trong tòa nhà cần có trước khi yêu cầu điều xe tải được tạo hoặc giữ lại.**\n" +
                    "Vanilla = **100** đơn vị rác.\n" +
                    "**100 đơn vị rác = 0.1t**\n" +
                    "**1,000 đơn vị rác = 1t**\n" +
                    "Giữ giá trị này bằng hoặc cao hơn Ngưỡng thu gom.\n" +
                    "Điều này thường làm tăng số xe tải được dùng thay vì đỗ lại."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbagePickupThreshold)), "Ngưỡng thu gom" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbagePickupThreshold)),
                    "**Lượng rác tối thiểu trong tòa nhà trước khi xe tải có thể thu gom.**\n" +
                    "Vanilla = **20** đơn vị rác.\n" +
                    "Thanh trượt thu gom <không thể> cao hơn Yêu cầu điều xe (DR); nó được giới hạn để tránh lỗi logic.\n" +
                    "Nếu xe tải được điều tới một tòa nhà và giá trị thu gom cao hơn DR, đôi khi xe tải có thể không thu gom được từ tòa nhà đó (tốc độ tích tụ cũng ảnh hưởng đến việc này).\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessBaseline)), "Mốc hạnh phúc do rác" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessBaseline)),
                    "**Mức rác trong tòa nhà trước khi bắt đầu gây phạt sức khỏe + hạnh phúc.**\n" +
                    "**Vanilla = 100** đơn vị rác.\n" +
                    "Mốc cao hơn = tòa nhà có thể chứa nhiều rác hơn trước khi hình phạt bắt đầu.\n" +
                    "100 đơn vị rác = 0.1t\n" +
                    "Tổng quan:\n" +
                    "- <Ngưỡng> = điểm kích hoạt hành vi hệ thống\n" +
                    "- <Mốc> = điểm bắt đầu của công thức phạt\n" +
                    "- <Bước> = kích thước tăng trong công thức, tức hình phạt tăng nhanh thế nào sau khi bắt đầu"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageHappinessStep)), "Bước hạnh phúc do rác" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageHappinessStep)),
                    "**Lượng rác thêm vượt mốc khiến hình phạt -1 bắt đầu.**\n" +
                    "Vanilla = **65** đơn vị rác.\n" +
                    "Bước cao hơn = hình phạt tăng chậm hơn.\n" +
                    "Game giới hạn hình phạt do rác ở **-10**.\n" +
                    "Hình phạt vanilla đầu tiên <-1 penalty> xảy ra ở **165 rác** (100 mốc + 65 bước)\n" +
                    "Thay đổi ngưỡng phải cân bằng với các thanh trượt hạnh phúc, nếu không hình phạt có thể nặng hơn bình thường."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageAccumulationRate)), "Tốc độ tích tụ" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageAccumulationRate)),
                    "**Nhân các giá trị nguồn rác của tòa nhà được hỗ trợ.**\n" +
                    "Cẩn thận: đây là một đòn bẩy mạnh và thay đổi tốc độ này ảnh hưởng tới nhiều thứ.\n" +
                    "Bạn vẫn có thể có hệ thống tốt mà không cần dùng mục này.\n" +
                    "\n" +
                    "**100% = tốc độ tích tụ vanilla**.\n" +
                    "**20%** = tích tụ chậm hơn nhiều.\n" +
                    "**200%** = tốc độ gấp đôi - rất nhiều rác.\n" +
                    "Ở 20%, rõ ràng tất cả Cim đều đang ủ phân, nên tốc độ tích tụ rác thấp hơn rất nhiều ;)\n" +
                    "\n" +
                    "Ghi chú kỹ thuật: game thêm rác dần trong ngày, không thêm tất cả cùng lúc."
                },

                // Power User Presets
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserRecommended)), "Khuyến nghị" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserRecommended)),
                    "Áp dụng các giá trị Người dùng nâng cao **khuyến nghị**.\n" +
                    "Bật Người dùng nâng cao.\n" +
                    "Hình phạt rác đầu tiên bắt đầu ở **700** rác (550 mốc + 150 bước).\n" +
                    "Tốc độ tích tụ rác vẫn ở **100%** vanilla trừ khi bạn đổi thủ công."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.PowerUserDefaults)), "Mặc định game" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.PowerUserDefaults)),
                    "Đưa tất cả giá trị Người dùng nâng cao **trở về vanilla**.\n" +
                    "Tắt **Người dùng nâng cao**.\n" +
                    ""
                },

                // About
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutName)), "Mod" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutName)), "Tên hiển thị của mod này." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.AboutVersion)), "Phiên bản" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.AboutVersion)), "Phiên bản hiện tại của mod." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenParadoxPage)), "Paradox Mods" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenParadoxPage)), "Mở trang Paradox Mods." },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenDiscord)), "Discord" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenDiscord)), "Mở lời mời Discord trong trình duyệt." },

                // Usage block
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.UsageNotes)),
                    "<Trạng thái Tự động dọn sạch>\n" +
                    "  * Total Magic BẬT = **[ ✓ ]**\n" +
                    "  * Rác được tự động xóa - Xong.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Trạng thái Tự quản lý>\n" +
                    "  * Trash Boss = **[ ✓ ]**\n" +
                    "  * Đặt các thanh trượt theo ý muốn.\n" +
                    "  * Tùy chọn: bật để hiện các thanh trượt nâng cao (không bắt buộc).\n" +
                    "  * Vẫn là hệ thống rác của game; xe tải/cơ sở được tự quản lý tốt hơn.\n" +
                    " <-------------------------------------->\n" +
                    "\n" +
                    "<Trạng thái / vanilla>\n" +
                    "  * Total Magic = TẮT\n" +
                    "  * Trash Boss = TẮT\n" +
                    "  * Chỉ báo cáo trạng thái.\n" +
                    "  * Game rác vanilla không thay đổi."
                },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.UsageNotes)), "Cách dùng" },

                // Status
                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageServiceRating)), "Đánh giá dịch vụ rác" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageServiceRating)),
                    "Đánh giá hạnh phúc do rác đơn giản từ game.\n" +
                    "**0 = Tuyệt vời**\n" +
                    "**-1 **= Cần chỉnh nhẹ. Game thường dao động giữa 0 và -1 và có thể bỏ qua (số đã được làm tròn).\n" +
                    "**-2 đến -4** = Hơi có mùi\n" +
                    "**-5 đến -10** = Vấn đề rác\n" +
                    "**Núm gián tiếp:** Dùng <thanh trượt rác> để cải thiện dần bằng cách giảm rác tích tụ.\n" +
                    "**Núm trực tiếp:** Mốc hạnh phúc do rác + Bước hạnh phúc do rác thay đổi <mức Cim chịu được> trước khi họ không vui.\n" +
                    "**Tốc độ tích tụ rác**: thay đổi tốc độ các tòa nhà được hỗ trợ tạo rác. Dùng cẩn thận vì cân bằng rất quan trọng. Hầu hết người chơi không cần chỉnh mục này.\n" +
                    "<Thời gian cập nhật = lần làm mới gần nhất.>"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusCriticalBuildings)), "Tòa nhà 7t+" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusCriticalBuildings)),
                    "Số tòa nhà tạo rác đang ở mức hoặc trên **7t / 7000** rác.\n" +
                    "Đây là các tòa nhà quá tải nặng, hãy bật [x] Hỗ trợ ưu tiên để ưu tiên chúng tốt hơn.\n" +
                    "Dùng nút ghi Trạng thái vào log nếu bạn muốn số Entity ID để kiểm tra."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusGarbageProcessing)), "Rác/tháng" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusGarbageProcessing)),
                    "Hiển thị lượng rác toàn thành phố hiện tại và tổng tốc độ xử lý rác.\n" +
                    "Tăng xử lý nếu rác tạo ra mỗi tháng cao hơn nhiều.\n" +
                    "**Tạo ra** và **Xử lý** dùng tấn mỗi tháng."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusRequests)), "Yêu cầu thu gom" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusRequests)),
                    "**Đang chờ** = yêu cầu thu gom đang hoạt động nhưng chưa được gán cho xe tải hoặc đường đi.\n" +
                    "**Đã điều xe** = yêu cầu thu gom đang hoạt động đã được gán.\n" +
                    "**Tổng** = đếm thực thể yêu cầu **đang hoạt động** hiện tại (trong pipeline rác).\n" +
                    "\n" +
                    "Ghi chú kỹ thuật: Khác với <Trên ngưỡng yêu cầu>. Mục này đếm <yêu cầu>, không phải tòa nhà.\n" +
                    "Một số yêu cầu đang chờ sẽ được gán sau; một số cũng có thể bị xóa sau nếu quá trình kiểm tra lại vanilla quyết định mục tiêu không còn cần dịch vụ."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusProducers)), "Tòa nhà" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusProducers)),
                    "**Có rác** = tòa nhà hiện đang chứa bất kỳ lượng rác nào.\n" +
                    "**Tổng** = tất cả tòa nhà tạo rác trong thành phố.\n" +
                    "**Trên ngưỡng yêu cầu** = số **tòa nhà** hiện có đủ rác để tạo yêu cầu thu gom.\n" +
                    "Trong vanilla, ngưỡng yêu cầu là **100** đơn vị rác nội bộ.\n" +
                    "Tùy chọn Người dùng nâng cao có thể ghi đè ngưỡng yêu cầu và thu gom.\n" +
                    ""
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusFacilities)), "Cơ sở" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusFacilities)),
                    "Tóm tắt các cơ sở rác được đếm.\n" +
                    "**Cơ sở** = các tòa nhà rác được đếm.\n" +
                    "**Xe chở rác** = xe thu gom bình thường. Tại cơ sở Chất thải công nghiệp, chúng thu gom chất thải công nghiệp thay vì rác.\n" +
                    "**Xe ben** = chuyển rác giữa các cơ sở.\n" +
                    "**Công nhân tối đa** = tổng sức chứa công nhân trên cùng các cơ sở đó."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.StatusTrucks)), "Xe chở rác" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.StatusTrucks)),
                    "**Đang chạy** = xe tải hiện đang ở ngoài thành phố.\n" +
                    "**Đang quay về** = nhóm xe đang chạy được đánh dấu quay về cơ sở.\n" +
                    "**Đang đỗ** = xe tải đỗ tại cơ sở.\n" +
                    "**Tổng** = số tất cả xe chở rác."
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.GarbageStatusLog)), "Ghi trạng thái chi tiết vào log" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.GarbageStatusLog)),
                    "Gửi báo cáo rác chi tiết hơn vào **Logs/MagicGarbage.log**.\n" +
                    "Bao gồm thống kê rác thành phố có tổ chức"
                },

                { m_Setting.GetOptionLabelLocaleID(nameof(Setting.OpenLog)), "Mở log" },

                { m_Setting.GetOptionDescLocaleID(nameof(Setting.OpenLog)), "Mở thư mục Logs/.. của game." },

                // Runtime status strings
                { "MG.Status.NoCity", "Chưa tải thành phố." },

                { "MG.Status.Row.GarbageServiceRating.Excellent", "Tuyệt vời ({0:N0}) | cập nhật {1}" },

                { "MG.Status.Row.GarbageServiceRating.Minor", "Cần chỉnh nhẹ ({0:N0}) | cập nhật {1}" },

                { "MG.Status.Row.GarbageServiceRating.Stinky", "Hơi có mùi ({0:N0}) | cập nhật {1}" },

                { "MG.Status.Row.GarbageServiceRating.Problem", "Vấn đề rác ({0:N0}) | cập nhật {1}" },

                { "MG.Status.Row.CriticalBuildings", "{0:N0} trên 7t" },

                { "MG.Status.Row.GarbageProcessing", "{0:N0} t tạo ra | {1:N0} t xử lý" },

                { "MG.Status.Row.Requests", "{1:N0} đang chờ | {2:N0} đã điều xe | {0:N0} tổng" },

                { "MG.Status.Row.Producers", "{0:N0} / {1:N0} có rác | {2:N0} trên ngưỡng yêu cầu" },

                { "MG.Status.Row.FacilitiesSummary", "{0:N0} cơ sở | {1:N0}/{2:N0} xe rác/xe ben | {3:N0} công nhân" },

                { "MG.Status.Row.Trucks", "{1:N0} đang chạy ({3:N0} đang quay về) | {2:N0} đang đỗ | {0:N0} tổng" },

                { "MG.Status.Row.FacilitiesNone", "Chưa có dữ liệu cơ sở." },

                // Log strings
                { "MG.Status.Log.Title", "Trạng thái rác ({0})" },

                { "MG.Status.Log.City", "Thành phố: {0}" },

                { "MG.Status.Log.Mode", "Chế độ: Total Magic={0}, Trash Boss={1}" },

                { "MG.Status.Log.SettingsHeader", "Thiết lập mod hiện tại" },

                { "MG.Status.Log.SettingsTrashBoss", "Thanh trượt Trash Boss (đã lưu): tải xe={0:N0}% | sức chứa cơ sở={1:N0}% | xử lý cơ sở={2:N0}% | đội xe cơ sở={3:N0}%" },

                { "MG.Status.Log.SettingsPowerUser", "Người dùng nâng cao (đã lưu): bật={0} | yêu cầu={1:N0} | thu gom={2:N0} | mốc hạnh phúc={3:N0} | bước hạnh phúc={4:N0} | tốc độ tích tụ={5:N0}%" },

                { "MG.Status.Log.Legend",
                    "Chú giải:\n" +
                    "- Tạo ra/Xử lý dùng tấn mỗi tháng.\n" +
                    "- Các giá trị ngưỡng bên dưới dùng đơn vị rác nội bộ, không phải tấn.\n" +
                    "- Với hiển thị cho người chơi, game đổi 100 đơn vị = 0.1t và 1,000 đơn vị = 1t.\n" +
                    "- Đánh giá dịch vụ rác = hệ số hạnh phúc do rác của thành phố trong game.\n" +
                    "  - 0 = Tuyệt vời\n" +
                    "  - -1 = Cần chỉnh nhẹ, hoặc bỏ qua\n" +
                    "  - -2 đến -4 = Hơi có mùi\n" +
                    "  - -5 đến -10 = Vấn đề rác\n" +
                    "Thanh trượt ngưỡng:\n" +
                    "  - Ngưỡng thu gom = lượng rác tối thiểu trước khi xe tải sẽ thu gom từ tòa nhà.\n" +
                    "  - Ngưỡng yêu cầu = lượng rác tối thiểu trước khi game tạo hoặc giữ yêu cầu thu gom.\n" +
                    "- Biểu tượng cảnh báo = lượng rác khiến biểu tượng cảnh báo xuất hiện trên tòa nhà.\n" +
                    "- Giới hạn cứng = lượng rác tối đa một tòa nhà có thể tích tụ.\n" +
                    "- Đang chờ = yêu cầu đang hoạt động chưa được gán cho xe tải hoặc đường đi.\n" +
                    "- Một số yêu cầu đang chờ sẽ được gán sau; một số cũng có thể bị xóa sau nếu quá trình kiểm tra lại vanilla quyết định mục tiêu không còn cần dịch vụ.\n" +
                    "-----------------------------------------------------------------------------\n" +
                    ""
                },

                { "MG.Status.Log.Thresholds", "Ngưỡng game (đơn vị rác nội bộ): thu gom={1:N0}, yêu cầu={0:N0}, biểu tượng cảnh báo={2:N0}, giới hạn cứng={3:N0}" },

                { "MG.Status.Log.ThresholdsMissing", "Ngưỡng: <Không có GarbageParameterData>" },

                { "MG.Status.Log.GarbageProcessing", "Rác: {0:N0} t/tháng | Xử lý: {1:N0} t/tháng" },

                { "MG.Status.Log.GarbageServiceRating", "Đánh giá dịch vụ rác: {0} | thô={1:N2} | làm tròn={2:N0}" },

                { "MG.Status.Log.Requests", "Yêu cầu thu gom: đang chờ={1:N0}, đã điều xe={2:N0}, tổng={0:N0}" },

                { "MG.Status.Log.PendingPeak", "Mục tiêu đang chờ có rác cao nhất: {0:N0} ({1:N1}t) tại {2}" },

                { "MG.Status.Log.PendingPeakNone", "Mục tiêu đang chờ có rác cao nhất: không có" },

                { "MG.Status.Log.Producers", "Tòa nhà: {0:N0} biểu tượng cảnh báo | {1:N0} tổng | {2:N0} có rác | {3:N0} trên ngưỡng yêu cầu " },

                { "MG.Status.Log.ProducerGarbageStats", "Rác tòa nhà (chỉ tính khác 0): TB={0:N0} ({1:N1}t) | trung vị={2:N0} ({3:N1}t) | tối đa={4:N0} ({5:N1}t) tại {6}" },

                { "MG.Status.Log.NearWarning75", "Tòa nhà gần biểu tượng cảnh báo (ít nhất {1:N0} đơn vị / {2:N1}t): {0:N0}" },

                { "MG.Status.Log.FacilitiesSummary", "Cơ sở: {0:N0} tổng | {1:N0} xe chở rác | {2:N0} xe ben ({3:N0} đang chạy) | {4:N0} công nhân" },

                { "MG.Status.Log.Trucks", "Xe chở rác: {2:N0} đang chạy ({3:N0} đang quay về) | {1:N0} đang đỗ | {4:N0} bị vô hiệu | {0:N0} tổng" },

                { "MG.Status.Log.FacilitiesHeader", "Tóm tắt cơ sở" },

                { "MG.Status.Log.FacilityLine", "- Cơ sở {0}: xe chở rác={1:N0} ({2:N0} đang chạy, {3:N0} đang đỗ) | xe ben={4:N0} ({5:N0} đang chạy) | công nhân tối đa={6:N0}" },

                { "MG.Status.Log.GarbageServiceRating.Excellent", "Tuyệt vời" },

                { "MG.Status.Log.GarbageServiceRating.Minor", "Cần chỉnh nhẹ" },

                { "MG.Status.Log.GarbageServiceRating.Stinky", "Hơi có mùi" },

                { "MG.Status.Log.GarbageServiceRating.Problem", "Vấn đề rác" },

                { "MG.Status.Log.ThresholdsHeader", "Ngưỡng + Dịch vụ" },

                { "MG.Status.Log.RequestsHeader", "Yêu cầu" },

                { "MG.Status.Log.BuildingsHeader", "Tòa nhà" },

                { "MG.Status.Log.CriticalBuildingsHeader", "Tòa nhà nghiêm trọng trên 7t" },

                { "MG.Status.Log.LocalTransferProbeHeader", "Kiểm tra chuyển rác cục bộ" },

                { "MG.Status.Log.LocalTransferProbeNone", "Không tìm thấy cơ sở rác cục bộ." },

                { "MG.Status.Log.OutsideTransferProbeHeader", "Kiểm tra chuyển rác kết nối ngoài" },

                { "MG.Status.Log.OutsideTransferProbeNone", "Không tìm thấy cơ sở rác kết nối ngoài." },

                { "MG.Status.Log.TransferProbeHeader", "Kiểm tra chuyển rác" },

                { "MG.Status.Log.TransferProbeNone", "Không tìm thấy cơ sở lưu trữ-chuyển rác." },

                { "MG.Status.Log.TransferProbeLine", "- {0,-20} | lưu={1,7:N0} ({2,4:N1}t) / chứa={3,7:N0} ({4,4:N1}t) | nhận={5:N2} | gửi={6:N2} | inReq={7} | outReq={8} | {9}" },

                { "MG.Status.Log.TrucksHeader", "Xe tải" },

                { "MG.Status.Log.SettingsPriority", "Hệ thống ưu tiên (đã lưu): bật={0} | kích hoạt={1:N0} ({2:N1}t)" },

                { "MG.Status.Log.PriorityState", "Hỗ trợ ưu tiên đang chạy={0} | khoảng cách={1:N0} frame | tòa nhà quét lần cuối={2:N0} | tòa nhà nghiêm trọng={3:N0}" },

                { "MG.Status.Log.PriorityPeak", "Tòa nhà nghiêm trọng cao nhất: {0:N0} ({1:N1}t) | {2} | yêu cầu={3}" },

                { "MG.Status.Log.PriorityHeader", "Hỗ trợ ưu tiên" },

                { "MG.Status.Log.PriorityPasses", "Lượt ưu tiên: nâng={0:N0} | bình thường={1:N0}" },

                { "MG.Status.Log.PriorityPeakNone", "Tòa nhà nghiêm trọng đang hoạt động cao nhất: không có" },

                { "MG.Status.Log.PriorityPeakState.Pending", "đang chờ" },

                { "MG.Status.Log.PriorityPeakState.Dispatched", "đã điều xe" },

                { "MG.Status.Log.PriorityPerf", "Thời gian quét hỗ trợ ưu tiên lần cuối={0:N3} ms" },

                { "MG.Status.Log.CriticalBuildingsNone", "không có" },

                { "MG.Status.Log.CriticalBuildingLine", "- {0,-20} | {1,7:N0} ({2,4:N1}t) | {3}" },


            };
        }

        public void Unload()
        {
        }
    }
}
