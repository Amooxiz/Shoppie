namespace Shoppie.Interfaces
{
    public interface IUserRepository
    {
        public Task<bool> ChangePersonalDiscount(double discount, string userId);
        public Task<List<AppUser>> GetUsers();
    }
}
