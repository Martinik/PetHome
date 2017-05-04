using PetHome.Models.BindingModels.Home;
using PetHome.Models.ViewModels.Home;
using PetHome.Services;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    public class HomeController : Controller
    {
        private HomeService service;

        public HomeController()
        {
            this.service = new HomeService();
        }

        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            HomeIndexVM vm = this.service.GetHomeIndexVM();

            return View(vm);
        }

 

        //[ChildActionOnly]
        //public ActionResult RenderUserName()
        //{
            
        //    string username = User.Identity.Name;

        //    if (string.IsNullOrEmpty(username))
        //    {
        //        return null;
        //    }


        //    NavBarUserVM vm = this.service.GetNavBarUserVM(username);
        //    return PartialView("_RenderUserName", vm);
        //}


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