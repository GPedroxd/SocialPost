using SP.Core.Events;

namespace SP.Common.Events;

public record PostLikedEvent : BaseEvent
{
    public PostLikedEvent() : base(nameof(PostLikedEvent))
    {
    }
    
}