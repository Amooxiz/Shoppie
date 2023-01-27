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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOfferService _offerService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, IOfferService offerService)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
            _offerService = offerService;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllOffers();
            string? cartString = _httpContextAccessor.HttpContext.Request.Cookies["cart"];
            Cart cart = new Cart(cartString);
            ViewBag.cartCount = cart.ItemCount;

            return View(offers);
        }

        public IActionResult AddToCart(int id)
        {
            var offer = _offerService.GetOffer(id);
            string? cartString = _httpContextAccessor.HttpContext.Request.Cookies["cart"];
            Cart cart = new Cart(cartString);
            CartProduct cartProduct = new CartProduct();
            cartProduct.Title = offer.Title;
            cartProduct.Price = offer.Price;
            cart.AddItem(cartProduct);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("cart", cart.ToString());
            return RedirectToAction("Index");
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