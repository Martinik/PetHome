using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.ViewModels;
using PetHome.Models.ViewModels.LostPets;
using PetHome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    [RoutePrefix("LostPets")]
    public class LostPetsController : Controller
    {
        private LostPetsService service;

        public LostPetsController()
        {
            this.service = new LostPetsService();
        }

        // GET: LostPets
        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            IEnumerable<LostPetVM> vm = this.service.GetLostPetsVM();
           

            return View(vm);
        }

        [HttpGet, Route("create")]
        [Authorize]
        public ActionResult Create()
        {
            CreateLostPetVM vm = new CreateLostPetVM();

            return View(vm);
        }

        [HttpPost, Route("create")]
        [Authorize]
        public ActionResult Create(CreateLostPetBM bind)
        {
            if (this.ModelState.IsValid)
            {
                string username = User.Identity.Name;

                this.service.CreateNewLostPet(bind, username);

                return this.RedirectToAction("Index");
            }

            CreateLostPetVM vm = new CreateLostPetVM();

            return View(vm);
        }

        [HttpGet, Route("edit/{id}")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            string username = User.Identity.Name;
            if (this.service.PetBelongsToUser(username, id))
            {
                EditLostPetVM vm = this.service.GetEditPetVM(id);

                return View(vm);
            }


            return RedirectToAction("index", "home");

            //TODO:  add custom redirect/ error message
        }
    }
}