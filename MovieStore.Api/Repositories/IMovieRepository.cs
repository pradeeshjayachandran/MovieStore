using MovieStore.Api.Models;

namespace MovieStore.Api.Repositories;

public interface IMovieRepository
{
    Task<string> InsertMovieAsync(Movie movie);
    
    Task<Movie> GetMovieById(string id);
}