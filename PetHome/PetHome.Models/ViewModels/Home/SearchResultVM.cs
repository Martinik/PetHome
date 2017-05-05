using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Home
{
    public class SearchResultVM
    {
        [Display(Name = "Lost Pets")]
        public IEnumerable<SearchedLostPetVM> LostPets { get; set; }


        [Display(Name = "Found Pets")]
        public IEnumerable<SearchedFoundPetVM> FoundPets { get; set; }
    }
}
