using System.Collections.Generic;
using System.Threading.Tasks;

namespace ETicketsApp.Data.Repository
{
    public interface IEntityRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T model);
        Task UpdateAsync(int id, T model);
        Task DeleteAsync(int id);
    }
}
