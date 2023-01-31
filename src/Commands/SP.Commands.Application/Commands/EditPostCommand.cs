using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class EditPostCommand : IBaseCommand
{
    public string? Message { get; set; }
    public Guid Id => Guid.NewGuid();
}
