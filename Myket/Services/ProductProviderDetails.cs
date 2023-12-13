using System.Text.Json;
using Myket.Models;

namespace Myket.Services;

public interface IProductProviderDetails
{
    public Task<List<ProductResult>> GetProductDetail(string productName);
}


public class TorobProductProviderDetails : IProductProviderDetails
{

    private readonly IHttpClientFactory _httpClientFactory;

    public TorobProductProviderDetails(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<ProductResult>> GetProductDetail(string productName)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://api.torob.com/v4/base-product/search/?page=0&sort=popularity&size=24&q={productName}");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (!httpResponseMessage.IsSuccessStatusCode) return new List<ProductResult>();
        var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<TorobProductResult>(contentString);
        return result.Results.Select(r => new ProductResult
        {
            ImageUrl = r.ImageUrl,
            Name = r.Name,
            Price = r.Price,
            Provider = "Torob"
        }).ToList();
    }
}

public class DigikalaProductProviderDetails : IProductProviderDetails
{
    private readonly IHttpClientFactory _httpClientFactory;

    public DigikalaProductProviderDetails(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<ProductResult>> GetProductDetail(string productName)
    {
        var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"https://api.digikala.com/v1/search/?q={productName}&page=1");

        var httpClient = _httpClientFactory.CreateClient();
        var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

        if (!httpResponseMessage.IsSuccessStatusCode) return new List<ProductResult>();
        var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
        var result = JsonSerializer.Deserialize<DigikalaProductResult>(contentString);
        return result.Results.Products.Select(r => new ProductResult
        {
            ImageUrl = "",
            Name = r.Name,
            Price = 0m,
            Provider = "Digikala"
        }).ToList();

    }
}