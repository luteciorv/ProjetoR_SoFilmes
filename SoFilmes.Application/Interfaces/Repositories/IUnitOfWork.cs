namespace SoFilmes.Application.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IMovieRepository Movies { get; }
        IGenreRepository Genres { get; }
        IMovieGenreRepository MoviesGenres { get; }

        Task CommitAsync();
    }
}
