using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.ViewModels.LostPets;
using PetHome.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    [RoutePrefix("LostPets")]
    public class LostPetsController : Controller
    {
        private ILostPetsService service;

        public LostPetsController(ILostPetsService service)
        {
            this.service = service;
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
            if (this.service.PetBelongsToUser(username, id) || User.IsInRole("Admin"))
            {
                EditLostPetVM vm = this.service.GetEditPetVM(id);

                return View(vm);
            }


            return RedirectToAction("index", "home");
            
        }


        [HttpPost, Route("edit/{id}")]
        [Authorize]
        public ActionResult Edit(EditLostPetBM bind)
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

            //if (bind.Thumbnail == null || bind.Thumbnail.ContentLength == 0)
            //{
            //    ModelState.AddModelError("Thumbnail", "This field is required");
            //}
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
                LostPetVM vm = this.service.GetLostPetVM(username, id);

                return View(vm);
            }

            return RedirectToAction("index", "home");
            
        }

        [HttpPost, Route("delete/{id}")]
        [Authorize]
        public ActionResult ConfirmDelete(DeleteLostPetBM bind)
        {
            string username = User.Identity.Name;

            if (ModelState.IsValid && this.service.PetBelongsToUser(username, bind.Id) || User.IsInRole("Admin"))
            {
                this.service.DeleteLostPet(bind.Id);

                return RedirectToAction("profile", "users");
            }

            return RedirectToAction("index", "home");
         
        }


        [HttpGet, Route("details/{id}")]
        public ActionResult Details(int id)
        {
            var username = User.Identity.Name;
            var vm = this.service.GetLostPetVM(username, id);

            return View(vm);

        }
    }
}