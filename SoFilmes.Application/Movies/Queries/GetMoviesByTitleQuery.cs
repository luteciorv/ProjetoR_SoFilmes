using MediatR;
using SoFilmes.Application.Movies.DTOs;

namespace SoFilmes.Application.Movies.Queries
{
    public class GetMoviesByTitleQuery : IRequest<IReadOnlyCollection<ReadMovieDto>>
    {
        public GetMoviesByTitleQuery(string title, int skip, int take)
        {
            Title = title;
            Skip = skip;
            Take = take;
        }

        public string Title { get; private set; }
        public int Skip { get; private set; }
        public int Take { get; private set; }
    }
}
