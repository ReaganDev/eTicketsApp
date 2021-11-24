using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETicketsApp.Data.Enum;

namespace ETicketsApp.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string MovieUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Category Category { get; set; }
        public List<Actor_Movie> Actor_Movies { get; set; }
        public Cinema Cinema { get; set; }
        public int CinemaId { get; set; }
        public Producer Producer { get; set; }
        public int ProducerId { get; set; }

    }
}
