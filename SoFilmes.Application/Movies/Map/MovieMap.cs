using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Movies.Map
{
    public static class MovieMap
    {
        public static ReadMovieDto MapToReadMovieDto(this Movie entity) =>
            new(entity.Id, entity.Title, entity.Summary, entity.DurationInMinutes, entity.AgeClassification, entity.CreatedAt, entity.UpdatedAt);
    }
}
