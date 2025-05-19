using Application.Models.Requests.Commands.Categories;
using Application.Models.Response.Commands.Categories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Extensions.Mapping
{
    static class CategoryMapping
    {
        public static Category MapToDomain(this CreateCategoryCommand command)
        {
            return new Category(command.CategoryName, command.CategoryDescription);
        }

        public static CreateCategoryResponse MapToResponse(this Category category)
        {
            return new CreateCategoryResponse(
                category.Id,
                category.Name,
                category.Description);
        }

        public static Category MapToDomain(this UpdateCategoryCommand command)
        {
            ///TODO... nullability
            return new Category(command.CategoryId, command.CategoryName, command.CategoryDescription);
        }
    }
}
