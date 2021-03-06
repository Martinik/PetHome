﻿using PetHome.Models.BindingModels.FoundPets;
using PetHome.Models.ViewModels.FoundPets;
using PetHome.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    [RoutePrefix("FoundPets")]
    public class FoundPetsController : Controller
    {
        private IFoundPetsService service;

        public FoundPetsController(IFoundPetsService service)
        {
            this.service = service;
        }

        // GET: FoundPets
        [HttpGet, Route("index")]
        public ActionResult Index()
        {
            IEnumerable<FoundPetVM> vm = this.service.GetFoundPetsVM();


            return View(vm);
        }

        [HttpGet, Route("create")]
        [Authorize]
        public ActionResult Create()
        {
            CreateFoundPetVM vm = new CreateFoundPetVM();

            return View(vm);
        }

        [HttpPost, Route("create")]
        [Authorize]
        public ActionResult Create(CreateFoundPetBM bind)
        {

            var validImageTypes = new string[]
           {
                 "image/gif",
                 "image/jpeg",
                 "image/pjpeg",
                 "image/jpg",
                 "image/png"
           };

            //if (bind.Thumbnail == null || bind.Thumbnail.ContentLength == 0)
            //{
            //    ModelState.AddModelError("Thumbnail", "This field is required");
            //}
            if (bind.Thumbnail != null && (!validImageTypes.Contains(bind.Thumbnail.ContentType)))
            {
                ModelState.AddModelError("Thumbnail", "Please choose either a GIF, JPG or PNG image.");
            }


            if (this.ModelState.IsValid)
            {
                string username = User.Identity.Name;

                this.service.CreateNewFoundPet(bind, username);

                return this.RedirectToAction("Index");
            }

            CreateFoundPetVM vm = new CreateFoundPetVM();

            return View(vm);
        }

        [HttpGet, Route("edit/{id}")]
        [Authorize]
        public ActionResult Edit(int id)
        {
            string username = User.Identity.Name;
            if (this.service.PetBelongsToUser(username, id) || User.IsInRole("Admin"))
            {
                EditFoundPetVM vm = this.service.GetEditPetVM(id);

                return View(vm);
            }


            return RedirectToAction("index", "home");

          
        }


        [HttpPost, Route("edit/{id}")]
        [Authorize]
        public ActionResult Edit(EditFoundPetBM bind)
        {
            string username = User.Identity.Name;

            var validImageTypes = new string[]
             {
                    "image/gif",
                    "image/jpeg",
                    "image/pjpeg",
                    "image/jpg",
                    "image/png"
             };

            if (bind.Thumbnail != null && !validImageTypes.Contains(bind.Thumbnail.ContentType))
            {
                ModelState.AddModelError("Thumbnail", "Please choose either a GIF, JPG or PNG image.");
            }

            if (this.ModelState.IsValid && this.service.PetBelongsToUser(username, bind.Id) || User.IsInRole("Admin"))
            {
                try
                {
                    this.service.EditPet(bind);
                    return RedirectToAction("profile", "users");
                }
                catch (System.Web.HttpException e)
                {
                    ModelState.AddModelError("Thumbnail", e.Message);
                }
            }


            return RedirectToAction("index", "home");

            
        }



        [HttpGet, Route("delete/{id}")]
        [Authorize]
        public ActionResult ConfirmDelete(int id)
        {
            string username = User.Identity.Name;
            if (this.service.PetBelongsToUser(username, id) || User.IsInRole("Admin"))
            {
                FoundPetVM vm = this.service.GetFoundPetVM(username, id);

                return View(vm);
            }

            return RedirectToAction("index", "home");

        }

        [HttpPost, Route("delete/{id}")]
        [Authorize]
        public ActionResult ConfirmDelete(DeleteFoundPetBM bind)
        {
            string username = User.Identity.Name;

            if (ModelState.IsValid && this.service.PetBelongsToUser(username, bind.Id) || User.IsInRole("Admin"))
            {
                this.service.DeleteFoundPet(bind.Id);

                return RedirectToAction("profile", "users");
            }

            return RedirectToAction("index", "home");
        }


        [HttpGet, Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var username = User.Identity.Name;
            var vm = this.service.GetFoundPetVM(username, id);

            return View(vm);

        }
    }
}