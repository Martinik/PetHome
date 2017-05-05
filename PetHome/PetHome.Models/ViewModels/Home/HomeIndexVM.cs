using PetHome.Models.ViewModels.FoundPets;
using PetHome.Models.ViewModels.LostPets;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Home
{
    public class HomeIndexVM
    {
        [Display(Name = "Lost Pets")]
        public IEnumerable<LostPetVM> LostPets { get; set; }

        [Display(Name = "Found Pets")]
        public IEnumerable<FoundPetVM> FoundPets { get; set; }
    }
}
