using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.DTOs
{
    public record ReadMovieDto(
        Guid Id, 
        string Title, 
        string Summary, 
        int DurationInMinutes, 
        decimal Rating,
        string AgeClassification, 
        string CreatedAt, 
        string UpdatedAt
    );
}
