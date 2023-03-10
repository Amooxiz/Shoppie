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
        Task<OfferVM> GetOffer(int? id);
        Task AddOffer(Offer offer);
        Task UpdateOffer(OfferVM offer);
        Task DeleteOffer(int id);
    }
}
