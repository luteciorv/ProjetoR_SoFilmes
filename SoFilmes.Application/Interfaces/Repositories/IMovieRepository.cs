using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IReadOnlyCollection<Movie>> GetByTitleAsync(string title, int skip, int take); 
    }
}
