namespace Shoppie.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(IFormCollection Form)
        {
            return View();
        }
    }
}
