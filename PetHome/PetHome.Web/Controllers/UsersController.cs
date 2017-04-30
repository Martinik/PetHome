using PetHome.Models.BindingModels;
using PetHome.Models.ViewModels.Users;
using PetHome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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


        // GET: Users
        [HttpGet]
        public ActionResult Profile()
        {
            string userName = User.Identity.Name;
            ProfileVM vm = this.service.GetProfileVm(userName);

            return View(vm);
        }


        [HttpGet]
        public ActionResult Edit()
        {
            string userName = User.Identity.Name;
            EditUserVM vm = this.service.GetEditUserVm(userName);
            return View(vm);

            
        }



        [HttpPost]
        public ActionResult Edit(EditUserBM bind)
        {
            string userName = User.Identity.Name;

            if (this.ModelState.IsValid)
            {

                this.service.EditUser(bind, userName);
                return this.RedirectToAction("Profile");
            }

            EditUserVM vm = this.service.GetEditUserVm(userName);
            return this.View(vm);

        }
    }
}