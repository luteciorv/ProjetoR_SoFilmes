using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Genres.Commands.Handlers
{
    public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<UpdateGenreCommand> _validator;

        public UpdateGenreCommandHandler(IUnitOfWork uow, IValidator<UpdateGenreCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task Handle(UpdateGenreCommand command, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid) throw new ValidationRequestException($"Não foi possível atualizar os dados do gênero de id {command.Id}", result.Errors);

            var genre = await _uow.Genres.GetByIdAsync(command.Id) ??
                        throw new EntityNotFoundException($"Não foi possível encontrar o gênero de id {command.Id}.");

            genre.Update(command.Name);

            _uow.Genres.Update(genre);
            await _uow.CommitAsync();
        }
    }
}
