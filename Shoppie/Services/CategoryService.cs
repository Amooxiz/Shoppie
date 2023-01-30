using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Shoppie.Extensions;
using Shoppie.Interfaces;
using Shoppie.ViewModels;
using System.Runtime.CompilerServices;

namespace Shoppie.Services
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
