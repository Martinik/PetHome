using System.Collections.Generic;

namespace PetHome.Models.ViewModels.Admin
{
    public class AdminPanelVM
    {
        public IEnumerable<AdminPanelUserVM> Users { get; set; }
        public IEnumerable<AdminPanelLostPetVM> LostPets { get; set; }
        public IEnumerable<AdminPanelFoundPetVM> FoundPets { get; set; }
    }
}
