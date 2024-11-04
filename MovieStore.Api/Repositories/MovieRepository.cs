using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStore.Api.Infrastructure.Database;
using MovieStore.Api.Models;

namespace MovieStore.Api.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IMongoCollection<Movie> _movieCollection;

    public MovieRepository(IOptions<DbConnectionSettings> dbConnectionSettings)
    {
        var connectionSettings = dbConnectionSettings.Value;
        var dbClient = new MongoClient(connectionSettings.ConnectionURI);
        var database = dbClient.GetDatabase(connectionSettings.DatabaseName);
        _movieCollection = database.GetCollection<Movie>(Movie.CollectionName);
    }

    /// <summary>
    /// Inserts given movie into database
    /// </summary>
    /// <param name="movie"> Movie to be inserted</param>
    /// <returns></returns>>
    public async Task<string> InsertMovieAsync(Movie movie)
    {
        await _movieCollection.InsertOneAsync(movie);
        return movie.Id;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<Movie> GetMovieById(string id)
    {
        var movie = await _movieCollection.FindAsync(movie => movie.Id == id);
        return await movie.FirstOrDefaultAsync();
    }
}