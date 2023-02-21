using Microsoft.EntityFrameworkCore;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;
using Shoppie.Extensions;
using System.Runtime.CompilerServices;

namespace Shoppie.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void DisableCategory(Category category)
        {
            category.IsActive = false;

            _categoryRepository.DisableCategory(category);
        }


        public async Task<List<CategoryVM>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories().ToModel().ToListAsync();

            return categories;
        }

        public Category GetCategory(int id)
        {
            var category = _categoryRepository.GetCategory(id);

            return category;
        }

        public void EnableCategory(Category category)
        {
            category.IsActive = true;

            _categoryRepository.EnableCategory(category);
        }
    }
}
