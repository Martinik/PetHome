using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PetHome.Models.ViewModels.LostPets
{
    public class CreateLostPetVM
    {

        public string Name { get; set; }


        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        public string Breed { get; set; }

        public int? Age { get; set; }


        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        [DataType(DataType.Date)]
        public DateTime? LastSeenTime { get; set; }


        [Display(Name = "Distinguishing Features")]
        public string DistinguishingFeatures { get; set; }

        public Temper? Temper { get; set; }
 
        public string Description { get; set; }

        [DataType(DataType.Upload)]
        public HttpPostedFileBase Thumbnail { get; set; }
    }
}
