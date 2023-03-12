using Shoppie.Business.Services.Interfaces;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
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
        public async Task AddToCart(int offerId)
        {
            var cart = await FindCart();

            cart.Items.Add(new CartItem { OfferId = offerId });

            await _cartRepository.AddToCart(cart);
        }

        public Cart CreateCartForUser(string userId, int offerId)
        {
            return new Cart
            {
                AuthenticatedCartOwnerId = userId,
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        OfferId = offerId,
                    }
                }
            };
        }
        public Cart CreateCartForGuest(string guestId, int offerId)
        {
            return new Cart
            {
                AnnoynymousCartOwnerId = guestId,                
                Items = new List<CartItem>
                {
                    new CartItem
                    {
                        OfferId = offerId,
                    }
                }
            };
        }
        public async Task RemoveFromCart()
        {
            throw new NotImplementedException();
        }

        public async Task<Cart?> GetCart()
        {
            return new Cart { };
        }

        public async Task<Cart?> FindCart()
        {
            string? userId = null;

            if (_ctx.HttpContext.User.Identity.IsAuthenticated is true)
            {
                userId = _ctx.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }

            userId ??= _ctx.HttpContext.Request.Cookies["UserId"];

            return userId is null ?  null : await _cartRepository.GetCart(userId);

        }
    }
}
