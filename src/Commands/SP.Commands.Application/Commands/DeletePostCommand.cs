using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class DeletePostCommand : BaseCommand<Unit>
{
    public string? UserName { get; set; }
}