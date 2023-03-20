using Microsoft.AspNetCore.Mvc.Rendering;
using Shoppie.Business.Generators.Interfaces;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly ICategoryService _categoryService;
        private readonly IPdfGenerator _generator;
        private readonly ApplicationDbContext _context;
        private readonly ICookieService _cookieService;
        private readonly INBPIntegratorService _nbpIntegratorService;
        private readonly UserManager<AppUser> _userManager;

        public OfferController(IOfferService offerService, ICategoryService categoryService,
            ApplicationDbContext context, IPdfGenerator generator, ICookieService cookieService, 
            INBPIntegratorService nbpIntegratorService, UserManager<AppUser> userManager)
        {
            _offerService = offerService;
            _categoryService = categoryService;
            _context = context;
            _generator = generator;
            _cookieService = cookieService;
            _nbpIntegratorService = nbpIntegratorService;
            _userManager = userManager;
        }

        // GET: Offer/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = await _offerService.GetOfferAsync(id);

            if (offer is null)
            {
                return NotFound();
            }
            

            return View(offer);
        }

        // GET: Offer/Create
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Create()
        {
            OfferVM offervM = new();

            var categories = await _categoryService.GetAllCategoriesAsync();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", offervM.CategoryId);
            return View(offervM);
        }

        // POST: Offer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Create(OfferVM vM)
        {
            if(vM.Image is null)
            {
                ModelState.AddModelError(nameof(vM.Image), "Please add an image");
            }
            
            if (!ModelState.IsValid)
            {
                var categories = await _categoryService.GetAllCategoriesAsync();

                ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", vM.CategoryId);
                return View(vM);
            }
            
            await _offerService.AddOfferAsync(vM);

            return RedirectToAction(nameof(Index), "Home");
        }

        public IActionResult AddToCart(int id)
        {
            return RedirectToAction("Index");
        }

        // GET: Offer/Edit/5
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var offer = await _offerService.GetOfferAsync(id);

            if (offer is null)
            {
                return NotFound();
            }

            var categories = await _categoryService.GetAllCategoriesAsync();


            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View(offer);
        }

        // POST: Offer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Edit(OfferVM offer)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", offer.CategoryId);

            if (offer.Image is null && offer.ImagePath is null)
            {
                ModelState.AddModelError(nameof(offer.Image), "Please add an image");
            }

            if (ModelState.IsValid)
            {
                await _offerService.UpdateOfferAsync(offer);
                return View(offer);
            }
    
            return View(offer);
        }

        // GET: Offer/Delete/5
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var offer = await _offerService.GetOfferAsync(id);

            return offer is null ? NotFound() : View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _offerService.DeleteOfferAsync(id);
            return RedirectToAction("Index", "Home");
        }

       [Authorize(Roles = $"Administrator")]
        public async Task<IActionResult> Management()
        {
            if (TempData["categories"] is not null)
            {
                ModelState.AddModelError("categories", TempData["categories"].ToString());
            }

            var offers = await _offerService.GetAllOffersAsync();
            var categories = await _categoryService.GetAllCategoriesAsync();
        
            OfferManagementModel model = new()
            {
                Offers = offers,
                Categories = categories,
            };
            ViewBag.CategoriesSelectList = new SelectList(model.Categories, "Id", "Name");
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GeneratePDF(int SelectedCategoryId)
        {
            var offers = await _offerService.GetOffersByCategoryIdAsync(SelectedCategoryId);
            
            if(offers.Count == 0)
            {
                TempData["categories"] = "Cannot generate PDF for category with no associated offers";
                return RedirectToAction(nameof(Management));
            }

            string c = "euro";

            return _generator.GeneratePdf(offers);
        }
    }
}
