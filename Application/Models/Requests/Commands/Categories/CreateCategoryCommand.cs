using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Commands.Categories;

namespace Application.Models.Requests.Commands.Categories;

public class CreateCategoryCommand : IRequest<RequestHandlerResult<CreateCategoryResponse>>
{
    /// <summary>
    /// Gets or sets the name of the new category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the new category.
    /// </summary>
    public string CategoryDescription { get; set; } = string.Empty;
}
