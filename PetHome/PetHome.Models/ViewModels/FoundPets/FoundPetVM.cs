using PetHome.Models.Enums;
using PetHome.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;

namespace PetHome.Models.ViewModels.FoundPets
{
    public class FoundPetVM
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public AnimalType AnimalType { get; set; }
        public string ThumbnailUrl { get; set; }
        public string AssociatedUsername { get; set; }
        public IEnumerable<CommentVM> Comments { get; set; }
        public bool IsLostPet { get; set; }
        public string ActionTaken { get; set; }
        public string Description { get; set; }


    }
}
