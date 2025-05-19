using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Commands.Categories;

public class DeleteCategoryResponse : IResponse<DeleteCategoryCommand>
{
    /// <summary>
    /// Gets or sets the ID of the deleted category.
    /// </summary>
    public int? CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the deleted category.
    /// </summary>
    public string? CategoryName { get; set; }

    /// <summary>
    /// Gets or sets the description of the deleted category.
    /// </summary>
    public string? CategoryDescription { get; set; }
    
    /// <summary>
    /// Gets or sets a value indicating whether the deletion was successful.
    /// </summary>
    public bool IsDeleted { get; set; } = false;
}