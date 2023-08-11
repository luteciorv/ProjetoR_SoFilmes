using SoFilmes.Application.Movies.Commands;
using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Movies.Map
{
    public static class MovieMap
    {
        public static ReadMovieDto MapToReadMovieDto(this Movie entity) =>
            new(entity.Id, entity.Title, entity.Summary, entity.DurationInMinutes, entity.Rating, entity.AgeClassification.MapToString(), entity.CreatedAt.ToShortDateString(), entity.UpdatedAt.ToShortDateString());

        public static CreateMovieCommand MapToCreateMovieCommand(this CreateMovieDto dto) =>
            new(dto.Title, dto.Summary, dto.DurationInMinutes, dto.AgeClassification);

        public static UpdateMovieCommand MapToUpdateMovieCommand(this UpdateMovieDto dto, Guid id) =>
            new(id, dto.Title, dto.Summary, dto.DurationInMinutes, dto.AgeClassification);

        public static PatchMovieCommand MapToPatchMovieCommand(this PatchMovieDto dto, Guid id) =>
            new(id, dto.Rating);

        public static Movie MapToMovie(this CreateMovieCommand command) =>
            new(command.Title, command.Summary, command.DurationInMinutes, command.AgeClassification);
    }
}
