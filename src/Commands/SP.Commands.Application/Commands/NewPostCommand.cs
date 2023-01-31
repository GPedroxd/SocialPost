using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class NewPostCommand : IBaseCommand
{
    public string? Author { get; set;  }
    public string? Message { get; set; }
    public Guid Id => Guid.NewGuid();
}