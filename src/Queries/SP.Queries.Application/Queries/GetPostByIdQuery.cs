using SP.Core.Commands;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;

namespace SP.Queries.Application.Queries;

public record GetPostByIdQuery : IBaseCommand<BaseResponse<PostEntity>>
{
    public Guid PostId { get; set; }

    public Guid Id { get; set; } = Guid.NewGuid();
}