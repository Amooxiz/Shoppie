using Shoppie.Interfaces;

namespace Shoppie.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Category> GetAllCategories()
        {
            return _context.Categories;
        }
    }
}
