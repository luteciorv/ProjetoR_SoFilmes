using MediatR;

namespace SoFilmes.Application.Movies.Commands
{
    public class DeleteMovieCommand : IRequest
    {
        public DeleteMovieCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; private set; }
    }
}
