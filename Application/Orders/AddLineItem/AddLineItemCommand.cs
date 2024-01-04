using Domain.Orders;
using Domain.Products;
using MediatR;

namespace Application.Orders.AddLineItem;

internal record AddLineItemCommand(OrderId OrderId, ProductId ProductId, int Quantity) : IRequest;