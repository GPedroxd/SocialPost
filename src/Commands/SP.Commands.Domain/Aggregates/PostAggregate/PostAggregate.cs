using SP.Common.Events;
using SP.Core.Domain;
using SP.Core.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate;

public class PostAggregate : AggregateRoot
{
    private List<BaseEvent> _events = new();
    public override IReadOnlyList<BaseEvent> Events => _events.AsReadOnly();

    private List<PostComment>  _comments = new();
    public IReadOnlyList<PostComment> Comments => _comments.AsReadOnly();

    public string? Author { get; private set; }

    public string? Message { get; private set; }

    public int Likes { get; set; }

    private bool _isActive = true;

    public PostAggregate()
    { }

    public PostAggregate(string? author, string? message)
    { }

    public PostAggregate(Guid id, string? author, string? message)
    { 
        Id = id;
        Author = author;
        Message = message;

        AddEvent(new PostCreatedEvent()
        {
            Id = id,
            Author = author,
            Message = message
        });
    }

    public override void AddEvent(BaseEvent @event)
        => _events.Add(@event);

    public override void ClearEvents()
        => _events.Clear();

    public override void CommitChanges()
    { 
        foreach (var @event in Events)
        {
            var eventType = @event.GetType().Name;

            switch (eventType)
            {
                case nameof(PostCreatedEvent):
                        var postCreatedEvent = @event as PostCreatedEvent;

                        if(postCreatedEvent is null) throw new NullReferenceException();

                        this.Id = postCreatedEvent.Id;
                        _isActive = true;
                        Author = postCreatedEvent.Author;
                        Message = postCreatedEvent.Message;
                    break;

                case nameof(MessageUpdatedEvent):
                        var messageUpdatedEvent = @event as MessageUpdatedEvent;

                        if(messageUpdatedEvent is null) throw new NullReferenceException();

                        UpdateMessage(messageUpdatedEvent.Message, false);
                    break;
                
                case nameof(PostDeletedEvent):
                        var postDeletedEvent = @event as PostDeletedEvent;

                        if(postDeletedEvent is null) throw new NullReferenceException();

                        Delete(false);
                    break;

                case nameof(PostLikedEvent):
                        var postLikedEvent = @event as PostLikedEvent;

                        if(postLikedEvent is null) throw new NullReferenceException();

                        LikePost(false);
                    break;

                case nameof(PostCommentAddedEvent):
                        var postCommentAddedEvent = @event as PostCommentAddedEvent;

                        if(postCommentAddedEvent is null) throw new NullReferenceException();

                        AddComment(postCommentAddedEvent.Comment, postCommentAddedEvent.UserName, false);
                    break;

                case nameof(PostCommentUpdatedEvent):
                        var postCommentUpdatedEvent = @event as PostCommentUpdatedEvent;

                        if(postCommentUpdatedEvent is null) throw new NullReferenceException();

                        UpdateComment(postCommentUpdatedEvent.CommentId, postCommentUpdatedEvent.Comment, postCommentUpdatedEvent.UserName, false);
                    break;
                case nameof(PostCommentRemovedEvent):
                        var postCommentRemovedEvent = @event as PostCommentRemovedEvent;

                        if(postCommentRemovedEvent is null) throw new NullReferenceException();

                        RemoveComment(postCommentRemovedEvent.CommentId, false);
                    break;
            }
        }
    }

    public void ReplayChanges(List<BaseEvent> events)
    {
        _events = events;

        CommitChanges();

        ClearEvents();
    }

    public void UpdateMessage(string? message, bool isNew = true)
    {
        if(!_isActive) return;

        Message = message;

        if(isNew)
            AddEvent(new MessageUpdatedEvent()
            {
                Id = Id,
                Message = message
            });
    } 
    
    public void LikePost(bool isNew = true)
    {
        Likes++;
        if(isNew)
            AddEvent(new PostLikedEvent()
            {
                Id = Id
            });
    }

    public void Delete(bool isNew = true)
    {
        _isActive = false;
        if(isNew)
            AddEvent(new PostDeletedEvent()
            {
                Id = Id
            });
    }

    public void AddComment(string? message, string? userName, bool isNew = true)
    {
        var comment = new PostComment() 
        {
            Id = Guid.NewGuid(),
            Author = userName,
            Message = message
        };

        _comments.Add(comment);

        AddEvent(new PostCommentAddedEvent()
        {
            Id = Id,
            CommentId = comment.Id,
            Comment = comment.Message,
            UserName = comment.Author
        });
    }

    public void RemoveComment(Guid commentId, bool isNew = true)
    {
        _comments.RemoveAll(f => f.Id == commentId);
        
        if(isNew)
            AddEvent(new PostCommentRemovedEvent()
            {
                CommentId = commentId
            });
    }

    public void UpdateComment(Guid commentId, string? message, string? userName, bool isNew = true)
    {
        var comment = _comments.First(f => f.Id == commentId);

        comment.Message = message;

        if(isNew)
            AddEvent(new PostCommentUpdatedEvent()
            {
                Comment = message,
                CommentId = commentId,
                UserName = userName
            });
     }
}