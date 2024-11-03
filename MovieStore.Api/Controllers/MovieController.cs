using Microsoft.AspNetCore.Mvc;
using MovieStore.Api.Contracts;
using MovieStore.Api.Services;

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
    public async Task<ActionResult> AddMovie([FromBody] MovieDto movie)
    {
        var movieId = await _movieService.AddMovieAsync(movie);
        return CreatedAtAction(nameof(GetMovie), new { id = movieId }, movie);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetMovie(string id)
    {
        var movie = await _movieService.GetMovieByIdAsync(id);
        return Ok(movie);
    }
}