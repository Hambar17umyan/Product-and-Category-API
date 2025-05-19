using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Products;

namespace Application.Models.Requests.Commands.Products;

public class DeleteProductCommand : IRequest<RequestHandlerResult<DeleteProductResponse>>
{
    /// <summary>
    /// Gets or sets the ID of the product to be deleted.
    /// </summary>
    public int ProductId { get; set; }
}