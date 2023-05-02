using MediatR;
using SP.Core.Commands;

namespace SP.Commands.Application.Commands;

public class LikePostCommand : IBaseCommand
{
    public Guid Id {get; set; }
}