using SP.Core.Events;

namespace SP.Common.Events;

public record PostCreatedEvent : BaseEvent
{
    public PostCreatedEvent() : base(nameof(PostCreatedEvent))
    {
    }

    public string? Author { get; set; }
    public string? Message { get; set; }
}