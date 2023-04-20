using SP.Common.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate.Events;

public record PostCreatedEvent : BaseEvent
{
    public PostCreatedEvent() : base(nameof(PostCreatedEvent))
    {
    }

    public string? Author { get; set; }
    public string? Message { get; set; }
}