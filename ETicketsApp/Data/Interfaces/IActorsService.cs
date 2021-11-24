using System.Collections.Generic;
using System.Threading.Tasks;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Interfaces
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAll();
        Actor GetById(int id);
        void Add(Actor actor);
        Actor Update(int id, Actor actor);
        void Delete(int id);
    }
}
