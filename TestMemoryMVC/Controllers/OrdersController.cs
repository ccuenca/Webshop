using System.Web.Mvc;

namespace TestMemoryMVC.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            return View("List");
        }
    }
}