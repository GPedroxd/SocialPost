using SP.Core.Domain;

namespace SP.Core.Handlers;

public interface IEventSourcingHandler<T> where T : AggregateRoot
{
    Task SaveAsync(AggregateRoot aggregate);

    Task<T> GetByIdAsync(Guid aggregateId);
}