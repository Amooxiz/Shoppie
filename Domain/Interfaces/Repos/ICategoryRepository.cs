using Domain.Entities;

namespace Domain.Interfaces.Repos
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
