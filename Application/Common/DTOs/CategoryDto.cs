namespace Application.Common.DTOs;

/// <summary>
/// Data Transfer Object (DTO) for Category.
/// </summary>
public class CategoryDto
{
    /// <summary>
    /// Gets or sets the unique identifier for the category.
    /// </summary>
    public int CategoryId { get; set; }

    /// <summary>
    /// Gets or sets the name of the category.
    /// </summary>
    public string CategoryName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the category.
    /// </summary>
    public string CategoryDescription { get; set; } = string.Empty;
}