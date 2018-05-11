using System.Linq;
using System.Web.Mvc;
using TestMemoryMVC.ViewModels;

namespace TestMemoryMVC.Controllers
{
    public class CustomersController : Controller
    {
        

        // GET: Customers
        public ActionResult Index()
        {
           

            return View("List");
        }
    }
}