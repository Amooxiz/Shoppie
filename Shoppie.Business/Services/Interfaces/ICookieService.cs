using Shoppie.Business.SupportModels;
using Shoppie.Business.ViewModels;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICookieService
    {
        string GetCookie(string key);
        void RemoveCookie(string key);
        void SetCookie(string key, string value);
        bool RemoveItemFromCart(int nr);
        void AddItemToCart(OfferVM offer);
        CartProduct MapOfferToCartProduct(OfferVM offer);
        Cart GetCart();
    }
}
