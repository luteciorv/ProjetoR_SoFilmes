using MediatR;
using SoFilmes.Application.Genres.DTOs;

namespace SoFilmes.Application.Genres.Queries
{
    public class GetGenreByIdQuery : IRequest<ReadGenreDto>
    {
        public GetGenreByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
