namespace PetHome.Data
{
    using Interfaces;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models.EntityModels;
    using System.Data.Entity;

    public class PetHomeContext : IdentityDbContext<ApplicationUser>, IPetHomeContext
    {
       
        public PetHomeContext()
             : base("PetHome", throwIfV1Schema: false)
        {
        }

        public DbSet<FoundPet> FoundPets { get; set; }
        public DbSet<LostPet> LostPets { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public override IDbSet<ApplicationUser> Users { get; set; }

        public static PetHomeContext Create()
        {
            return new PetHomeContext();
        }

    }

 
}