using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.DbSeeder
{
    internal class CategoryEntitySeed : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {

            builder.HasData(
                new Category { Id = 1, IsActive = true, Name = "Garden" },
                new Category { Id = 2, IsActive = true, Name = "School" },
                new Category { Id = 3, IsActive = true, Name = "Car" },
                new Category { Id = 4, IsActive = true, Name = "Food" },
                new Category { Id = 5, IsActive = true, Name = "Garment" },
                new Category { Id = 6, IsActive = true, Name = "Gaming" }
                );
        }
    }
    internal class OfferEntitySeed : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasData(
            new Offer { Id = 1, Title = "Mocna Łopata", Description = "Stworzona do kopania dziur", Price = 10, IsActive = true, IsFinished = false, Discount = 0, CreationDate = DateTime.Now.AddDays(-10), CategoryId = 1, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 2, Title = "Fajny Piórnik", Description = "Wejddzie tam bardzo duzo długpoisów", Price = 250, IsActive = true, IsFinished = false, Discount = 0, CreationDate = DateTime.Now.AddDays(-7), CategoryId = 2, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 3, Title = "Niebieska bluza", Description = "Bardzo wygodna i elegancka", Price = 300, IsActive = true, IsFinished = false, Discount = 0, CreationDate = DateTime.Now.AddDays(-6), CategoryId = 5, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 4, Title = "Odżywka białkowa", Description = "Idealna na mocnego bulka", Price = 430, IsActive = true, IsFinished = false, Discount = 30, CreationDate = DateTime.Now.AddDays(-7), CategoryId = 4, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 5, Title = "GTA V", Description = "Super gierka od Rockstar", Price = 24, IsActive = true, IsFinished = false, Discount = 40, CreationDate = DateTime.Now.AddDays(-3), CategoryId = 6, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 6, Title = "Opony Zimowe", Description = "Zapewniają świetną przyczepność", Price = 41, IsActive = true, IsFinished = false, Discount = 10, CreationDate = DateTime.Now.AddDays(-2), CategoryId = 3, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 7, Title = "Dmuchawa do liści", Description = "Idealnie nada się do twojego ogrodu", Price = 15, IsActive = true, IsFinished = false, Discount = 15, CreationDate = DateTime.Now.AddDays(-1), CategoryId = 1, ImagePath = $"/Images/1.jpg" },
            new Offer { Id = 8, Title = "Plecak", Description = "Plecak, który pomieści dużo przedmiotów", Price = 32, IsActive = true, IsFinished = false, Discount = 33, CreationDate = DateTime.Now.AddDays(-5), CategoryId = 2, ImagePath = $"/Images/1.jpg" }
        );
        }
    }
}
