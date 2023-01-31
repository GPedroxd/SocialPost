using SP.Core.Events;

namespace SP.Core.Producers;

public interface IEventProducer 
{
    Task ProduceAsync<T>(string? topic, T @event) where T : IBaseEvent;
}