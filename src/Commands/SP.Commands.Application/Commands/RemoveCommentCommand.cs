using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class RemoveCommentCommand : IBaseCommand
{
    public Guid CommentId { get; set; }

    public string? UserName { get; set;}
    public Guid Id => Guid.NewGuid();
}