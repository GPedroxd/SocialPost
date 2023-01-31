using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class DeletePostCommand : IBaseCommand
{
    public string? UserName { get; set; }

    public Guid Id => Guid.NewGuid();
}