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
    public class LostPetsControllerTests
    {
        private LostPetsController _controller;
        private ILostPetsService _service;
        private IPetHomeContext _context;
        private List<LostPet> lostPets;


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

            foreach (var pet in lostPets)
            {
                this._context.LostPets.Add(pet);
            }

            //
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, new string[] { "Admin" });

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            this._service = new LostPetsService(this._context);
            this._controller = new LostPetsController(this._service);
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
                .WithModel<IEnumerable<LostPetVM>>();
        }

        [TestMethod]
        public void Index_ShouldReturnRightPetCount()
        {
            this._controller.WithCallTo(c => c.Index()).ShouldRenderDefaultView()
    .WithModel<IEnumerable<LostPetVM>>(m => m.Count() == 2);

        }

        [TestMethod]
        public void Create_ShouldReturnDefaultView()
        {
            this._controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView();
        }

        [TestMethod]
        public void Create_ShouldReturnDefaultVm()
        {
            this._controller.WithCallTo(c => c.Create()).ShouldRenderDefaultView().WithModel<CreateLostPetVM>();
        }

        [TestMethod]
        public void Create_ShouldSuccessfullyCreate()
        {
            CreateLostPetBM bm = new CreateLostPetBM()
            {
                AnimalType = AnimalType.Other,
                Name = "Test Animal",
                Age = 12,
                Breed = "Test Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                Temper = Temper.Calm,
                Thumbnail = null
            };

            this._controller.Create(bm);

            Assert.AreEqual(3, this._context.LostPets.Count());
        }

        [TestMethod]
        public void Create_ShouldRedirectToIndex()
        {
            CreateLostPetBM bm = new CreateLostPetBM()
            {
                AnimalType = AnimalType.Other,
                Name = "Test Animal",
                Age = 12,
                Breed = "Test Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                Temper = Temper.Calm,
                Thumbnail = null
            };

            this._controller.WithCallTo(c => c.Create(bm)).ShouldRedirectToRoute("");
        }


        [TestMethod]
        public void Edit_ShouldReturnCorrectViewAndModel()
        {
            this._controller.WithCallTo(c => c.Edit(1)).ShouldRenderDefaultView().WithModel<EditLostPetVM>();
        }

        [TestMethod]
        public void Edit_ShouldEditSuccessfully()
        {

            EditLostPetBM bm = new EditLostPetBM()
            {
                AnimalType = AnimalType.Other,
                Name = "Edited Animal",
                Age = 12,
                Breed = "Edited Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                Temper = Temper.Calm,
                Thumbnail = null,
                 Id = 1
            };

            this._controller.Edit(bm);

            Assert.AreEqual("Edited Animal", this._context.LostPets.Find(1).Name);
        }

        [TestMethod]
        public void Edit_ShouldRedirectSuccessfully()
        {

            EditLostPetBM bm = new EditLostPetBM()
            {
                AnimalType = AnimalType.Other,
                Name = "Edited Animal",
                Age = 12,
                Breed = "Edited Breed",
                Description = "",
                DistinguishingFeatures = "",
                LastSeenLocation = "West Park",
                LastSeenTime = DateTime.Today,
                Temper = Temper.Calm,
                Thumbnail = null,
                Id = 1
            };

            this._controller.WithCallTo(c => c.Edit(bm)).ShouldRedirectToRoute("");
        }


        //

        [TestMethod]
        public void Delete_ShouldReturnCorrectViewAndModel()
        {
            this._controller.WithCallTo(c => c.ConfirmDelete(1)).ShouldRenderDefaultView().WithModel<LostPetVM>();
        }

        [TestMethod]
        public void Delete_ShouldDeleteSuccessfully()
        {
            DeleteLostPetBM bm = new DeleteLostPetBM()
            {
                Id = 1
            };

            this._controller.ConfirmDelete(bm);

            Assert.AreEqual(null, this._context.LostPets.FirstOrDefault(pet => pet.Id == 1));
        }

        [TestMethod]
        public void Details_ShouldReturnCorrectViewAndModel()
        {
            this._controller.WithCallTo(c => c.Details(1)).ShouldRenderDefaultView().WithModel<LostPetVM>();
        }


    }
}
