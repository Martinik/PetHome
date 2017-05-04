using System;

namespace PetHome.Models.ViewModels.Comments
{
    public class CommentVM
    {
        public int Id { get; set; }
        public CommentUserVM Author { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }
    }
}
