using PetHome.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetHome.Models.EntityModels
{
    public abstract class Pet
    {
        public Pet()
        {
            this.Images = new HashSet<string>();
            this.Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public AnimalType AnimalType { get; set; }
        public string Breed { get; set; }
        public string Thumnbail { get; set; }
        public ICollection<string> Images { get; set; }
        public string Description { get; set; }
        public virtual ApplicationUser AssociatedUser { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }


    }
}
