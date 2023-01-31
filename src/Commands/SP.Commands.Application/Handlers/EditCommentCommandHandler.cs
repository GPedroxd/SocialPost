using MediatR;
using SP.Commands.Application.Commands;
using SP.Core.Handlers;

namespace SP.Commands.Application.Handlers;

public class EditCommentCommandHandler : ICommandHandler<EditCommentCommand>
{
    public Task<Unit> Handle(EditCommentCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}