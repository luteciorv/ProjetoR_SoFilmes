using MediatR;

namespace SoFilmes.Application.Genres.Commands
{
    public class CreateGenreCommand : IRequest
    {
        public CreateGenreCommand(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
