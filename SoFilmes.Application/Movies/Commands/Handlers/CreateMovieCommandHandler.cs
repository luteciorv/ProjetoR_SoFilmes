using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Application.Movies.Map;
using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Movies.Commands.Handlers
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CreateMovieCommand> _validator;

        public CreateMovieCommandHandler(IUnitOfWork uow, IValidator<CreateMovieCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task Handle(CreateMovieCommand command, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid) throw new ValidationRequestException("Não foi possível criar o filme. Os seus dados na requisição estão inválidos.", result.Errors);

            var movie = command.MapToMovie();
            command.SetId(movie.Id);

            await _uow.Movies.AddAsync(movie);

            foreach (var genreId in command.GenresId)
            {
                var movieGenre = new MovieGenre(movie.Id, genreId);
                await _uow.MoviesGenres.AddAsync(movieGenre);
            }

            await _uow.CommitAsync();
        }
    }
}
