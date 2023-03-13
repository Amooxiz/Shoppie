using Domain.Interfaces.Repos;
using Microsoft.EntityFrameworkCore;
using Shoppie.Domain.Entities;

namespace Shoppie.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly ApplicationDbContext _context;
        public OfferRepository(ApplicationDbContext context)
        {
            _context= context;
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

        public Offer GetOffer(int? id)
        {
            return _context.Offers.Include(o => o.Category).SingleOrDefault(o => o.Id == id);
        }

        public void AddOffer(Offer offer)
        {
            _context.Offers.Add(offer);
            _context.SaveChanges();
        }

        public void UpdateOffer(Offer offer)
        {
            _context.Offers.Update(offer);
            _context.SaveChanges();
        }

        public void DeleteOffer(Offer offer)
        {
            _context.Offers.Remove(offer);
            _context.SaveChanges();
        }

        public IQueryable<Offer> GetOffersByCategoryId(int id)
        {
            return _context.Offers.Where(o => o.CategoryId == id);
        }
    }
}
