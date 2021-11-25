using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.Repository;
using ETicketsApp.Models;

namespace ETicketsApp.Data.Services
{
    public class CinemasService : EntityRepository<Cinema>, ICinemasService
    {
        public CinemasService(AppDbContext context) : base(context) { }

    }
}
