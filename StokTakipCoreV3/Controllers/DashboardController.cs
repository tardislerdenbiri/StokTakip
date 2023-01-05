using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StokTakipCoreV3.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StokTakipCoreV3.Controllers
{
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        CompanyManager cm = new CompanyManager(new EfCompanyDal());
        OrderManager om = new OrderManager(new EfOrderDal());
        StokManager sm = new StokManager(new EfStokDal());
        WebConfigManager wcm = new WebConfigManager(new EfWebConfigDal());

        public DashboardController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var uservalue = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userName = uservalue.Name + " " + uservalue.Surname;

            DashboardViewModel dashboardViewModel = new DashboardViewModel();
            dashboardViewModel.Companies = cm.TGetList();
            dashboardViewModel.Orders = om.TGetList();
            dashboardViewModel.Stoks = sm.TGetList();
            dashboardViewModel.webConfig = wcm.TGetByID(1);

            return View(dashboardViewModel);
        }
        public IActionResult YoneticiNotGuncelle(WebConfig webConfig)
        {
            var value = wcm.TGetID(webConfig.OptionID);
            value.OptionName = webConfig.OptionName;
            wcm.TUpdate(value);
            TempData["SistemNotuGuncellendi"] = "";
            return RedirectToAction("Index");
        }
    }
}
