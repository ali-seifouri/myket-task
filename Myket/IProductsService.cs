namespace Myket
{
    public interface IProductsService
    {
        Task<ProductResult> GetProductAsync(string productName);
    }
}
