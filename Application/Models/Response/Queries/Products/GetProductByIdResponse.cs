using Application.Models.Requests.Queries.Products;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Products
{
    public class GetProductByIdResponse : IResponse<GetProductByIdQuery>
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        
        public int Category1Id { get; set; }
        public int Category2Id { get; set; }
        public int? Category3Id { get; set; }
    }
}