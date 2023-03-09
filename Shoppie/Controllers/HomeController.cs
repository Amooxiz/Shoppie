using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using System.Diagnostics;
using System.Security.Claims;

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

        public async Task<IActionResult> New()
        {
            var offers = await _offerService.GetNewOffers(3);

            return View(offers);
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllActiveOffers();

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
            return RedirectToAction("Index");
        }

        public IActionResult ChangeRate(string rate)
        {
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Discount()
        {
            var offers = await _offerService.GetDiscountedOffers();
            
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