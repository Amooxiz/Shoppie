using Shoppie.DataAccess.Entities;

namespace Shoppie.DataAccess.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
