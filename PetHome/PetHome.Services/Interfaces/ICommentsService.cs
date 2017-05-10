using PetHome.Models.BindingModels.Comments;

namespace PetHome.Services.Interfaces
{
    public interface ICommentsService
    {
        void AddComment(AddComentBM bind);
    }
}
