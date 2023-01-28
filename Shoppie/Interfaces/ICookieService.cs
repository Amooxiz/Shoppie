using Shoppie.SupportModels;
using Shoppie.ViewModels;

namespace Shoppie.Interfaces
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
