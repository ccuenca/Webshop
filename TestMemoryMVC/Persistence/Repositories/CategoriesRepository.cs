using System.Collections.Generic;
using System.Linq;

namespace TestMemoryMVC.Persistence.Repositories
{
    public class CategoriesRepository
    {
        private Persistence.WebshopDBEntities _context;

        public CategoriesRepository()
        {
            _context = new Persistence.WebshopDBEntities();
        }

        public List<Category> GetAll()
        {
            return _context.Categories.ToList();

        }
    }
}