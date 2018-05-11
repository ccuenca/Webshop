using System.Collections.Generic;
using TestMemoryMVC.Persistence;

namespace TestMemoryMVC.ViewModels
{
    public class ProductsViewModel
    {

        public ProductsViewModel()
        {
            this.Products = new List<Product>();
        }


        public Product Product { get; set; }

        public List<Product> Products { get; set; }

        public List<Category> Categories { get; set; }


    }
}