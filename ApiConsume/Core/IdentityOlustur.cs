using Core.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public class IdentityOlustur
    {
        public static void OlusturAdmin(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            AppUser appUser = new AppUser
            {
                Name = "İlk Kullanıcı",
                UserName = "ada",

            };
            AppRole role = new AppRole
            {
                Name = "Admin"
            };
            if (userManager.FindByNameAsync("ada").Result == null)
            {
                var identityResult = userManager.CreateAsync(appUser, "1").Result;
            }
            if (roleManager.FindByNameAsync("Admin").Result == null)
            {

                var identityResult = roleManager.CreateAsync(role).Result;
                var result = userManager.AddToRoleAsync(appUser, role.Name).Result;
            }
        }
    }
}
