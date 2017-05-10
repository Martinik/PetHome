using System;
using System.Linq;
using PetHome.Models.BindingModels.Comments;
using PetHome.Models.EntityModels;
using PetHome.Services.Interfaces;
using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public class CommentsService : Service, ICommentsService
    {
        public CommentsService(IPetHomeContext context)
            :base(context)
        {
        }

        public void AddComment(AddComentBM bind)
        {      
            var author = this.Context.Users.FirstOrDefault(u => u.UserName == bind.Username);

            Comment comment = new Comment
            {
                Author = author,
                Content = bind.Content,
                DatePosted = DateTime.Now,
            };

            if (bind.IsLostPet)
            {
                LostPet lostPet = this.Context.LostPets.FirstOrDefault(p => p.Id == bind.PetId);
                lostPet.Comments.Add(comment);
            }
            else
            {
                FoundPet foundPet = this.Context.FoundPets.FirstOrDefault(p => p.Id == bind.PetId);
                foundPet.Comments.Add(comment);
            }

            this.Context.SaveChanges();
        }
    }
}
