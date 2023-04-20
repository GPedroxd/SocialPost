using SP.Core.Events;

namespace SP.Common.Events;

public record PostCommentRemovedEvent: BaseEvent
{
    public PostCommentRemovedEvent() : base(nameof(PostCommentRemovedEvent))
    {  }

    public Guid CommentId { get; set; }
}