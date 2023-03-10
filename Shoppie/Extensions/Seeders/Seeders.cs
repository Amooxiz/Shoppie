using Shoppie.Business.Seeders;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Extensions.Seeders
{
    public static class Seeder
    {
        public static async Task SeedDatabase(this WebApplication webApplication)
        {
            var scopeFactory = webApplication.Services.GetRequiredService<IServiceProvider>();

            using var scope = scopeFactory.CreateScope();

            var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = scope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            await DataSeeder.Seed(userManager, roleManager);
        }
    }
}
