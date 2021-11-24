using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class Producer : Base
    {
        [Key]
        public int Id { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
