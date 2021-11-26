using System.Collections.Generic;
using ETicketsApp.Models;

namespace ETicketsApp.Data.ViewModels
{
    public class MovieDropdownVM
    {
        public MovieDropdownVM()
        {
            Producers = new List<Producer>();
            Cinemas = new List<Cinema>();
            Actors = new List<Actor>();
        }
        public List<Producer> Producers { get; set; }
        public List<Cinema> Cinemas { get; set; }
        public List<Actor> Actors { get; set; }
    }
}
