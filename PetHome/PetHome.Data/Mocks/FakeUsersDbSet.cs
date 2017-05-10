using PetHome.Models.EntityModels;
using System.Linq;

namespace PetHome.Data.Mocks
{
    public class FakeUsersDbSet : FakeDbSet<ApplicationUser>
    {
        public override ApplicationUser Find(params object[] keyValues)
        {
            var wantedId = (string)keyValues[0];
            return this.Set.FirstOrDefault(user => user.Id == wantedId);
        }
    }
}
