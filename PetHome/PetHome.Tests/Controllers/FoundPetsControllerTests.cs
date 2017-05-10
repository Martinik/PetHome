using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetHome.Data.Interfaces;
using PetHome.Data.Mocks;
using PetHome.Models.BindingModels.FoundPets;
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
    public class FoundPetsControllerTests
    {
        private FoundPetsController _controller;
        private IFoundPetsService _service;
        private IPetHomeContext _context;
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

            this.foundPets = new List<FoundPet>()
            {
                new FoundPet()
                {
                     Id = 1,
                     AnimalType = AnimalType.Cat,
                     AssociatedUser = null,
                     Breed = "Lion",
                     IsLostPet = false,
                     LastSeenLocation = "South Park",
                     LastSeenTime = DateTime.Today,
                      ActionTaken = "Nothing"
                },
                new FoundPet()
                {
                     Id = 2,
                     AnimalType = AnimalType.Rodent,
                     AssociatedUser = null,
                     Breed = "Hedgehog",
                     IsLostPet = false,
                     LastSeenLocation = "West Park",
                     LastSeenTime = DateTime.Today,
                      ActionTaken = "Nothing"
                }
            };

            foreach (var pet in foundPets)
            {
                this._context.FoundPets.Add(pet);
            }

            //
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, new string[] { "Admin" });

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            this._service = new FoundPetsService(this._context);
            this._controller = new FoundPetsController(this._service);
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
            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
                .WithModel<IEnumerable<FoundPetVM>>();
        }

        [TestMethod]
        public void Index_ShouldReturnRightPetCount()
        {
            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
    .WithModel<IEnumerable<FoundPetVM>>(m => m.Count() == 2);

        }

        [TestMethod]
        public void Create_ShouldReturnDefaultView()
        {
            this._controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Create_ShouldReturnDefaultVm()
        {
            this._controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView().WithModel<CreateFoundPetVM>();
        }

        [TestMethod]
        public void Create_ShouldSuccessfullyCreate()
        {
            CreateFoundPetBM bm = new CreateFoundPetBM()
            {
                AnimalType = AnimalType.Other,        
                Breed = "Test Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                ActionTaken = "nothing",
                Thumbnail = null
            };

            this._controller.Create(bm);

            Assert.AreEqual(3, this._context.FoundPets.Count());
        }

        [TestMethod]
        public void Create_ShouldRedirectToIndex()
        {
            CreateFoundPetBM bm = new CreateFoundPetBM()
            {
                AnimalType = AnimalType.Other,
                Breed = "Test Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                ActionTaken = "nothing",
                Thumbnail = null
            };

            this._controller.WithCallTo(c => c.Create(bm)).ShouldRedirectToRoute("");
        }


        [TestMethod]
        public void Edit_ShouldReturnCorrectViewAndModel()
        {
            this._controller.WithCallTo(c => c.Edit(1)).ShouldRenderDefaultView().WithModel<EditFoundPetVM>();
        }

        [TestMethod]
        public void Edit_ShouldEditSuccessfully()
        {

            EditFoundPetBM bm = new EditFoundPetBM()
            {
                AnimalType = AnimalType.Other,
                Breed = "Edited Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                Thumbnail = null,
                Id = 1,
                ActionTaken = "Edited"
            };

            this._controller.Edit(bm);

            Assert.AreEqual("Edited", this._context.FoundPets.Find(1).ActionTaken);
        }

        [TestMethod]
        public void Edit_ShouldRedirectSuccessfully()
        {

            EditFoundPetBM bm = new EditFoundPetBM()
            {
                AnimalType = AnimalType.Other,
                
                Breed = "Edited Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                ActionTaken = "nothing",
                Thumbnail = null,
                Id = 1
            };

            this._controller.WithCallTo(c => c.Edit(bm)).ShouldRedirectToRoute("");
        }


        //

        [TestMethod]
        public void Delete_ShouldReturnCorrectViewAndModel()
        {
           this. _controller.WithCallTo(c => c.ConfirmDelete(1)).ShouldRenderDefaultView().WithModel<FoundPetVM>();
        }

        [TestMethod]
        public void Delete_ShouldDeleteSuccessfully()
        {
            DeleteFoundPetBM bm = new DeleteFoundPetBM()
            {
                Id = 1
            };

            this._controller.ConfirmDelete(bm);

            Assert.AreEqual(null, this._context.FoundPets.FirstOrDefault(pet => pet.Id == 1));
        }

        [TestMethod]
        public void Details_ShouldReturnCorrectViewAndModel()
        {
           this._controller.WithCallTo(c => c.Details(1)).ShouldRenderDefaultView().WithModel<FoundPetVM>();
        }



    }
}
