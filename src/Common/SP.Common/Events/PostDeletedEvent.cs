using SP.Core.Events;

namespace SP.Common.Events;

public record PostDeletedEvent : BaseEvent 
{
    public PostDeletedEvent() : base(nameof(PostDeletedEvent))
    { }

}