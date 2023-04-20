using SP.Core.Events;

namespace SP.Common.Events;

public record PostCommentUpdatedEvent : BaseEvent
{
    public PostCommentUpdatedEvent() : base(nameof(PostCommentUpdatedEvent))
    { }

    public Guid CommentId { get; set; } 
    public string? Comment { get; set; }
    public string? UserName { get; set; }
}