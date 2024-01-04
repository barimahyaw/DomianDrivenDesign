using Domain.Customers;
using Domain.Orders;
using MediatR;

namespace Application.Orders.Create;

internal sealed class CreateOrderCommandHandler(
    ICustomerRepository customerRepository,
    IOrderRepository orderRepository,
    IOrderSummaryRepository orderSummaryRepository) : IRequestHandler<CreateOrderCommand>
{
    private readonly ICustomerRepository _customerRepository = customerRepository;
    private readonly IOrderRepository _orderRepository = orderRepository;
    private readonly IOrderSummaryRepository _orderSummaryRepository = orderSummaryRepository;

    public async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        // create order implementation
        var customer = await _customerRepository.GetByIdAsync(
            new CustomerId(request.CustomerId));

        if (customer is null)  { return; }

        var order = Order.Create(customer.Id);

        _orderRepository.Add(order);

        _orderSummaryRepository.Add(new OrderSummary(order.Id.Value, customer.Id.Value, 0));
    }
}
