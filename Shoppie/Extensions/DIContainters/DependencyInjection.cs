using Shoppie.DataAccess.Repositories;
using Shoppie.DataAccess.Repositories.Interfaces;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.Generators.Interfaces;
using Shoppie.Business.Services;
using Shoppie.Business.Generators;
using Shoppie.Business.Seeders;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Extensions.DIContainters
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddProjectService(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IOfferRepository, OfferRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IPdfGenerator, PdfGenerator>();
            services.AddTransient<INBPIntegratorService, NBPIntegratorService>();
            services.AddTransient<ICookieService, CookieService>();
            return services;
        }
    }
}
