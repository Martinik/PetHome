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

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult RenderUserName()
        {
            string username = User.Identity.Name; 
            NavBarUserVM vm = this.service.GetNavBarUserVM(username);
            

            return PartialView("_RenderUserName", vm);
        }
    }
}