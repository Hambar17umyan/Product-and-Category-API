using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Application.Services.ModelServices;
using Domain.Results;

namespace Application.RequestHandlers.CommandHandlers.Categories;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, RequestHandlerResult<DeleteCategoryResponse>>
{

    public async Task<RequestHandlerResult<DeleteCategoryResponse>> HandleAsync(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var result = await this._categoryService.TryGetByIdAsync(request.CategoryId);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<DeleteCategoryResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<DeleteCategoryResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<DeleteCategoryResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<DeleteCategoryResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<DeleteCategoryResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var deleteResult = await this._categoryService.TryDeleteAsync(request.CategoryId);

            if (deleteResult.IsFail)
            {
                switch (deleteResult.StatusCode)
                {
                    case StatusCode.NotFound:
                        return RequestHandlerResult<DeleteCategoryResponse>.NotFound(deleteResult.Message);
                    case StatusCode.ArgumentNullError:
                        return RequestHandlerResult<DeleteCategoryResponse>.BadRequest(deleteResult.Message);
                    case StatusCode.ArgumentInvalidError:
                        return RequestHandlerResult<DeleteCategoryResponse>.BadRequest(deleteResult.Message);
                    case StatusCode.NotSpecified:
                        return RequestHandlerResult<DeleteCategoryResponse>.Unknown(deleteResult.Message);
                    default:
                        return RequestHandlerResult<DeleteCategoryResponse>.InternalServerError(deleteResult.Message);
                }
            }

            var response = new DeleteCategoryResponse()
            {
                CategoryId = request.CategoryId,
                CategoryDescription = result.Value!.Description,
                CategoryName = result.Value.Name,
                IsDeleted = true
            };

            return RequestHandlerResult<DeleteCategoryResponse>.Ok(response);
        }
    }

    private ICategoryService _categoryService;

    public DeleteCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
}
