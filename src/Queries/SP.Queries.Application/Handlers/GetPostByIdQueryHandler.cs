using SP.Core.Handlers;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Queries;
using SP.Queries.Application.Repositories;

namespace SP.Queries.Application.Handlers;

public class GetPostByIdQueryHandler : ICommandHandler<GetPostByIdQuery, BaseResponse<PostEntity>>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdQueryHandler(IPostRepository postRepository)
        => _postRepository = postRepository;

    public async Task<BaseResponse<PostEntity>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<PostEntity>();

        var post = await _postRepository.GetByIdAsync(request.PostId);

        response.Success = !(post is null);
        response.SuccessResponse = post;

        return response;
    }
}