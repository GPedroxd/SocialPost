using Microsoft.EntityFrameworkCore;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Repositories;
using SP.Queries.Infra.DataAcess;

namespace SP.Queries.Infra.Repositories;

public class PostRepository : IPostRepository
{
    private readonly DatabaseContextFactory _contextFactory;

    public PostRepository(DatabaseContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateAsync(PostEntity post)
    {
        using var context = _contextFactory.CreateDbContext();
        
        context.Posts.Add(post);

        _ = await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid postId)
    {
        using var context = _contextFactory.CreateDbContext();
        var post = await GetByIdAsync(postId);

        if(post is null) return;

        context.Posts.Remove(post);

        _ = await context.SaveChangesAsync();
    }

    public async Task<List<PostEntity>> GetAsync()
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Posts
        .AsNoTracking()
        .OrderByDescending(o => o.Dateposted)
        .ToListAsync();
    }

    public async Task<List<PostEntity>> GetByAuthorAsync(string author)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Posts
        .AsNoTracking()
        .Include( p => p.Comments)
        .Where(w => w.Author.Contains(author))
        .ToListAsync();
    }

    public async Task<List<PostEntity>> GetByCommentAsync(int likes)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Posts
        .AsNoTracking()
        .Include( p => p.Comments)
        .Where(w => w.Comments != null && w.Comments.Any())
        .ToListAsync();
    }

    public async Task<PostEntity> GetByIdAsync(Guid postId)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Posts.Include( p => p.Comments).FirstOrDefaultAsync(f => f.PostId == postId);
    }

    public async Task<List<PostEntity>> GetByLikesAsync(int likes)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Posts
        .AsNoTracking()
        .Include( p => p.Comments)
        .Where(w => w.Likes >= likes)
        .ToListAsync();
    }

    public async Task UpdateAsync(PostEntity post)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Posts.Update(post);

        _ = await context.SaveChangesAsync();
    }
}