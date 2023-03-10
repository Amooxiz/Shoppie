using Shoppie.Business.Services.Interfaces;

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

        public async Task<IActionResult> Disable(int id)
        {
            var category = await _categoryService.GetCategory(id);

            if(category is null)
                return NotFound();
            else
                await _categoryService.DisableCategory(category);

            return RedirectToAction(nameof(Management));
        }

        public async Task<IActionResult> Enable(int id)
        {
            var category = await _categoryService.GetCategory(id);

            if (category is null)
                return NotFound();
            else
                await _categoryService.EnableCategory(category);

            return RedirectToAction(nameof(Management));
        }
    }
}
