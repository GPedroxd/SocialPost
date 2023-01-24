using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class EditPostCommand : BaseCommand<Unit>
{
    public string? Message { get; set; }
}
