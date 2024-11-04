using MovieStore.Api.Contracts;
using MovieStore.Api.Models;
using MovieStore.Api.Repositories;
using MovieStore.Api.Services;
using NSubstitute;

namespace MovieStore.Api.Unit.Test;

public class MovieServiceTests
{
    private readonly MovieService _sut = null!;
    private readonly IMovieRepository _movieRepository = null!;
    
    public MovieServiceTests()
    {
        _movieRepository= Substitute.For<IMovieRepository>();
        _sut = new MovieService(_movieRepository);
    }
    
    
    [Fact]
    public async Task AddMovieAsync_ShouldAddMovie_WhenMovieIsProvided()
    {
        //Arrange
        var movieDto = new MovieDto
        {
            Title = "Forrest Gump",
            Directors = ["Babybob"],
            ReleaseYear = 2024,
            Genre = "Comedy",
            Actors = ["Tom Hanks"]
        };
        _movieRepository.InsertMovieAsync(Arg.Any<Movie>()).Returns(Guid.NewGuid().ToString());  
        
        //Act
        var movieId = await _sut.AddMovieAsync(movieDto);
        
        //Assert
        Assert.NotNull(movieId);
    }
}