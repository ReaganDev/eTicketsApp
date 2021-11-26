using System.Threading.Tasks;
using ETicketsApp.Data.Repository;
using ETicketsApp.Data.ViewModels;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Interfaces
{
    public interface IMoviesService : IEntityRepository<Movie>
    {
        Task<Movie> GetMovieByIdAync(int id);
        Task<MovieDropdownVM> GetMovieDropdownValues();
        Task AddNewMovieAsync(NewMovieVM model);
        Task UpdateMovieAsync(NewMovieVM model);
    }
}
