using PetHome.Models.BindingModels;
using PetHome.Models.ViewModels.Users;
using PetHome.Services;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private UsersService service;

        public UsersController()
        {
            this.service = new UsersService();
        }




        [HttpGet, Route("profile/{username}")]
        public ActionResult Profile(string username)
        {
            string usernameUsed = username;

            if (string.IsNullOrEmpty(username))
            {
                usernameUsed = User.Identity.Name;
            }
            ProfileVM vm = this.service.GetProfileVm(usernameUsed);

            if (vm == null)
            {
                return HttpNotFound();
            }

            return View(vm);
        }


        //[HttpGet]
        //public ActionResult Edit()
        //{
        //    string userName = User.Identity.Name;
        //    EditUserVM vm = this.service.GetEditUserVm(userName);
        //    return View(vm);


        //}


        [HttpGet, Route("Edit/{username}")]
        public ActionResult Edit(string username)
        {

            var usernameUsed = username;

            if (string.IsNullOrEmpty(username))
            {
                usernameUsed = User.Identity.Name;
            }

            if (usernameUsed == User.Identity.Name || User.IsInRole("Admin"))
            {
                EditUserVM vm = this.service.GetEditUserVmByUsername(username);
                return View(vm);
            }

            return HttpNotFound("You can not edit this user!");




        }

        [HttpPost]
        public ActionResult Edit(EditUserBM bind)
        {
            string userName = User.Identity.Name;

            if (this.ModelState.IsValid)
            {
                if ( userName == bind.UserName || User.IsInRole("Admin"))
                {
                    this.service.EditUser(bind, userName);
                    return this.RedirectToAction("Profile");
                }


                return HttpNotFound();
            }

            EditUserVM vm = this.service.GetEditUserVm(userName);
            return this.View(vm);
        }


    }
}