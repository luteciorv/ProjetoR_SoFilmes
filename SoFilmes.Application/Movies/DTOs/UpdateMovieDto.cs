using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.DTOs
{
    public record UpdateMovieDto(
        string Title, 
        string Summary, 
        int DurationInMinutes, 
        EAgeClassification AgeClassification
    );
}
