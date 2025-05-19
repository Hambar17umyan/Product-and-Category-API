using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Common.Extensions.Mapping;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Commands.Categories;
using Application.Models.Response.Commands.Products;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;

namespace Application.RequestHandlers.CommandHandlers.Products;

public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, RequestHandlerResult<CreateProductResponse>>
{
    public CreateProductCommandHandler(IProductService productService, ICategoryService categoryService)
    {
        this._productService = productService;
        this._categoryService = categoryService;
    }

    public async Task<RequestHandlerResult<CreateProductResponse>> HandleAsync(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var res = await _productService.TryGetCategories(request.ProductCategory1Id, request.ProductCategory2Id, request.ProductCategory3Id);
        if (res.IsFail)
        {
            switch(res.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<CreateProductResponse>.NotFound(res.Message);
                case StatusCode.ArgumentNullError:
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(res.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateProductResponse>.Unknown(res.Message);
                default:
                    return RequestHandlerResult<CreateProductResponse>.InternalServerError(res.Message);
            }
        }

        var product = new Product(request.ProductName, res.Value!.Category1, res.Value!.Category2, res.Value?.Category3);

        var result = await this._productService.TryAddAsync(product);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<CreateProductResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<CreateProductResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<CreateProductResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var response = result.Value!.MapToResponse();
            return RequestHandlerResult<CreateProductResponse>.Ok(response);
        }
    }

    private IProductService _productService;
    private ICategoryService _categoryService;
}
