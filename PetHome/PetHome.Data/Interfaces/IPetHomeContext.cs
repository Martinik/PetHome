using PetHome.Models.EntityModels;
using System.Data.Entity;

namespace PetHome.Data.Interfaces
{
    public interface IPetHomeContext
    {
        DbSet<FoundPet> FoundPets { get; set; }
        DbSet<LostPet> LostPets { get; set; }
        DbSet<Comment> Comments { get; set; }
        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();

        
    }
}
