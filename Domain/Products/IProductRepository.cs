
namespace Domain.Products;

public interface IProductRepository
{
    Task<Product?> GetByIdAsync(ProductId productId);
}
