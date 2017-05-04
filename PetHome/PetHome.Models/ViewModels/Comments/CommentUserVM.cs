using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Comments
{
    public class CommentUserVM
    {
        public string Id { get; set; }

        [Display(Name = "Author")]
        public string Name { get; set; }
    }
}
