using SP.Common.Events;

namespace SP.Queries.Infra.Handlers;


public interface IEventHandler 
{  
    Task On(PostCreatedEvent @event);
    Task On(MessageUpdatedEvent @event);
    Task On(PostLikedEvent @event);
    Task On(PostCommentAddedEvent @event);
    Task On(PostCommentUpdatedEvent @event);
    Task On(PostCommentRemovedEvent @event);
    Task On(PostDeletedEvent @event);
}