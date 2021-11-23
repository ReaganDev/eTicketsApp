using ETicketsApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ETicketsApp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Actor_Movie>().HasKey(x => new
            {
                x.ActorId,
                x.MovieId
            });
            builder.Entity<Actor_Movie>().HasOne(x => x.Actor).WithMany(x => x.Actor_Movies).HasForeignKey(x => x.ActorId);
            builder.Entity<Actor_Movie>().HasOne(x => x.Movie).WithMany(x => x.Actor_Movies).HasForeignKey(x => x.MovieId);

            base.OnModelCreating(builder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
    }
}
