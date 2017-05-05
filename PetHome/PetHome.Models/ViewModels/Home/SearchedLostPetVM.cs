using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchedLostPetVM
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

        [Display(Name = "Distinguishing Features")]
        public string DistinguishingFeatures { get; set; }

        public Temper Temper { get; set; }

        public string Description { get; set; }

        public string Thumbnail { get; set; }

        [Display(Name = "Associated User")]
        public string AssociatedUsername { get; set; }

        [Display(Name = "Is Lost")]
        public bool IsLostPet { get; set; }

        [Display(Name = "Search Score")]
        public int SearchScore { get; set; }

    }
}



