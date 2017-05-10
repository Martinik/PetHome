using PetHome.Models.BindingModels.Home;
using PetHome.Models.ViewModels.Home;
using PetHome.Services.Interfaces;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    public class HomeController : Controller
    {
        private IHomeService service;

        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            HomeIndexVM vm = this.service.GetHomeIndexVM();

            return View(vm);
        }


        [HttpPost]
        public ActionResult Search(SearchBM bind)
        {
            SearchResultVM vm = this.service.GetSearchResultVM(bind);

            return View(vm);
        }


        public ActionResult GetLoginPartial()
        {
            string username = User.Identity.Name;

            if (string.IsNullOrEmpty(username))
            {
                return null;
            }


            NavBarUserVM vm = this.service.GetNavBarUserVM(username);
            return PartialView("_LoginPartial", vm);
        }
    }
}