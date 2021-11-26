using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ETicketsApp.Data.Enum;
using ETicketsApp.Models;

namespace ETicketsApp.Data.ViewModels
{
    public class NewMovieVM
    {
        public int Id { get; set; }
        [Display(Name = "Movie Name")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Display(Name = "Movie Description")]
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Display(Name = "Price in $")]
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Display(Name = "Movie Poster Url")]
        [Required(ErrorMessage = "Movie Poster Url is required")]
        public string MovieUrl { get; set; }
        [Display(Name = "Movie Start Date")]
        [Required(ErrorMessage = "Start Date is required")]
        public DateTime StartDate { get; set; }
        [Display(Name = "Movie End Date")]
        [Required(ErrorMessage = "End Date is required")]
        public DateTime EndDate { get; set; }
        [Display(Name = "Select a category")]
        [Required(ErrorMessage = "Movie Category is required")]
        public Category Category { get; set; }
        [Display(Name = "Select Actor(s)")]
        [Required(ErrorMessage = "Movie Actor(s) is required")]
        public List<int> ActorIds { get; set; }
        [Display(Name = "Select a cinema")]
        [Required(ErrorMessage = "Movie Cinema is required")]
        public int CinemaId { get; set; }
        [Display(Name = "Select Producer(s)")]
        [Required(ErrorMessage = "Movie Producer(s) is required")]
        public int ProducerId { get; set; }

    }
}
