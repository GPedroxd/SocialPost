using SP.Queries.Application.Entities;

namespace SP.Queries.Application.Repositories;

public interface IPostRepository
{
    Task CreateAsync(PostEntity post);
    Task UpdateAsync(PostEntity post);
    Task DeleteAsync(Guid postId);
    Task<PostEntity> GetByIdAsync(Guid postId);
    Task<List<PostEntity>> GetAsync();
    Task<List<PostEntity>> GetByAuthorAsync(string? author);
    Task<List<PostEntity>> GetByLikesAsync(int likes);
    Task<List<PostEntity>> GetByCommentAsync(int likes);
}