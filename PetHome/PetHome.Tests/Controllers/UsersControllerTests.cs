using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PetHome.Data.Interfaces;
using PetHome.Data.Mocks;
using PetHome.Models.BindingModels;
using PetHome.Models.BindingModels.FoundPets;
using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.Admin;
using PetHome.Models.ViewModels.Comments;
using PetHome.Models.ViewModels.FoundPets;
using PetHome.Models.ViewModels.Home;
using PetHome.Models.ViewModels.LostPets;
using PetHome.Models.ViewModels.Users;
using PetHome.Services;
using PetHome.Services.Interfaces;
using PetHome.Web.Controllers;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using TestStack.FluentMVCTesting;

namespace PetHome.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTests
    {

        private UsersController _controller;
        private IUsersService _service;
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
            var fakeHttpContext = new Mock<HttpContextBase>();
            var fakeIdentity = new GenericIdentity("User");
            var principal = new GenericPrincipal(fakeIdentity, new string[] { "Admin" });
            fakeHttpContext.Setup(t => t.User).Returns(principal);
            var controllerContext = new Mock<ControllerContext>();
            controllerContext.Setup(t => t.HttpContext).Returns(fakeHttpContext.Object);

            this._service = new UsersService(this._context);
            this._controller = new UsersController(this._service);
            //
            this._controller.ControllerContext = controllerContext.Object;



            this._context.Users.Add(new ApplicationUser()
            {
                UserName = "Tester",
                Name = "Tester",
                Details = "For testing purposes",
                IsAdmin = true
            });

        }

   
        [TestMethod]
        public void Profile_ShouldReturnNotFound()
        {

            this._controller.WithCallTo(c => c.Profile("NonExistent")).ShouldGiveHttpStatus(404);
        }


        [TestMethod]
        public void Edit_ShouldEditSuccessfully()
        {

            EditUserBM bm = new EditUserBM()
            {
                UserName = "Tester",
                Details = "Edited",
                Name = "Tester",
                Facebook = "test",
                Skype = "test",
                Surname = "test"
            };

            this._controller.Edit(bm);

            Assert.AreEqual("Edited", this._context.Users.FirstOrDefault(u => u.UserName == "Tester").Details);
        }



    }
}
