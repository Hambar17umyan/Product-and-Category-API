using Application.Common.DTOs;
using Application.Models.Requests.Queries.Products;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Products
{
    public class GetProductsPaginationResponse : IResponse<GetProductsPaginationQuery>
    {
        public List<ProductDTO> Products { get; set; } = new List<ProductDTO>();
    }
}