using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResitalTurizmWEB.UI.Identity
{
    public static class SeedIdentity
    {
        //IConfiguration kullanarak, appsettings.json dosyasına erişip oraya girdiğimiz bilgileri alabiliriz.
        //Bu seed metodu admin kullanıcısı olusturmak icin. Startup class'ına ekleme yaptım
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            var username = configuration["Data:AdminUser:username"];
            var email = configuration["Data:AdminUser:email"];
            var password = configuration["Data:AdminUser:password"];
            var role = configuration["Data:AdminUser:role"];

            if (await userManager.FindByNameAsync(username)==null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User()
                {
                    UserName = username,
                    Email = email,
                    FirstName = "admin",
                    LastName = "admin",
                };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }
    }
}
