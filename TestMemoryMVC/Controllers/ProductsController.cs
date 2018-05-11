using System.Web.Mvc;
using TestMemoryMVC.Persistence;
using TestMemoryMVC.Persistence.Repositories;
using TestMemoryMVC.ViewModels;

namespace TestMemoryMVC.Controllers
{
    public class ProductsController : Controller
    {

        private ProductsRepository _productsRepository;
        private CategoriesRepository _categoryRepository;

        public ProductsController()
        {
            _productsRepository = new ProductsRepository();
            _categoryRepository = new CategoriesRepository();
        }

        public ActionResult Index()
        {
            var viewModel = new ProductsViewModel();

            viewModel.Products = _productsRepository.GetAll();

            return View("List", viewModel);
        }


        public ActionResult New()
        {
            var viewModel = new ProductsViewModel();

            viewModel.Categories = _categoryRepository.GetAll();

            return View("ProductsForm", viewModel);
        }

        public ActionResult Add(Product product)
        {
            var viewModel = new ProductsViewModel();
            
            _productsRepository.Add(product);

            viewModel.Products = _productsRepository.GetAll();

            return View("List", viewModel);
        }
    }
}