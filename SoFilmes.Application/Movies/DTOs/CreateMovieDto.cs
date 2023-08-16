using SoFilmes.Domain.Enums;

namespace SoFilmes.Application.Movies.DTOs
{
    public record CreateMovieDto(
        string Title, 
        string Summary, 
        int DurationInMinutes, 
        EAgeClassification AgeClassification,
        List<Guid> GenresId
    );
}
