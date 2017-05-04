using PetHome.Models.ViewModels.Admin;
using PetHome.Services;
using System.Web.Mvc;

namespace PetHome.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private AdminService service;

        public AdminController()
        {
            this.service = new AdminService();
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