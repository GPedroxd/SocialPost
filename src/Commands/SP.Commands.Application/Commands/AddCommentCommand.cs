using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class AddCommentCommand : IBaseCommand
{
    public string? Comment { get; set; }
    public string? UserName{ get; set; }

    public Guid Id => Guid.NewGuid();
}