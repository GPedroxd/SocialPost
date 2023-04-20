using SP.Common.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record PostDeletedEvent : BaseEvent 
{
    public PostDeletedEvent() : base(nameof(PostDeletedEvent))
    { }

}