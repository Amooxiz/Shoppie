using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shoppie.Business.Extensions.VM;
using Shoppie.Business.Seeders.Enums;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;

namespace Shoppie.Business.Services
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

        public async Task<bool> ChangePersonalDiscountAsync(double discount, string userId)
        {
            if (discount < 0 && discount > 1) return false;

            return await _userRepository.ChangePersonalDiscountAsync(discount, userId);
        }

        public async Task<List<AppUserVM>> GetUsersAsync()
        {

            var users = await _userRepository
                .GetUsers()
                .ToModel()
                .ToListAsync();

            return users;

        }

        public async Task<AppUserVM> GetUserAsync(string id)
        {
            var user = await _userRepository.GetUserAsync(id);

            AppUserVM vm = new()
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

        public async Task UpdateUserAsync(AppUserManagementModel appUser)
        {
            var user = await _userRepository.GetUserAsync(appUser.User.Id);

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
            user.PersonalDicount = double.Parse(appUser.User.PersonalDicount);

            var isInRole = _userManager.IsInRoleAsync(user, ((Roles)appUser.SelectedRoleId).ToString()).Result;
            if (!isInRole)
            {
                await _userManager.AddToRoleAsync(user, ((Roles)appUser.SelectedRoleId).ToString());
            }
            else if (appUser.SelectedRoleId != (int)Roles.Administrator)
            {
                await _userManager.RemoveFromRoleAsync(user, Roles.Administrator.ToString());
            }

            await _userRepository.UpdateUserAsync(user);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
