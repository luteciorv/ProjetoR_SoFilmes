using FluentValidation;
using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Genres.Map;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Genres.Commands.Handlers
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommand>
    {
        private readonly IUnitOfWork _uow;
        private readonly IValidator<CreateGenreCommand> _validator;

        public CreateGenreCommandHandler(IUnitOfWork uow, IValidator<CreateGenreCommand> validator)
        {
            _uow = uow;
            _validator = validator;
        }

        public async Task Handle(CreateGenreCommand command, CancellationToken cancellationToken)
        {
            var result = _validator.Validate(command);
            if (!result.IsValid) throw new ValidationRequestException($"Não foi possível criar o gênero.", result.Errors);

            var genre = command.MapToEntity();

            await _uow.Genres.AddAsync(genre);
            await _uow.CommitAsync();
        }
    }
}
