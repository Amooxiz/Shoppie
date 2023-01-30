using Newtonsoft.Json;
using Shoppie.DataAccess.Models;
using Shoppie.Interfaces;
using Shoppie.SupportModels;
using Shoppie.ViewModels;
using System.Diagnostics;

namespace Shoppie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfferService _offerService;
        private readonly INBPIntegratorService _nbpIntegratorService;
        private readonly ICookieService _cookieService;

        public HomeController(ILogger<HomeController> logger, IOfferService offerService, INBPIntegratorService nBPIntegratorService, ICookieService cookieService)
        {
            _logger = logger;
            _offerService = offerService;
            _nbpIntegratorService = nBPIntegratorService;
            _cookieService = cookieService;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetNewOffers(3);
            string? rateCookie = _cookieService.GetCookie("rate");
            if (rateCookie is null)
            {
                rateCookie = "PLN";
                _cookieService.SetCookie("rate", rateCookie);
            }
            else if (rateCookie != "PLN")
            {
                double rate = await _nbpIntegratorService.GetRate(rateCookie);
                offers.ForEach(x => x.Price = x.Price * rate);
            }
            var cart = _cookieService.GetCart();
            ViewBag.cartCount = cart.ItemCount;

            return View(offers);
        }

        public IActionResult AddToCart(int id)
        {
            var offer = _offerService.GetOffer(id);
            _cookieService.AddItemToCart(offer);
            
            return RedirectToAction("Index");
        }
        
        public IActionResult ChangeRate(string rate)
        {
            _cookieService.SetCookie("rate", rate);
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Discount()
        {
            var offers = await _offerService.GetDiscountedOffers();

            return View(offers);
            //return RedirectToAction("Discount", "Offer"); Po zrobieniu metody Discount w offerControlerze mozna to odkomentowac
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