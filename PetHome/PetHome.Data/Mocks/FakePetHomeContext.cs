using PetHome.Data.Interfaces;
using PetHome.Models.EntityModels;
using System.Data.Entity;

namespace PetHome.Data.Mocks
{
    public class FakePetHomeContext : IPetHomeContext
    {
        public FakePetHomeContext()
        {
            this.Comments = new FakeCommentsDbSet();
            this.FoundPets = new FakeFoundPetsDbSet();
            this.LostPets = new FakeLostPetsDbSet();
            this.Users = new FakeUsersDbSet();
        }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<FoundPet> FoundPets { get; set; }

        public DbSet<LostPet> LostPets { get; set; }

        public IDbSet<ApplicationUser> Users { get; set; }


        public int SaveChanges()
        {
            return 0;
        }
    }
}
