using PetHome.Models.BindingModels.FoundPets;
using PetHome.Models.ViewModels.FoundPets;
using System.Collections.Generic;

namespace PetHome.Services.Interfaces
{
    public interface IFoundPetsService
    {
        IEnumerable<FoundPetVM> GetFoundPetsVM();
        FoundPetVM GetFoundPetVM(string username, int id);
        void CreateNewFoundPet(CreateFoundPetBM bind, string username);        
        bool PetBelongsToUser(string username, int id);
        EditFoundPetVM GetEditPetVM(int id);
        void DeleteFoundPet(int id);
        void EditPet(EditFoundPetBM bind);






    }
}
