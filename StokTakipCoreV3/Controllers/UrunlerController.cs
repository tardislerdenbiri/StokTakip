using BusinessLayer.Concrete;
using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StokTakipCoreV3.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StokTakipCoreV3.Controllers
{
    public class UrunlerController : Controller
    {
        ProductsManager pm = new ProductsManager(new EfProductsDal());
        StokManager sm = new StokManager(new EfStokDal());
        StoresManager storm = new StoresManager(new EfStoresDal());

        public IActionResult Index()
        {
            ProductsAndStokView productsAndStokView = new ProductsAndStokView();
            productsAndStokView.Productss = pm.TGetList();
            productsAndStokView.Stoks = sm.TGetList();
            return View(productsAndStokView);
        }
        [HttpPost]
        public IActionResult UrunEkle(Products products)
        {
            pm.TAdd(products);
            TempData["UrunEkle"] = "";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UrunDuzenle(Products products)
        {
            pm.TUpdate(products);
            TempData["UrunUpdate"] = "";
            return Redirect("UrunGoruntule/" + products.ProductsID);
        }

        [HttpGet]
        public IActionResult UrunGoruntule(int id)
        {
            List<SelectListItem> depolar = (from x in storm.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.StoresName,
                                                Value = x.StoresID.ToString()
                                            }).ToList();
            ViewBag.depolar = depolar;


            ProductsAndStokView productsAndStokView = new ProductsAndStokView();
            productsAndStokView.Products = pm.TGetByID(id);
            productsAndStokView.Stoks = sm.GetUrunlerStok(id).Where(x => x.OrderID == null);



            int toplamstok = sm.GetUrunlerStok(id).Count(x => x.OrderID == null);
            ViewBag.toplamstok = toplamstok;


            //Depolardaki adeti çekmek için devamı getirilmedi burdan devam edecek
            //var depoadet = sm.GetListUrunDetayDepoAdet(1).Count(x => x.ProductsID == id);
            //ViewBag.depoadet = depoadet;

            return View(productsAndStokView);
        }

        public IActionResult UrunSil(int id)
        {
            var deletevalue = pm.TGetByID(id);
            pm.TDelete(deletevalue);
            TempData["UrunSil"] = "";
            return RedirectToAction("Index");

        }

        [HttpPost]
        public IActionResult UrunStokEkle(Stok stok, Products products, Stores stores)
        {
            Context c = new Context();
            List<string> stoksntrim = stok.StokSn.Split(new[] { '\r', '\n', ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            var stoklist = new List<Stok>();

            foreach (var sn in stoksntrim)
            {
                stoklist.Add(new Stok()
                {
                    StokSn = sn,
                    ProductsID = products.ProductsID,
                    StoresID = stores.StoresID
                });

            }
            c.Stoks.AddRange(stoklist);
            c.SaveChanges();

            TempData["UrunStokEkle"] = "";
            return Redirect("UrunGoruntule/" + products.ProductsID);
        }


        public IActionResult UrunStokSil(int id)
        {
            var deletevalue = sm.TGetByID(id);
            sm.TDelete(deletevalue);
            TempData["UrunStokSil"] = "";
            return Redirect("/Urunler/UrunGoruntule/" + deletevalue.ProductsID);
        }

        public IActionResult ExportToExcel()
        {
            var productall = pm.TGetList();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Marka";
                worksheet.Cell(currentRow, 2).Value = "Model";
                worksheet.Cell(currentRow, 3).Value = "Stok Sayısı";
                foreach (var product in productall)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = product.ProductsMarka;
                    worksheet.Cell(currentRow, 2).Value = product.ProductsModel;
                    worksheet.Cell(currentRow, 3).Value = product.Stoks.Where(x => x.ProductsID == product.ProductsID).Count();
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
                        $"{uid}.xlsx");
                }
            }
        }
    }
}
