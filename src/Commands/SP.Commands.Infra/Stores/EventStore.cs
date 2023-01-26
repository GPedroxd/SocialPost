using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Events;
using SP.Core.Infra;

namespace SP.Commands.Infra.Store;

public class EventStore : IEventStore
{
    private readonly IEventRepository _eventRepository;

    public EventStore(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<List<BaseEvent>> GetEventsAsync(Guid aggregateId)
    {
        var eventStream = await _eventRepository.FindByAggregateAsync(aggregateId);

        if(eventStream is null || !eventStream.Any()) return new();

        return eventStream.OrderBy(o => o.Version).Select(s => s.EventData).ToList();
    }

    public async Task SaveAsync(Guid aggregateId, IEnumerable<BaseEvent> events, int expectedVersion)
    {
        var version = expectedVersion;
         
        var eventsModels = new List<EventModel>();
        
        foreach (var @event in events)
        {
            @event.Version = ++version;
            
            var eventModel = new EventModel(aggregateId, version, @event, nameof(PostAggregate));
        };

        await _eventRepository.SaveAsync(eventsModels);
    }
}