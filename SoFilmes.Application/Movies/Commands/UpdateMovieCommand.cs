using MediatR;
using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.Commands
{
    public class UpdateMovieCommand : IRequest
    {
        public UpdateMovieCommand(Guid id, string title, string summary, int durationInMinutes, EAgeClassification ageClassification)
        {
            Id = id;
            Title = title;
            Summary = summary;
            DurationInMinutes = durationInMinutes;
            AgeClassification = ageClassification;
        }

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Summary { get; private set; }
        public int DurationInMinutes { get; private set; }
        public EAgeClassification AgeClassification { get; private set; }
    }
}
