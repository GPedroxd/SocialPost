using MediatR;

namespace SP.Core.Events;

public interface IBaseEvent : INotification
{
    Guid Id { get; }
    DateTime OccurredOn { get; }
    int Version { get; }
    string? Type{ get; }
}