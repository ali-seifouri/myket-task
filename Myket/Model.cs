using System.Text.Json.Serialization;

namespace Myket
{
    public record ProductResult{}

    public record TorobProductResult : ProductResult
    {
        [property: JsonPropertyName("results")]
        public TorobInnerResult[] Results { get; set; }
    }

    public record TorobInnerResult(
        [property: JsonPropertyName("image_url")] string ImageUrl,
        [property: JsonPropertyName("name1")] string Name,
        [property: JsonPropertyName("price")] decimal Price
    );


    public record DigikalaProductResult : ProductResult
    {
        [property: JsonPropertyName("data")]
        public DigikalaDataResult Results { get; set; }
    }

    public record DigikalaDataResult(
        [property: JsonPropertyName("products")] DigikalaProductsResult[] Products
    );

    public record DigikalaProductsResult(
        [property: JsonPropertyName("title_fa")] string Name
        // [property: JsonPropertyName("images")] string Images
    );

    public record DigikalaImageResult(
        [property: JsonPropertyName("title_fa")] string Name,
        [property: JsonPropertyName("images")] string Images
    );


}

