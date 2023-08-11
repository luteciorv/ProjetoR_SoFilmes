using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Movies.Commands.Handlers
{
    public class PatchMovieCommandHandler : IRequestHandler<PatchMovieCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<PatchMovieCommand> _validator;

        public PatchMovieCommandHandler(IUnitOfWork uow, IValidator<PatchMovieCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task Handle(PatchMovieCommand command, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid) throw new ValidationRequestException($"Não foi possível atualizar a avaliação do filme de id {command.Id}.", result.Errors);

            var movie = await _uow.Movies.GetByIdAsync(command.Id) ??
                        throw new EntityNotFoundException($"Não foi possível encontrar o filme de id {command.Id}.");

            movie.UpdateRating(command.Rating);
            
            _uow.Movies.Update(movie);
            await _uow.CommitAsync();
        }
    }
}
