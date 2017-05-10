using PetHome.Models.EntityModels;
using PetHome.Models.ViewModels.Account;

namespace PetHome.Services.Interfaces
{
    public interface IAccountService
    {
        ApplicationUser GetNewUser(RegisterViewModel model);  
       
    }
}
