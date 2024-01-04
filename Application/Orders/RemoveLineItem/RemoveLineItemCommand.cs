using Domain.Orders;
using MediatR;

namespace Application.Orders.RemoveLineItem;

internal sealed record RemoveLineItemCommand(OrderId OrderId, LineItemId LineItemId) : IRequest;
