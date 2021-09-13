using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using Project.Areas.Admin.Model;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace Project.Areas.Admin.Controllers
{
    public class HistoryController : Controller
    {

        public List<HistoryBuy> getApiListHistory()
        {
            var client = new RestClient("https://localhost:44308/get-history/");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            var body = @"";
            request.AddParameter("text/plain", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            string rawResponse = response.Content;
            List<HistoryBuy> list = JsonConvert.DeserializeObject<List<HistoryBuy>>(rawResponse);
            return list;
        }

        public ActionResult Index()
        {
            List<HistoryBuy> listHistory = this.getApiListHistory();
            ViewBag.list = listHistory;
            return View();
        }



        public void Export_Excel()
        {
            List<HistoryBuy> listHistory = this.getApiListHistory();
            ExcelPackage p = new ExcelPackage();
            // đặt tên người tạo file
            p.Workbook.Properties.Author = "Nhóm 6";

            // đặt tiêu đề cho file
            p.Workbook.Properties.Title = "Báo cáo thống kê lịch sử mua hàng";

            //Tạo một sheet để làm việc trên đó
            p.Workbook.Worksheets.Add("History sheet");

            // lấy sheet vừa add ra để thao tác
            ExcelWorksheet ws = p.Workbook.Worksheets[1];

            // đặt tên cho sheet
            ws.Name = "History sheet";

            // fontsize mặc định cho cả sheet
            ws.Cells.Style.Font.Size = 11;

            // font family mặc định cho cả sheet
            ws.Cells.Style.Font.Name = "Calibri";

            // Tạo danh sách các column header
            string[] arrColumnHeader = {
                                                "STT",
                                                "ID",
                                                "Họ và tên",
                                                "Email",
                                                "Địa chỉ",
                                                "ID Sản Phẩm",
                                                "Tên Sản Phẩm",
                                                "Gía",
                                                "Số lượng mua",
                                                "Ngày Mua",
                                                "Thành Tiền"
                };
            // ố lượng cột cần dùng dựa vào số lượng header
            var countColHeader = arrColumnHeader.Count();
            // đặt tên cho cell [1 1]
            ws.Cells[1, 1].Value = "Lịch sử mua hàng";
            ws.Cells[1, 1, 1, countColHeader].Merge = true;
            // in đậm
            ws.Cells[1, 1, 1, countColHeader].Style.Font.Bold = true;
            ws.Cells[1, 1, 1, countColHeader].Style.Font.Size = 20;
            // căn giữa
            ws.Cells[1, 1, 1, countColHeader].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            var fillHeader = ws.Cells[1, 1, 1, countColHeader].Style.Fill;
            fillHeader.PatternType = ExcelFillStyle.Solid;
            fillHeader.BackgroundColor.SetColor(System.Drawing.Color.LightBlue);
            // căn khung
            var borderTitle = ws.Cells[1, 1, 1, countColHeader].Style.Border;
            borderTitle.Bottom.Style =
                borderTitle.Top.Style =
                borderTitle.Left.Style =
                borderTitle.Right.Style = ExcelBorderStyle.Thin;
            // vì hàng đầu tiên là tiêu đề nên ta phải dùng hàng thứ 2 trở đi
            int colIndex = 1;
            int rowIndex = 2;

            //tạo các header. duyệt theo cột bắt đầu từ hàng 2
            foreach (var item in arrColumnHeader)
            {
                var cell = ws.Cells[rowIndex, colIndex];
                cell.Value = item;

                //căn boder
                var border = cell.Style.Border;
                border.Bottom.Style =
                    border.Top.Style =
                    border.Left.Style =
                    border.Right.Style = ExcelBorderStyle.Thin;
                cell.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                // tăng số cột lên 
                colIndex++;
            }

            // truyen thong tin vo. bat dau tu hàng 3
            double sum = 0;
            foreach (HistoryBuy history in listHistory)
            {
                // bắt đầu ghi từ cột 1
                colIndex = 1;

                // rowIndex bắt đầu từ dòng 3
                rowIndex++;
                ws.Cells[rowIndex, colIndex++].Value = history.stt;
                ws.Cells[rowIndex, colIndex++].Value = history.id;
                ws.Cells[rowIndex, colIndex++].Value = history.fullName;
                ws.Cells[rowIndex, colIndex++].Value = history.email;
                ws.Cells[rowIndex, colIndex++].Value = history.address;
                ws.Cells[rowIndex, colIndex++].Value = history.idProduct;
                ws.Cells[rowIndex, colIndex++].Value = history.nameProduct;
                ws.Cells[rowIndex, colIndex++].Value = history.price;
                ws.Cells[rowIndex, colIndex++].Value = history.quantity;
                ws.Cells[rowIndex, colIndex++].Value = history.createAt.ToShortDateString();
                ws.Cells[rowIndex, colIndex++].Value = history.total;
                sum += history.price * history.quantity;
            }
            rowIndex++;
            ws.Cells[rowIndex, 4].Value = "Tổng thu nhập: " + sum;
            ws.Cells[rowIndex, 4, rowIndex, 5].Merge = true;
            var fill = ws.Cells[rowIndex, 4, rowIndex, 5].Style.Fill;
            fill.PatternType = ExcelFillStyle.Solid;
            fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
            ws.Cells[rowIndex, 4, rowIndex, 5].Style.Font.Bold = true;
            ws.Cells[rowIndex, 4, rowIndex, 5].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("Content-Disposition", "attachment:filename=" + "somefile.xlsx");
            Response.BinaryWrite(p.GetAsByteArray());
            Response.End();
        }
    }
}