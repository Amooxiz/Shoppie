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
            OwnerId = o.OwnerId,
        });
    }
}