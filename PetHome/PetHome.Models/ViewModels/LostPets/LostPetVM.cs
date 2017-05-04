using PetHome.Models.Enums;
using PetHome.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;

namespace PetHome.Models.ViewModels.LostPets
{
    public class LostPetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public AnimalType AnimalType { get; set; }
        public string ThumbnailUrl { get; set; }
        public string AssociatedUsername { get; set; }
        public IEnumerable<CommentVM> Comments { get; set; }
        public bool IsLostPet { get; set; }

    }
}
