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
    [property: JsonPropertyName("title_fa")] string Name,
    [property: JsonPropertyName("images")] DigikalaImagesResult Images,
    [property: JsonPropertyName("default_variant")] DigikalaDefaultVariantResult DefaultVariant
);

public record DigikalaImagesResult(
    [property: JsonPropertyName("main")] DigikalaMainImageResult? Main
);

public record DigikalaMainImageResult(
    [property: JsonPropertyName("url")] string[] Url
);

public record DigikalaDefaultVariantResult(
    [property: JsonPropertyName("price")] DigikalaPriceResult Price
);

public record DigikalaPriceResult(
    [property: JsonPropertyName("selling_price")] decimal SellingPrice
);
