using MediatR;

namespace SoFilmes.Application.Movies.Commands
{
    public class PatchMovieCommand : IRequest
    {
        public PatchMovieCommand(Guid id, decimal rating)
        {
            Id = id;
            Rating = rating;
        }

        public Guid Id { get; private set; }
        public decimal Rating { get; private set; }
    }
}
