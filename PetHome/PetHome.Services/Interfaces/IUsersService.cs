using PetHome.Models.BindingModels;
using PetHome.Models.ViewModels.Users;

namespace PetHome.Services.Interfaces
{
    public interface IUsersService
    {
        ProfileVM GetProfileVm(string userName);
        EditUserVM GetEditUserVm(string userName);
        EditUserVM GetEditUserVmByUsername(string username);
        void EditUser(EditUserBM bind, string userName);

    }
}
