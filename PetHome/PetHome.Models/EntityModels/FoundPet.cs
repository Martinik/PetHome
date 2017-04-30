using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.EntityModels
{
    public class FoundPet : Pet
    {
        public FoundPet()
        {
            this.DistinguishingFeatures = new HashSet<string>();
        }

        public ICollection<string> DistinguishingFeatures { get; set; }
    }
}
