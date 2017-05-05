using PetHome.Models.Enums;
using PetHome.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.LostPets
{
    public class LostPetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        public DateTime LastSeenTime { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; }

        [Display(Name = "Associated Username")]
        public string AssociatedUsername { get; set; }

        public IEnumerable<CommentVM> Comments { get; set; }

        [Display(Name = "Is Lost")]
        public bool IsLostPet { get; set; }

    }
}
