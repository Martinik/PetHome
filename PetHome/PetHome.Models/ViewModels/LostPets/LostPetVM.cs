using PetHome.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.ViewModels
{
    public class LostPetVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Breed { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime LastSeenTime { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Thumnbail { get; set; }

    }
}
