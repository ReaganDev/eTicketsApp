using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace ETicketsApp.Models
{
    public class AppUser : IdentityUser
    {
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
    }
}
