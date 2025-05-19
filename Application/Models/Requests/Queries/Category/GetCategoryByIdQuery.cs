using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;

namespace Application.Models.Requests.Queries.Categories;

public class GetCategoryByIdQuery : IRequest<RequestHandlerResult<GetCategoryByIdResponse>>
{
    public int CategoryId { get; set; }
}