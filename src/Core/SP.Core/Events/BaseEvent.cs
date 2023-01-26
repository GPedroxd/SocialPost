namespace SP.Core.Events;

public abstract record BaseEvent : IBaseEvent
{
    protected BaseEvent(string type)
    {
        Type = type;
    }

    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime OccurredOn => DateTime.UtcNow;

    public int Version { get; set; } = -1;

    public string? Type { get; }
} 