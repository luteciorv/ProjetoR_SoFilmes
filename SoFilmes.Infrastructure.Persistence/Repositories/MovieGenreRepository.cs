using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Domain.Entities;
using SoFilmes.Infrastructure.Persistence.Context;

namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class MovieGenreRepository : Repository<MovieGenre>, IMovieGenreRepository
    {
        public MovieGenreRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
