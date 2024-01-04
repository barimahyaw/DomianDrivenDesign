namespace Domain.Products;

public class Product
{
    public ProductId Id { get; private set; } = default!;
    public string Name { get; private set; } = default!;
    public Money Price { get; private set; } = default!;
    public Sku? Sku { get; private set; }
}