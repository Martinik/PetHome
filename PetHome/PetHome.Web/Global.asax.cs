using AutoMapper;
using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels;
using PetHome.Models.ViewModels.LostPets;
using PetHome.Models.ViewModels.Users;
using System;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PetHome.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<ApplicationUser, ProfileVM>();
                expression.CreateMap<LostPet, UserPetVM>();
                expression.CreateMap<FoundPet, UserPetVM>();
                expression.CreateMap<ApplicationUser, EditUserVM>();
                expression.CreateMap<Pet, LostPetVM>();
                expression.CreateMap<CreateLostPetBM, LostPet>();
                expression.CreateMap<LostPet, EditLostPetVM>();
               




            });
        }
    }
}
