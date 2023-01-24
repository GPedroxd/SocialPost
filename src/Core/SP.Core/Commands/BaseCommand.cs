namespace SP.Core.Commands;

public abstract class BaseCommand<TResult> : IBaseCommand<TResult>
{
    public Guid Id => Guid.NewGuid();
}