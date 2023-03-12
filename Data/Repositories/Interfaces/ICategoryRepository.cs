using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        Task DisableCategoryAsync(Category category);
        Task EnableCategoryAsync(Category category);
        Task<Category> GetCategoryAsync(int id);

    }
}
