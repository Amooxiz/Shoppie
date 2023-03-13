using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategoriesAsync();
        Task DisableCategoryAsync(Category category);
        Task EnableCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int id);

    }
}
