namespace Shoppie.RolesSeed
{
    public static class DataSeeder
    {
        public static void Seed(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }

        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if(!roleManager.RoleExistsAsync(Roles.Administrator.ToString()).Result)
            {
                var role = new IdentityRole
                {
                    Name = Roles.Administrator.ToString()
                };

                var result = roleManager.CreateAsync(role).Result;
            }
            
            if (!roleManager.RoleExistsAsync(Roles.BasicUser.ToString()).Result)
            {
                var role = new IdentityRole
                {
                    Name = Roles.BasicUser.ToString()
                };

                var result = roleManager.CreateAsync(role).Result;
            }
        }
        private static void SeedUsers(UserManager<AppUser> userManager)
        {
            if (userManager.FindByEmailAsync("admin@admin.com").Result is null)
            {
                var user = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@admin.com",
                    LastName = "admin",
                    Name = "admin",
                    isAdmin = true,
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

                var result = userManager.CreateAsync(user, "Password123.").Result;

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, Roles.Administrator.ToString()).Wait();
                }
            }
        }
    }
}
