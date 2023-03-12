using Shoppie.Business.ViewModels;

namespace Shoppie.Business.Services.Interfaces
{
    public interface IUserService
    {
        public Task<bool> ChangePersonalDiscountAsync(double discount, string userId);
        public Task<List<AppUserVM>> GetUsersAsync();
        public Task<AppUserVM> GetUserAsync(string id);
        public Task UpdateUserAsync(AppUserManagementModel appUser);
        public Task<bool> DeleteUserAsync(string id);
    }
}
