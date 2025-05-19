using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Commands.Products;

public class DeleteProductResponse : IResponse<DeleteProductCommand>
{
    /// <summary>
    /// Gets or sets the ID of the deleted product.
    /// </summary>
    public int? ProductId { get; set; }
    /// <summary>
    /// Gets or sets the name of the deleted product.
    /// </summary>
    public string? ProductName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the first product category.
    /// </summary>
    public int? ProductCategory1Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the second product category.
    /// </summary>
    public int? ProductCategory2Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the third product category.
    /// </summary>
    public int? ProductCategory3Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the second product category.
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}