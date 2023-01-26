using SP.Core.Events;

namespace SP.Core.Domain;

public interface IAggregateRoot 
{    
    IReadOnlyList<BaseEvent> Events { get; }
    void AddEvent(BaseEvent @event); 
    void CommitChanges();
    void ClearEvents();
}