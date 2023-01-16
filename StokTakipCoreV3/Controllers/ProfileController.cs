using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StokTakipCoreV3.Models;
using System.ComponentModel.DataAnnotations;
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
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            user.Name = model.appUser.Name;
            user.Surname = model.appUser.Surname;
            user.UserName = model.appUser.UserName;
            user.PhoneNumber = model.appUser.PhoneNumber;
            user.Email = model.appUser.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.password);

            var result =await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["updatemessage"] = "";
                return Redirect("/Login/Logout");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
            }
            return View();

        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            UserEditViewModel userEditViewModel = new UserEditViewModel();
            userEditViewModel.appUsers = aum.TGetList();
            return View(userEditViewModel);
        }
    }
}
