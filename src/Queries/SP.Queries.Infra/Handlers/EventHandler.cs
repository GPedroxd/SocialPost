using SP.Common.Events;
using SP.Queries.Domain.Entities;
using SP.Queries.Domain.Repositories;

namespace SP.Queries.Infra.Handlers;

public class EventHandler : IEventHandler
{
    private readonly IPostRepository _postRepository;
    private readonly ICommentRepository _commentRepository;

    public EventHandler(IPostRepository postRepository, ICommentRepository commentRepository)
    {
        _postRepository = postRepository;
        _commentRepository = commentRepository;
    }

    public async Task On(PostCommentAddedEvent @event)
    {
        var comment = new CommentEntity
        {
            PostId = @event.Id,
            CommentId = @event.CommentId,
            Comment = @event.Comment,
            UserName = @event.UserName,
            Edited = false
        };

        await _commentRepository.CreateAsync(comment);
    }

    public async Task On(PostCommentRemovedEvent @event)
    {
        var comment = await _commentRepository.GetByIdAsync(@event.CommentId);
        
        if(comment is null) return;

        await _commentRepository.DeleteAsync(comment.CommentId);
    }

    public async Task On(PostCommentUpdatedEvent @event)
    {
        var comment = await _commentRepository.GetByIdAsync(@event.CommentId);
        if(comment is null) return;
        comment.Comment = @event.Comment;
        comment.Edited = true;
        comment.CommentDate = @event.OccurredOn;

        await _commentRepository.UpdateAsync(comment);
    }

    public async Task On(MessageUpdatedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if(post is null) return;

        post.Message = @event.Message;

        await _postRepository.UpdateAsync(post);
    }

    public async Task On(PostCreatedEvent @event)
    {
        var post = new PostEntity
        {
            PostId = @event.Id,
            Author = @event.Author,
            Dateposted = @event.OccurredOn,
            Message = @event.Message
        };

        await _postRepository.CreateAsync(post);
    }

    public async Task On(PostDeletedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if(post is null) return;

        await _postRepository.DeleteAsync(post.PostId);
    }

    public async Task On(PostLikedEvent @event)
    {
        var post = await _postRepository.GetByIdAsync(@event.Id);

        if(post is null) return;

        post.Likes++;
        
        await _postRepository.UpdateAsync(post);
    }
}