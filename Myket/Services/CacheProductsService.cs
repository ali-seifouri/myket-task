using Microsoft.Extensions.Caching.Memory;
using Myket.Models;

namespace Myket.Services;

public class CacheProductsService : IProductsService
{
    private readonly IProductsService _innerService;
    private readonly IMemoryCache _memoryCache;

    public CacheProductsService(IProductsService innerService, IMemoryCache memoryCache)
    {
        _innerService = innerService;
        _memoryCache = memoryCache;
    }

    public async Task<List<ProductResult>> GetProductAsync(string productName)
    {
        if (_memoryCache.TryGetValue(productName, out List<ProductResult>? cacheValue))
            return cacheValue ?? new List<ProductResult>();
        var result = await _innerService.GetProductAsync(productName);
        var cacheEntryOptions = new MemoryCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(1)
        };
        _memoryCache.Set(productName, result, cacheEntryOptions);
        return result;
    }
}