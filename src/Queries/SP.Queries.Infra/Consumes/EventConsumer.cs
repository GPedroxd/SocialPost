using System.Text.Json;
using Confluent.Kafka;
using Microsoft.Extensions.Options;
using SP.Core.Consumers;
using SP.Core.Events;
using SP.Queries.Infra.Convertes;
using SP.Queries.Infra.Handlers;

namespace SP.Queries.Infra.Consumers;

public class EventConsumer : IEventConsumer
{
    private readonly ConsumerConfig _config;
    private readonly IEventHandler _eventHandler;

    public EventConsumer(IOptions<ConsumerConfig> config, IEventHandler handler)
    {
        _config = config.Value;
        _eventHandler = handler;
    }

    public void Consume(string topic)
    {
        using var consumer = new ConsumerBuilder<string, string>(_config)
                    .SetKeyDeserializer(Deserializers.Utf8)
                    .SetValueDeserializer(Deserializers.Utf8)
                    .Build();
        
        consumer.Subscribe(topic);

        while(true)
        {
            var consumeResult = consumer.Consume();

            if(consumeResult?.Message == null) continue;

            var opts = new JsonSerializerOptions(){ Converters = {new EventJsonConverter() }};

            var @event = JsonSerializer.Deserialize<BaseEvent>(consumeResult.Message.Value, opts);

            var handlerMethod = _eventHandler.GetType().GetMethod("On", new Type[] {@event.GetType() });

            if(handlerMethod is null) throw new ArgumentNullException( nameof(handlerMethod), "Could not find event handler method!");

            handlerMethod.Invoke(_eventHandler, new object[]{ @event });
            consumer.Commit(consumeResult);
        }
    }
}