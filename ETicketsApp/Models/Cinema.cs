using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class Cinema : BaseEntity
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Cinema Name is required")]
        public string Name { get; set; }
        [Display(Name = "Cinema Logo")]
        [Required(ErrorMessage = "Cinema Logo is required")]
        public string Logo { get; set; }
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Cinema Description is required")]
        public string Description { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
