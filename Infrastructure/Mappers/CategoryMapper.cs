using Domain.Models;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public static class CategoryMapper
    {
        public static Category MapToDomain(this CategoryEntity category)
        {
            return new Category(
                category.Id,
                category.Name,
                category.Description);
        }
        public static CategoryEntity MapToEntity(this Category category)
        {
            return new CategoryEntity
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description
            };
        }
    }
}
