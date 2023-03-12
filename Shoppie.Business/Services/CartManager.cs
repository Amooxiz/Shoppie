using Microsoft.EntityFrameworkCore;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;
using Shoppie.Business.Extensions.VM;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace Shoppie.Business.Services
{
    public class CartManager : ICartManager
    {
        private readonly IHttpContextAccessor _ctx;
        public CartManager(IHttpContextAccessor ctx)
        {
            _ctx = ctx;
        }
        public async Task AddToCart(int offerId)
        {
            if(_ctx.HttpContext.User.Identity.IsAuthenticated is true)
            {
                var id = _ctx.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            }
        }

        public async Task RemoveFromCart()
        {
            throw new NotImplementedException();
        }
    }
}
