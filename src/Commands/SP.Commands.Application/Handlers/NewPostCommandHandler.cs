using MediatR;
using SP.Commands.Application.Commands;
using SP.Commands.Domain.Aggregates.PostAggregate;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class NewPostCommandHandler : ICommandHandler<NewPostCommand>
{
    private readonly IEventSourcingHandler<PostAggregate> _eventSourcingHandler;

    public NewPostCommandHandler(IEventSourcingHandler<PostAggregate> eventSourcingHandler)
    {
        _eventSourcingHandler = eventSourcingHandler;
    }

    public async Task<Unit> Handle(NewPostCommand request, CancellationToken cancellationToken)
    {
        var agg = new PostAggregate(request.Id, request.Author, request.Message);

        await _eventSourcingHandler.SaveAsync(agg);

        return await Task.FromResult(Unit.Value);
    }
}
