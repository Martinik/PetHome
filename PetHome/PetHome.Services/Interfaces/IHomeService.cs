using PetHome.Models.BindingModels.Home;
using PetHome.Models.ViewModels.Home;

namespace PetHome.Services.Interfaces
{
    public interface IHomeService
    {
        string GetNameOfUser(string username);
        HomeIndexVM GetHomeIndexVM();      
        SearchResultVM GetSearchResultVM(SearchBM bind);
        NavBarUserVM GetNavBarUserVM(string username);
      
    }
}
