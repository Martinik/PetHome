using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PetHome.Models.BindingModels.LostPets
{
    public class EditLostPetBM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Breed { get; set; }
        public int? Age { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime? LastSeenTime { get; set; }
        public string DistinguishingFeatures { get; set; }
        public Temper? Temper { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Thumbnail { get; set; }
    }
}
