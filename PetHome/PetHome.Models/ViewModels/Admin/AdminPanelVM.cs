using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Admin
{
    public class AdminPanelVM
    {
        [Display(Name = "Users")]
        public IEnumerable<AdminPanelUserVM> Users { get; set; }

        [Display(Name = "Lost Pets")]
        public IEnumerable<AdminPanelLostPetVM> LostPets { get; set; }

        [Display(Name = "Found Pets")]
        public IEnumerable<AdminPanelFoundPetVM> FoundPets { get; set; }
    }
}
