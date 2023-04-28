using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class RemoveCommentCommandHandler : ICommandHandler<RemoveCommentCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public RemoveCommentCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.RemoveComment(request.CommentId);

        await _eventSourcingHandler.SaveAsync(agg);
    }
}
