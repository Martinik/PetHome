using System.ComponentModel.DataAnnotations;

namespace PetHome.Models.ViewModels.Admin
{
    public class AdminPanelUserVM
    {
        [Display(Name = "Id")]
        public string Id { get; set; }

        [Display(Name = "Username")]
        public string Username { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

    }
}
