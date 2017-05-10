using PetHome.Models.BindingModels.LostPets;
using PetHome.Models.ViewModels.LostPets;
using System.Collections.Generic;

namespace PetHome.Services.Interfaces
{
    public interface ILostPetsService
    {
        IEnumerable<LostPetVM> GetLostPetsVM();
        LostPetVM GetLostPetVM(string username, int id);
        void CreateNewLostPet(CreateLostPetBM bind, string username);
        bool PetBelongsToUser(string username, int id);
        EditLostPetVM GetEditPetVM(int id);
        void DeleteLostPet(int id);
        void EditPet(EditLostPetBM bind);
       
    }
}
