using PetHome.Models.Enums;
using PetHome.Models.Interfaces;
using System;
using System.Collections.Generic;

namespace PetHome.Models.EntityModels
{

    public abstract class Pet : ICommentable
    {
        public Pet()
        {
            //this.Images = new List<string>();
            this.Comments = new List<Comment>();
        }

      
        public int Id { get; set; }

       
        public AnimalType AnimalType { get; set; }
        public string Breed { get; set; }
        public string ThumbnailUrl { get; set; }

       // public List<string> Images { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser AssociatedUser { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime? LastSeenTime { get; set; }
        public string DistinguishingFeatures { get; set; }
        public bool IsLostPet { get; set; }

    }
}
