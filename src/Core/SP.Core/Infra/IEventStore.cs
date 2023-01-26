using SP.Core.Events;

namespace SP.Core.Infra;

public interface IEventStore
{
    Task SaveAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion);
    Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId);
}