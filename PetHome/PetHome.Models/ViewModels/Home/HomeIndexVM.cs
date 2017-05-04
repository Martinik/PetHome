using PetHome.Models.ViewModels.FoundPets;
using PetHome.Models.ViewModels.LostPets;
using System.Collections.Generic;

namespace PetHome.Models.ViewModels.Home
{
    public class HomeIndexVM
    {
        public IEnumerable<LostPetVM> LostPets { get; set; }
        public IEnumerable<FoundPetVM> FoundPets { get; set; }
    }
}
