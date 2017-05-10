using PetHome.Models.EntityModels;
using System.Linq;

namespace PetHome.Data.Mocks
{
    public class FakeFoundPetsDbSet : FakeDbSet<FoundPet>
    {
        public override FoundPet Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(pet => pet.Id == wantedId);
        }
    }
}
