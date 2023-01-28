using Shoppie.Interfaces;
using Shoppie.Generators;
using Shoppie.Repositories;
using Shoppie.Services;

namespace Shoppie
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
