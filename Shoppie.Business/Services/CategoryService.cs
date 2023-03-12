using Microsoft.EntityFrameworkCore;
using Shoppie.Business.Services.Interfaces;
using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;
using Shoppie.DataAccess.Repositories.Interfaces;
using Shoppie.Business.Extensions.VM;

namespace Shoppie.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task DisableCategoryAsync(Category category)
        {
            category.IsActive = false;

            await _categoryRepository.DisableCategoryAsync(category);
        }


        public async Task<List<CategoryVM>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategories().ToModel().ToListAsync();

            return categories;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryAsync(id);

            return category;
        }

        public async Task EnableCategoryAsync(Category category)
        {
            category.IsActive = true;

            await _categoryRepository.EnableCategoryAsync(category);
        }
    }
}
