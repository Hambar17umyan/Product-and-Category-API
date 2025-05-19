using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Products;

namespace Application.Models.Requests.Commands.Products;

public class CreateProductCommand : IRequest<RequestHandlerResult<CreateProductResponse>>
{
    /// <summary>
    /// Gets or sets the name of the new product.
    /// </summary>
    public string ProductName { get; set; }

    /// <summary>
    /// Gets or sets the description of the new product.
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