using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Application.Movies.Map;

namespace SoFilmes.Application.Movies.Queries.Handlers
{
    public class GetMoviesByTitleQueryHandler : IRequestHandler<GetMoviesByTitleQuery, IReadOnlyCollection<ReadMovieDto?>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<GetMoviesByTitleQuery> _validator;

        public GetMoviesByTitleQueryHandler(IUnitOfWork uow, IValidator<GetMoviesByTitleQuery> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task<IReadOnlyCollection<ReadMovieDto?>> Handle(GetMoviesByTitleQuery query, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(query);
            if (!result.IsValid) throw new ValidationRequestException($"Não foi possível recuperar os filmes que contém o nome: {query.Title}.", result.Errors);
        
            var movies = await _uow.Movies.GetByTitleAsync(query.Title, query.Skip, query.Take);
            var moviesDto = movies.Select(m => m.MapToReadMovieDto()).ToList();

            return moviesDto;
        }
    }
}
