using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Products;

namespace Application.Models.Requests.Queries.Products;

public class GetProductByIdQuery : IRequest<RequestHandlerResult<GetProductByIdResponse>>
{
    /// <summary>
    /// Gets or sets the product ID.
    /// </summary>
    public int ProductId { get; set; }
}