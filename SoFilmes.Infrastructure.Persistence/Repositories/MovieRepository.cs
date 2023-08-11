using Microsoft.EntityFrameworkCore;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Domain.Entities;
using SoFilmes.Infrastructure.Persistence.Context;
    
namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class MovieRepository : Repository<Movie>, IMovieRepository
    {
        public MovieRepository(DataContext dataContext) : base(dataContext) { }

        public async Task<IReadOnlyCollection<Movie>> GetByTitle(string title) =>
            await GetAll()
                .Where(m => m.Title.ToLower().Contains(title.ToLower()))
                .AsNoTracking()
                .ToListAsync();
    }
}
