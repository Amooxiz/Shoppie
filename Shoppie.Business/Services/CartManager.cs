using Microsoft.AspNetCore.Http;
using Shoppie.Business.Services.Interfaces;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;
using System.Security.Claims;

namespace Shoppie.Business.Services
{
    public class CartManager : ICartManager
    {
        private readonly IHttpContextAccessor _ctx;
        private readonly ICartRepository _cartRepository;
        public CartManager(IHttpContextAccessor ctx, ICartRepository cartRepository)
        {
            _ctx = ctx;
            _cartRepository = cartRepository;
        }
        public async Task AddToCartAsync(int offerId)
        {
            var cart = await GetCartAsync();

            cart.Items.Add(new CartItem { OfferId = offerId });

            await _cartRepository.AddToCartAsync(cart);
        }
        public async Task CreateCartAsync(string userId, bool IsAuthenthicated)
        {
            Cart cart = new Cart { };

            if (IsAuthenthicated)
                cart.AuthenticatedCartOwnerId = userId;
            else
                cart.AnnoynymousCartOwnerId = userId;

            await _cartRepository.CreateCartAsync(cart);
        }
        public async Task RemoveFromCartAsync()
        {
            throw new NotImplementedException();
        }
        public async Task<Cart?> GetCartAsync()
        {
            string? userId;
            bool IsAuthenthicated;

            if (_ctx.HttpContext.User.Identity.IsAuthenticated is true)
            {
                userId = _ctx.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
                IsAuthenthicated = true;
            }
            else
            {
                userId = _ctx.HttpContext.Request.Cookies["UserId"];
                IsAuthenthicated = false;
            }

            var cart = await _cartRepository.GetCartAsync(userId);

            if (cart is null)
            {
                await CreateCartAsync(userId, IsAuthenthicated);
                cart = await _cartRepository.GetCartAsync(userId);
            }

            return cart;
        }

    }
}
