using Microsoft.AspNetCore.Mvc;

namespace StokTakipCoreV3.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error(int code)
        {
            return View();
        }
    }
}
