using Application.Models.Requests.Queries.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Categories
{
    public class GetCategoryByIdResponse : IResponse<GetCategoryByIdQuery>
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
    }
}