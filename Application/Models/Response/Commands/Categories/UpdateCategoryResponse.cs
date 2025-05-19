using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Commands.Categories;

public class UpdateCategoryResponse : IResponse<UpdateCategoryCommand>
{
    public int CategoryId { get; internal set; }
    public string CategoryDescription { get; internal set; }
    public string CategoryName { get; internal set; }
    public bool IsDeleted { get; internal set; }
}