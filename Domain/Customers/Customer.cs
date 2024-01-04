namespace Domain.Customers;

public class Customer
{
    public CustomerId Id { get; private set; } = default!;
    public string Email { get; private set; } = default!;
    public string Name { get; private set; } = default!;
}
