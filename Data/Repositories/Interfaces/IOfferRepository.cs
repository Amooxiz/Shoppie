using Shoppie.DataAccess.Entities;
using System.Drawing;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        IQueryable<Offer> GetOffersByCategoryId(int id);
        IQueryable<Offer> GetNewOffers(int count);
        IQueryable<Offer> GetDiscountedOffers();
        IQueryable<Offer> GetAllActiveOffers();
        /*IQueryable<Offer> GetUsersOffers(string userId);*/
        Task<Offer> GetOffer(int? id);
        Task AddOffer(Offer offer);
        Task UpdateOffer(Offer offer);
        Task DeleteOffer(Offer offer);
    }
}