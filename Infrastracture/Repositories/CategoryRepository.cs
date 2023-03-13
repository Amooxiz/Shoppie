using Domain.Interfaces.Repos;
using Shoppie.Domain.Entities;

namespace Shoppie.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DisableCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public void EnableCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
        }

        public IQueryable<Category> GetAllCategories()
        {
            return _context.Categories;
        }

        public Category GetCategory(int id)
        {
            var category = _context.Categories.SingleOrDefault(c => c.Id == id);
            return category;
        }
    }
}
