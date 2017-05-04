using System.Web.Mvc;
using System.Web.Routing;

namespace PetHome.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");



            routes.MapRoute(
               name: "Admin",
               url: "admin/{action}/{id}",
               defaults: new { controller = "Admin", action = "AdminPanel", area = "admin", id = UrlParameter.Optional }
           );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
