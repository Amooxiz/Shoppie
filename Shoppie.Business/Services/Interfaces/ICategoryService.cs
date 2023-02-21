using Shoppie.Business.ViewModels;
using Shoppie.DataAccess.Entities;

namespace Shoppie.Business.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
