using System;
using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Comments
{
    public class CommentVM
    {
        public int Id { get; set; }
        public CommentUserVM Author { get; set; }
        public string Content { get; set; }

        [Display(Name = "Date Posted")]
        public DateTime DatePosted { get; set; }
    }
}
