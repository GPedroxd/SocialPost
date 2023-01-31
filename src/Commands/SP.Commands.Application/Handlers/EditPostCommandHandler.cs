using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class EditPostCommandHandler : ICommandHandler<EditPostCommand>
{
    public Task<Unit> Handle(EditPostCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
