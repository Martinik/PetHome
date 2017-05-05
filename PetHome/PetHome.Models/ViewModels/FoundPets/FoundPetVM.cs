using PetHome.Models.Enums;
using PetHome.Models.ViewModels.Comments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.FoundPets
{
    public class FoundPetVM
    {
        public int Id { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        public DateTime LastSeenTime { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; }

        [Display(Name = "Associated User")]
        public string AssociatedUsername { get; set; }

        public IEnumerable<CommentVM> Comments { get; set; }

        [Display(Name = "Is Lost")]
        public bool IsLostPet { get; set; }

        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }

        public string Description { get; set; }


    }
}
