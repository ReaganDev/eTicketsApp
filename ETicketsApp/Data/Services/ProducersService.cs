using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.Repository;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Services
{
    public class ProducersService : EntityRepository<Producer>, IProducersService
    {
        public ProducersService(AppDbContext context) : base(context) { }

    }
}
