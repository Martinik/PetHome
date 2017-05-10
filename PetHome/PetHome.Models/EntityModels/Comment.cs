using System;

namespace PetHome.Models.EntityModels
{
    public class Comment
    {
       
        public int Id { get; set; }

      
        public virtual ApplicationUser Author { get; set; }
       // public virtual ICommentable AssociatedPet { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

    }
}
