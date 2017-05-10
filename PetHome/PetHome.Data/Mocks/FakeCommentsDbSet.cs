using PetHome.Models.EntityModels;
using System.Linq;

namespace PetHome.Data.Mocks
{
    public class FakeCommentsDbSet : FakeDbSet<Comment>
    {
        public override Comment Find(params object[] keyValues)
        {
            int wantedId = (int)keyValues[0];
            return this.Set.FirstOrDefault(comment => comment.Id == wantedId);
        }
    }
}
