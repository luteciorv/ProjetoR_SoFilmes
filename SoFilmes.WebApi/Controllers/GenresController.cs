using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoFilmes.Application.Genres.Commands;
using SoFilmes.Application.Genres.DTOs;
using SoFilmes.Application.Genres.Map;
using SoFilmes.Application.Genres.Queries;
using SoFilmes.WebApi.Exceptions;

namespace SoFilmes.WebApi.Controllers
{
    [TypeFilter(typeof(ExceptionFilter))]
    [Route("api/generos")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly ISender _mediator;

        public GenresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyCollection<ReadGenreDto>>> Get(
            [FromQuery] int skip = 0,
            [FromQuery] int take = 25)
        {
            var query = new GetGenresQuery(skip, take);
            var genresDto = await _mediator.Send(query);

            return Ok(genresDto);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ReadGenreDto>> Get([FromRoute] Guid id)
        {
            var query = new GetGenreByIdQuery(id);
            var genreDto = await _mediator.Send(query);

            return Ok(genreDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateGenreDto createGenreDto)
        {
            var command = createGenreDto.MapToCreateGenreCommand();
            await _mediator.Send(command);

            var query = new GetGenreByIdQuery(command.Id);
            var genreDto = await _mediator.Send(query);

            return CreatedAtAction(nameof(Get), new { genreDto.Id }, genreDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult> Put([FromRoute] Guid id, [FromBody] UpdateGenreDto updateGenreDto)
        {
            var command = updateGenreDto.MapToUpdateGenreCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> Delete([FromRoute] Guid id)
        {
            var command = new DeleteGenreCommand(id);
            await _mediator.Send(command);

            return Ok();
        }
    }
}
