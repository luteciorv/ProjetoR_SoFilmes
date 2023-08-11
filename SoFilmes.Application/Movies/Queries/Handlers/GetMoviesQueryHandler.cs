using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Application.Movies.Map;

namespace SoFilmes.Application.Movies.Queries.Handlers
{
    public class GetMoviesQueryHandler : IRequestHandler<GetMoviesQuery, IReadOnlyCollection<ReadMovieDto?>>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<GetMoviesQuery> _validator;

        public GetMoviesQueryHandler(IUnitOfWork uow, IValidator<GetMoviesQuery> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public Task<IReadOnlyCollection<ReadMovieDto?>> Handle(GetMoviesQuery query, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(query);
            if (!result.IsValid) throw new ValidationRequestException("Não foi possível recuperar os filmes cadastrados.", result.Errors);

            var movies = _uow.Movies.GetAll().Skip(query.Skip).Take(query.Take);
            var moviesDto = movies.Select(m => m.MapToReadMovieDto()).ToList();
            
            return Task.FromResult<IReadOnlyCollection<ReadMovieDto?>>(moviesDto);
        }
    }
}
