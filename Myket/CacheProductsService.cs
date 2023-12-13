namespace Myket
{
    public class CacheProductsService : IProductsService
    {
        private readonly IProductsService _innerService;

        public CacheProductsService(IProductsService innerService)
        {
            _innerService = innerService;
        }

        public async Task<ProductResult> GetProductAsync(string productName)
        {
            //search in cache if not go to web
            var result = await _innerService.GetProductAsync(productName);
            return result ;
        }
    }
}
