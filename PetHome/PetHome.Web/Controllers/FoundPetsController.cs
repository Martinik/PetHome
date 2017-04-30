using PetHome.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    
    public class FoundPetsController : Controller
    {
        private FoundPetsService service;

        public FoundPetsController()
        {
            this.service = new FoundPetsService();
        }
        // GET: FoundPets
        public ActionResult Index()
        {
            return View();
        }
    }
}