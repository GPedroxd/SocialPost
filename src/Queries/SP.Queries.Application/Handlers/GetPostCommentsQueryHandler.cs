using SP.Core.Handlers;
using SP.Queries.Application.Dtos;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Queries;
using SP.Queries.Application.Repositories;

namespace SP.Queries.Application.Handlers;

public class GetPostCommentsQueryHandler : ICommandHandler<GetPostCommentsQuery, BaseResponse<List<CommentEntity>>>
{
    private readonly ICommentRepository _commentRepository;

    public GetPostCommentsQueryHandler(ICommentRepository commentRepository)
        =>_commentRepository = commentRepository;
    
    public async Task<BaseResponse<List<CommentEntity>>> Handle(GetPostCommentsQuery request, CancellationToken cancellationToken)
    {
        var response = new BaseResponse<List<CommentEntity>>();

        response.Success = true;
        response.SuccessResponse = await _commentRepository.GetCommentsByPostIdAsync(request.PostId);

        return response;
    }
}