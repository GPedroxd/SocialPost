namespace SP.Core.Events;

public class EventModel
{
    public EventModel(Guid aggregationIdentifier, int version, BaseEvent @event, string? aggregateType)
    {
        Id = Guid.NewGuid();
        OccurredOn = DateTime.UtcNow;
        AggregateIdentifier = aggregationIdentifier;
        AggregateType = aggregateType;
        Version = version;
        EventData = @event;
    }
    public EventModel()
        => EventData = default!;
    
    public Guid Id { get; set; }
    public DateTime OccurredOn { get; set; }
    public Guid AggregateIdentifier { get; set; }
    public string? AggregateType { get; set; }
    public int Version { get; set; }
    public string? EventType { get => EventData.GetType().Name; }
    public BaseEvent EventData { get; set; }
}