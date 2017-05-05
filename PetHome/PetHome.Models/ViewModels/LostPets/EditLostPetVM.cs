using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.LostPets
{
    public class EditLostPetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        public string Breed { get; set; }

        public int? Age { get; set; }

        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        public DateTime? LastSeenTime { get; set; }

        [Display(Name = "Distinguishing Features")]
        public string DistinguishingFeatures { get; set; }

        public Temper? Temper { get; set; }

        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; }

        public string Description { get; set; }  

    }
}
