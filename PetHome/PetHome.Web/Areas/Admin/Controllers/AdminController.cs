using PetHome.Models.ViewModels.Admin;
using PetHome.Services.Interfaces;
using System.Web.Mvc;

namespace PetHome.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }

        // GET: Admin/Admin
        [HttpGet]
        public ActionResult AdminPanel()
        {
            AdminPanelVM vm = this.service.GetAdminPanelVM();

            return View(vm);
        }
    }
}