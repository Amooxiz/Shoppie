using Shoppie.ViewModels;

namespace Shoppie.Extensions;
public static class OfferModelExtensions
{
    public static IQueryable<OfferVM> ToModel(this IQueryable<Offer> source)
    {
        return source.Select(o => new OfferVM
        {
            Id = o.Id,
            Title = o.Title,
            Description = o.Description,
            IsActive = o.IsActive,
            IsFinished = o.IsFinished,
            Price = o.Price,
            CategoryName = o.Category.Name,
            CreationDate = o.CreationDate,
            Discount = o.Discount,
            CategoryId = o.CategoryId,
        });
    }
}

public static class CategoryModelExtensions
{
    public static IQueryable<CategoryVM> ToModel(this IQueryable<Category> source)
    {
        return source.Select(c => new CategoryVM
        {
            Id = c.Id,
            Name = c.Name,
            IsActive = c.IsActive,
        });
    }
}