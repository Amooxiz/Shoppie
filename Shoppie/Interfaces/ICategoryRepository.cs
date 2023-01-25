using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
    }
}
