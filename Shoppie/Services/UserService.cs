using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ChangePersonalDiscount(double discount, string userId)
        {
            if (discount < 0 && discount > 1) return false;

            return await _userRepository.ChangePersonalDiscount(discount, userId);
        }

        public async Task<List<AppUserVM>> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            List<AppUserVM> usersToReturn = new List<AppUserVM>();

            foreach (var user in users)
            {
                AppUserVM vm = new AppUserVM()
                {
                    Id = user.Id,
                    Street = user.Address.Street,
                    ApartamentNr= user.Address.ApartamentNr,
                    BuildingNr= user.Address.BuildingNr,
                    City= user.Address.City,
                    Country= user.Address.Country,
                    Email = user.Email,
                    PersonalDicount = user.PersonalDicount,
                    PostalCode = user.Address.PostalCode,
                    LastName = user.LastName,
                    Name= user.Name,
                    UserName = user.UserName,
                };
                usersToReturn.Add(vm);
            }
            return usersToReturn;
        }
    }
}
