using MediatR;

namespace SoFilmes.Application.Genres.Commands
{
    public class CreateGenreCommand : IRequest
    {
        public CreateGenreCommand(string name)
        {
            Name = name;
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public void SetId(Guid id) =>
            Id = id;
    }
}
