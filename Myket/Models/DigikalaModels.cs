using System.Text.Json.Serialization;

namespace Myket.Models;

public record DigikalaProductResult
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


