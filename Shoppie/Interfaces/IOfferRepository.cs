using System.Drawing;

namespace Shoppie.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        IQueryable<Offer> GetNewOffers(int count);
        IQueryable<Offer> GetDiscountedOffers();
        IQueryable<Offer> GetAllActiveOffers();
        IQueryable<Offer> GetUsersOffers(string userId);
    }
}