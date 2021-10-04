using Microsoft.EntityFrameworkCore;
using MyMovies.Entities;

namespace MyMovies
{
    public class MyMoviesDbContext : DbContext
    {
        public MyMoviesDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

    }
}
