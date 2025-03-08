using HoloCart.Data.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HoloCart.Infrastructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new ApplicationUser()
                {

                    UserName = "admin",
                    Email = "admin@gmail.com",
                    FullName = "Hamza",
                    PhoneNumber = "01234564567",
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(defaultuser, "QwE123!@#");
                await _userManager.AddToRoleAsync(defaultuser, "Admin");
            }
        }
    }
}

