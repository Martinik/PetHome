using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetHome.Data.Interfaces;
using PetHome.Data.Mocks;
using PetHome.Models.BindingModels.FoundPets;
using PetHome.Models.BindingModels.Home;
using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.EntityModels;
using PetHome.Models.Enums;
using PetHome.Models.ViewModels.Admin;
using PetHome.Models.ViewModels.Comments;
using PetHome.Models.ViewModels.FoundPets;
using PetHome.Models.ViewModels.Home;
using PetHome.Models.ViewModels.LostPets;
using PetHome.Models.ViewModels.Users;
using PetHome.Services;
using PetHome.Services.Interfaces;
using PetHome.Web.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace PetHome.Tests
{
    [TestClass]
    public class HomeControllerTests
    {
        private HomeController _controller;
        private IHomeService _service;
        private IPetHomeContext _context;
        private List<LostPet> lostPets;
        private List<FoundPet> foundPets;

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<ApplicationUser, ProfileVM>();
                expression.CreateMap<LostPet, UserLostPetVM>();
                expression.CreateMap<FoundPet, UserFoundPetVM>();
                expression.CreateMap<ApplicationUser, EditUserVM>();
                expression.CreateMap<LostPet, LostPetVM>();
                expression.CreateMap<CreateLostPetBM, LostPet>();
                expression.CreateMap<LostPet, EditLostPetVM>();
                expression.CreateMap<FoundPet, FoundPetVM>();
                expression.CreateMap<CreateFoundPetBM, FoundPet>();
                expression.CreateMap<FoundPet, EditFoundPetVM>();
                expression.CreateMap<Comment, CommentVM>();
                expression.CreateMap<ApplicationUser, CommentUserVM>();
                expression.CreateMap<LostPet, SearchedLostPetVM>();
                expression.CreateMap<FoundPet, SearchedFoundPetVM>();
                expression.CreateMap<LostPet, AdminPanelLostPetVM>();
                expression.CreateMap<FoundPet, AdminPanelFoundPetVM>();
                expression.CreateMap<ApplicationUser, AdminPanelUserVM>();
                expression.CreateMap<ApplicationUser, NavBarUserVM>();


            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMappings();

            this._context = new FakePetHomeContext();

            this.lostPets = new List<LostPet>()
            {
                new LostPet()
                {
                     Id = 1,
                     Name = "Simba",
                     AnimalType = AnimalType.Cat,
                     AssociatedUser = null,
                     Breed = "Lion",
                     IsLostPet = true,
                     LastSeenLocation = "South Park",
                     LastSeenTime = DateTime.Today
                },
                new LostPet()
                {
                     Id = 2,
                     Name = "Sonic",
                     AnimalType = AnimalType.Rodent,
                     AssociatedUser = null,
                     Breed = "Hedgehog",
                     IsLostPet = true,
                     LastSeenLocation = "West Park",
                     LastSeenTime = DateTime.Today
                }
            };

            this.foundPets = new List<FoundPet>()
            {
                new FoundPet()
                {
                    Id = 1,
                     AnimalType = AnimalType.Snake,
                     AssociatedUser = null,
                     Breed = "Rattlesnake",
                     IsLostPet = false,
                     LastSeenLocation = "West Park",
                     LastSeenTime = DateTime.Today,
                     ActionTaken = "nothing"
                },
                new FoundPet()
                {
                    Id = 2,
                     AnimalType = AnimalType.Dog,
                     AssociatedUser = null,
                     Breed = "Rattlesnake",
                     IsLostPet = false,
                     LastSeenLocation = "West Park",
                     LastSeenTime = DateTime.Today,
                     ActionTaken = "nothing"
                }

            };

            foreach (var pet in lostPets)
            {
                this._context.LostPets.Add(pet);
            }
            foreach (var pet in foundPets)
            {
                this._context.FoundPets.Add(pet);
            }
   

            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

           

            this._service = new HomeService(this._context);
            this._controller = new HomeController(this._service);

            //
            this._controller.ControllerContext = controllerContext.Object;
           

        }


        [TestMethod]
        public void Index_ShouldReturnDefaultView()
        {
            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Index_ShouldReturnCorrectVm()
        {
            HomeIndexVM vm = new HomeIndexVM();

            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<HomeIndexVM>();
        }

        [TestMethod]
        public void Index_ShouldReturnRightPetCount()
        {
            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
    .WithModel<HomeIndexVM>(m => m.LostPets.ToList().Count == 2);

            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
    .WithModel<HomeIndexVM>(m => m.FoundPets.ToList().Count == 2);
        }

        [TestMethod]
        public void Search_ShouldReturnRightVm()
        {
            SearchBM bm = new SearchBM() { SearchContent = "South Park" };

            this._controller.WithCallTo(c => c.Search(bm)).ShouldRenderDefaultView()
    .WithModel<SearchResultVM>();
        }

        [TestMethod]
        public void Search_ShouldFindResults()
        {
            SearchBM bm = new SearchBM() { SearchContent = "South Park" };

            this._controller.WithCallTo(c => c.Search(bm)).ShouldRenderDefaultView()
    .WithModel<SearchResultVM>(r => (r.FoundPets.Count() > 0) || (r.LostPets.Count() > 0));
        }


        [TestMethod]
        public void GetLoginPartial_ShouldReturnCorrectView()
        {
            this._controller.WithCallTo(c => c.GetLoginPartial()).ShouldRenderPartialView("_LoginPartial");
        }

        [TestMethod]
        public void GetLoginPartial_ShouldReturnCorrectVm()
        {
            this._context.Users.Add(new ApplicationUser()
            {
                UserName = "User"
            });

            this._controller.WithCallTo(c => c.GetLoginPartial()).ShouldRenderPartialView("_LoginPartial").WithModel<NavBarUserVM>();
        }



    }
}
