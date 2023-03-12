using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> ChangePersonalDiscountAsync(double discount, string userId);
        public IQueryable<AppUser> GetUsers();
        public Task<AppUser> GetUserAsync(string id);
        public Task UpdateUserAsync(AppUser appUser);
        public Task<bool> DeleteUserAsync(string id);
    }
}
