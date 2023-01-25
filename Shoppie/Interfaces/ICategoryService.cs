using Shoppie.ViewModels;

namespace Shoppie.Interfaces
{
    public interface ICategoryService
    {
        Task<List<CategoryVM>> GetAllCategories();
    }
}
