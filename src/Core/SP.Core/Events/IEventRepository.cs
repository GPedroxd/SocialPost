namespace SP.Core.Events;

public interface IEventRepository
{
    Task SaveAsync(EventModel @event);
    Task SaveAsync(IEnumerable<EventModel> events);
    Task<List<EventModel>> FindByAggregateAsync(Guid aggregateId);
}