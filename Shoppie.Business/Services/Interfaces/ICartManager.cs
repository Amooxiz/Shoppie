using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICartManager
    {
        Task AddToCartAsync(int offerId);
        Task RemoveFromCartAsync();
        Task<Cart?> GetCartAsync();
        Task CreateCartAsync(string userId, bool IsAuthenthicated);
    }
}
