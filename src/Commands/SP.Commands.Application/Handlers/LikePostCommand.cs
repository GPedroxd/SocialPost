using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class LikePostCommandHandler : ICommandHandler<LikePostCommand>
{
    public Task<Unit> Handle(LikePostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
