using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess;
using Shoppie.DataAccess.Models;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Controllers
{
    public class OfferController : Controller
    {
        private readonly IOfferService _offerService;
        private readonly ICategoryService _categoryService;
        private readonly IPdfGenerator _generator;
        private readonly ApplicationDbContext _context;


        public OfferController(IOfferService offerService, ICategoryService categoryService, 
            ApplicationDbContext context, IPdfGenerator generator)
        {
            _offerService = offerService;
            _categoryService = categoryService;
            _context = context;
            _generator = generator;
        }

        // GET: Offer
        public async Task<IActionResult> Index()
        {
            var offers = await _offerService.GetAllOffers();
            
            return  View(offers);
        }

        // GET: Offer/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var offer = _offerService.GetOffer(id);

            if (offer is null)
            {
                return NotFound();
            }

            return View(offer);
        }

        // GET: Offer/Create
        public async Task<IActionResult> Create()
        {
            Offer offerModel = new();

            var categories = await _categoryService.GetAllCategories();

            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", offerModel.CategoryId);
            return View(offerModel);
        }

        // POST: Offer/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Price,IsActive,IsFinished,Discount,CreationDate,CategoryId")] Offer offer)
        {
            if (!ModelState.IsValid && offer.Category is not null)
            {
                var categories = await _categoryService.GetAllCategories();

                ViewData["CategoryId"] = new SelectList(categories, "Id", "Name", offer.CategoryId);
                return View(offer);
            }
                _offerService.AddOffer(offer);
                return RedirectToAction(nameof(Index));
        }

        // GET: Offer/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
            {
                return NotFound();
            }

            var offer = _offerService.GetOffer(id);

            if (offer is null)
            {
                return NotFound();
            }

            var categories = await _categoryService.GetAllCategories();


            ViewData["CategoryId"] = new SelectList(categories, "Id", "Name");
            return View(offer);
        }

        // POST: Offer/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OfferVM offer)
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", offer.CategoryId);

            if (ModelState.IsValid)
            {
                _offerService.UpdateOffer(offer);
                return View(offer);
            }
    
            return View(offer);
        }

        // GET: Offer/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return NotFound();

            var offer = _offerService.GetOffer(id);

            return offer is null ? NotFound() : View(offer);
        }

        // POST: Offer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            _offerService.DeleteOffer(id);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> GeneratePDF(int id)
        {
            return View();
        }

        [HttpPost]
        public async Task<FileResult> GeneratePDFF()
        {
            string c = "euro";
            return _generator.GeneratePdf(new List<OfferVM>
                { 
                    new OfferVM { Id = 1,Title= "Fajna super rybka", CategoryName = "Ryby"},
                    new OfferVM { Id = 2,Title= "Giga piękny ogród", CategoryName = "Ogród"}, 
                    new OfferVM { Id = 3,Title= "Piękne zwierzątka",CategoryName = "Zwierzęta"}
            },c);
        }

        /*        private bool OfferExists(int id)
                {
                  return (_context.Offers?.Any(e => e.Id == id)).GetValueOrDefault()                }
        */
    }
}
