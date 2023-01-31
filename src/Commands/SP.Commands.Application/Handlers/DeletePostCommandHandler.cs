using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class DeletePostCommandHandler : ICommandHandler<DeletePostCommand>
{
    public Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
