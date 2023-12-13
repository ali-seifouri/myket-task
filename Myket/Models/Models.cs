namespace Myket.Models;

public record ProductResult
{
    public string Provider { get; set; }
    public string ImageUrl { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
}