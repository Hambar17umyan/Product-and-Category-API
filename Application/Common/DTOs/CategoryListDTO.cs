namespace Application.Common.DTOs;

using Domain.Models;

/// <summary>
/// Data Transfer Object (DTO) for a list of categories.
/// </summary>
public class CategoryListDTO
{
    /// <summary>
    /// Gets or sets the first category.
    /// </summary>
    public Category Category1 { get; set; } = new("", "");

    /// <summary>
    /// Gets or sets the second category.
    /// </summary>
    public Category Category2 { get; set; } = new("", "");

    /// <summary>
    /// Gets or sets the third category.
    /// </summary>
    public Category? Category3 { get; set; }
}
