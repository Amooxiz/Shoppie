using Microsoft.EntityFrameworkCore;
using Shoppie.Extensions;
using Shoppie.Interfaces;
using Shoppie.RolesSeed;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly UserManager<AppUser> _userManager;


        public UserService(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<bool> ChangePersonalDiscount(double discount, string userId)
        {
            if (discount < 0 && discount > 1) return false;

            return await _userRepository.ChangePersonalDiscount(discount, userId);
        }

        public async Task<List<AppUserVM>> GetUsers()
        {

            var users = await _userRepository
                .GetUsers()
                .ToModel()
                .ToListAsync();
            
            return users;

        }
        
        public async Task<AppUserVM> GetUser(string id)
        {
            var user = await _userRepository.GetUser(id)

            AppUserVM vm = new AppUserVM()
            {
                PersonalDicount = user.PersonalDicount,
                Id = user.Id,
                Street = user.Address.Street,
                ApartamentNr = user.Address.ApartamentNr,
                BuildingNr = user.Address.BuildingNr,
                City = user.Address.City,
                Country = user.Address.Country,
                Email = user.Email,
                PostalCode = user.Address.PostalCode,
                LastName = user.LastName,
                Name = user.Name,
                UserName = user.UserName,
            };

            return vm;
        }
        
        public async Task<bool> EditUser(AppUserVM appUser)
        {
            var user = await _userRepository.GetUser(appUser.Id);

            user.PersonalDicount = appUser.PersonalDicount;
            user.Address.Street = appUser.Street;
            user.Address.ApartamentNr = appUser.ApartamentNr;
            user.Address.BuildingNr = appUser.BuildingNr;
            user.Address.City = appUser.City;
            user.Address.Country = appUser.Country;
            user.Address.PostalCode = appUser.PostalCode;
            user.LastName = appUser.LastName;
            user.Name = appUser.Name;
            user.UserName = appUser.UserName;

            return await _userRepository.UpdateUser(user);
        }
        
        public async Task<bool> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
