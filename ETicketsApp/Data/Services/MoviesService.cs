using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.Repository;
using ETicketsApp.Data.ViewModels;
using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data.Services
{
    public class MoviesService : EntityRepository<Movie>, IMoviesService
    {
        private readonly AppDbContext _context;

        public MoviesService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddNewMovieAsync(NewMovieVM model)
        {
            var movie = new Movie()
            {
                Name = model.Name,
                Category = model.Category,
                Description = model.Description,
                Price = model.Price,
                MovieUrl = model.MovieUrl,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ProducerId = model.ProducerId,
                CinemaId = model.CinemaId,
            };

            await _context.AddAsync(movie);
            await _context.SaveChangesAsync();

            foreach (var actorId in model.ActorIds)
            {
                var actorMovies = new Actor_Movie()
                {
                    MovieId = movie.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(actorMovies);
            }
            await _context.SaveChangesAsync();
        }

        public async Task<Movie> GetMovieByIdAync(int id)
        {
            var movie = await _context.Movies.Include(x => x.Cinema)
                .Include(x => x.Producer)
                .Include(x => x.Actor_Movies).ThenInclude(x => x.Actor)
                .FirstOrDefaultAsync(x => x.Id == id);
            return movie;
        }

        public async Task<MovieDropdownVM> GetMovieDropdownValues()
        {
            var res = new MovieDropdownVM()
            {
                Actors = await _context.Actors.OrderBy(x => x.Name).ToListAsync(),
                Cinemas = await _context.Cinemas.OrderBy(x => x.Name).ToListAsync(),
                Producers = await _context.Producers.OrderBy(x => x.Name).ToListAsync()
            };

            return res;
        }

        public async Task UpdateMovieAsync(NewMovieVM model)
        {
            var dbMovie = await _context.Movies.FirstOrDefaultAsync(x => x.Id == model.Id);
            if (dbMovie != null)
            {
                dbMovie.Name = model.Name;
                dbMovie.Category = model.Category;
                dbMovie.Description = model.Description;
                dbMovie.Price = model.Price;
                dbMovie.MovieUrl = model.MovieUrl;
                dbMovie.StartDate = model.StartDate;
                dbMovie.EndDate = model.EndDate;
                dbMovie.ProducerId = model.ProducerId;
                dbMovie.CinemaId = model.CinemaId;

                await _context.SaveChangesAsync();
            }
            // REMOVIE EXISTING ACTORS
            var existing = _context.Actors_Movies.Where(x => x.MovieId == model.Id).ToList();
            _context.Actors_Movies.RemoveRange(existing);
            await _context.SaveChangesAsync();

            foreach (var actorId in model.ActorIds)
            {
                var actorMovies = new Actor_Movie()
                {
                    MovieId = model.Id,
                    ActorId = actorId
                };
                await _context.Actors_Movies.AddAsync(actorMovies);
            }
            await _context.SaveChangesAsync();
        }
    }
}
