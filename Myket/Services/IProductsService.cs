using Myket.Models;

namespace Myket.Services;

public interface IProductsService
{
    Task<List<ProductResult>> GetProductAsync(string productName);
}