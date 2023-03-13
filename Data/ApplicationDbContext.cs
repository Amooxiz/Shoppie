using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Shoppie.DataAccess.DbSeeder;
using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<AppUser> AppUsers { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Offer> Offers { get; set; }
    public DbSet<Cart> ShoppingCart { get; set; }
    public DbSet<CartItem> ShoppingCartItems { get; set; }


    protected override void OnModelCreating(ModelBuilder builder)
    {
        new CategoryEntitySeed().Configure(builder.Entity<Category>());
        new OfferEntitySeed().Configure(builder.Entity<Offer>());

        base.OnModelCreating(builder);
    }
}

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var connectionString = configuration.GetConnectionString("ApplicationDbContextConnection");

        builder.UseSqlServer(connectionString);

        return new ApplicationDbContext(builder.Options);
    }
}