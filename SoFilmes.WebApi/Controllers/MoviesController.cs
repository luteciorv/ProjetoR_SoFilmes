using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoFilmes.Application.Movies.DTOs;
using SoFilmes.Application.Movies.Map;
using SoFilmes.Application.Movies.Queries;
using SoFilmes.WebApi.Exceptions;

namespace SoFilmes.WebApi.Controllers
{
    [TypeFilter(typeof(ExceptionFilter))]
    [Route("api/filmes")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly ISender _mediator;

        public MoviesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Recupera um total de "take" filmes cadastrados
        /// </summary>
        /// <param name="skip">Quantidade de filmes que serão ignorados na busca.</param>
        /// <param name="take">Quantidade de filmes que serão retornados na busca.</param>
        /// <returns>Um IReadOnlyCollection dos filmes recuperados</returns>
        /// <response code="200">Filmes recuperados com sucesso</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<ReadMovieDto?>>> Get(
            [FromQuery] int skip = 0, 
            [FromQuery] int take = 25)
        {
            var query = new GetMoviesQuery(skip, take);
            var moviesDto = await _mediator.Send(query);

            return Ok(moviesDto);
        }

        /// <summary>
        /// Recupera o filme com o "id" informado
        /// </summary>
        /// <param name="id">Identificador do filme.</param>
        /// <returns>Um ReadMovieDto do filme recuperado</returns>
        /// <response code="200">Filme recuperado com sucesso</response>
        /// <response code="404">Filme não encontrado</response>
        [HttpGet("{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ReadMovieDto>> Get([FromRoute] Guid id) 
        {
            var query = new GetMovieByIdQuery(id);
            var movieDto = await _mediator.Send(query);

            return Ok(movieDto);
        }

        /// <summary>
        /// Recupera os filmes comtendo o "title" informado
        /// </summary>
        /// <param name="title">Título conteido no filme.</param>
        /// <param name="skip">Quantidade de filmes que serão ignorados na busca.</param>
        /// <param name="take">Quantidade de filmes que serão retornados na busca.</param>
        /// <returns>Um IReadOnlyCollection dos filmes recuperados.</returns>
        /// <response code="200">Filmes recuperados com sucesso</response>
        [HttpGet("{title}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyCollection<ReadMovieDto?>>> Get(
            [FromRoute] string title,
            [FromQuery] int skip = 0,
            [FromQuery] int take = 25)
        {
            var query = new GetMoviesByTitleQuery(title, skip, take);
            var moviesDto = await _mediator.Send(query);

            return Ok(moviesDto);
        }

        /// <summary>
        /// Cria o filma
        /// </summary>
        /// <param name="dto">Dados utilizados para criar o filme</param>
        /// <returns>O CreatedAtAction do filme criado</returns>
        /// <response code="200">Filme recuperado com sucesso</response>
        /// <response code="400">Erro na requisição. Os dados estão inválidos</response>
        /// <response code="404">O filme criado não foi encontrado.</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Post([FromBody] CreateMovieDto dto)
        {
            var command = dto.MapToCreateMovieCommand();
            await _mediator.Send(command);

            var query = new GetMovieByIdQuery(command.Id);
            var movieDto = await _mediator.Send(query);

            return CreatedAtAction(nameof(Get), new { command.Id }, movieDto);
        }

        // Atualizar os dados do filme
        [HttpPut("{id:guid}")]
        public ActionResult Put([FromRoute] Guid id)
        {
            return Ok(id);
        }

        // Atualizar o rating do filme
        [HttpPatch("{id:guid}")]
        public ActionResult Pacth([FromRoute] Guid id)
        {
            return Ok(id);
        }

        // Excluir o filme
        [HttpDelete("{id:guid}")]
        public ActionResult Delete([FromRoute] Guid id)
        {
            return Ok(id);
        }
    }
}
