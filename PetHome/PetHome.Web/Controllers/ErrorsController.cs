using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult InvalidUrlError()
        {
            return View();
        }
    }
}