using PetHome.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.ViewModels.Users
{
    public class UserPetVM
    {
        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }       
        public string Thumnbail { get; set; }
                   
       
    }
}
