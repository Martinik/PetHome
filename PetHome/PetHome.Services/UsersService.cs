using AutoMapper;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.Users;
using System.Collections.Generic;
using System.Linq;
using PetHome.Models.BindingModels;
using PetHome.Services.Interfaces;
using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public class UsersService : Service, IUsersService
    {
        public UsersService(IPetHomeContext context)
            :base(context)
        {

        }

        public ProfileVM GetProfileVm(string userName)
        {

            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            if (currentUser == null)
            {
                return null;
            }
            ProfileVM vm = Mapper.Map<ApplicationUser, ProfileVM>(currentUser);

            IEnumerable<LostPet> lostPets = currentUser.LostPets;
            IEnumerable<FoundPet> foundPets = currentUser.FoundPets;

            vm.LostPets = Mapper.Map<IEnumerable<LostPet>, IEnumerable<UserLostPetVM>>(lostPets);
            vm.FoundPets = Mapper.Map<IEnumerable<FoundPet>, IEnumerable<UserFoundPetVM>>(foundPets);

            return vm;
        }

        public EditUserVM GetEditUserVm(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditUserVM vm = Mapper.Map<ApplicationUser, EditUserVM>(currentUser);

            return vm;
        }

        public EditUserVM GetEditUserVmByUsername(string username)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);
            EditUserVM vm = Mapper.Map<ApplicationUser, EditUserVM>(user);
            
            return vm;
        }

        public void EditUser(EditUserBM bind, string userName)
        {

            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == bind.UserName);

            user.Name = bind.Name;
            user.Surname = bind.Surname;
            user.Skype = bind.Skype;
            user.Facebook = bind.Facebook;
            user.Details = bind.Details;

            this.Context.SaveChanges();



        }
    }
}
