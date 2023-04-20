using SP.Common.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record PostCommentRemovedEvent: BaseEvent
{
    public PostCommentRemovedEvent() : base(nameof(PostCommentRemovedEvent))
    {  }

    public Guid CommentId { get; set; }
}