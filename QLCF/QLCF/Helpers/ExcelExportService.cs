using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Threading.Tasks;

namespace QLCF.Helpers
{
    public static class ExcelExportService
    {
        /// <summary>
        /// Xuất báo cáo thống kê ra file Excel (.xlsx) bất đồng bộ với định dạng UX/UI ProMax.
        /// </summary>
        public static async Task<bool> ExportStatisticsToExcelAsync(
            string filePath,
            DataTable topItemsData,
            DataTable invoiceData,
            DateTime fromDate,
            DateTime toDate,
            string reportTitle,
            decimal totalRevenue,
            int totalOrders,
            int totalItems)
        {
            return await Task.Run(() =>
            {
                try
                {
                    GenerateExcelFile(filePath, topItemsData, invoiceData, fromDate, toDate, reportTitle, totalRevenue, totalOrders, totalItems);
                    return true;
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine("Excel export error: " + ex.Message);
                    throw;
                }
            });
        }

        /// <summary>
        /// Overload đơn giản tự động lấy dữ liệu từ CSDL và xuất báo cáo Excel.
        /// </summary>
        public static bool ExportReport(string filePath, DateTime fromDate, DateTime toDate)
        {
            DataTable topItemsData = null;
            DataTable invoiceData = null;
            decimal totalRevenue = 0m;
            int totalOrders = 0;
            int totalItems = 0;

            try
            {
                using (var conn = QLCF.Data.Db.CreateConnection())
                {
                    conn.Open();

                    using (var cmd = new System.Data.SqlClient.SqlCommand("sp_GetDashboardSummary", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = fromDate.Date;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = toDate.Date;
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                totalRevenue = reader["DoanhThu"] != DBNull.Value ? Convert.ToDecimal(reader["DoanhThu"]) : 0m;
                                totalOrders = reader["SoHoaDon"] != DBNull.Value ? Convert.ToInt32(reader["SoHoaDon"]) : 0;
                                totalItems = reader["TongMonDaBan"] != DBNull.Value ? Convert.ToInt32(reader["TongMonDaBan"]) : 0;
                            }
                        }
                    }

                    using (var cmd = new System.Data.SqlClient.SqlCommand("sp_TopMonBanChay", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = fromDate.Date;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = toDate.Date;
                        cmd.Parameters.Add("@Top", SqlDbType.Int).Value = 10;
                        using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            topItemsData = new DataTable();
                            adapter.Fill(topItemsData);
                        }
                    }

                    string sqlInv = @"
                        SELECT MaHD, TenBan, TenKhuVuc, GioVao, GioRa, NguoiThanhToan, TongTien, PhuongThucThanhToan
                        FROM dbo.vw_LichSuHoaDon
                        WHERE CAST(GioVao AS DATE) >= @TuNgay
                          AND CAST(GioVao AS DATE) <= @DenNgay
                          AND TrangThai = 1
                        ORDER BY GioVao DESC, MaHD DESC";

                    using (var cmd = new System.Data.SqlClient.SqlCommand(sqlInv, conn))
                    {
                        cmd.Parameters.Add("@TuNgay", SqlDbType.Date).Value = fromDate.Date;
                        cmd.Parameters.Add("@DenNgay", SqlDbType.Date).Value = toDate.Date;
                        using (var adapter = new System.Data.SqlClient.SqlDataAdapter(cmd))
                        {
                            invoiceData = new DataTable();
                            adapter.Fill(invoiceData);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("ExportReport db fetch error: " + ex.Message);
            }

            GenerateExcelFile(filePath, topItemsData, invoiceData, fromDate, toDate, "BÁO CÁO THỐNG KÊ DOANH THU & BÁN HÀNG", totalRevenue, totalOrders, totalItems);
            return true;
        }

        private static void GenerateExcelFile(
            string filePath,
            DataTable topItemsData,
            DataTable invoiceData,
            DateTime fromDate,
            DateTime toDate,
            string reportTitle,
            decimal totalRevenue,
            int totalOrders,
            int totalItems)
        {
            // Xóa file cũ nếu đã tồn tại và không bị khóa
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (ZipArchive zip = new ZipArchive(fs, ZipArchiveMode.Create, true))
                {
                    // 1. [Content_Types].xml
                    CreateZipEntry(zip, "[Content_Types].xml", GetContentTypesXml());

                    // 2. _rels/.rels
                    CreateZipEntry(zip, "_rels/.rels", GetRelsXml());

                    // 3. xl/_rels/workbook.xml.rels
                    CreateZipEntry(zip, "xl/_rels/workbook.xml.rels", GetWorkbookRelsXml());

                    // 4. xl/workbook.xml
                    CreateZipEntry(zip, "xl/workbook.xml", GetWorkbookXml());

                    // 5. xl/styles.xml
                    CreateZipEntry(zip, "xl/styles.xml", GetStylesXml());

                    // 6. xl/worksheets/sheet1.xml
                    string sheetXml = BuildWorksheetXml(topItemsData, invoiceData, fromDate, toDate, reportTitle, totalRevenue, totalOrders, totalItems);
                    CreateZipEntry(zip, "xl/worksheets/sheet1.xml", sheetXml);
                }
            }
        }

        private static void CreateZipEntry(ZipArchive zip, string entryName, string content)
        {
            ZipArchiveEntry entry = zip.CreateEntry(entryName, CompressionLevel.Optimal);
            using (StreamWriter writer = new StreamWriter(entry.Open(), Encoding.UTF8))
            {
                writer.Write(content);
            }
        }

        private static string GetContentTypesXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Types xmlns=""http://schemas.openxmlformats.org/package/2006/content-types"">
  <Default Extension=""rels"" ContentType=""application/vnd.openxmlformats-package.relationships+xml""/>
  <Default Extension=""xml"" ContentType=""application/xml""/>
  <Override PartName=""/xl/workbook.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml""/>
  <Override PartName=""/xl/worksheets/sheet1.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml""/>
  <Override PartName=""/xl/styles.xml"" ContentType=""application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml""/>
</Types>";
        }

