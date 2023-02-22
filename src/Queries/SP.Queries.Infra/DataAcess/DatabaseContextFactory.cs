using Microsoft.EntityFrameworkCore;

namespace SP.Queries.Infra.DataAcess;

public class DatabaseContextFactory
{
    private readonly Action<DbContextOptionsBuilder> _configureDbContext;

    public DatabaseContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
    {
        _configureDbContext = configureDbContext;
    }

    public DatabaseContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<DatabaseContext>();
        _configureDbContext(options);
        
        return new DatabaseContext(options.Options);
    }
}