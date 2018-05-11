using System;
using System.Linq;

namespace TestMemoryMVC.Persistence.Repositories
{
    public class ConfigurationRepository
    {
        private Persistence.WebshopDBEntities _context;

        public ConfigurationRepository()
        {
            _context = new Persistence.WebshopDBEntities();
        }

        public ConfigurationRepository(Persistence.WebshopDBEntities context)
        {
            _context = context;
        }

        public GeneralParameters GetConfiguration()
        {
            return _context.GeneralParameters.SingleOrDefault();
        }


        public bool GetStorageStrategy()
        {
            var parameters = _context.GeneralParameters.SingleOrDefault();

            return (bool)parameters.MemoryStrategy;
        }


        public void SaveConfiguration(bool memoryStrategy)
        {
            var parameters = _context.GeneralParameters.SingleOrDefault();

            parameters.MemoryStrategy = memoryStrategy;
            parameters.MameryStrategyDateChaged = DateTime.Now;

            _context.SaveChanges();
        }

    }
}