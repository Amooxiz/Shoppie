using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategories();
        Task DisableCategory(Category category);
        Task EnableCategory(Category category);
        Task<Category> GetCategory(int id);

    }
}
