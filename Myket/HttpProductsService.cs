namespace Myket;

public class HttpProductsService : IProductsService
{

    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IProductDetail _torobProductDetail;
    private readonly IEnumerable<IProductDetail> _services;
    

    public HttpProductsService(IHttpClientFactory httpClientFactory, IProductDetail torobProductDetail, IEnumerable<IProductDetail> services)
    {
        _httpClientFactory = httpClientFactory;
        _torobProductDetail = torobProductDetail;
        _services = services;
    }


    public async Task<ProductResult> GetProductAsync(string productName)
    {
        var tasks = new List<Task<ProductResult>>();
        foreach (var service in _services)
        {
            Task<ProductResult> task = Task.Run(async () => await service.GetProductDetail(productName));
            tasks.Add(task);
        }
        var results = await Task.WhenAll(tasks);
        foreach (var result in results)
        {
            
        }

        return null;
    }

    public async Task<string> GetProductData()
    {
        return "";
    }
}



