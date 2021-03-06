﻿using System.Collections.Generic;
using PetHome.Models.ViewModels.Admin;
using AutoMapper;
using PetHome.Models.EntityModels;
using PetHome.Services.Interfaces;
using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public class AdminService : Service, IAdminService
    {
        public AdminService(IPetHomeContext context)
            :base(context)
        {
        }

        public AdminPanelVM GetAdminPanelVM()
        {
            var lostPets = this.Context.LostPets;
            var foundPets = this.Context.FoundPets;
            var users = this.Context.Users;

            var lostPetsVm = Mapper.Map<IEnumerable<LostPet>, IEnumerable<AdminPanelLostPetVM>>(lostPets);
            var foundPetsVm = Mapper.Map<IEnumerable<FoundPet>, IEnumerable<AdminPanelFoundPetVM>>(foundPets);
            var usersVm = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AdminPanelUserVM>>(users);

            var adminPanelVm = new AdminPanelVM
            {
                Users = usersVm,
                LostPets = lostPetsVm,
                FoundPets = foundPetsVm
            };

            return adminPanelVm;
        }
    }
}
