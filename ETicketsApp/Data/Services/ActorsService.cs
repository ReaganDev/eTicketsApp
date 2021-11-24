using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext _context;

        public ActorsService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(Actor actor)
        {
            await _context.Actors.AddAsync(actor);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var actor = await GetByIdAsync(id);
            _context.Actors.Remove(actor);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Actor>> GetAllAsync()
        {
            var data = await _context.Actors.ToListAsync();
            return data;
        }

        public async Task<Actor> GetByIdAsync(int id)
        {
            var actor = await _context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task<Actor> UpdateAsync(int id, Actor actor)
        {
            _context.Actors.Update(actor);
            await _context.SaveChangesAsync();
            return actor;
        }
    }
}
