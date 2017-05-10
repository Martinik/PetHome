using PetHome.Models.EntityModels;
using System.Linq;

namespace PetHome.Data.Mocks
{
    public class FakeLostPetsDbSet : FakeDbSet<LostPet>
    {
        public override LostPet Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(pet => pet.Id == wantedId);
        }


        public int Count()
        {
            return this.Set.Count();
        }
    }
}
