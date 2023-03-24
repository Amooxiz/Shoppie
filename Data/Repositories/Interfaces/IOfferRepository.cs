using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface IOfferRepository
    {
        IQueryable<Offer> GetAllOffers();
        IQueryable<Offer> GetOffersByCategoryId(int id);
        IQueryable<Offer> GetNewOffers(int count);
        IQueryable<Offer> GetDiscountedOffers();
        IQueryable<Offer> GetAllActiveOffers();
        (IQueryable<Offer>, int) GetAllOffersPaginated(int pageNumber, int pageSize);
        (IQueryable<Offer>, int) GetDiscountedOffersPaginated(int pageNumber, int pageSize);
        (IQueryable<Offer>, int) GetNewOffersPaginated(int pageNumber, int pageSize, int count);
        /*IQueryable<Offer> GetUsersOffers(string userId);*/
        Task<Offer> GetOfferAsync(int? id);
        Task AddOfferAsync(Offer offer);
        Task UpdateOfferAsync(Offer offer);
        Task DeleteOfferAsync(Offer offer);
    }
}