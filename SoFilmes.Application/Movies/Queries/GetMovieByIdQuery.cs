using MediatR;
using SoFilmes.Application.Movies.DTOs;

namespace SoFilmes.Application.Movies.Queries
{
    public class GetMovieByIdQuery : IRequest<ReadMovieDto>
    {
        public GetMovieByIdQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
