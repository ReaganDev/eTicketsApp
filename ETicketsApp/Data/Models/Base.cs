using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class Base
    {
        [Display(Name = "Full Name")]
        public string Name { get; set; }
        [Display(Name = "Profile Picture")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Biography")]
        public string Bio { get; set; }
    }
}
