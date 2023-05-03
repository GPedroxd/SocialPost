using SP.Core.Handlers;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Queries;
using SP.Queries.Application.Repositories;

namespace SP.Queries.Application.Handlers;

public class GetPostsByAuthrQueryHandler : ICommandHandler<GetPostsByAuthorQuery, BaseResponse<List<PostEntity>>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsByAuthrQueryHandler(IPostRepository postRepository)
        => _postRepository = postRepository;

    public async Task<BaseResponse<List<PostEntity>>> Handle(GetPostsByAuthorQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<PostEntity>>();

        var posts = await _postRepository.GetByAuthorAsync(request.Author);

        response.Success = true;
        response.SuccessResponse = posts;

        return response;
    }
}