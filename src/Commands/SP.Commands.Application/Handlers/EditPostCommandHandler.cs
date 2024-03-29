using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class EditPostCommandHandler : ICommandHandler<EditPostCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public EditPostCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.UpdateMessage(request.Message);

        await _eventSourcingHandler.SaveAsync(agg);
    }
}
