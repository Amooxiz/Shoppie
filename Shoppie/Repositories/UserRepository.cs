using Microsoft.EntityFrameworkCore;
using Shoppie.DataAccess;
using Shoppie.Interfaces;

namespace Shoppie.Repositories
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

        public async Task<List<AppUser>> GetUsers()
        {
            return await _userManager.Users
                .Where(x => x.isAdmin == false)
                .Include(x => x.Address)
                .ToListAsync();
        }
    }
}
