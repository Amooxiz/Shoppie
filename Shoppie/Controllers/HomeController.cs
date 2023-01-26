using Newtonsoft.Json;
using Shoppie.DataAccess.Models;
using Shoppie.Interfaces;
using Shoppie.SupportModels;
using System.Diagnostics;

namespace Shoppie.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IOfferService _offerService;

        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
        {
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetNewOffers(10);
            string? cart = _httpContextAccessor.HttpContext.Request.Cookies["cart"];
            if (cart is not null)
            {
                Cart cartModel = JsonConvert.DeserializeObject<Cart>(cart);
                ViewBag.CartCount = cartModel.ItemCount;
            }
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