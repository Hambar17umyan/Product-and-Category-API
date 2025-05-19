using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Common.Extensions.Mapping;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;

namespace Application.RequestHandlers.CommandHandlers.Categories;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, RequestHandlerResult<CreateCategoryResponse>>
{
    public CreateCategoryCommandHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    public async Task<RequestHandlerResult<CreateCategoryResponse>> HandleAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = request.MapToDomain();
        var result = await this._categoryService.TryAddAsync(entity);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<CreateCategoryResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateCategoryResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateCategoryResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<CreateCategoryResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = result.Value!.MapToResponse();
            return RequestHandlerResult<CreateCategoryResponse>.Ok(response);
        }
    }

    private ICategoryService _categoryService;
}
