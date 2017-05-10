using PetHome.Models.BindingModels.Comments;
using PetHome.Services.Interfaces;
using System.Web.Mvc;

namespace PetHome.Web.Controllers
{
    [Authorize]
    public class CommentsController : Controller
    {
        private ICommentsService service;

        public CommentsController(ICommentsService service)
        {
            this.service = service;
        }

        [HttpPost, Route("AddComment")]
        public ActionResult AddComment(AddComentBM bind)
        {
            if (ModelState.IsValid)
            {
                this.service.AddComment(bind);
            }

            if (bind.IsLostPet)
            {
                return RedirectToAction("Details", "LostPets", new { id = bind.PetId });
            }

            return RedirectToAction("Details", "FoundPets", new { id = bind.PetId });

        }
    }
}