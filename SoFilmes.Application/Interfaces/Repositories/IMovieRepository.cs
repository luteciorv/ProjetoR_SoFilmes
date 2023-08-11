using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Interfaces.Repositories
{
    public interface IMovieRepository : IRepository<Movie>
    {
        Task<IReadOnlyCollection<Movie>> GetByTitle(string title); 
    }
}
