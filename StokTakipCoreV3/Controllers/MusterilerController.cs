using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using StokTakipCoreV3.Models;

namespace StokTakipCoreV3.Controllers
{
    public class MusterilerController : Controller
    {
        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        OrderManager om = new OrderManager(new EfOrderDal());

        public IActionResult Index()
        {
            FirmaListAndFirmaAdd firmalist = new FirmaListAndFirmaAdd();
            firmalist.Companies = cm.TGetList();
            return View(firmalist);
        }

        [HttpPost]
        public ActionResult MusteriEkle(Company company)
        {
            cm.TAdd(company);
            TempData["MusteriEkle"] = "";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult MusteriDuzenle(Company company)
        {
            var value = cm.TGetByID(company.CompanyID);
            value.CompanyName = company.CompanyName;
            value.CompanyPhone = company.CompanyPhone;
            value.CompanyAdress= company.CompanyAdress;
            cm.TUpdate(value);
            TempData["MusteriUpdate"] = "";
            return Redirect("MusteriGoruntule/" + company.CompanyID);
        }

        public IActionResult MusteriSil(int id)
        {
            var deletevalue = cm.TGetByID(id);
            cm.TDelete(deletevalue);
            TempData["MusteriSil"] = "";
            return RedirectToAction("Index");

        }

        [HttpGet]
        public IActionResult MusteriGoruntule(int id)
        {
            FirmaAndHistoryView firmaAndHistoryView = new FirmaAndHistoryView();
            firmaAndHistoryView.Company = cm.TGetByID(id);
            firmaAndHistoryView.Orders = om.GetFirmalarHistoryView(id);
            return View(firmaAndHistoryView);
        }
        public IActionResult MusteriNotGuncelle(Company company)
        {
            var value = cm.TGetByID(company.CompanyID);
            value.CompanyNot = company.CompanyNot;
            cm.TUpdate(value);
            TempData["MusteriNotGuncellendi"] = "";
            return Redirect("MusteriGoruntule/" + value.CompanyID);
        }
    }
}
