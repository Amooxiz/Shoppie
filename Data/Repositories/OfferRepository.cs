using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.DataAccess.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IQueryable<Offer> GetAllOffers()
        {
            return _context.Offers;
        }
        public IQueryable<Offer> GetAllActiveOffers()
        {
            return _context.Offers.Where(o => o.IsActive && o.IsFinished != true && o.Category.IsActive == true);
        }

        public IQueryable<Offer> GetDiscountedOffers()
        {
            return _context.Offers.Where(o => o.Discount > 0 && o.IsFinished != true && o.Category.IsActive == true);
        }

        public IQueryable<Offer> GetNewOffers(int count)
        {
            return _context.Offers.Where(o => o.IsFinished != true && o.Category.IsActive == true).OrderByDescending(o => o.CreationDate).Take(count);
        }

        /*public IQueryable<Offer> GetUsersOffers(string userId)
        {
            return _context.Offers.Where(o => o.OwnerId == userId);
        }*/

        public async Task<Offer> GetOfferAsync(int? id)
        {
            return await _context.Offers.Include(o => o.Category).SingleOrDefaultAsync(o => o.Id == id);
        }

        public async Task AddOfferAsync(Offer offer)
        {
            await _context.Offers.AddAsync(offer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateOfferAsync(Offer offer)
        {
            _context.Offers.Update(offer);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteOfferAsync(Offer offer)
        {
            _context.Offers.Remove(offer);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Offer> GetOffersByCategoryId(int id)
        {
            return _context.Offers.Where(o => o.CategoryId == id);
        }
    }
}
