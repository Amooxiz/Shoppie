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
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;


        public UserService(IUserRepository userRepository, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
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
            var user = await _userRepository.GetUser(id);

            AppUserVM vm = new AppUserVM()
            {
                PersonalDicount = user.PersonalDicount.ToString(),
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
        
        public async Task UpdateUser(AppUserManagementModel appUser)
        {
            var user = await _userRepository.GetUser(appUser.User.Id);

            user.UserName = appUser.User.UserName;
            user.Address.Street = appUser.User.Street;
            user.Address.ApartamentNr = appUser.User.ApartamentNr;
            user.Address.BuildingNr = appUser.User.BuildingNr;
            user.Address.City = appUser.User.City;
            user.Address.Country = appUser.User.Country;
            user.Address.PostalCode = appUser.User.PostalCode;
            user.Name = appUser.User.Name;
            user.LastName = appUser.User.LastName;
            user.Email = appUser.User.Email;
            user.PersonalDicount = Double.Parse(appUser.User.PersonalDicount);

            var isInRole = _userManager.IsInRoleAsync(user, ((Roles)appUser.SelectedRoleId).ToString()).Result;
            if (!isInRole)
            {  
                await _userManager.AddToRoleAsync(user, ((Roles)appUser.SelectedRoleId).ToString());                            
            }
            else if (appUser.SelectedRoleId != (int)Roles.Administrator)
            {
                await _userManager.RemoveFromRoleAsync(user, Roles.Administrator.ToString());                
            }
            
            await _userRepository.UpdateUser(user);
        }
        
        public async Task<bool> DeleteUser(string id)
        {
            return await _userRepository.DeleteUser(id);
        }
    }
}
