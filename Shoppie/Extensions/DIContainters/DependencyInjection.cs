using Shoppie.Business.Generators;
using Shoppie.Business.Generators.Interfaces;
using Shoppie.Business.Services;
using Shoppie.Business.Services.Interfaces;
using Shoppie.DataAccess.Repositories;
using Shoppie.DataAccess.Repositories.Interfaces;

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
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddScoped<ICartManager, CartManager>();
            services.AddScoped<IImageService, ImageService>();
            services.AddHttpClient<INBPIntegratorService, NBPIntegratorService>(client =>
            {
                client.BaseAddress = new Uri("http://api.nbp.pl/api/exchangerates/rates/A/");
            });
            return services;
        }
    }
}
