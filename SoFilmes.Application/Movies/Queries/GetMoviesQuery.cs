using MediatR;
using SoFilmes.Application.Movies.DTOs;

namespace SoFilmes.Application.Movies.Queries
{
    public class GetMoviesQuery : IRequest<IReadOnlyCollection<ReadMovieDto>>
    {
        public GetMoviesQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; private set; }
        public int Take { get; private set; }
    }
}
