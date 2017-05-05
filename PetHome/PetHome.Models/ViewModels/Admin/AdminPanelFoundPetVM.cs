using PetHome.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Admin
{
    public class AdminPanelFoundPetVM
    {
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Display(Name = "Breed")]
        public string Breed { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }

        [Display(Name = "Thumbnail")]
        public string ThumbnailUrl { get; set; }
    }
}
