using SP.Core.Commands;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;

namespace SP.Queries.Application.Queries;

public record GetPostsByAuthorQuery : IBaseCommand<BaseResponse<List<PostEntity>>>
{
    public string? Author { get; set; }

    public Guid Id { get; set;}
}