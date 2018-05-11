using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using TestMemoryMVC.Persistence.MemoryPersistence;

namespace TestMemoryMVC.Persistence.Repositories
{
    public class ProductsRepository
    {
        private Persistence.WebshopDBEntities _context;
        private Persistence.Repositories.ConfigurationRepository _conf;

        public ProductsRepository()
        {
            _context = new Persistence.WebshopDBEntities();
            _conf = new ConfigurationRepository(_context);
        }

        public List<Product> GetAll()
        {
            List<Product> products;

            if (_conf.GetStorageStrategy())
                products = _context.Products.ToList();
            else
                products = MemoryDatabase.products;

            return products;
        }


        public void Add(Product product)
        {
            if (_conf.GetStorageStrategy())
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            else
            {
                MemoryDatabase.products.Add(product);
            }
        }

    }
}