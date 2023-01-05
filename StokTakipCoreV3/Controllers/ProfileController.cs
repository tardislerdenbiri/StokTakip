using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StokTakipCoreV3.Models;
using System.Threading.Tasks;

namespace StokTakipCoreV3.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        AppUserManager aum = new AppUserManager(new EfAppUserDal());

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.appUser = aum.TGetByID(values.Id);
            userEditViewModel.appUserEdit=aum.TGetByID(values.Id);
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> ProfilDuzenle(UserEditViewModel p)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = p.appUserEdit.Name;
            user.Surname = p.appUserEdit.Surname;
            user.UserName = p.appUserEdit.UserName;
            user.Email = p.appUserEdit.Email;
            user.PhoneNumber = p.appUserEdit.PhoneNumber;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.password);
            var result =await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            TempData["SiparisGuncelle"] = "";
            return RedirectToAction("Index");

        }
    }
}
