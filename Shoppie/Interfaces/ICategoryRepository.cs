using iText.IO.Image;
using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface ICategoryRepository
    {
        IQueryable<Category> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
