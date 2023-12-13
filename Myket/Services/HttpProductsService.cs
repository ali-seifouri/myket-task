using Myket.Models;

namespace Myket.Services;

public class HttpProductsService : IProductsService
{
    private readonly IEnumerable<IProductProviderDetails> _services;


    public HttpProductsService(IEnumerable<IProductProviderDetails> services)
    {
        _services = services;
    }


    public async Task<List<ProductResult>> GetProductAsync(string productName)
    {
        var tasks = _services.Select(
            service => 
                Task.Run(async () => await service.GetProductDetail(productName))
                ).ToList();

        var result = new List<ProductResult>();
        var results = await Task.WhenAll(tasks);
        foreach (var r in results)
        {
            result.AddRange(r);
        }
        return result;
    }
}