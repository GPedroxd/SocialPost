using SP.Common.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record MessageUpdatedEvent : BaseEvent
{
    public MessageUpdatedEvent() : base(nameof(MessageUpdatedEvent))
    {
    }

    public string? Message{ get; set; }
}