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
        private readonly UserManager<AppUser> _userManager;


        public UserService(IUserRepository userRepository, UserManager<AppUser> userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
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

            var vm = user.ToModel();

            return vm;
        }

        public async Task UpdateUserAsync(AppUserManagementVM appUser)
        {
            var user = await _userRepository.GetUserAsync(appUser.User.Id);

            MapToEntity(appUser.User, user);

            var isInRole = await _userManager.IsInRoleAsync(user, ((Roles)appUser.SelectedRoleId).ToString());
            var selectedRole = appUser.SelectedRoleId;

            if (!isInRole)
            {
                await _userManager.AddToRoleAsync(user, ((Roles)selectedRole).ToString());
            }
            else if (appUser.SelectedRoleId != (int)Roles.Administrator)
            {
                await _userManager.RemoveFromRoleAsync(user, Roles.Administrator.ToString());
            }

            await _userRepository.UpdateUserAsync(user);
        }

        private static void MapToEntity(AppUserVM vm, AppUser entity)
        {
            entity.UserName = vm.UserName;
            entity.Address.Street = vm.Street;
            entity.Address.ApartamentNr = vm.ApartamentNr;
            entity.Address.BuildingNr = vm.BuildingNr;
            entity.Address.City = vm.City;
            entity.Address.Country = vm.Country;
            entity.Address.PostalCode = vm.PostalCode;
            entity.Name = vm.Name;
            entity.LastName = vm.LastName;
            entity.Email = vm.Email;
            entity.PersonalDicount = double.Parse(vm.PersonalDicount);
        }

        public async Task<bool> DeleteUserAsync(string id)
        {
            return await _userRepository.DeleteUserAsync(id);
        }
    }
}
