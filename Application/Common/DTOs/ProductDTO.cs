namespace Application.Common.DTOs;

/// <summary>
/// Data Transfer Object (DTO) for Product.
/// </summary>
public class ProductDTO
{
    /// <summary>
    /// Gets or sets the unique identifier for the product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the product.
    /// </summary>
    public string ProductName { get; set; } = "";

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public int ProductCategory1Id { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public int ProductCategory2Id { get; set; }

    /// <summary>
    /// Gets or sets the description of the product.
    /// </summary>
    public int? Category3Id { get; set; }
}
