using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ETicketsApp.Models
{
    public class Actor : Base
    {
        [Key]
        public int Id { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
    }
}
