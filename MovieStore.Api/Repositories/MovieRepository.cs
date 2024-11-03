using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStore.Api.Infrastructure.Database;
using MovieStore.Api.Models;

namespace MovieStore.Api.Repositories;

public class MovieRepository
{
    private readonly IMongoCollection<Movie> _movieCollection;

    public MovieRepository(IOptions<DbConnectionSettings> dbConnectionSettings)
    {
        var connectionSettings = dbConnectionSettings.Value;
        var dbClient = new MongoClient(connectionSettings.ConnectionURI);
        var database = dbClient.GetDatabase(connectionSettings.DatabaseName);
        _movieCollection = database.GetCollection<Movie>(Movie.CollectionName);
    }

    internal async Task InsertMovieAsync(Movie movie)
    {
        await _movieCollection.InsertOneAsync(movie);
    }
    
    internal async Task<Movie> GetMovieById(string id)
    {
        var movie = await _movieCollection.FindAsync(movie => movie.Id == id);
        return await movie.FirstOrDefaultAsync();
    }
}