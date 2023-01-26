namespace SP.Commands.Domain.Aggregates.PostAggregate;

public class PostComment
{
    public Guid Id { get; set; }
    public string? Author { get; set; }
    public string? Message { get; set; }
}