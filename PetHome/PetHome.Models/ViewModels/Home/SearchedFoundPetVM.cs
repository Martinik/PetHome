using PetHome.Models.Enums;
using System;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchedFoundPetVM
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Description { get; set; }
        public string DistinguishingFeatures { get; set; }
        public string ActionTaken { get; set; }
        public string Thumbnail { get; set; }
        public string AssociatedUsername { get; set; }
        public bool IsLostPet { get; set; }
        public int SearchScore { get; set; }

    }
}
