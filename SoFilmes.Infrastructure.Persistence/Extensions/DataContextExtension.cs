using Microsoft.EntityFrameworkCore;
using SoFilmes.Domain.Entities;

namespace SoFilmes.Infrastructure.Persistence.Extensions
{
    public static class DataContextExtension
    {
        public static void ConfigureModelCreating(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(movieGenre => new { movieGenre.MovieId, movieGenre.GenreId });

            modelBuilder.Entity<MovieGenre>()
                .HasOne(movieGenre => movieGenre.Movie)
                .WithMany(movie => movie.MoviesGenres)
                .HasForeignKey(movieGenre => movieGenre.MovieId);

            modelBuilder.Entity<MovieGenre>()
                .HasOne(movieGenre => movieGenre.Genre)
                .WithMany(genre => genre.MoviesGenres)
                .HasForeignKey(movieGenre => movieGenre.GenreId);
        }
    }
}
