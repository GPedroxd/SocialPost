using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using SP.Common.Events;
using SP.Core.Events;

namespace SP.Commands.Infra.MongoConfiguration;

public static class MongoConfiguration 
{
    public static void Config ()
    {
        //difine how will be serialize guids atributtes, in this case will be as string
        BsonSerializer.RegisterSerializer(typeof(Guid), new GuidSerializer(MongoDB.Bson.BsonType.String));  

        BsonClassMap.RegisterClassMap<BaseEvent>();
        BsonClassMap.RegisterClassMap<PostCreatedEvent>();
        BsonClassMap.RegisterClassMap<MessageUpdatedEvent>();
        BsonClassMap.RegisterClassMap<PostLikedEvent>();
        BsonClassMap.RegisterClassMap<PostCommentAddedEvent>();
        BsonClassMap.RegisterClassMap<PostCommentUpdatedEvent>();
        BsonClassMap.RegisterClassMap<PostCommentRemovedEvent>();
        BsonClassMap.RegisterClassMap<PostDeletedEvent>();
    }
}