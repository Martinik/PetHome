using PetHome.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.EntityModels
{
    public class LostPet : Pet
    {
      

        public string Name { get; set; }
        public int? Age { get; set; }
        public string LastSeenLocation { get; set; }
        public DateTime? LastSeenTime { get; set; }
        public string DistinguishingFeatures { get; set; }
        public Temper? Temper { get; set; }

    }
}
