namespace MovieStore.Api.Contracts;

public class MovieDto
{ 
    public string? Title { get; set; }
    public string? Genre { get; set; }
    public int? ReleaseYear { get; set; }
    public List<string>? Actors { get; set; }
    public List<string>? Directors { get; set; }
}

