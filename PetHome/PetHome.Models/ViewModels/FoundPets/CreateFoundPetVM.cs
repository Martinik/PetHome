using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PetHome.Models.ViewModels.FoundPets
{
    public class CreateFoundPetVM
    {
       
        public AnimalType AnimalType { get; set; }
        public string Breed { get; set; }   
        public string LastSeenLocation { get; set; }

        [DataType(DataType.Date)]
        public DateTime? LastSeenTime { get; set; }
        public string DistinguishingFeatures { get; set; }
        public string Description { get; set; }
        public string ActionTaken { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Thumbnail { get; set; }
    }

}
