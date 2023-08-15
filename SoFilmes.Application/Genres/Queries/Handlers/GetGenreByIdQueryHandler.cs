using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Genres.DTOs;
using SoFilmes.Application.Genres.Map;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Genres.Queries.Handlers
{
    public class GetGenreByIdQueryHandler : IRequestHandler<GetGenreByIdQuery, ReadGenreDto>
    {
        private readonly IUnitOfWork _uow;

        public GetGenreByIdQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ReadGenreDto> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
        {
            var genre = await _uow.Genres.GetByIdAsync(request.Id) ?? 
                        throw new EntityNotFoundException($"O gênero de id {request.Id} não foi encontrado.");

            var genreDto = genre.MapToReadGenreDto();

            return genreDto;
        }
    }
}
