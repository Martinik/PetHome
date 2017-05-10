using System.Linq;
using PetHome.Data.Interfaces;
using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.Account;
using PetHome.Services.Interfaces;
using System;

namespace PetHome.Services
{
    public class AccountService : Service, IAccountService
    {
        public AccountService(IPetHomeContext context) 
            : base(context)
        {
        }

        public ApplicationUser GetNewUser(RegisterViewModel model)
        {
            var user = new ApplicationUser
            {
                Email = model.Email,
                Name = this.GenerateNameFromEmail(model.Email),
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.UserName
            };

            if ( string.IsNullOrEmpty(model.UserName))
            {
                user.UserName = this.GenerateUserNameFromEmail(model.Email);
            }
            else
            {
                user.UserName = model.UserName;
            }

            return user;
        }


        private string GenerateNameFromEmail(string email)
        {
            string name = email.Split('@')[0];

            return name;
        }

        private string GenerateUserNameFromEmail(string email)
        {
            string username =  email.Split('@')[0];
            username = CheckIfUsernameExists(username, 1);

            return username;
        }

        private string CheckIfUsernameExists(string username, int num)
        {

            if (!this.Context.Users.Any(user => user.UserName == username))
            {
                return username;
            }

            username = username + num;

            username = CheckIfUsernameExists(username, num++);

            return username;
        }
    }
}
