using System.Collections.Generic;

namespace PetHome.Models.ViewModels.Users
{
    public class ProfileVM
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Details { get; set; }
        public virtual IEnumerable<UserLostPetVM> LostPets { get; set; }
        public virtual IEnumerable<UserFoundPetVM> FoundPets { get; set; }

    }
}
