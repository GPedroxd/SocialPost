using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public DeletePostCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.Delete();

        await _eventSourcingHandler.SaveAsync(agg);
    }
}
