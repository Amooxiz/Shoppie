using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserService _userService;

        public AppUserController(IUserService userService)
        {
            _userService = userService;
        }
        
        public async Task<IActionResult> Management()
        {
            var users = await _userService.GetUsers();
            return View(users);
        }

        // GET: AppUserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userService.GetUser(id);
            return View(user);
        }

        // GET: AppUserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppUserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppUserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userService.GetUser(id);

            if (user is null)
                return NotFound();

            return View(user);
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, IFormCollection collection)
        {
            try
            {
                AppUserVM vm = new()
                {
                    Street = collection["Street"],
                    City = collection["City"],
                    PostalCode = collection["PostalCode"],
                    Country = collection["Country"],
                    BuildingNr = collection["BuildingNr"],
                    PersonalDicount = double.Parse(collection["PersonalDicount"]),
                    ApartamentNr = int.Parse(collection["ApartamentNr"]),
                    Id = id,
                    Email = collection["Email"],
                    UserName = collection["UserName"],
                    Name = collection["Name"],
                    LastName = collection["LastName"],
                };
                var result = await _userService.EditUser(vm);
                
                if (!result)
                {
                    throw new Exception("Problem with editing user");
                }
                
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppUserController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userService.GetUser(id);
            return View(user);
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                var result = await _userService.DeleteUser(id);
                if (!result)
                {
                    throw new Exception("Problem with deleting user");
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
