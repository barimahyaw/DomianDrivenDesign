namespace Domain.Orders;

public interface IOrderRepository
{
    void Add(Order order);
    bool HasOneLineItem(Order order);
    Task<Order> GetByIdAsync(OrderId orderId);
}
