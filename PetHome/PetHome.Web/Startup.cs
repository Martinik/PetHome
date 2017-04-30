using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetHome.Web.Startup))]
namespace PetHome.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
