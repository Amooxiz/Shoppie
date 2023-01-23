using Shoppie.DataAccess.Models;

namespace Shoppie.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public string Register(IFormCollection form)
        {
            string userName = form["UserName"].ToString();
            string email = form["Email"].ToString();
            string password = form["PasswordHash"].ToString();
            Guid id = Guid.NewGuid();

            //User user = new() 
            //{ 
            //    Id = id,
            //    Email = email,
            //    Address = null,
            //    UserName = userName,
            //    PasswordHash = password
            //};
            //TODO: Add user to database
            return "DOne";
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public string Login(IFormCollection form)
        {
            string userName = form["UserName"].ToString();
            string password = form["PasswordHash"].ToString();
            //TODO: Check if can logIn
            return "Dooone";
        }
    }
}
