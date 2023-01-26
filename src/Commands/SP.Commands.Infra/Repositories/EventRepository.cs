using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SP.Commands.Infra.Config;
using SP.Core.Events;

namespace SP.Commands.Infra.Repositories;

public class EventRepository : IEventRepository
{
    private readonly IMongoCollection<EventModel> _eventCollention;

    public EventRepository(IOptions<MongoDbConfig> config)
    {
        var mongoClient = new MongoClient(config.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(config.Value.DatabaseName);

        _eventCollention = mongoDatabase.GetCollection<EventModel>(config.Value.CollectionName);
    }

    public async Task<List<EventModel>> FindByAggregateAsync(Guid aggregateId)
        =>  await _eventCollention.Find(f => f.AggregateIdentifier == aggregateId).ToListAsync().ConfigureAwait(false);
        
    public async Task SaveAsync(EventModel @event)
        => await _eventCollention.InsertOneAsync(@event).ConfigureAwait(false);  

    public async Task SaveAsync(IEnumerable<EventModel> events)
        => await _eventCollention.InsertManyAsync(events).ConfigureAwait(false);  
}