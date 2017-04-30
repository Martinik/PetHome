using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHome.Models.ViewModels;
using AutoMapper;
using PetHome.Models.EntityModels;
using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.ViewModels.LostPets;

namespace PetHome.Services
{
    public class LostPetsService : Service
    {
        public IEnumerable<LostPetVM> GetLostPetsVM()
        {
            IEnumerable<LostPetVM> vm = this.Context.LostPets.ToList().Select(pet => Mapper.Map<Pet, LostPetVM>(pet)).ToList();

            return vm;
        }

        public void CreateNewLostPet(CreateLostPetBM bind, string username)
        {
            LostPet lostPet = Mapper.Map<CreateLostPetBM, LostPet>(bind);

            ApplicationUser associatedUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);
            lostPet.AssociatedUser = associatedUser;
            associatedUser.LostPets.Add(lostPet);
            //this.Context.LostPets.Add(lostPet);
            this.Context.SaveChanges();

        }

        public bool PetBelongsToUser(string username, int id)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user.LostPets.Any(pet => pet.Id == id))
            {
                return true;
            }
            //LostPet lostPet = this.Context.LostPets.FirstOrDefault(p => p.Id == id);
            //if (lostPet.AssociatedUser.UserName == username)
            //{
            //    return true;
            //}

            return false;
        }

        public EditLostPetVM GetEditPetVM(int id)
        {
            LostPet lostPet = this.Context.LostPets.FirstOrDefault(p => p.Id == id);

            EditLostPetVM vm = Mapper.Map<LostPet, EditLostPetVM>(lostPet);

            return vm;
        }
    }
}
