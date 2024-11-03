using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MovieStore.Api.Contracts;

namespace MovieStore.Api.Models;

public class Movie
{
    internal const string CollectionName = "movies";
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("title")] public string? Title { get; set; }
    
    [BsonElement("genre")] public string? Genre { get; set; }
    
    [BsonElement("releaseYear")] public int? ReleaseYear { get; set; }
    
    [BsonElement("actors")] public List<string>? Actors { get; set; }
    
    [BsonElement("directors")] public List<string>? Directors { get; set; }
    
    [BsonElement("insertedOn")] public DateTime InsertedOn { get; set; }
}

public static class MovieExtensions
{
    public static MovieDto ToDto(this Movie movie)
    {
        return new MovieDto
        {
            Title = movie.Title,
            Genre = movie.Genre,
            Directors = movie.Directors,
            Actors = movie.Actors,
            ReleaseYear = movie.ReleaseYear
        };
    }
}