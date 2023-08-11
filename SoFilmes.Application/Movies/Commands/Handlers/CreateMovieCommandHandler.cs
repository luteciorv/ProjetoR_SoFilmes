using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;
using SoFilmes.Application.Movies.Map;

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
            
            await _uow.Movies.AddAsync(movie);
            await _uow.CommitAsync();

            command.SetId(movie.Id);
        }
    }
}
