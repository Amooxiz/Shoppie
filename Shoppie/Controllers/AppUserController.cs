using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AppUserController(IUserService userService, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Management()
        {
            var users = await _userService.GetUsersAsync();
            return View(users);
        }

        // GET: AppUserController/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user is null)
                return NotFound();

            return View(user);
        }


        // GET: AppUserController/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = await _userService.GetUserAsync(id);

            if (user is null)
                return NotFound();

            var model = new AppUserManagementVM
            {
                User = user,
            };

            return View(model);
        }

        // POST: AppUserController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(AppUserManagementVM model)
        {
            var user = await _userManager.FindByIdAsync(model.User.Id);

            if (user is null)
                return NotFound();

            await _userService.UpdateUserAsync(model);


            await _signInManager.RefreshSignInAsync(user);

            return RedirectToAction("Index", "Offer");
        }

        // GET: AppUserController/Delete/5
        public async Task<ActionResult> Delete(string id)
        {

            var user = await _userService.GetUserAsync(id);
            return View(user);
        }

        // POST: AppUserController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(string id, IFormCollection collection)
        {
            try
            {
                var result = await _userService.DeleteUserAsync(id);
                if (!result)
                {
                    throw new InvalidOperationException("Problem with deleting user");
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
