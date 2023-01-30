using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
