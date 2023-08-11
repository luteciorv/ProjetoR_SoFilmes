using MediatR;
using Microsoft.AspNetCore.Mvc;
using SoFilmes.Application.Movies.DTOs;
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
        public async Task<ActionResult<IReadOnlyCollection<ReadMovieDto>>> Get(
            [FromQuery] int skip = 0, 
            [FromQuery] int take = 25)
        {
            var query = new GetMoviesQuery(skip, take);
            var movies = await _mediator.Send(query);

            return Ok(movies);
        }

        // Recuperar o filme de id informado
        [HttpGet("{id:guid}")]
        public ActionResult Get([FromRoute] Guid id) 
        {
            return Ok(id);
        }

        // Recuperar o filme pelo título informado
        [HttpGet("{title}")]
        public ActionResult Get([FromRoute] string title)
        {
            return Ok(title);
        }

        // Criar o filme
        [HttpPost]
        public ActionResult Post()
        {
            return Ok();
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
