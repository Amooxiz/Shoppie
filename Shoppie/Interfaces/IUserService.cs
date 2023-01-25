using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface IUserService
    {
        public Task<bool> ChangePersonalDiscount(double discount, string userId);
        public Task<List<AppUserVM>> GetUsers();
        public Task<AppUserVM> GetUser(string id);
        public Task<bool> EditUser(AppUserVM appUser);
        public Task<bool> DeleteUser(string id);
    }
}
