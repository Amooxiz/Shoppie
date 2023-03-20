using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<List<OfferVM>> GetAllOffersAsync();
        Task<List<OfferVM>> GetOffersByCategoryIdAsync(int id);
        Task<List<OfferVM>> GetNewOffersAsync(int count);
        Task<List<OfferVM>> GetDiscountedOffersAsync();
        Task<List<OfferVM>> GetAllActiveOffersAsync();
        /*        Task<List<OfferVM>> GetUsersOffers(string userId);*/
        Task<OfferVM> GetOfferAsync(int? id);
        Task AddOfferAsync(OfferVM offer);
        Task UpdateOfferAsync(OfferVM offer);
        Task DeleteOfferAsync(int id);
    }
}
