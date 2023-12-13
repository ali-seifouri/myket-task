using System.Text.Json;

namespace Myket
{
    public interface IProductDetail
    {
        public Task<ProductResult> GetProductDetail(string productName);
    }

    
    public class TorobProductDetail: IProductDetail
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public TorobProductDetail(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductResult> GetProductDetail(string productName)
        {
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://api.torob.com/v4/base-product/search/?page=0&sort=popularity&size=24&q={productName}");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            // var result;
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<TorobProductResult>(contentString);
                return result;
            }

            return null;
        }
    }

    public class DigikalaProductDetails : IProductDetail
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DigikalaProductDetails(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<ProductResult> GetProductDetail(string productName)
        {
            // https://api.digikala.com/v1/search/?q=asd&page=1
            var httpRequestMessage = new HttpRequestMessage(
                HttpMethod.Get,
                $"https://api.digikala.com/v1/search/?q={productName}&page=1");

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                var contentString = await httpResponseMessage.Content.ReadAsStringAsync();
                var result = JsonSerializer.Deserialize<DigikalaProductResult>(contentString);
                return result;
            }

            return null;
        }
    }
}
