using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface IUserService
    {
        public Task<bool> ChangePersonalDiscount(double discount, string userId);
        public Task<List<AppUserVM>> GetUsers();
    }
}
