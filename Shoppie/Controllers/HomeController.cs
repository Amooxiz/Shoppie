using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using System.Diagnostics;

namespace Shoppie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOfferService _offerService;
        private readonly INBPIntegratorService _nbpIntegratorService;
        private readonly ICookieService _cookieService;
        private readonly UserManager<AppUser> _userManager;

        public HomeController(ILogger<HomeController> logger, IOfferService offerService,
            INBPIntegratorService nBPIntegratorService, ICookieService cookieService, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _offerService = offerService;
            _nbpIntegratorService = nBPIntegratorService;
            _cookieService = cookieService;
            _userManager = userManager;
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
                offers.ForEach(x => x.Price *= rate);
            }
            foreach (var offer in offers)
            {
                if (offer.Discount > 0)
                {
                    offer.Price *= (1.0 - offer.Discount);
                }
            }
            offers.ForEach(x => x.Price = Math.Round(x.Price, 2));

            return View(offers);
        }

        public IActionResult Cart()
        {
            var cart = _cookieService.GetCart();
            return View(cart.Items);
        }

        public IActionResult AddToCart(int id)
        {
            var offer = _offerService.GetOffer(id);
            var user = _userManager.GetUserAsync(User).Result;

            if (user is null)
            {
                return Redirect("/Identity/Account/Login");
            }

            string? rateCookie = _cookieService.GetCookie("rate");
            if (rateCookie is null)
            {
                rateCookie = "PLN";
                _cookieService.SetCookie("rate", rateCookie);
            }
            else if (rateCookie != "PLN")
            {
                double rate = _nbpIntegratorService.GetRate(rateCookie).Result;
                offer.Price *= rate;
            }
            if (offer.Discount > 0)
            {
                offer.Price *= (1.0 - offer.Discount);
            }
            offer.Price = Math.Round(offer.Price, 2);

            if (user.PersonalDicount > 0)
            {
                offer.Price *= (1.0 - user.PersonalDicount);
            }

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

            string? rateCookie = _cookieService.GetCookie("rate");
            if (rateCookie is null)
            {
                rateCookie = "PLN";
                _cookieService.SetCookie("rate", rateCookie);
            }
            else if (rateCookie != "PLN")
            {
                double rate = await _nbpIntegratorService.GetRate(rateCookie);
                offers.ForEach(x => x.Price *= rate);
            }
            foreach (var offer in offers)
            {
                if (offer.Discount > 0)
                {
                    offer.Price *= 1.0 - offer.Discount;
                }
            }
            offers.ForEach(x => x.Price = Math.Round(x.Price, 2));


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