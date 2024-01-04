using Domain.Customers;
using Domain.Primitives;
using Domain.Products;

namespace Domain.Orders;

public class Order : Entity
{
    private readonly HashSet<LineItem> _lineItems = [];

    public OrderId Id { get; private set; } = default!;
    public CustomerId CustomerId { get; private set; } = default!;
    public OrderStatus Status { get; private set; } 

    public IReadOnlyList<LineItem> LineItems => _lineItems.ToList();

    public static Order Create(CustomerId customerId)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = customerId,
            Status = OrderStatus.Pending
        };

        order.Raise(new OrderCreatedDomainEvent(Guid.NewGuid(), order.Id));

        return order;
    }

    public void AddLineItem(ProductId productId, Money price, int quantity)
    {
        var lineItem = new LineItem(
            new LineItemId(Guid.NewGuid()), 
            Id, 
            productId, 
            price, 
            quantity);

        _lineItems.Add(lineItem);

        Raise(new LineItemAddedDomainEvent(Guid.NewGuid(), Id, lineItem.Id));
    }

    public void RemoveLineItem(ProductId productId)
    {
        var lineItems = _lineItems.Where(li => li.ProductId == productId).ToList();
        
        _lineItems.RemoveWhere(li => li.ProductId == productId);

        foreach (var lineItem in lineItems)
            Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(), Id, lineItem.Id));
    }

    // implemented double dispatch 
    public void RemoveLineItem(LineItemId lineItemId, IOrderRepository orderRepository) 
    {
        if (orderRepository.HasOneLineItem(this))
        {
            var lineItem = _lineItems.FirstOrDefault(li => li.Id == lineItemId);
            if (lineItem != null) _lineItems.Remove(lineItem);

            Raise(new LineItemRemovedDomainEvent(Guid.NewGuid(), Id, lineItemId));

            //_lineItems.RemoveWhere(li => li.Id == lineItemId);     
        }
    }
}