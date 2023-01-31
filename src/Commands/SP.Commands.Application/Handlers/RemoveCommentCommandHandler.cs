using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class RemoveCommentCommandHandler : ICommandHandler<RemoveCommentCommand>
{
    public Task<Unit> Handle(RemoveCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
