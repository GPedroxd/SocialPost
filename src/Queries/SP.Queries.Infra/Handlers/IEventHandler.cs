using SP.Common.Events;

namespace SP.Queries.Infra.Handlers;


public interface IEventHandler 
{  
    Task OnPostCreated(PostCreatedEvent @event);
    Task OnMessageUpdated(MessageUpdatedEvent @event);
    Task OnPostLiked(PostLikedEvent @event);
    Task OnCommentAdded(PostCommentAddedEvent @event);
    Task OnCommentUpdated(PostCommentUpdatedEvent @event);
    Task OnCommentRemoved(PostCommentRemovedEvent @event);
    Task OnPostDeleteEvent(PostDeletedEvent @event);
}