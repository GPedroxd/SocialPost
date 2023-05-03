using SP.Core.Commands;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;

namespace SP.Queries.Application.Queries;

public record GetPostsQuery : IBaseCommand<BaseResponse<List<PostEntity>>>
{
    public Guid Id { get; set; }
}