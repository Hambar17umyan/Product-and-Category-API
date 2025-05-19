using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappers.Abstract
{
    public interface ICategoryMapper
    {
        /// <summary>
        /// Maps a CreateCategoryCommand to a Category domain model.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The category.</returns>
        Category MapToDomain(CreateCategoryCommand command);

        /// <summary>
        /// Maps a Category domain model to a CreateCategoryResponse.
        /// </summary>
        /// <param name="category">The category.</param>
        /// <returns>The Response Model.</returns>
        CreateCategoryResponse MapToResponse(Category category);

        /// <summary>
        /// Maps an UpdateCategoryCommand to a Category domain model.
        /// </summary>
        /// <param name="command">The command.</param>
        /// <returns>The category.</returns>
        Category MapToDomain(UpdateCategoryCommand command);
    }
}
