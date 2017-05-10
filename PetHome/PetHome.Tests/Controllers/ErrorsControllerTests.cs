using Microsoft.VisualStudio.TestTools.UnitTesting;
using PetHome.Web.Controllers;
using TestStack.FluentMVCTesting;

namespace PetHome.Tests.Controllers
{
    [TestClass]
    public class ErrorsControllerTests
    {
        private ErrorsController _controller;   

        [TestInitialize]
        public void Init()
        {          
            this._controller = new ErrorsController();
        }

        [TestMethod]
        public void InvalidUrlError_ShouldReturnCorrectViewAndModel()
        {
            this._controller.WithCallTo(c => c.InvalidUrlError()).ShouldRenderDefaultView();
        }
    }
}
