using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PetHome.Models.EntityModels
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.LostPets = new List<LostPet>();
            this.FoundPets = new List<FoundPet>();
            this.PostedComments = new List<Comment>();
         
        }


        public override string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string Details { get; set; }
        public virtual List<LostPet> LostPets { get; set; }
        public virtual List<FoundPet> FoundPets { get; set; }
        public virtual List<Comment> PostedComments { get; set; }
        public bool IsAdmin { get; set; }



        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            

            return userIdentity;
        }
    }
}
