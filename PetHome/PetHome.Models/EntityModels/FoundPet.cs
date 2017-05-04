using System.ComponentModel.DataAnnotations.Schema;

namespace PetHome.Models.EntityModels
{
    [Table("FoundPets")]
    public class FoundPet : Pet
    {
        public FoundPet()
        {
            this.IsLostPet = false;
        }
        public string ActionTaken { get; set; }


    }
}
