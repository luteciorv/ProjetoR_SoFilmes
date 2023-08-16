using MediatR;
using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.Commands
{
    public class CreateMovieCommand : IRequest
    {
        public CreateMovieCommand(string title, string summary, int durationInMinutes, EAgeClassification ageClassification, List<Guid> genresId)
        {
            Title = title;
            Summary = summary;
            DurationInMinutes = durationInMinutes;
            AgeClassification = ageClassification;
            GenresId = genresId;
        }

        public Guid Id { get; private set; }

        public string Title { get; private set; }
        public string Summary { get; private set; }
        public int DurationInMinutes { get; private set; }
        public EAgeClassification AgeClassification { get; private set; }
        public IEnumerable<Guid> GenresId { get; private set; }

        public void SetId(Guid newId) =>
            Id = newId; 
    }
}
