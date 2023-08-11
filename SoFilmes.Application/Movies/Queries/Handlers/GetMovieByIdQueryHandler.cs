using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Application.Movies.Map;

namespace SoFilmes.Application.Movies.Queries.Handlers
{
    public class GetMovieByIdQueryHandler : IRequestHandler<GetMovieByIdQuery, ReadMovieDto>
    {
        private readonly IUnitOfWork _uow;

        public GetMovieByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ReadMovieDto> Handle(GetMovieByIdQuery query, CancellationToken cancellationToken)
        {
            var movie = await _uow.Movies.GetByIdAsync(query.Id) ?? 
                        throw new EntityNotFoundException($"O filme de id {query.Id} não foi encontrado.");

            return movie.MapToReadMovieDto();
        }
    }
}
