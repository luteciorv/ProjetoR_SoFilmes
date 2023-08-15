using SoFilmes.Application.Genres.Commands;
using SoFilmes.Application.Genres.DTOs;
using SoFilmes.Domain.Entities;

namespace SoFilmes.Application.Genres.Map
{
    public static class GenreMap
    {
        public static ReadGenreDto MapToReadGenreDto(this Genre entity) =>
            new(entity.Id, entity.Name, entity.CreatedAt.ToShortDateString(), entity.UpdatedAt.ToShortDateString());

        public static Genre MapToEntity(this CreateGenreCommand command) =>
            new(command.Name);
    }
}
