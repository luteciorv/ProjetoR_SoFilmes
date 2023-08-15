using MediatR;

namespace SoFilmes.Application.Genres.Commands
{
    public class UpdateGenreCommand : IRequest
    {
        public UpdateGenreCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}
