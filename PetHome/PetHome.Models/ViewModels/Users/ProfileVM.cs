using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.ViewModels.Users
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Details { get; set; }
        public virtual IEnumerable<UserPetVM> LostPets { get; set; }
        public virtual IEnumerable<UserPetVM> FoundPets { get; set; }

    }
}
