using System.Collections.Generic;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchResultVM
    {
        public IEnumerable<SearchedLostPetVM> LostPets { get; set; }
        public IEnumerable<SearchedFoundPetVM> FoundPets { get; set; }
    }
}
