using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class EditCommentCommand : BaseCommand<Unit>
{
    public Guid CommentId { get; set; }
    public string? Comment { get; set; }
    public string? UserName { get; set; }
}