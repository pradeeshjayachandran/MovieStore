using MovieStore.Api.Contracts;
using MovieStore.Api.Models;
using MovieStore.Api.Repositories;

namespace MovieStore.Api.Services;

public class MovieService
{
    private readonly MovieRepository _movieRepository;

    public MovieService(MovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    public async Task<string?> AddMovieAsync(MovieDto movieDto)
    {
        var movie = new Movie
        {
            Title = movieDto.Title,
            Genre = movieDto.Genre,
            Actors = movieDto.Actors,
            Directors = movieDto.Directors,
            ReleaseYear = movieDto.ReleaseYear,
            InsertedOn = DateTime.UtcNow
        };
        
        await _movieRepository.InsertMovieAsync(movie);
        return movie.Id;
    }

    public async Task<MovieDto> GetMovieByIdAsync(string id)
    {
        var movie = await _movieRepository.GetMovieById(id);
        return movie.ToDto();
    }
}