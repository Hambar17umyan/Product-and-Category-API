using Application.Models.Requests.Commands.Categories;
using Application.Models.Requests.Commands.Products;
using Application.Models.Response.Commands.Categories;
using Application.Models.Response.Commands.Products;
using Domain.Models;

namespace Application.Common.Extensions.Mapping
{
    static class ProductMapping
    {
        public static CreateProductResponse MapToResponse(this Product product)
        {
            var res = new CreateProductResponse
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ProductCategory1Id = product.Category1.Id,
                ProductCategory2Id = product.Category2.Id,
                ProductCategory3Id = product.Category3?.Id ?? 0
            };
            return res;
        }
    }
}
