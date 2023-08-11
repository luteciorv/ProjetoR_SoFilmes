using MediatR;
using SoFilmes.Application.Exceptions;
using SoFilmes.Application.Interfaces.Repositories;

namespace SoFilmes.Application.Movies.Commands.Handlers
{
    public class DeleteMovieCommandHandler : IRequestHandler<DeleteMovieCommand>
    {
        private readonly IUnitOfWork _uow;

        public DeleteMovieCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task Handle(DeleteMovieCommand command, CancellationToken cancellationToken)
        {
            var movie = await _uow.Movies.GetByIdAsync(command.Id) ??
                        throw new EntityNotFoundException($"O filme de id {command.Id} não foi encontrado.");

            _uow.Movies.Delete(movie);
            await _uow.CommitAsync();
        }
    }
}
