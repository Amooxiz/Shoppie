using Microsoft.AspNetCore.Mvc;
using Shoppie.Interfaces;
using Shoppie.Services;
using static iText.StyledXmlParser.Jsoup.Select.Evaluator;

namespace Shoppie.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICategoryService _categoryService;

        public CategoryController(ILogger<HomeController> logger, ICategoryService categoryService)
        {
            _logger = logger;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Management()
        {
            var categories = await _categoryService.GetAllCategories();

            return View(categories);
        }

        public IActionResult Disable(int id)
        {
            var category = _categoryService.GetCategory(id);

            if(category is null)
                return NotFound();
            else
                _categoryService.DisableCategory(category);

            return RedirectToAction(nameof(Management));
        }

        public IActionResult Enable(int id)
        {
            var category = _categoryService.GetCategory(id);

            if (category is null)
                return NotFound();
            else
                _categoryService.EnableCategory(category);

            return RedirectToAction(nameof(Management));
        }
    }
}
