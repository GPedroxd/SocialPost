using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class LikePostCommandHandler : ICommandHandler<LikePostCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public LikePostCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task Handle(LikePostCommand request, CancellationToken cancellationToken)
    {
        var agg = await _eventSourcingHandler.GetByIdAsync(request.Id);

        agg.LikePost();

        await _eventSourcingHandler.SaveAsync(agg);
    }
}
