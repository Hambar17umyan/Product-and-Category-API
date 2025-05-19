using Domain.Models;
using Infrastructure.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mappers
{
    public static class ProductMapper
    {
        public static Product MapToDomain(this ProductEntity product)
        {
            return new Product(
                product.Id,
                product.Name,
                product.Category1.MapToDomain(),
                product.Category2.MapToDomain(),
                product.Category3 is not null ?
                    product.Category3.MapToDomain() :
                    null);
        }

        public static ProductEntity MapToEntity(this Product product)
        {
            return new ProductEntity
            {
                Id = product.Id,
                Name = product.Name,
                Category1Id = product.Category1.Id,
                Category2Id = product.Category2.Id,
                Category3Id = product.Category3 is not null ?
                    product.Category3.Id :
                    null


            };
        }
    }
}
