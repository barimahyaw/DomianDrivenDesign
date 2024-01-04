using MediatR;

namespace Application.Orders.Create;

internal sealed record CreateOrderCommand(Guid CustomerId) : IRequest;
