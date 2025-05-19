namespace Application.Models.Requests.Queries.Categories;

using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;
public class GetCategoriesPaginationQuery : IRequest<RequestHandlerResult<GetCategoriesPaginationResponse>>
{
    /// <summary>
    /// Gets or sets the page number.
    /// </summary>
    public int Page { get; set; } = 1;
    /// <summary>
    /// Gets or sets the page size.
    /// </summary>
    public int PageSize { get; set; } = 10;
}
