using Microsoft.AspNetCore.Identity;
using Microsoft.Identity.Client;
using Shoppie.Business.Seeders.Enums;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Seeders
{
    public static class DataSeeder
    {
        public static async Task Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(Roles.Administrator.ToString()))
            {
                var role = new IdentityRole
                {
                    Name = Roles.Administrator.ToString()
                };
                
                var result = await roleManager.CreateAsync(role);

                if (!result.Succeeded)
                {
                    throw new Exception();
                }

            }

            if (! await roleManager.RoleExistsAsync(Roles.BasicUser.ToString()))
            {
                var role = new IdentityRole
                {
                    Name = Roles.BasicUser.ToString()
                };

                var result = await roleManager.CreateAsync(role);

                if(!result.Succeeded)
                {
                    throw new Exception();
                }
            }
        }
        private static async Task SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result is null)
            {
                var user = new AppUser
                {
                    UserName = "admin@admin.com",
                    Email = "admin@admin.com",
                    LastName = "admin",
                    Name = "admin",
                    IsAdmin = true,
                    Address = new Address
                    {
                        ApartamentNr = 0,
                        BuildingNr = "not specified",
                        City = "not specified",
                        Country = "not specified",
                        PostalCode = "not specified",
                        Street = "not specified"
                    }
                };

                var result = await userManager.CreateAsync(user, "Password123.");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, Roles.Administrator.ToString());
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    await userManager.ConfirmEmailAsync(user, token);
                }
            }
        }
    }
}
