using MediatR;
using SoFilmes.Application.Genres.DTOs;

namespace SoFilmes.Application.Genres.Queries
{
    public class GetGenresQuery : IRequest<IReadOnlyCollection<ReadGenreDto>>
    {
        public GetGenresQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
        }

        public int Skip { get; private set; }
        public int Take { get; private set; }
    }
}
