using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ETicketsApp.Data.Repository
{
    public class EntityRepository<T> : IEntityRepository<T> where T : class, IEntityBase, new()
    {

        private readonly AppDbContext _context;

        public EntityRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(T model)
        {
            await _context.Set<T>().AddAsync(model);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var model = await GetByIdAsync(id);
            EntityEntry entity = _context.Entry<T>(model);
            entity.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();


        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);


        public async Task UpdateAsync(int id, T model)
        {
            EntityEntry entity = _context.Entry<T>(model);
            entity.State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
