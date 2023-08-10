using SoFilmes.Domain.Enums;

namespace SoFilmes.Domain.Entities
{
    public sealed class Movie : EntityBase
    {
        public Movie(string title, string summary, int durationInMinutes, EAgeClassification ageClassification)
        {
            Title = title;
            Summary = summary;
            DurationInMinutes = durationInMinutes;
            AgeClassification = ageClassification;

            Rating = 0;
        }

        public string Title { get; private set; }
        public string Summary { get; private set; }
        public int DurationInMinutes { get; private set; }
        public EAgeClassification AgeClassification { get; private set; }
        public decimal Rating { get; private set; }

        public IReadOnlyCollection<MovieGenre> MoviesGenres { get; private set; } = null!;

        public void Update(string title, string summary, int durationInMinutes,  EAgeClassification ageClassification)
        {
            Title = title;
            Summary = summary;
            DurationInMinutes = durationInMinutes;
            AgeClassification = ageClassification;

            UpdatedAt = DateTime.Now;
        }

        public void UpdateRating(decimal rating)
        {
            Rating = rating;

            UpdatedAt = DateTime.Now;
        }
    }
}
