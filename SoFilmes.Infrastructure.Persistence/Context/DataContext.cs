using Microsoft.EntityFrameworkCore;
using SoFilmes.Domain.Entities;
using SoFilmes.Infrastructure.Persistence.Extensions;

namespace SoFilmes.Infrastructure.Persistence.Context
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ConfigureModelCreating();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<MovieGenre> MoviesGenres { get; set; }
    }
}
