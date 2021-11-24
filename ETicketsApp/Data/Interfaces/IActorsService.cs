using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Interfaces
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllAsync();
        Task<Actor> GetByIdAsync(int id);
        Task Add(Actor actor);
        Task<Actor> UpdateAsync(int id, Actor actor);
        Task DeleteAsync(int id);
    }
}
