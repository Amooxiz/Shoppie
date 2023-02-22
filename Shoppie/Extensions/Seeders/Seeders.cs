using Shoppie.Business.Seeders;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Extensions.Seeders
{
    public static class Seeder
    {
        public static void SeedDatabase(this WebApplication webApplication)
        {
            var scopeFactory = webApplication.Services.GetRequiredService<IServiceProvider>();

            using var scope = scopeFactory.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            DataSeeder.Seed(userManager, roleManager);
        }
    }
}
