using PetHome.Models.Enums;

namespace PetHome.Models.ViewModels.Users
{
    public class UserLostPetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public AnimalType AnimalType { get; set; }       
        public string Thumbnail { get; set; }
                   
       
    }
}
