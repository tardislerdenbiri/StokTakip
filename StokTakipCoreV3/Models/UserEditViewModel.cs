using EntityLayer.Concrete;
using System.Collections.Generic;

namespace StokTakipCoreV3.Models
{
    public class UserEditViewModel
    {
        public string password { get; set; }
        public string confirmpassword { get; set; }

        public IEnumerable<AppUser> appUsers { get; set; }
        public AppUser appUser { get; set; }

    }
}
