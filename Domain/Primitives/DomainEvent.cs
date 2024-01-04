using MediatR;

namespace Domain.Primitives;

// use nuget package MediatR.Contracts which only contains the contracts
public record DomainEvent(Guid Id) : INotification;