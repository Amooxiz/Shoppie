using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using System.Diagnostics;
using System.Security.Claims;

namespace Shoppie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly ICookieService _cookieService;
        private readonly ICartManager _cartManager;

        public HomeController(IOfferService offerService, ICookieService cookieService, ICartManager cartManager)
        {
            _offerService = offerService;
            _cookieService = cookieService;
            _cartManager = cartManager;
        }

        public async Task<IActionResult> New()
        {
            var offers = await _offerService.GetNewOffersAsync(3);

            return View(offers);
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllActiveOffersAsync();

            return View(offers);
        }

        public IActionResult Cart()
        {
            if (HttpContext.Request.Cookies["UserId"] is null || !User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            } 

            var cart = _cookieService.GetCart();

            return View(cart.Items);
        }

        public IActionResult AddToCart(int id)
        {
            _cartManager.AddToCartAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeRate(string rate)
        {
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Discount()
        {
            var offers = await _offerService.GetDiscountedOffersAsync();
            
            foreach (var offer in offers)
            {
                if (offer.Discount > 0)
                {
                    offer.Price *= 1.0 - offer.Discount;
                }
            }
            offers.ForEach(x => x.Price = Math.Round(x.Price, 2));


            return View(offers);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}