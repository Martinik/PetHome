using AutoMapper;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHome.Models.BindingModels;

namespace PetHome.Services
{
    public class UsersService : Service
    {
        public ProfileVM GetProfileVm(string userName)
        {

            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            ProfileVM vm = Mapper.Map<ApplicationUser, ProfileVM>(currentUser);

            IEnumerable<LostPet> lostPets = currentUser.LostPets;
            IEnumerable<FoundPet> foundPets = currentUser.FoundPets;

            vm.LostPets = Mapper.Map<IEnumerable<LostPet>, IEnumerable<UserPetVM>>(lostPets);
            vm.FoundPets = Mapper.Map<IEnumerable<FoundPet>, IEnumerable<UserPetVM>>(foundPets);

            return vm;
        }

        public EditUserVM GetEditUserVm(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(u => u.UserName == userName);
            EditUserVM vm = Mapper.Map<ApplicationUser, EditUserVM>(currentUser);

            return vm;
        }

        public void EditUser(EditUserBM bind, string userName)
        {

            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == userName);

            user.Name = bind.Name;
            user.Surname = bind.Surname;
            user.Skype = bind.Skype;
            user.Facebook = bind.Facebook;
            user.Details = bind.Details;

            this.Context.SaveChanges();



        }
    }
}
