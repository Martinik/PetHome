using PetHome.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Users
{
    public class UserLostPetVM
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [Display(Name = "Animal Type")]
        public AnimalType AnimalType { get; set; }   
            
        public string Thumbnail { get; set; }
                   
       
    }
}
