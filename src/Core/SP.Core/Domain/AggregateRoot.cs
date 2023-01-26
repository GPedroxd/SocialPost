using SP.Core.Events;

namespace SP.Core.Domain;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public abstract IReadOnlyList<BaseEvent> Events { get; }
    public int Version { get; set; }
    public abstract void AddEvent(BaseEvent @event);

    public abstract void ClearEvents();

    public abstract void CommitChanges();

    public void ReplayEvents(IEnumerable<BaseEvent> events)
    {
        
    }
}