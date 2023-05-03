using SP.Queries.Application.Entities;

namespace SP.Queries.Application.Repositories;

public interface ICommentRepository
{
    Task CreateAsync(CommentEntity comment);
    Task UpdateAsync(CommentEntity comment);
    Task<CommentEntity> GetByIdAsync(Guid commentId);
    Task DeleteAsync(Guid commentId);
    Task<List<CommentEntity>> GetCommentsByPostIdAsync(Guid postId);
}