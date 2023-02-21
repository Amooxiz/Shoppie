using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<List<OfferVM>> GetAllOffers();
        Task<List<OfferVM>> GetOffersByCategoryId(int id);
        Task<List<OfferVM>> GetNewOffers(int count);
        Task<List<OfferVM>> GetDiscountedOffers();
        Task<List<OfferVM>> GetAllActiveOffers();
        /*        Task<List<OfferVM>> GetUsersOffers(string userId);*/
        OfferVM GetOffer(int? id);
        void AddOffer(Offer offer);
        void UpdateOffer(OfferVM offer);
        void DeleteOffer(int id);
    }
}
