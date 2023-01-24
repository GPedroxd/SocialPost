using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class AddCommentCommand : BaseCommand<Unit>
{
    public string? Comment { get; set; }
    public string? UserName{ get; set; }
}