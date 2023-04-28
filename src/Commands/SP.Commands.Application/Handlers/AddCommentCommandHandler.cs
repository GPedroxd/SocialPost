using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public AddCommentCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.AddComment(request.Comment, request.UserName);

        await _eventSourcingHandler.SaveAsync(agg);
    }
}