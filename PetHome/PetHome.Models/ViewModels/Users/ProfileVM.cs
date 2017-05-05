using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Display(Name = "Lost Pets")]
        public virtual IEnumerable<UserLostPetVM> LostPets { get; set; }

        [Display(Name = "Found Pets")]
        public virtual IEnumerable<UserFoundPetVM> FoundPets { get; set; }

    }
}
