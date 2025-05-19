using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Products;

namespace Application.Models.Requests.Commands.Products;

public class UpdateProductCommand : IRequest<RequestHandlerResult<UpdateProductResponse>>
{
    /// <summary>
    /// Gets or sets the ID of the updated product.
    /// </summary>
    public int ProductId { get; set; }

    /// <summary>
    /// Gets or sets the name of the updated product.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Gets or sets the ID of the first product category.
    /// </summary>
    public int ProductCategory1Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the second product category.
    /// </summary>
    public int ProductCategory2Id { get; set; }

    /// <summary>
    /// Gets or sets the ID of the third product category.
    /// </summary>
    public int? ProductCategory3Id { get; set; }
}