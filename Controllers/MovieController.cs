using Microsoft.AspNetCore.Mvc;
using MyMovies.Dtos;
using MyMovies.Services.Interfaces;
using System.Collections.Generic;

namespace MyMovies.Controllers
{
    [ApiController]
    [Route("api/movie")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<MovieDto>> GetAll()
        {
            var moviesDto = _movieService.GetAll();

            return Ok(moviesDto);
        }

        [HttpGet("{id}")]
        public ActionResult<MovieDto> Get([FromRoute] int id)
        {
            var movieDto = _movieService.Get(id);

            if (movieDto is null)
                return NotFound();

            return Ok(movieDto);
        }

        [HttpPost]
        public ActionResult Create([FromBody] CreateMovieDto dto)
        {
            var movieId = _movieService.Create(dto);

            return Created($"/api/movie/{movieId}", null);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _movieService.Delete(id);

            if (isDeleted)
                return NoContent();

            return NotFound();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromRoute] int id, [FromBody] CreateMovieDto dto)
        {
            var isUpdated = _movieService.Update(id, dto);

            if (isUpdated)
                return Ok();

            return NotFound();
        }

    }
}
