using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class NewPostCommand : BaseCommand<Unit>
{
    public string? Author { get; set;  }
    public string? Message { get; set; }
}