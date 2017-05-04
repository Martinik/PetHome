using PetHome.Models.Enums;
using System;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchedLostPetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public AnimalType AnimalType { get; set; }
        public string DistinguishingFeatures { get; set; }
        public Temper Temper { get; set; }
        public string Description { get; set; }
        public string Thumbnail { get; set; }
        public string AssociatedUsername { get; set; }
        public bool IsLostPet { get; set; }
        public int SearchScore { get; set; }

    }
}
