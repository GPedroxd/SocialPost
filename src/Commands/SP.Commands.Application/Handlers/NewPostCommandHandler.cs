using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class NewPostCommandHandler : ICommandHandler<NewPostCommand>
{
    public Task<Unit> Handle(NewPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
