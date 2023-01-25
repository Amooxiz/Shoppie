using Microsoft.EntityFrameworkCore;
using Shoppie.Extensions;
using Shoppie.Interfaces;
using Shoppie.ViewModels;

namespace Shoppie.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<List<CategoryVM>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories().ToModel().ToListAsync();

            return categories;
        }
    }
}
