using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETicketsApp.Data.Interfaces;
using ETicketsApp.Data.Repository;
using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data.Services
{
    public class ActorsService : EntityRepository<Actor>, IActorsService
    {

        public ActorsService(AppDbContext context) : base(context) { }



    }
}
