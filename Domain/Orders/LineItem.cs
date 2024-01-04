using Domain.Products;

namespace Domain.Orders;

public class LineItem
{
    public LineItem() { }
    public LineItem(
        LineItemId id,
        OrderId orderId,
        ProductId productId,
        Money price,
        int quantity) 
    { 
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
        Quantity = quantity;
    }
    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; private set; } 
    public ProductId ProductId { get; private set; } 
    public Money Price { get; private set; } 
    public int Quantity { get; private set; }
}