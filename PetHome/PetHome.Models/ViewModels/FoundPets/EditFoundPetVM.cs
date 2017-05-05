using PetHome.Models.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PetHome.Models.ViewModels.FoundPets
{
    public class EditFoundPetVM
    {
        public int Id { get; set; }

        [Display(Name = "Breed")]
        public AnimalType AnimalType { get; set; }

        public string Breed { get; set; }

        [Display(Name = "Last Seen Location")]
        public string LastSeenLocation { get; set; }

        [Display(Name = "Last Seen Time")]
        [DataType(DataType.Date)]
        public DateTime? LastSeenTime { get; set; }

        [Display(Name = "Distinguishing Features")]
        public string DistinguishingFeatures { get; set; }

        public string Description { get; set; }

        [Display(Name = "Action Taken")]
        public string ActionTaken { get; set; }


        [DataType(DataType.Upload)]
        public HttpPostedFileBase Thumbnail { get; set; }
    }
}
