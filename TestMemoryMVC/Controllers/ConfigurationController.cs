using System;
using System.Linq;
using System.Web.Mvc;
using TestMemoryMVC.Persistence.Repositories;
using TestMemoryMVC.ViewModels;

namespace TestMemoryMVC.Controllers
{
    public class ConfigurationController : Controller
    {
        private ConfigurationRepository _conf;

        public ConfigurationController()
        {
            _conf = new ConfigurationRepository();
        }

        public ActionResult Index()
        {
            var viewModel = new ConfigurationViewModel();
            var conf = _conf.GetConfiguration();

            viewModel.MemoryStrategy = (bool)conf.MemoryStrategy;
            viewModel.LastUpdate = conf.MameryStrategyDateChaged.ToString();

            return View("Index", viewModel);
        }


        public ActionResult Save(ConfigurationViewModel viewModel)
        {
            _conf.SaveConfiguration(viewModel.MemoryStrategy);
            return RedirectToAction("Index", "Home");
        }
    }
}