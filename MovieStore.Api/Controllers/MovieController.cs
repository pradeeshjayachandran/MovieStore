using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Contracts;
using MovieStore.Api.Services;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieStore.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MovieController : ControllerBase
{
    private readonly MovieService _movieService;

    public MovieController(MovieService movieService)
    {
        _movieService = movieService;
    }
    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Adds movie to moviestore",
        Description = "Inserts the given movie to moviestore with generated id"
    )]
    public async Task<ActionResult> AddMovie([FromBody] MovieDto movie)
    {
        var movieId = await _movieService.AddMovieAsync(movie);
        return CreatedAtAction(nameof(GetMovie), new { id = movieId }, movie);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Gets movie by id", 
        Description = "Fetches movie details from movie store using the specified id"
    )]
    public async Task<ActionResult> GetMovie(string id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        return Ok(movie);
    }
}