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
        Actor Update(int id, Actor actor);
        void Delete(int id);
    }
}
