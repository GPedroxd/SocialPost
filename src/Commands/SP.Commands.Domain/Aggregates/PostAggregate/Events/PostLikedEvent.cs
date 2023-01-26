using SP.Core.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record PostLikedEvent : BaseEvent
{
    public PostLikedEvent() : base(nameof(PostLikedEvent))
    {
    }
    
}