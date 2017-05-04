using PetHome.Models.Enums;

namespace PetHome.Models.ViewModels.Users
{
    public class UserFoundPetVM
    {
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Thumbnail { get; set; }
    }
}
