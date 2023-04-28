using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class EditCommentCommandHandler : ICommandHandler<EditCommentCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public EditCommentCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.UpdateComment(request.CommentId, request.Comment, request.UserName);

        await _eventSourcingHandler.SaveAsync(agg);
    }
}