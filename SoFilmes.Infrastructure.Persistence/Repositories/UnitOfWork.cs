using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Infrastructure.Persistence.Context;

namespace SoFilmes.Infrastructure.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            IMovieRepository movies, 
            IGenreRepository genres, 
            IMovieGenreRepository moviesGenres,
            DataContext dataContext)
        {
            Movies = movies;
            Genres = genres;
            MoviesGenres = moviesGenres;

            _dataContext = dataContext;
        }

        public IMovieRepository Movies { get; private set; }
        public IGenreRepository Genres {get; private set;}
        public IMovieGenreRepository MoviesGenres {get; private set;}

        private readonly DataContext _dataContext;

        public async Task CommitAsync() =>
            await _dataContext.SaveChangesAsync();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposing) _dataContext.Dispose();
        }
    }
}
