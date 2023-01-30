using Microsoft.AspNetCore.Mvc;
using Shoppie.Interfaces;
using Shoppie.Services;

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

        public IActionResult Management()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Management(CategoryVM category)
        {
            return View();
        }
    }
}
