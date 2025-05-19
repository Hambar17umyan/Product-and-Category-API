namespace Application.Common.Mappers;

using Application.Common.Mappers.Abstract;
using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Domain.Models;

/// <summary>
/// This class provides mapping methods for category-related commands and responses.
/// </summary>
internal class CategoryMapping : ICategoryMapper
{
    public Category MapToDomain(CreateCategoryCommand command)
    {
        return new Category(command.CategoryName, command.CategoryDescription);
    }

    public CreateCategoryResponse MapToResponse(Category category)
    {
        return new CreateCategoryResponse(
            category.Id,
            category.Name,
            category.Description);
    }

    public Category MapToDomain(UpdateCategoryCommand command)
    {
        ///TODO... nullability
        return new Category(command.CategoryId, command.CategoryName, command.CategoryDescription);
    }
}
