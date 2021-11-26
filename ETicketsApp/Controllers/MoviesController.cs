using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMoviesService _service;

        public MoviesController(IMoviesService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync(x => x.Cinema);
            return View(data);
        }

        public async Task<IActionResult> Filter(string searchString)
        {
            var data = await _service.GetAllAsync(x => x.Cinema);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filtered = data.Where(x => x.Name.ToLower().Contains(searchString.ToLower())).ToList();
                return View("Index", filtered);
            }
            return View("Index", data);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _service.GetMovieByIdAync(id);
            return View(movie);
        }

        public async Task<IActionResult> Create()
        {
            var dropdowns = await _service.GetMovieDropdownValues();
            ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "Name");
            ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewMovieVM model)
        {
            if (!ModelState.IsValid)
            {
                var dropdowns = await _service.GetMovieDropdownValues();
                ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "Name");
                ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "Name");
                return View(model);
            }
            await _service.AddNewMovieAsync(model);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var movie = await _service.GetMovieByIdAync(id);
            if (movie == null) return View("NotFound");

            var response = new NewMovieVM()
            {
                Id = id,
                Name = movie.Name,
                Category = movie.Category,
                Description = movie.Description,
                Price = movie.Price,
                MovieUrl = movie.MovieUrl,
                StartDate = movie.StartDate,
                EndDate = movie.EndDate,
                ProducerId = movie.ProducerId,
                CinemaId = movie.CinemaId,
                ActorIds = movie.Actor_Movies.Select(x => x.ActorId).ToList(),
            };
            var dropdowns = await _service.GetMovieDropdownValues();
            ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "Name");
            ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "Name");
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM model)
        {
            if (id != model.Id) return View("NotFound");
            if (!ModelState.IsValid)
            {
                var dropdowns = await _service.GetMovieDropdownValues();
                ViewBag.Cinemas = new SelectList(dropdowns.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(dropdowns.Producers, "Id", "Name");
                ViewBag.Actors = new SelectList(dropdowns.Actors, "Id", "Name");
                return View(model);
            }
            await _service.UpdateMovieAsync(model);
            return RedirectToAction(nameof(Index));
        }
    }
}
