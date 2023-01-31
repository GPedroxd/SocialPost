using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Events;
using SP.Core.Infra;
using SP.Core.Producers;

namespace SP.Commands.Infra.Store;

public class EventStore : IEventStore
{
    private readonly IEventRepository _eventRepository;
    private readonly IEventProducer _eventProducer;
    public EventStore(IEventRepository eventRepository, IEventProducer eventProducer)
    {
        _eventRepository = eventRepository;
        _eventProducer = eventProducer;
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
         
        var topic = Environment.GetEnvironmentVariable("KAFKA_TOPIC");

        foreach (var @event in events)
        {
            @event.Version = ++version;
            
            var eventModel = new EventModel(aggregateId, version, @event, nameof(PostAggregate));
            await _eventRepository.SaveAsync(eventModel);

            await _eventProducer.ProduceAsync(topic, @event);
        }
    }
}