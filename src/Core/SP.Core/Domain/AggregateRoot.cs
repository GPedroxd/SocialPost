using SP.Core.Events;

namespace SP.Core.Domain;

public abstract class AggregateRoot : IAggregateRoot
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public abstract IReadOnlyList<IBaseEvent> Events { get; }

    public abstract void AddEvent(IBaseEvent @event);

    public abstract void ClearEvents();

    public abstract void CommitChanges();
}