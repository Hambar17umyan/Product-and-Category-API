using Application.Common.AppMediator;
using Application.Common.AppRequestHandlerResult;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Commands.Categories;
using Application.Models.Response.Commands.Products;
using Application.Services.ModelServices;
using Domain.Results;

namespace Application.RequestHandlers.CommandHandlers.Products;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, RequestHandlerResult<DeleteProductResponse>>
{
    public async Task<RequestHandlerResult<DeleteProductResponse>> HandleAsync(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var result = await this._productService.TryGetByIdAsync(request.ProductId);

        if (result.IsFail)
        {
            switch (result.StatusCode)
            {
                case StatusCode.NotFound:
                    return RequestHandlerResult<DeleteProductResponse>.NotFound(result.Message);
                case StatusCode.ArgumentNullError:
                    return RequestHandlerResult<DeleteProductResponse>.BadRequest(result.Message);
                case StatusCode.ArgumentInvalidError:
                    return RequestHandlerResult<DeleteProductResponse>.BadRequest(result.Message);
                case StatusCode.NotSpecified:
                    return RequestHandlerResult<DeleteProductResponse>.Unknown(result.Message);
                default:
                    return RequestHandlerResult<DeleteProductResponse>.InternalServerError(result.Message);
            }
        }
        else
        {
            var deleteResult = await this._productService.TryDeleteAsync(request.ProductId);

            if (deleteResult.IsFail)
            {
                switch (deleteResult.StatusCode)
                {
                    case StatusCode.NotFound:
                        return RequestHandlerResult<DeleteProductResponse>.NotFound(deleteResult.Message);
                    case StatusCode.ArgumentNullError:
                        return RequestHandlerResult<DeleteProductResponse>.BadRequest(deleteResult.Message);
                    case StatusCode.ArgumentInvalidError:
                        return RequestHandlerResult<DeleteProductResponse>.BadRequest(deleteResult.Message);
                    case StatusCode.NotSpecified:
                        return RequestHandlerResult<DeleteProductResponse>.Unknown(deleteResult.Message);
                    default:
                        return RequestHandlerResult<DeleteProductResponse>.InternalServerError(deleteResult.Message);
                }
            }

            var response = new DeleteProductResponse()
            {
                ProductId = result.Value!.Id,
                ProductName = result.Value!.Name,
                ProductCategory1Id = result.Value.Category1.Id,
                ProductCategory2Id = result.Value.Category2.Id,
                ProductCategory3Id = result.Value.Category3?.Id,
            };

            return RequestHandlerResult<DeleteProductResponse>.Ok(response);
        }
    }


    private IProductService _productService;

    public DeleteProductCommandHandler(IProductService productService)
    {
        this._productService = productService;
    }
}