        private static string GetRelsXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument"" Target=""xl/workbook.xml""/>
</Relationships>";
        }

        private static string GetWorkbookRelsXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<Relationships xmlns=""http://schemas.openxmlformats.org/package/2006/relationships"">
  <Relationship Id=""rId1"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet"" Target=""worksheets/sheet1.xml""/>
  <Relationship Id=""rId2"" Type=""http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles"" Target=""styles.xml""/>
</Relationships>";
        }

        private static string GetWorkbookXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<workbook xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"">
  <sheets>
    <sheet name=""ThongKeDoanhThu"" sheetId=""1"" r:id=""rId1""/>
  </sheets>
</workbook>";
        }

        private static string GetStylesXml()
        {
            return @"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>
<styleSheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"">
  <numFmts count=""4"">
    <numFmt numFmtId=""164"" formatCode=""#,##0 &quot;₫&quot;""/>
    <numFmt numFmtId=""165"" formatCode=""#,##0""/>
    <numFmt numFmtId=""166"" formatCode=""dd/mm/yyyy""/>
    <numFmt numFmtId=""167"" formatCode=""dd/mm/yyyy hh:mm""/>
  </numFmts>
  <fonts count=""8"">
    <font><sz val=""11""/><color rgb=""FF000000""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""10""/><color rgb=""FF64748B""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""16""/><color rgb=""FF1E293B""/><name val=""Segoe UI""/></font>
    <font><i/><sz val=""10""/><color rgb=""FF64748B""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""11""/><color rgb=""FFFFFFFF""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""11""/><color rgb=""FF065F46""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""10""/><color rgb=""FF334155""/><name val=""Segoe UI""/></font>
    <font><b/><sz val=""14""/><color rgb=""FF0F172A""/><name val=""Segoe UI""/></font>
  </fonts>
  <fills count=""6"">
    <fill><patternFill patternType=""none""/></fill>
    <fill><patternFill patternType=""gray125""/></fill>
    <fill><patternFill patternType=""solid""><fgColor rgb=""FF1E293B""/><bgColor indexed=""64""/></patternFill></fill>
    <fill><patternFill patternType=""solid""><fgColor rgb=""FFDCFCE7""/><bgColor indexed=""64""/></patternFill></fill>
    <fill><patternFill patternType=""solid""><fgColor rgb=""FFF8FAFC""/><bgColor indexed=""64""/></patternFill></fill>
    <fill><patternFill patternType=""solid""><fgColor rgb=""FFF1F5F9""/><bgColor indexed=""64""/></patternFill></fill>
  </fills>
  <borders count=""3"">
    <border><left/><right/><top/><bottom/><diagonal/></border>
    <border>
      <left style=""thin""><color rgb=""FFE2E8F0""/></left>
      <right style=""thin""><color rgb=""FFE2E8F0""/></right>
      <top style=""thin""><color rgb=""FFE2E8F0""/></top>
      <bottom style=""thin""><color rgb=""FFE2E8F0""/></bottom>
    </border>
    <border>
      <left style=""thin""><color rgb=""FFE2E8F0""/></left>
      <right style=""thin""><color rgb=""FFE2E8F0""/></right>
      <top style=""thin""><color rgb=""FF10B981""/></top>
      <bottom style=""double""><color rgb=""FF065F46""/></bottom>
    </border>
  </borders>
  <cellStyleXfs count=""1"">
    <xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0""/>
  </cellStyleXfs>
  <cellXfs count=""21"">
    <xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""0"" xfId=""0""/>
    <xf numFmtId=""0"" fontId=""2"" fillId=""0"" borderId=""0"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""3"" fillId=""0"" borderId=""0"" xfId=""0""><alignment horizontal=""left"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""1"" fillId=""0"" borderId=""0"" xfId=""0""><alignment horizontal=""left"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""6"" fillId=""5"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""165"" fontId=""7"" fillId=""5"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""164"" fontId=""7"" fillId=""5"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""4"" fillId=""2"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center"" wrapText=""1""/></xf>
    <xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""1"" xfId=""0""><alignment horizontal=""left"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""0"" fillId=""4"" borderId=""1"" xfId=""0""><alignment horizontal=""left"" vertical=""center""/></xf>
    <xf numFmtId=""165"" fontId=""0"" fillId=""0"" borderId=""1"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""165"" fontId=""0"" fillId=""4"" borderId=""1"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""164"" fontId=""0"" fillId=""0"" borderId=""1"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""164"" fontId=""0"" fillId=""4"" borderId=""1"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""167"" fontId=""0"" fillId=""0"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""167"" fontId=""0"" fillId=""4"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""5"" fillId=""3"" borderId=""2"" xfId=""0""><alignment horizontal=""left"" vertical=""center""/></xf>
    <xf numFmtId=""165"" fontId=""5"" fillId=""3"" borderId=""2"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""164"" fontId=""5"" fillId=""3"" borderId=""2"" xfId=""0""><alignment horizontal=""right"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""0"" fillId=""0"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
    <xf numFmtId=""0"" fontId=""0"" fillId=""4"" borderId=""1"" xfId=""0""><alignment horizontal=""center"" vertical=""center""/></xf>
  </cellXfs>
</styleSheet>";
        }

        private static string BuildWorksheetXml(
            DataTable topItemsData,
            DataTable invoiceData,
            DateTime fromDate,
            DateTime toDate,
            string reportTitle,
            decimal totalRevenue,
            int totalOrders,
            int totalItems)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""UTF-8"" standalone=""yes""?>");
            sb.AppendLine(@"<worksheet xmlns=""http://schemas.openxmlformats.org/spreadsheetml/2006/main"" xmlns:r=""http://schemas.openxmlformats.org/officeDocument/2006/relationships"">");

            // Gridlines enabled
            sb.AppendLine(@"  <sheetViews>");
            sb.AppendLine(@"    <sheetView tabSelected=""1"" workbookViewId=""0"" showGridLines=""1""/>");
            sb.AppendLine(@"  </sheetViews>");
            sb.AppendLine(@"  <sheetFormatPr defaultRowHeight=""22""/>");

            // Column Widths
            sb.AppendLine(@"  <cols>");
            sb.AppendLine(@"    <col min=""1"" max=""1"" width=""8"" customWidth=""1""/>");   // A: STT / MaHD
            sb.AppendLine(@"    <col min=""2"" max=""2"" width=""28"" customWidth=""1""/>");  // B: TenMon / TenBan
            sb.AppendLine(@"    <col min=""3"" max=""3"" width=""22"" customWidth=""1""/>");  // C: SoLuong / KhuVuc
            sb.AppendLine(@"    <col min=""4"" max=""4"" width=""22"" customWidth=""1""/>");  // D: DoanhThu / GioVao
            sb.AppendLine(@"    <col min=""5"" max=""5"" width=""22"" customWidth=""1""/>");  // E: GioRa / NguoiMo
            sb.AppendLine(@"    <col min=""6"" max=""6"" width=""22"" customWidth=""1""/>");  // F: NguoiThanhToan
            sb.AppendLine(@"    <col min=""7"" max=""7"" width=""20"" customWidth=""1""/>");  // G: TongTien
            sb.AppendLine(@"    <col min=""8"" max=""8"" width=""18"" customWidth=""1""/>");  // H: PhuongThucTT
            sb.AppendLine(@"  </cols>");

            sb.AppendLine(@"  <sheetData>");

            // Row 1: Company Name
            sb.AppendLine(@"    <row r=""1"" ht=""20"">");
            sb.AppendLine(CreateStringCell("A1", "QUÁN CAFÉ QLCF - BÁO CÁO QUẢN TRỊ", 3));
            sb.AppendLine(@"    </row>");

            // Row 2: Title
            sb.AppendLine(@"    <row r=""2"" ht=""30"">");
            string titleText = string.IsNullOrEmpty(reportTitle) ? "BÁO CÁO THỐNG KÊ DOANH THU & BÁN HÀNG" : reportTitle.ToUpper();
            sb.AppendLine(CreateStringCell("A2", titleText, 1));
            sb.AppendLine(@"    </row>");

            // Row 3: Subtitle
            sb.AppendLine(@"    <row r=""3"" ht=""20"">");
            string subtitle = $"Thời gian: {fromDate:dd/MM/yyyy} - {toDate:dd/MM/yyyy} | Ngày xuất: {DateTime.Now:dd/MM/yyyy HH:mm}";
            sb.AppendLine(CreateStringCell("A3", subtitle, 2));
            sb.AppendLine(@"    </row>");

            // Row 4: Spacer

            // Row 5: KPI Card Labels (A5:B5, C5:D5, E5:F5)
            sb.AppendLine(@"    <row r=""5"" ht=""22"">");
            sb.AppendLine(CreateStringCell("A5", "💵 TỔNG DOANH THU", 4));
            sb.AppendLine(CreateStringCell("B5", "", 4));
            sb.AppendLine(CreateStringCell("C5", "🧾 SỐ HÓA ĐƠN", 4));
            sb.AppendLine(CreateStringCell("D5", "", 4));
            sb.AppendLine(CreateStringCell("E5", "☕ TỔNG MÓN ĐÃ BÁN", 4));
            sb.AppendLine(CreateStringCell("F5", "", 4));
            sb.AppendLine(@"    </row>");

            // Row 6: KPI Card Values (A6:B6, C6:D6, E6:F6)
            sb.AppendLine(@"    <row r=""6"" ht=""32"">");
            sb.AppendLine(CreateNumberCell("A6", Convert.ToDouble(totalRevenue), 6));
            sb.AppendLine(CreateStringCell("B6", "", 6));
            sb.AppendLine(CreateNumberCell("C6", totalOrders, 5));
            sb.AppendLine(CreateStringCell("D6", "", 5));
            sb.AppendLine(CreateNumberCell("E6", totalItems, 5));
            sb.AppendLine(CreateStringCell("F6", "", 5));
            sb.AppendLine(@"    </row>");

            // Row 7: Spacer

            // Section 1: Top món bán chạy
            int currentRow = 8;
            sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"24\">");
            sb.AppendLine(CreateStringCell($"A{currentRow}", "🏆 TOP MÓN BÁN CHẠY NHẤT", 16));
            sb.AppendLine(@"    </row>");

            currentRow = 9;
            sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"26\">");
            sb.AppendLine(CreateStringCell($"A{currentRow}", "STT", 7));
            sb.AppendLine(CreateStringCell($"B{currentRow}", "Tên món ăn / Đồ uống", 7));
            sb.AppendLine(CreateStringCell($"C{currentRow}", "Tổng số lượng bán", 7));
            sb.AppendLine(CreateStringCell($"D{currentRow}", "Doanh thu (VNĐ)", 7));
            sb.AppendLine(@"    </row>");

            int topStartRow = 10;
            int topEndRow = topStartRow;

            if (topItemsData != null && topItemsData.Rows.Count > 0)
            {
                int stt = 1;
                foreach (DataRow dr in topItemsData.Rows)
                {
                    currentRow = topStartRow + stt - 1;
                    topEndRow = currentRow;
                    bool isOdd = (stt % 2 != 0);

                    string tenMon = dr.Table.Columns.Contains("TenMon") && dr["TenMon"] != DBNull.Value ? dr["TenMon"].ToString() : "";
                    double soLuong = dr.Table.Columns.Contains("TongSoLuong") && dr["TongSoLuong"] != DBNull.Value ? Convert.ToDouble(dr["TongSoLuong"]) : 0;
                    double doanhThu = dr.Table.Columns.Contains("DoanhThu") && dr["DoanhThu"] != DBNull.Value ? Convert.ToDouble(dr["DoanhThu"]) : 0;

                    int styleCenter = isOdd ? 20 : 19;
                    int styleText = isOdd ? 9 : 8;
                    int styleNum = isOdd ? 11 : 10;
                    int styleCurr = isOdd ? 13 : 12;

                    sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"22\">");
                    sb.AppendLine(CreateNumberCell($"A{currentRow}", stt, styleCenter));
                    sb.AppendLine(CreateStringCell($"B{currentRow}", tenMon, styleText));
                    sb.AppendLine(CreateNumberCell($"C{currentRow}", soLuong, styleNum));
                    sb.AppendLine(CreateNumberCell($"D{currentRow}", doanhThu, styleCurr));
                    sb.AppendLine(@"    </row>");

                    stt++;
                }
            }
            else
            {
                currentRow = 10;
                topEndRow = 10;
                sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"22\">");
                sb.AppendLine(CreateStringCell($"A{currentRow}", "-", 19));
                sb.AppendLine(CreateStringCell($"B{currentRow}", "Chưa có dữ liệu món bán trong kỳ", 8));
                sb.AppendLine(CreateNumberCell($"C{currentRow}", 0, 10));
                sb.AppendLine(CreateNumberCell($"D{currentRow}", 0, 12));
                sb.AppendLine(@"    </row>");
            }

            // Summary Row for Top Mon
            currentRow++;
            int summaryTopRow = currentRow;
            sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"26\">");
            sb.AppendLine(CreateStringCell($"A{currentRow}", "TỔNG CỘNG TOP MÓN", 16));
            sb.AppendLine(CreateStringCell($"B{currentRow}", "", 16));
            sb.AppendLine(CreateFormulaCell($"C{currentRow}", $"SUM(C{topStartRow}:C{topEndRow})", 17));
            sb.AppendLine(CreateFormulaCell($"D{currentRow}", $"SUM(D{topStartRow}:D{topEndRow})", 18));
            sb.AppendLine(@"    </row>");

            // Spacer
            currentRow += 2;

            // Section 2: Detailed Invoices (if provided)
            if (invoiceData != null && invoiceData.Rows.Count > 0)
            {
                sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"24\">");
                sb.AppendLine(CreateStringCell($"A{currentRow}", "📋 CHI TIẾT LỊCH SỬ GIAO DỊCH HÓA ĐƠN", 16));
                sb.AppendLine(@"    </row>");

                currentRow++;
                sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"26\">");
                sb.AppendLine(CreateStringCell($"A{currentRow}", "Mã HD", 7));
                sb.AppendLine(CreateStringCell($"B{currentRow}", "Tên bàn", 7));
                sb.AppendLine(CreateStringCell($"C{currentRow}", "Khu vực", 7));
                sb.AppendLine(CreateStringCell($"D{currentRow}", "Giờ vào", 7));
                sb.AppendLine(CreateStringCell($"E{currentRow}", "Giờ ra", 7));
                sb.AppendLine(CreateStringCell($"F{currentRow}", "Người thanh toán", 7));
                sb.AppendLine(CreateStringCell($"G{currentRow}", "Thành tiền (VNĐ)", 7));
                sb.AppendLine(CreateStringCell($"H{currentRow}", "Phương thức TT", 7));
                sb.AppendLine(@"    </row>");

                int invStartRow = currentRow + 1;
                int invEndRow = invStartRow;
                int count = 0;

                foreach (DataRow dr in invoiceData.Rows)
                {
                    count++;
                    currentRow = invStartRow + count - 1;
                    invEndRow = currentRow;
                    bool isOdd = (count % 2 != 0);

                    string maHD = dr.Table.Columns.Contains("MaHDText") ? dr["MaHDText"].ToString() : (dr.Table.Columns.Contains("MaHD") ? "HD" + Convert.ToInt32(dr["MaHD"]).ToString("D5") : "");
                    string tenBan = dr.Table.Columns.Contains("TenBan") ? dr["TenBan"].ToString() : "";
                    string tenKhuVuc = dr.Table.Columns.Contains("TenKhuVuc") ? dr["TenKhuVuc"].ToString() : "";
                    string gioVao = dr.Table.Columns.Contains("GioVaoFormatted") ? dr["GioVaoFormatted"].ToString() : (dr.Table.Columns.Contains("GioVao") && dr["GioVao"] != DBNull.Value ? Convert.ToDateTime(dr["GioVao"]).ToString("dd/MM/yyyy HH:mm") : "");
                    string gioRa = dr.Table.Columns.Contains("GioRaFormatted") ? dr["GioRaFormatted"].ToString() : (dr.Table.Columns.Contains("GioRa") && dr["GioRa"] != DBNull.Value ? Convert.ToDateTime(dr["GioRa"]).ToString("dd/MM/yyyy HH:mm") : "");
                    string nguoiTT = dr.Table.Columns.Contains("NguoiThanhToan") ? dr["NguoiThanhToan"].ToString() : "";
                    double tongTien = dr.Table.Columns.Contains("TongTien") && dr["TongTien"] != DBNull.Value ? Convert.ToDouble(dr["TongTien"]) : 0;
                    string ptTT = dr.Table.Columns.Contains("PhuongThucThanhToan") ? dr["PhuongThucThanhToan"].ToString() : "";

                    int styleCenter = isOdd ? 20 : 19;
                    int styleText = isOdd ? 9 : 8;
                    int styleCurr = isOdd ? 13 : 12;

                    sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"22\">");
                    sb.AppendLine(CreateStringCell($"A{currentRow}", maHD, styleCenter));
                    sb.AppendLine(CreateStringCell($"B{currentRow}", tenBan, styleText));
                    sb.AppendLine(CreateStringCell($"C{currentRow}", tenKhuVuc, styleText));
                    sb.AppendLine(CreateStringCell($"D{currentRow}", gioVao, styleCenter));
                    sb.AppendLine(CreateStringCell($"E{currentRow}", gioRa, styleCenter));
                    sb.AppendLine(CreateStringCell($"F{currentRow}", nguoiTT, styleText));
                    sb.AppendLine(CreateNumberCell($"G{currentRow}", tongTien, styleCurr));
                    sb.AppendLine(CreateStringCell($"H{currentRow}", ptTT, styleCenter));
                    sb.AppendLine(@"    </row>");
                }

                // Summary Row for Invoices
                currentRow++;
                sb.AppendLine($"    <row r=\"{currentRow}\" ht=\"26\">");
                sb.AppendLine(CreateStringCell($"A{currentRow}", "TỔNG CỘNG DOANH THU HÓA ĐƠN", 16));
                sb.AppendLine(CreateStringCell($"B{currentRow}", "", 16));
                sb.AppendLine(CreateStringCell($"C{currentRow}", "", 16));
                sb.AppendLine(CreateStringCell($"D{currentRow}", "", 16));
                sb.AppendLine(CreateStringCell($"E{currentRow}", "", 16));
                sb.AppendLine(CreateStringCell($"F{currentRow}", "", 16));
                sb.AppendLine(CreateFormulaCell($"G{currentRow}", $"SUM(G{invStartRow}:G{invEndRow})", 18));
                sb.AppendLine(CreateStringCell($"H{currentRow}", "", 16));
                sb.AppendLine(@"    </row>");
            }

            sb.AppendLine(@"  </sheetData>");

            // Merge Cells
            sb.AppendLine(@"  <mergeCells count=""6"">");
            sb.AppendLine(@"    <mergeCell ref=""A1:H1""/>");
            sb.AppendLine(@"    <mergeCell ref=""A2:H2""/>");
            sb.AppendLine(@"    <mergeCell ref=""A3:H3""/>");
            sb.AppendLine(@"    <mergeCell ref=""A5:B5""/>");
            sb.AppendLine(@"    <mergeCell ref=""A6:B6""/>");
            sb.AppendLine(@"    <mergeCell ref=""C5:D5""/>");
            sb.AppendLine(@"    <mergeCell ref=""C6:D6""/>");
            sb.AppendLine(@"    <mergeCell ref=""E5:F5""/>");
            sb.AppendLine(@"    <mergeCell ref=""E6:F6""/>");
            sb.AppendLine(@"  </mergeCells>");

            sb.AppendLine(@"</worksheet>");

            return sb.ToString();
        }

        private static string CreateStringCell(string cellRef, string text, int styleIndex)
        {
            string safeText = System.Security.SecurityElement.Escape(text ?? "");
            return $"      <c r=\"{cellRef}\" s=\"{styleIndex}\" t=\"inlineStr\"><is><t>{safeText}</t></is></c>";
        }

        private static string CreateNumberCell(string cellRef, double value, int styleIndex)
        {
            return $"      <c r=\"{cellRef}\" s=\"{styleIndex}\"><v>{value.ToString(System.Globalization.CultureInfo.InvariantCulture)}</v></c>";
        }

        private static string CreateFormulaCell(string cellRef, string formula, int styleIndex)
        {
            return $"      <c r=\"{cellRef}\" s=\"{styleIndex}\"><f>{formula}</f></c>";
        }
    }
}
