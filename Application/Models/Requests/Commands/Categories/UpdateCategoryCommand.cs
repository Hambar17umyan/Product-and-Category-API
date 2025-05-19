using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Categories;

namespace Application.Models.Requests.Commands.Categories;

public class UpdateCategoryCommand : IRequest<RequestHandlerResult<UpdateCategoryResponse>>
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryDescription { get; set; }
}
