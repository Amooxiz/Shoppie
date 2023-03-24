using Shoppie.Business.ViewModels;

namespace Shoppie.Business.Services.Interfaces
{
    public interface IOfferService
    {
        Task<List<OfferVM>> GetAllOffersAsync();
        Task<List<OfferVM>> GetOffersByCategoryIdAsync(int id);
        Task<List<OfferVM>> GetNewOffersAsync(int count);
        Task<(List<OfferVM>, int)> GetAllOffersPaginatedAsync(int pageNumber, int pageSize);
        Task<(List<OfferVM>, int)> GetDiscountedOffersPaginatedAsync(int pageNumber, int pageSize);
        Task<(List<OfferVM>, int)> GetNewOffersPaginatedAsync(int pageNumber, int pageSize, int count);
        Task<List<OfferVM>> GetDiscountedOffersAsync();
        Task<List<OfferVM>> GetAllActiveOffersAsync();
        /*        Task<List<OfferVM>> GetUsersOffers(string userId);*/
        Task<OfferVM> GetOfferAsync(int? id);
        Task AddOfferAsync(OfferVM offer);
        Task UpdateOfferAsync(OfferVM offer);
        Task DeleteOfferAsync(int id);
    }
}
