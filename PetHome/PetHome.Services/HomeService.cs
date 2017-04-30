using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PetHome.Models.ViewModels.Home;

namespace PetHome.Services
{
    public class HomeService : Service
    {
        public string GetNameOfUser(string username)
        {
            var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);

            return user.Name;
        }

        public NavBarUserVM GetNavBarUserVM(string username)
        {
            string name = this.GetNameOfUser(username);

            NavBarUserVM vm = new NavBarUserVM
            {
                Name = name
            };
            return vm;
        }
    }
}
