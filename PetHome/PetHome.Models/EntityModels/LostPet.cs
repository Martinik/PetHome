using PetHome.Models.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetHome.Models.EntityModels
{
    [Table("LostPets")]
    public class LostPet : Pet
    {

        public LostPet()
        {
            this.IsLostPet = true;
        }
        public string Name { get; set; }
        public int? Age { get; set; }
        public Temper? Temper { get; set; }

    }
}
