using Microsoft.EntityFrameworkCore;
using SP.Queries.Application.Entities;
using SP.Queries.Application.Repositories;
using SP.Queries.Infra.DataAcess;

namespace SP.Queries.Infra.Repositories;

public class CommentRepository : ICommentRepository
{
    private readonly DatabaseContextFactory _contextFactory;

    public CommentRepository(DatabaseContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task CreateAsync(CommentEntity comment)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Comments.Add(comment);

        _ = await context.SaveChangesAsync();
    }

    public  async Task DeleteAsync(Guid commentId)
    {
        using var context = _contextFactory.CreateDbContext();

        var comment = await GetByIdAsync(commentId);

        if(comment is null) return;

        context.Comments.Remove(comment);

        _ = await context.SaveChangesAsync();
    }

    public async Task<CommentEntity> GetByIdAsync(Guid commentId)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Comments.FirstOrDefaultAsync(f => f.CommentId == commentId);
    }

    public async Task<List<CommentEntity>> GetCommentsByPostIdAsync(Guid postId)
    {
        using var context = _contextFactory.CreateDbContext();

        return await context.Comments
            .AsNoTracking()
            .Where(w => w.PostId == postId)
                .OrderBy(o => o.CommentDate)
                .ToListAsync();
    }

    public async Task UpdateAsync(CommentEntity comment)
    {
        using var context = _contextFactory.CreateDbContext();

        context.Comments.Update(comment);

        _ = await context.SaveChangesAsync();
    }
}
