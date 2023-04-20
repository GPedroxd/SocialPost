using SP.Core.Events;

namespace SP.Common.Events;

public record MessageUpdatedEvent : BaseEvent
{
    public MessageUpdatedEvent() : base(nameof(MessageUpdatedEvent))
    {
    }

    public string? Message{ get; set; }
}