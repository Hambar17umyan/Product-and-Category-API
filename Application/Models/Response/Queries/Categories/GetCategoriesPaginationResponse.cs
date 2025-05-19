using Application.Common.DTOs;
using Application.Models.Requests.Queries.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Queries.Categories
{
    public class GetCategoriesPaginationResponse : IResponse<GetCategoriesPaginationQuery>
    {
        public List<CategoryDto> Categories { get; set; } = new List<CategoryDto>();
    }
}