using Domain.Orders;
using Domain.Products;
using MediatR;

namespace Application.Orders.AddLineItem;

internal sealed class AddLineItemCommandHandler(
    IOrderRepository orderRepository,
    IProductRepository productRepository) : IRequestHandler<AddLineItemCommand>
{
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IProductRepository _productRepository = productRepository;

    public async Task Handle(AddLineItemCommand request, CancellationToken cancellationToken)
    {
        // 1. Fetch the order
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null) { return; }

        // 2. Fetch the product
        var product = await _productRepository.GetByIdAsync(request.ProductId);
        if(product == null) { return; }
        // 3. Add the product as line item

        order.AddLineItem(
            product.Id, 
            new Money(product.Price.Currency, product.Price.Amount), 
            request.Quantity);
    }
}
