using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class Base
    {
        [Display(Name = "Full Name")]
        [Required(ErrorMessage = "Full Name is required")]
        public string Name { get; set; }
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage = "Profile Picture Url is required")]

        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Biography is required")]

        public string Bio { get; set; }
    }
}
