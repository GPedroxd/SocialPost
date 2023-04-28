using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Domain;
using SP.Core.Handlers;
using SP.Core.Infra;

namespace SP.Commands.Infra.Handlers;

public class EventSourcingHandler : IEventSourcingHandler<PostAggregate>
{
    private readonly IEventStore _eventStore;

    public EventSourcingHandler(IEventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public async Task<PostAggregate> GetByIdAsync(Guid aggregateId)
    {
        var aggregate = new PostAggregate();
        var events = await _eventStore.GetEventsAsync(aggregateId);

        if(events == null || !events.Any()) return aggregate;

        aggregate.ReplayChanges(events);
        aggregate.Version = events.Select(s => s.Version).Max();

        return aggregate;
    }

    public async Task SaveAsync(AggregateRoot aggregate)
    {
        await _eventStore.SaveAsync(aggregate.Id, aggregate.Events, aggregate.Version);
        aggregate.ClearEvents();
    }
}