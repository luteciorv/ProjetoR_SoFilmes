using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Genres.DTOs;
using SoFilmes.Application.Genres.Map;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Genres.Queries.Handlers
{
    public class GetGenresQueryHandler : IRequestHandler<GetGenresQuery, IReadOnlyCollection<ReadGenreDto>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<GetGenresQuery> _validator;

        public GetGenresQueryHandler(IUnitOfWork uow, IValidator<GetGenresQuery> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task<IReadOnlyCollection<ReadGenreDto>> Handle(GetGenresQuery query, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(query);
            if (!result.IsValid) throw new ValidationRequestException("Não foi possível recuperar os gêneros cadastrados.", result.Errors);

            var genres = await _uow.Genres.GetAllAsync(query.Skip, query.Take);
            var genresDto = genres.Select(g => g.MapToReadGenreDto()).ToList();

            return genresDto;
        }
    }
}
