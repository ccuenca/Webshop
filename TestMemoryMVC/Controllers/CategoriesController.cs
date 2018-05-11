using System.Web.Mvc;

namespace TestMemoryMVC.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult Index()
        {
            return View("List");
        }
    }
}