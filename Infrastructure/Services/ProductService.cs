using Application.Common.DTOs;
using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstract;
using Infrastructure.Mappers;

namespace Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            this._productRepository = productRepository;
            this._categoryRepository = categoryRepository;
        }

        public async Task<Result<Product>> TryDeleteAsync(int id)
        {
            var deleted = await this._productRepository.DeleteAsync(id);
            return deleted.IsSuccess
                ? Result<Product>.GetSuccess(deleted.Value!.MapToDomain())
                : Result<Product>.GetFail(deleted.StatusCode, deleted.Message);
        }

        public async Task<Result<Product>> TryAddAsync(Product entity)
        {
            var product = entity.MapToEntity();
            var added = await this._productRepository.TryAddAsync(product);
            return added.IsSuccess
                ? Result<Product>.GetSuccess(added.Value!.MapToDomain())
                : Result<Product>.GetFail(added.StatusCode, added.Message);
        }

        public Result<IEnumerable<Product>> TryGetAll()
        {
            var res = this._productRepository.TryGetAll();
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }
            return Result<IEnumerable<Product>>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<Product>> TryGetByCondition(Func<Product, bool> predicate)
        {
            var res = this._productRepository.TryGetByCondition(x => predicate(x.MapToDomain()));
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }

            return Result<IEnumerable<Product>>.GetFail(res.StatusCode, res.Message);
        }

        public async Task<Result<Product>> TryGetByIdAsync(int id)
        {
            var res = await this._productRepository.TryGetByIdAsync(id);
            if (res.IsSuccess)
            {
                return Result<Product>.GetSuccess(res.Value!.MapToDomain());
            }

            return Result<Product>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<Product>> TryGetWithPagination(int page, int pageSize)
        {
            var res = this._productRepository.TryGetWithPagination(page, pageSize);
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }

            return Result<IEnumerable<Product>>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<TRes>?> TryGetWithQuery<TRes>(Func<IQueryable<Product>, IQueryable<TRes>> query)
        {
            var res = this._productRepository.TryGetWithQuery<TRes>(
                x => query(
                    x.Select(
                        y => y.MapToDomain()
                        )
                    )
                );

            if (res.IsSuccess)
            {
                return Result.GetSuccess(res?.Value?.AsEnumerable());
            }
            return Result<IEnumerable<TRes>?>.GetFail(res!.StatusCode, res!.Message);
        }

        public async Task<Result<Product>> TryUpdateAsync(Product entity)
        {
            var product = entity.MapToEntity();
            var updated = await this._productRepository.TryUpdateAsync(product);
            return updated.IsSuccess
                ? Result<Product>.GetSuccess(updated.Value!.MapToDomain())
                : Result<Product>.GetFail(updated.StatusCode, updated.Message);
        }

        public async Task<Result<CategoryListDTO>> TryGetCategories(int id1, int id2, int? id3)
        {
            var a = this._categoryRepository.TryGetByIdAsync(id1);
            var b = this._categoryRepository.TryGetByIdAsync(id2);
            Task<Result<CategoryEntity>>? c = null;
            if(id3 != null)
            {
                c = this._categoryRepository.TryGetByIdAsync(id3.Value);
            }

            var res1 = await a;
            if(res1.IsFail)
            {
                return Result<CategoryListDTO>.GetFail(res1.StatusCode, $"First category was not retreived. Message:\n{res1.Message}");
            }
            var res2 = await b;
            if (res2.IsFail)
            {
                return Result<CategoryListDTO>.GetFail(res2.StatusCode, $"Second category was not retreived. Message:\n{res2.Message}");
            }
            if(c != null)
            {
                var res3 = await c;
                if (res3.IsFail)
                {
                    return Result<CategoryListDTO>.GetFail(res3.StatusCode, $"Third category was not retreived. Message:\n{res3.Message}");
                }
                var res = new CategoryListDTO
                {
                    Category1 = res1.Value!.MapToDomain(),
                    Category2 = res2.Value!.MapToDomain(),
                    Category3 = res3.Value!.MapToDomain()
                };

                return Result<CategoryListDTO>.GetSuccess(res, string.Concat(res1.Message ?? "", res2.Message ?? "", res3.Message ?? ""));
            }
            else
            {
                var res = new CategoryListDTO
                {
                    Category1 = res1.Value!.MapToDomain(),
                    Category2 = res2.Value!.MapToDomain()
                };

                return Result<CategoryListDTO>.GetSuccess(res, string.Concat(res1.Message ?? "", res2.Message ?? ""));
            }
        }
    }
}
