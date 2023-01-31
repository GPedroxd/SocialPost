using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class AddCommentCommandHandler : ICommandHandler<AddCommentCommand>
{
    public Task<Unit> Handle(AddCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}