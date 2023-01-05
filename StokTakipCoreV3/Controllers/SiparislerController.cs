using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Office.Interop.Word;
using StokTakipCoreV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace StokTakipCoreV3.Controllers
{
    public class SiparislerController : Controller
    {
        OrderManager om = new OrderManager(new EfOrderDal());
        HistoryManager hm = new HistoryManager(new EfHistoryDal());
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        StokManager sm = new StokManager(new EfStokDal());


        public IActionResult Index()
        {


            List<SelectListItem> firmalar = (from x in cm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CompanyName,
                                                 Value = x.CompanyID.ToString()
                                             }).ToList();
            ViewBag.firmalist = firmalar;

            List<SelectListItem> nedenler = new List<SelectListItem>();

            nedenler.Add(new SelectListItem { Text = "Satış", Value = "Satış" });
            nedenler.Add(new SelectListItem { Text = "Demo", Value = "Demo" });
            nedenler.Add(new SelectListItem { Text = "Hibe", Value = "Hibe" });

            ViewBag.nedenler = nedenler;

            OrderListAndOrderAdd orderListAndOrderAdd = new OrderListAndOrderAdd();
            orderListAndOrderAdd.Orders = om.TGetList();
            return View(orderListAndOrderAdd);
        }

        public IActionResult HSiparisGoruntule(int id)
        {
            SiparisHistory siparisHistory = new SiparisHistory();
            siparisHistory.Order = om.TGetByID(id);
            siparisHistory.Histories = hm.GetListSiparisHistoryID(id);
            return View(siparisHistory);

        }

        public IActionResult SiparisGoruntule(int id)
        {
            List<SelectListItem> firmalar = (from x in cm.TGetList()
                                             select new SelectListItem
                                             {
                                                 Text = x.CompanyName,
                                                 Value = x.CompanyID.ToString()
                                             }).ToList();
            ViewBag.firmalist = firmalar;

            List<SelectListItem> nedenler = new List<SelectListItem>();

            nedenler.Add(new SelectListItem { Text = "Satış", Value = "Satış" });
            nedenler.Add(new SelectListItem { Text = "Demo", Value = "Demo" });
            nedenler.Add(new SelectListItem { Text = "Hibe", Value = "Hibe" });

            ViewBag.nedenler = nedenler;


            SiparisView siparisView = new SiparisView();
            siparisView.Order = om.TGetByID(id);
            siparisView.OrderEdit = om.TGetByID(id);
            siparisView.Stoks = sm.GetListSiparisView(siparisView.Order.OrderID);
            return View(siparisView);

        }

        [HttpPost]
        public JsonResult SiparisEkleGetCompanyAdress(int id)
        {
            var companyadress = cm.TGetByID(id);
            return Json(companyadress.CompanyAdress);
        }

        [HttpPost]
        public ActionResult SiparisOlustur(Order order)
        {
            om.TAdd(order);
            TempData["SiparisOlustur"] = "";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SiparisNotGuncelle(Order order)
        {

            var value = om.TGetByID(order.OrderID);
            value.OrderNot = order.OrderNot;
            om.TUpdate(value);
            TempData["SiparisNotGuncelle"] = "";
            if (value.OrderDurum == true)
            {
                return Redirect("HSiparisGoruntule/" + order.OrderID);
            }
            else
            {
                return Redirect("SiparisGoruntule/" + order.OrderID);
            }

        }

        public IActionResult SiparisSil(int id)
        {
            var value = om.TGetByID(id);
            var valuestok = sm.OrderDeleteGetStokProductid(value.OrderID);
            var liststok = valuestok.ToList();
            foreach (var item in liststok)
            {
                item.OrderID = null;
                sm.TUpdate(item);
            }
            om.TDelete(value);
            TempData["SiparisSil"] = "";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult SiparisDuzenle(Order OrderEdit)
        {
            om.TUpdate(OrderEdit);
            TempData["SiparisGuncelle"] = "";
            return Redirect("SiparisGoruntule/" + OrderEdit.OrderID);
        }

        [HttpPost]
        public IActionResult SiparisUrunEkle(Order order, string StokSn)
        {
            var stoksntrim = StokSn.Split(new[] { '\r','\n', ' '},StringSplitOptions.RemoveEmptyEntries);
            foreach (string sn in stoksntrim)
            {
                var item = sm.GetStokSn(sn).FirstOrDefault();
                item.OrderID = order.OrderID;
                sm.TUpdate(item);
            }
            TempData["SiparisEklendi"] = "";
            return Redirect("SiparisGoruntule/"+order.OrderID);
        }

        public IActionResult SiparisUrunSil(int id)
        {
            var value = sm.TGetByID(id);
            var returnid = value.OrderID;
            value.OrderID = null;
            sm.TUpdate(value);
            TempData["SiparisUrunSilindi"] = "";
            return Redirect("/Siparisler/SiparisGoruntule/"+returnid);
        }

        public IActionResult ExportToExcel(Order order)
        {
            var orderid = hm.GetExcelList(order.OrderID);
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Marka";
                worksheet.Cell(currentRow, 2).Value = "Model";
                worksheet.Cell(currentRow, 3).Value = "Seri_No";
                foreach (var user in orderid)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.HistoryUrunMarka;
                    worksheet.Cell(currentRow, 2).Value = user.HistoryUrunModel;
                    worksheet.Cell(currentRow, 3).Value = user.HistoryUrunSn;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    var rand = new Random();
                    var uid = rand.Next(100000, 1000000);

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        $"{order.Company.CompanyName}-{order.OrderTarih.ToShortDateString()}-{uid}.xlsx");
                }
            }
        }
    }
}
