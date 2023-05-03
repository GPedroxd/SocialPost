using SP.Core.Handlers;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Queries;
using SP.Queries.Application.Repositories;

namespace SP.Queries.Application.Handlers;

public class GetPostsQueryHandler : ICommandHandler<GetPostsQuery, BaseResponse<List<PostEntity>>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsQueryHandler(IPostRepository postRepository)
        => _postRepository = postRepository;

    public async Task<BaseResponse<List<PostEntity>>> Handle(GetPostsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<PostEntity>>();

        response.Success = true;
        response.SuccessResponse = await _postRepository.GetAsync();
        return response;
    }
}
