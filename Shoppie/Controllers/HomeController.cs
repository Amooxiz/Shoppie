using iText.Kernel.Geom;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using System.Diagnostics;
using System.Drawing.Printing;
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

        public async Task<IActionResult> New(int pageNr = 1, int pageSize = 7)
        {
            (var offers, var totalCount) = await _offerService.GetNewOffersPaginatedAsync(pageNr, pageSize, 10);

            var pager = new PaginationModel(totalCount, pageNr, pageSize);
            pager.Action = nameof(New);

            ViewBag.Pager = pager;

            return View(offers);
        }

        public async Task<IActionResult> Index(int pageNr = 1, int pageSize = 7)
        {
            (var offers, var totalCount) = await _offerService.GetAllOffersPaginatedAsync(pageNr, pageSize);

            var pager = new PaginationModel(totalCount, pageNr, pageSize);
            ViewBag.Pager = pager;

            return View(offers);
        }

        public async Task<IActionResult> Cart()
        {
            if (HttpContext.Request.Cookies["UserId"] is null || !User.Identity.IsAuthenticated)
            {
                RedirectToAction("Index");
            } 

            var cart = _cookieService.GetCart();

            return View(cart.Items);
        }

        public async Task<IActionResult> AddToCart(int id)
        {
            await _cartManager.AddToCartAsync(id);

            return RedirectToAction("Index");
        }

        public IActionResult ChangeRate(string rate)
        {
            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> Discount(int pageNr = 1, int pageSize = 7)
        {
            (var offers, var totalCount) = await _offerService.GetDiscountedOffersPaginatedAsync(pageNr, pageSize);

            foreach (var offer in offers)
            {
                if (offer.Discount > 0)
                {
                    offer.Price *= 1.0 - offer.Discount;
                }
            }
            offers.ForEach(x => x.Price = Math.Round(x.Price, 2));


            var pager = new PaginationModel(totalCount, pageNr, pageSize);
            pager.Action = nameof(Discount);
            ViewBag.Pager = pager;

            return View(offers);
            
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}