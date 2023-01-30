namespace Shoppie.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> ChangePersonalDiscount(double discount, string userId);
        public IQueryable<AppUser> GetUsers();
        public Task<AppUser> GetUser(string id);
        public Task UpdateUser(AppUser appUser);
        public Task<bool> DeleteUser(string id);
    }
}
