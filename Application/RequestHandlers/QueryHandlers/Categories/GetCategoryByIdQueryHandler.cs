using Application.Models.Requests.Queries.Categories;
using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Response.Queries.Categories;
using Application.Services.ModelServices;
using Domain.Results;

namespace Application.RequestHandlers.QueryHandlers.Categories;

public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, RequestHandlerResult<GetCategoryByIdResponse>>
{

    public async Task<RequestHandlerResult<GetCategoryByIdResponse>> HandleAsync(GetCategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var result = await this._categoryService.TryGetByIdAsync(request.CategoryId);
        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<GetCategoryByIdResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<GetCategoryByIdResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<GetCategoryByIdResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<GetCategoryByIdResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<GetCategoryByIdResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = new GetCategoryByIdResponse()
            {
                CategoryId = result.Value!.Id,
                CategoryName = result.Value!.Name,
                CategoryDescription = result.Value!.Description,
            };
            return RequestHandlerResult<GetCategoryByIdResponse>.Ok(response);
        }
    }

    private ICategoryService _categoryService;

    public GetCategoryByIdQueryHandler(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
}
