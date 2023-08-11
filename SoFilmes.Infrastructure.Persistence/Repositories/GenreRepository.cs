using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Domain.Entities;
using SoFilmes.Infrastructure.Persistence.Context;

namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
