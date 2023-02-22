using SP.Queries.Domain.Entities;

namespace SP.Queries.Domain.Repositories;

public interface IPostRepository
{
    Task CreateAsync(PostEntity post);
    Task UpdateAsync(PostEntity post);
    Task DeleteAsync(Guid postId);
    Task<PostEntity> GetByIdAsync(Guid postId);
    Task<IEnumerable<PostEntity>> GetAsync();
    Task<IEnumerable<PostEntity>> GetByAuthorAsync(string? author);
    Task<IEnumerable<PostEntity>> GetByLikesAsync(int likes);
    Task<IEnumerable<PostEntity>> GetByCommentAsync(int likes);
}