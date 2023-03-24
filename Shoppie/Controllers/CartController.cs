using Shoppie.Business.Services.Interfaces;

namespace Shoppie.Controllers
{
    public class CartController : Controller
    {
        private readonly ICookieService _cookieService;

        public CartController(ICookieService cookieService)
        {
            _cookieService = cookieService;
        }
        public IActionResult Index()
        {
            return View();
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
    }
}
