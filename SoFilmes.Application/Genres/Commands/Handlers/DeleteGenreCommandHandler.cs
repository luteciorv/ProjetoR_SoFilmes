using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Genres.Commands.Handlers
{
    public class DeleteGenreCommandHandler : IRequestHandler<DeleteGenreCommand>
    {
        private readonly IUnitOfWork _uow;

        public DeleteGenreCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(DeleteGenreCommand command, CancellationToken cancellationToken)
        {
            var genre = await _uow.Genres.GetByIdAsync(command.Id) ??
                        throw new EntityNotFoundException($"O gênero de id {command.Id} não foi encontrado.");

            _uow.Genres.Delete(genre);
            await _uow.CommitAsync();
        }
    }
}
