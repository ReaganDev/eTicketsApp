using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Data.ViewModels
{
    public class LoginVM
    {
        [Required(ErrorMessage = "Email is required")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Password")]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
