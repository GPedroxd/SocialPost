using MediatR;
using SP.Core.Commands;

namespace SP.Core.Handlers;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand>
    where TCommand : IBaseCommand
{

}

public interface ICommandHandler<in TCommand, TResult> : IRequestHandler<TCommand, TResult>
    where TCommand : IBaseCommand<TResult>
{

}