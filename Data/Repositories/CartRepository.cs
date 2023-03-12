using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.DataAccess.Repositories
{
    public class CartRepository : ICartRepository
    {
        public async Task<Cart> GetCartAsync(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
