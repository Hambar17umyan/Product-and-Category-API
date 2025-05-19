using Application.Common.DTOs;
using Domain.Models;
using Domain.Results;

namespace Application.Services.ModelServices;

public interface IProductService : IModelService<Product>
{
    Task<Result<CategoryListDTO>> TryGetCategories(int id1, int id2, int? id3);
}
