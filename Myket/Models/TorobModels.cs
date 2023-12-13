using System.Text.Json.Serialization;

namespace Myket.Models;

public record TorobProductResult
{
    [property: JsonPropertyName("results")]
    public TorobInnerResult[] Results { get; set; }
}

public record TorobInnerResult(
    [property: JsonPropertyName("image_url")] string ImageUrl,
    [property: JsonPropertyName("name1")] string Name,
    [property: JsonPropertyName("price")] decimal Price
);