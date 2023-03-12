using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Cart?> GetCart(string userId)
        {
            return await _context.ShoppingCart.
                FirstOrDefaultAsync( c => ( c.AuthenticatedCartOwnerId == userId
                || c.AnnoynymousCartOwnerId == userId ) && !c.IsFinished);
        }   
        public async Task AddToCart(Cart cart)
        {
            _context.Update(cart);
            await _context.SaveChangesAsync();            
        }

    }
}
