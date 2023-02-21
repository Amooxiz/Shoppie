using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess;
using Shoppie.Interfaces;
using Shoppie.RolesSeed;

namespace Infrastracture.Identity
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserRepository(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public async Task<bool> ChangePersonalDiscount(double discount, string userId)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);

            if (user == null) return false;

            user.PersonalDicount = discount;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public IQueryable<AppUser> GetUsers()
        {
            return _context.Users.Where(u => u.isAdmin == false);
        }

        public async Task<AppUser> GetUser(string id)
        {
            return await _context.Users.Include(u => u.Address).SingleOrDefaultAsync(u => u.Id == id && u.isAdmin == false);
        }

        public async Task UpdateUser(AppUser appUser)
        {
            var result = await _userManager.UpdateAsync(appUser);
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return false;
            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }
    }
}
