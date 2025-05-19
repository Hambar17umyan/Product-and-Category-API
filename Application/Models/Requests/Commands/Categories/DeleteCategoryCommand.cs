using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Categories;

namespace Application.Models.Requests.Commands.Categories;

public class DeleteCategoryCommand : IRequest<RequestHandlerResult<DeleteCategoryResponse>>
{
    /// <summary>
    /// Gets or sets the ID of the category to be deleted.
    /// </summary>
    public int CategoryId { get; set; }
}
