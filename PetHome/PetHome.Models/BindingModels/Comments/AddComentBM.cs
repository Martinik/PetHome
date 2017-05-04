namespace PetHome.Models.BindingModels.Comments
{
    public class AddComentBM
    {

        public string Content { get; set; }
        public int PetId { get; set; }
        public string Username { get; set; }
        public bool IsLostPet { get; set; }
    }
}
