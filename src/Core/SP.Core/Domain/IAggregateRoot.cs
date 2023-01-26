using SP.Core.Events;

namespace SP.Core.Domain;

public interface IAggregateRoot 
{    
    IReadOnlyList<IBaseEvent> Events { get; }
    void AddEvent(IBaseEvent @event); 
    void CommitChanges();
    void ClearEvents();
}