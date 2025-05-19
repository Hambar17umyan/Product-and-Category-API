using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Common.Extensions.Mapping;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Application.Services.ModelServices;
using Domain.Results;

namespace Application.RequestHandlers.CommandHandlers.Categories;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, RequestHandlerResult<UpdateCategoryResponse>>
{

    public async Task<RequestHandlerResult<UpdateCategoryResponse>> HandleAsync(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = request.MapToDomain();
        var updateResult = await this._categoryService.TryUpdateAsync(entity);

        if (updateResult.IsFail)
        {
            switch (updateResult.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<UpdateCategoryResponse>.NotFound(updateResult.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<UpdateCategoryResponse>.BadRequest(updateResult.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<UpdateCategoryResponse>.BadRequest(updateResult.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<UpdateCategoryResponse>.Unknown(updateResult.Message);
                default:
                    return RequestHandlerResult<UpdateCategoryResponse>.InternalServerError(updateResult.Message);
            }
        }

        var response = new UpdateCategoryResponse()
        {
            CategoryId = request.CategoryId,
            CategoryDescription = updateResult.Value!.Description,
            CategoryName = updateResult.Value.Name,
            IsDeleted = true
        };

        return RequestHandlerResult<UpdateCategoryResponse>.Ok(response);
    }

    private ICategoryService _categoryService;

    public UpdateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
}
