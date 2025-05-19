using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Abstract;

namespace Application.Models.Response.Commands.Categories;

public class CreateCategoryResponse : IResponse<CreateCategoryCommand>
{
    public CreateCategoryResponse(int id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    /// <summary>
    /// Gets or sets the ID of the new category.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the name of the new category.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the new category.
    /// </summary>
    public string Description { get; set; } = string.Empty;
}