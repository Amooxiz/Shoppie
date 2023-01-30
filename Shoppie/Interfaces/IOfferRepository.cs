using System.Drawing;

namespace Shoppie.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        IQueryable<Offer> GetOffersByCategoryId(int id);
        IQueryable<Offer> GetNewOffers(int count);
        IQueryable<Offer> GetDiscountedOffers();
        IQueryable<Offer> GetAllActiveOffers();
        /*IQueryable<Offer> GetUsersOffers(string userId);*/
        Offer GetOffer(int? id);
        void AddOffer(Offer offer);
        void UpdateOffer(Offer offer);
        void DeleteOffer(Offer offer);
    }
}