namespace SoFilmes.Application.Movies.DTOs
{
    public record ReadMovieDto(
        Guid Id, 
        string Title, 
        string Summary, 
        int DurationInMinutes, 
        decimal Rating,
        string AgeClassification, 
        List<string> Genres,
        string CreatedAt, 
        string UpdatedAt
    );
}
