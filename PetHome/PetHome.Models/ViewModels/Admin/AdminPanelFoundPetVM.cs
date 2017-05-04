using PetHome.Models.Enums;

namespace PetHome.Models.ViewModels.Admin
{
    public class AdminPanelFoundPetVM
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public AnimalType AnimalType { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
