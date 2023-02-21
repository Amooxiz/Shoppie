using Application.ViewModels;
using Shoppie.Domain.Entities;

namespace Application.Category.ICategoryService
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategories();
        void DisableCategory(Category category);
        void EnableCategory(Category category);
        Category GetCategory(int id);

    }
}
