using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetHome.Data.Interfaces;
using PetHome.Data.Mocks;
using PetHome.Models.BindingModels.Comments;
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
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace PetHome.Tests.Controllers
{
    [TestClass]
    public class CommentsControllerTests
    {
        private CommentsController _controller;
        private ICommentsService _service;
        private IPetHomeContext _context;


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

            var lostPet = new LostPet()
            {
                Id = 1,
                Name = "Simba",
                AnimalType = AnimalType.Cat,
                AssociatedUser = null,
                Breed = "Lion",
                IsLostPet = true,
                LastSeenLocation = "South Park",
                LastSeenTime = DateTime.Today
            };

            this._context.LostPets.Add(lostPet);

            this._context.Users.Add(new ApplicationUser()
            {
                UserName = "Tester",
                Name = "Tester",
                Details = "For testing purposes",
                IsAdmin = true
            });


            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, null);

            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            this._service = new CommentsService(this._context);
            this._controller = new CommentsController(this._service);

            //
            this._controller.ControllerContext = controllerContext.Object;

        }



        [TestMethod]
        public void AddComment_ShouldAddCommentSuccessfully()
        {
            AddComentBM bm = new AddComentBM()
            {
                Username = "Tester",
                PetId = 1,
                IsLostPet = true,
                Content = "Test Comment"
            };

            this._controller.AddComment(bm);

            Assert.AreEqual(1, this._context.LostPets.Find(1).Comments.Count);
            Assert.AreEqual("Test Comment", this._context.LostPets.Find(1).Comments.First().Content);
        }


        [TestMethod]
        public void AddComment_ShouldRedirectAfterAdding()
        {
            AddComentBM bm = new AddComentBM()
            {
                Username = "Tester",
                PetId = 1,
                IsLostPet = true,
                Content = "Test Comment"
            };

            this._controller.WithCallTo(c => c.AddComment(bm)).ShouldRedirectToRoute("");

        }

    }
}
