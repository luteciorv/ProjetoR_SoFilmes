using MediatR;

namespace SoFilmes.Application.Genres.Commands
{
    public class DeleteGenreCommand : IRequest
    {
        public DeleteGenreCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
