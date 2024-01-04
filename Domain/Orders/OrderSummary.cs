
namespace Domain.Orders;

public class OrderSummary
{
    public Guid OrderId {  get; private set; }
    public Guid CustomerId { get; private set; }
    public decimal TotalAmount {  get; init; }    

    public OrderSummary(
        Guid orderId,
        Guid customerId, 
        decimal totalAmount) 
    {  
        OrderId = orderId;
        CustomerId = customerId;
        TotalAmount = totalAmount;
    }
}
