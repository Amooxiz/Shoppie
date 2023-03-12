using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.DataAccess.Repositories
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

        public async Task<bool> ChangePersonalDiscountAsync(double discount, string userId)
        {
            AppUser? user = await _userManager.FindByIdAsync(userId);

            if (user == null) return false;

            user.PersonalDicount = discount;
            var result = await _userManager.UpdateAsync(user);

            return result.Succeeded;
        }

        public IQueryable<AppUser> GetUsers()
        { 
            return _context.Users.Where(u => u.IsAdmin == false);
        }

        public async Task<AppUser> GetUserAsync(string id)
        {
            return await _context.Users.Include(u => u.Address).SingleOrDefaultAsync(u => u.Id == id && u.IsAdmin == false);
        }

        public async Task UpdateUserAsync(AppUser appUser)
        {
            _ = await _userManager.UpdateAsync(appUser);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null)
            {
                return false;
            }
            
            var result = await _userManager.DeleteAsync(user);
            
            return result.Succeeded;
        }
    }
}
