using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.DTOs
{
    public record ReadMovieDto(
        Guid Id, 
        string Title, 
        string Summary, 
        int DurationInMinutes, 
        EAgeClassification AgeClassification, 
        DateTime CreatedAt, 
        DateTime UpdatedAt
    );
}
