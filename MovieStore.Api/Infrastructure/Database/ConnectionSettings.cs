using MongoDB.Driver;

namespace MovieStore.Api.Infrastructure.Database;

public class DbConnectionSettings
{
    public const string DatabaseConfig = "DataSource";
    public string ConnectionURI { get; set; }
    public string DatabaseName { get; set; }
    public string CollectionName { get; set; }
}