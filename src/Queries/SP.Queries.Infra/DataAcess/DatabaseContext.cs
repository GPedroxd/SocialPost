using Microsoft.EntityFrameworkCore;
using SP.Queries.Domain.Entities;

namespace SP.Queries.Infra.DataAcess;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<PostEntity> Posts { get;set; } 
    public DbSet<CommentEntity> Comments { get; set; }
}