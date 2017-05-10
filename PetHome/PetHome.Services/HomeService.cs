using System;
using System.Collections.Generic;
using System.Linq;
using PetHome.Models.ViewModels.Home;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.LostPets;
using AutoMapper;
using PetHome.Models.ViewModels.FoundPets;
using PetHome.Models.BindingModels.Home;
using PetHome.Services.Interfaces;
using PetHome.Data.Interfaces;

namespace PetHome.Services
{
    public class HomeService : Service, IHomeService
    {

        public HomeService(IPetHomeContext context)
            :base(context)
        {
        }

        public string GetNameOfUser(string username)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            if (user != null)
            {
                return user.Name;
            }

            return null;

        }

        public HomeIndexVM GetHomeIndexVM()
        {
            IEnumerable<LostPet> lostPets = this.Context.LostPets.ToList().OrderBy(pet => pet.LastSeenTime).Take(10);
            IEnumerable<FoundPet> foundPets = this.Context.FoundPets.ToList().OrderBy(pet => pet.LastSeenTime).Take(10);

            IEnumerable<LostPetVM> lostPetsVm = Mapper.Map<IEnumerable<LostPet>, IEnumerable<LostPetVM>>(lostPets);
            IEnumerable<FoundPetVM> foundPetsVm = Mapper.Map<IEnumerable<FoundPet>, IEnumerable<FoundPetVM>>(foundPets);

            HomeIndexVM vm = new HomeIndexVM
            {
                LostPets = lostPetsVm,
                FoundPets = foundPetsVm
            };

            return vm;

        }

        public SearchResultVM GetSearchResultVM(SearchBM bind)
        {
            IEnumerable<LostPet> lostPets = this.Context.LostPets;
            IEnumerable<FoundPet> foundPets = this.Context.FoundPets;

            IEnumerable<SearchedLostPetVM> lostVM = Mapper.Map<IEnumerable<LostPet>, IEnumerable<SearchedLostPetVM>>(lostPets);
            IEnumerable<SearchedFoundPetVM> foundVM = Mapper.Map<IEnumerable<FoundPet>, IEnumerable<SearchedFoundPetVM>>(foundPets);

            foreach (var lostPet in lostVM)
            {
                lostPet.SearchScore = GetLostPetSearchScore(lostPet, bind.SearchContent.ToLower());
            }

            foreach (var foundPet in foundVM)
            {
                foundPet.SearchScore = GetFoundPetSearchScore(foundPet, bind.SearchContent.ToLower());
            }

            lostVM = lostVM.Where(p => p.SearchScore > 0).OrderByDescending(p => p.SearchScore);
            foundVM = foundVM.Where(p => p.SearchScore > 0).OrderByDescending(p => p.SearchScore);

            SearchResultVM vm = new SearchResultVM
            {
                FoundPets = foundVM,
                LostPets = lostVM
            };

            return vm;

        }

        private int GetFoundPetSearchScore(SearchedFoundPetVM pet, string searchContent)
        {
            List<string> words = searchContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int score = 0;
            foreach (var keyWord in words)
            {
                bool matchedBreed = (!string.IsNullOrEmpty(pet.Breed)) && pet.Breed.ToLower().Contains(keyWord);
                bool matchedAnimalType = (!string.IsNullOrEmpty(pet.AnimalType.ToString())) && pet.AnimalType.ToString().ToLower().Contains(keyWord.ToLower());
                
                bool matchedDescription = (!string.IsNullOrEmpty(pet.Description)) && pet.Description.ToLower().Contains(keyWord.ToLower()) ;
                bool matchedLocation = (!string.IsNullOrEmpty(pet.LastSeenLocation)) && pet.LastSeenLocation.ToLower().Contains(keyWord.ToLower());
                bool matchedFeatures =(!string.IsNullOrEmpty(pet.DistinguishingFeatures)) && pet.DistinguishingFeatures.ToLower().Contains(keyWord.ToLower());
                bool matchedAction = (!string.IsNullOrEmpty(pet.ActionTaken)) && pet.ActionTaken.ToString().ToLower().Contains(keyWord.ToLower());

                List<bool> checks = new List<bool>
                {
                    matchedBreed,
                    matchedAnimalType,
                    matchedDescription,
                    matchedLocation,
                    matchedFeatures,
                    matchedAction
                };

                foreach (var check in checks)
                {
                    if (check)
                    {
                        score++;
                    }
                }
            }

            return score;
        }

        private int GetLostPetSearchScore(SearchedLostPetVM pet, string searchContent)
        {
            List<string> words = searchContent.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            int score = 0;
            foreach (var keyWord in words)
            {
                bool matchedBreed = (!string.IsNullOrEmpty(pet.Breed)) && pet.Breed.ToLower().Contains(keyWord.ToLower());
                bool matchedAnimalType = (!string.IsNullOrEmpty(pet.AnimalType.ToString())) && pet.AnimalType.ToString().ToLower().Contains(keyWord.ToLower());
                bool matchedName = (!string.IsNullOrEmpty(pet.Name)) && pet.Name.ToLower().Contains(keyWord.ToLower());
                bool matchedDescription = (!string.IsNullOrEmpty(pet.Description)) && pet.Description.ToLower().Contains(keyWord.ToLower());
                bool matchedLocation = (!string.IsNullOrEmpty(pet.LastSeenLocation)) && pet.LastSeenLocation.ToLower().Contains(keyWord.ToLower());
                bool matchedFeatures = (!string.IsNullOrEmpty(pet.DistinguishingFeatures)) && pet.DistinguishingFeatures.ToLower().Contains(keyWord.ToLower());
                bool matchedTemper = (!string.IsNullOrEmpty(pet.Temper.ToString())) && pet.Temper.ToString().ToLower().Contains(keyWord.ToLower());

                List<bool> checks = new List<bool>
                {
                    matchedBreed,
                    matchedAnimalType,
                    matchedName,
                    matchedDescription,
                    matchedLocation,
                    matchedFeatures,
                    matchedTemper
                };

                foreach (var check in checks)
                {
                    if (check)
                    {
                        score++;
                    }
                }
            }

            return score;
        }

        public NavBarUserVM GetNavBarUserVM(string username)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            NavBarUserVM vm = Mapper.Map<ApplicationUser, NavBarUserVM>(user);
            return vm;
        }
    }
}
