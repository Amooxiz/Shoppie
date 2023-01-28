using Shoppie.Interfaces;
using Shoppie.SupportModels;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class CookieService : ICookieService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CookieService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public void SetCookie(string key, string value)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value);
        }

        public string GetCookie(string key)
        {
            return _httpContextAccessor.HttpContext.Request.Cookies[key];
        }

        public void RemoveCookie(string key)
        {
            _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
        }

        public Cart GetCart()
        {
            var cartString = GetCookie("cart");
            return new Cart(cartString);
        }

        public CartProduct MapOfferToCartProduct(OfferVM offer)
        {
            CartProduct cartProduct = new CartProduct();
            cartProduct.Title = offer.Title;
            cartProduct.Price = offer.Price;
            return cartProduct;
        }

        public void AddItemToCart(OfferVM offer)
        {
            var cartProduct = MapOfferToCartProduct(offer);
            var cart = GetCart();
            cart.AddItem(cartProduct);
            SetCookie("cart", cart.ToString());
        }

        public bool RemoveItemFromCart(int nr)
        {
            var cart = GetCart();
            if (cart.ItemCount != 0)
            {
                cart.RemoveItem(nr);
                SetCookie("cart", cart.ToString());
                return true;
            }
            return false;
        }
    }
}
