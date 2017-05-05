using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchedFoundPetVM
    {
        public int Id { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        public DateTime LastSeenTime { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        public string Description { get; set; }

        [Display(Name = "Distinguishing Features")]
        public string DistinguishingFeatures { get; set; }

        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }

        public string Thumbnail { get; set; }

        [Display(Name = "Associated User")]
        public string AssociatedUsername { get; set; }

        [Display(Name = "Is Lost")]
        public bool IsLostPet { get; set; }

        [Display(Name = "Search Score")]
        public int SearchScore { get; set; }

    }
}
