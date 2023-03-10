using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        Task DisableCategory(Category category);
        Task EnableCategory(Category category);
        Task<Category> GetCategory(int id);

    }
}
