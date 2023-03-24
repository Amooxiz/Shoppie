using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using System.Diagnostics;

namespace Shoppie.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly ICartManager _cartManager;
        private readonly INBPIntegratorService _nbpIntegratorService;

        public HomeController(IOfferService offerService, ICartManager cartManager, INBPIntegratorService nbpIntegratorService)
        {
            _offerService = offerService;
            _cartManager = cartManager;
            _nbpIntegratorService = nbpIntegratorService;
        }

        public async Task<IActionResult> New(int pageNr = 1, int pageSize = 7)
        {
            (var offers, var totalCount) = await _offerService.GetNewOffersPaginatedAsync(pageNr, pageSize, 10);

            var pager = new PaginationModel(totalCount, pageNr, pageSize)
            {
                Action = nameof(New)
            };

            ViewBag.Pager = pager;

            return View(offers);
        }

        public async Task<IActionResult> Index(int pageNr = 1, int pageSize = 1)
        {
            (var offers, var totalCount) = await _offerService.GetAllOffersPaginatedAsync(pageNr, pageSize);

            var pager = new PaginationModel(totalCount, pageNr, pageSize);
            ViewBag.Pager = pager;

            return View(offers);
        }
        public async Task<IActionResult> ChangeCurrency(string prefix)
        {
            if (prefix is null)
            {
                throw new ArgumentNullException(nameof(prefix));
            }

            if (prefix == "PLN")
            {
                RedirectToAction(nameof(Index));
            }

            _nbpIntegratorService.GetRate(prefix);

            return RedirectToAction(nameof(Index));
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


            var pager = new PaginationModel(totalCount, pageNr, pageSize)
            {
                Action = nameof(Discount)
            };
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