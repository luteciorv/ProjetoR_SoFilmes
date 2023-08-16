using Microsoft.EntityFrameworkCore;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Domain.Entities;
using SoFilmes.Infrastructure.Persistence.Context;
    
namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext) : base(dataContext) { }

        public new async Task<IReadOnlyCollection<Movie>> GetAllAsync(int skip, int take) =>
            await GetAll()
                .Include(m => m.MoviesGenres).ThenInclude(mg => mg.Genre)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();

        public new async Task<Movie?> GetByIdAsync(Guid id) =>
           await GetAll()
                .Include(m => m.MoviesGenres).ThenInclude(mg => mg.Genre)
                .AsNoTracking()
                .FirstOrDefaultAsync();

        public async Task<IReadOnlyCollection<Movie>> GetByTitleAsync(string title, int skip, int take) =>
            await GetAll()
                .Where(m => m.Title.ToLower().Contains(title.ToLower()))
                .Include(m => m.MoviesGenres).ThenInclude(mg => mg.Genre)
                .Skip(skip)
                .Take(take)
                .AsNoTracking()
                .ToListAsync();
    }
}
