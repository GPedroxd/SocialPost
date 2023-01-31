using MediatR;

namespace SP.Core.Commands;

public interface IBaseCommand<TResult> : IRequest<TResult>
{
    Guid Id { get; }
}

public interface IBaseCommand : IRequest
{
    Guid Id { get; }
}     