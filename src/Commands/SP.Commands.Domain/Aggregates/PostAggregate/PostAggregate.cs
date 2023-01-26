using SP.Commands.Domain.Aggregates.PostAggregate.Events;
using SP.Core.Domain;
using SP.Core.Events;

namespace SP.Commands.Domain.Aggregates.PostAggregate;

public class PostAggregate : AggregateRoot
{
    private List<IBaseEvent> _events = new();
    public override IReadOnlyList<IBaseEvent> Events => _events.AsReadOnly();

    private List<PostComment>  _comments = new();
    public IReadOnlyList<PostComment> Comments => _comments.AsReadOnly();

    public string? Author { get; private set; }

    public string? Message { get; private set; }
    private bool _isActive;

    public PostAggregate()
    { }

    public PostAggregate(string author, string message)
    { }

    public PostAggregate(Guid id, string author, string message)
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

    public override void AddEvent(IBaseEvent @event)
        => _events.Add(@event);

    public override void ClearEvents()
        => _events.Clear();

    public override void CommitChanges()
    { }

    public void UpdateMessage(string? message)
    {
        Message = message;

        AddEvent(new MessageUpdatedEvent()
        {
            Id = Id,
            Message = message
        });
    } 
    
    public void LikePost()
    {
        AddEvent(new PostLikedEvent()
        {
            Id = Id
        });
    }

    public void Delete()
    {
        _isActive = false;

        AddEvent(new PostDeletedEvent()
        {
            Id = Id
        });
    }

    public void AddComment(string? message, string userName)
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

    public void RemoveComment(Guid commentId, string userName)
    {
        _comments.RemoveAll(f => f.Id == commentId);

        AddEvent(new PostCommentRemovedEvent()
        {
            CommentId = commentId
        });
    }

    public void UpdateComment(Guid commentId, string message, string userName)
    {
        var comment = _comments.First(f => f.Id == commentId);

        comment.Message = message;

        AddEvent(new PostCommentUpdatedEvent()
        {
            Comment = message,
            CommentId = commentId,
            UserName = userName
        });
     }
}