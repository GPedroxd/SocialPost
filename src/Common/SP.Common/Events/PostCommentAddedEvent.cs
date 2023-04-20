using SP.Common.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record PostCommentAddedEvent : BaseEvent
{
    public PostCommentAddedEvent() : base(nameof(PostCommentAddedEvent))
    {
    }

    public Guid CommentId { get; set; } 
    public string? Comment { get; set; }
    public string? UserName { get; set; }
}