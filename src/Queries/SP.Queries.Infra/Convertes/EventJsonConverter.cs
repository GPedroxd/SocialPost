using System.Text.Json;
using System.Text.Json.Serialization;
using SP.Common.Events;
using SP.Core.Events;

namespace SP.Queries.Infra.Convertes;

public class EventJsonConverter : JsonConverter<BaseEvent>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsAssignableFrom(typeof(BaseEvent));
    }

    public override BaseEvent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if(!JsonDocument.TryParseValue(ref reader, out var doc))
            throw new JsonException($"Failed to parse {nameof(JsonDocument)}");

        if(!doc.RootElement.TryGetProperty("Type", out var type))
            throw new JsonException("Could not detect the type discriminator property");

        var typeDiscriminator = type.GetString();
        var json = doc.RootElement.GetRawText();

        return typeDiscriminator switch
        {
            nameof(PostCreatedEvent) => JsonSerializer.Deserialize<PostCreatedEvent>(json, options),
            nameof(MessageUpdatedEvent) => JsonSerializer.Deserialize<MessageUpdatedEvent>(json, options),
            nameof(PostDeletedEvent) => JsonSerializer.Deserialize<PostDeletedEvent>(json, options),
            nameof(PostLikedEvent) => JsonSerializer.Deserialize<PostLikedEvent>(json, options),
            nameof(PostCommentAddedEvent) => JsonSerializer.Deserialize<PostCommentAddedEvent>(json, options),
            nameof(PostCommentRemovedEvent) => JsonSerializer.Deserialize<PostCommentRemovedEvent>(json, options),
            nameof(PostCommentUpdatedEvent) => JsonSerializer.Deserialize<PostCommentUpdatedEvent>(json, options),
             _ => throw new JsonException($"{typeDiscriminator} is not supported!")
        };
    }

    public override void Write(Utf8JsonWriter writer, BaseEvent value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}