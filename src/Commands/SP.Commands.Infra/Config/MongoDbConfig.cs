namespace SP.Commands.Infra.Config;

public record MongoDbConfig 
{
    public string? ConnectionString { get; set; }
    public string? DatabaseName { get; set; }
    public string? CollectionName { get; set; }
}