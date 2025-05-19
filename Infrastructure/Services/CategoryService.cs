using Application.Services.ModelServices;
using Domain.Models;
using Domain.Results;
using Infrastructure.Data.Repositories.Abstract;
using Infrastructure.Mappers;

namespace Infrastructure.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<Result<Category>> TryDeleteAsync(int id)
        {
            var deleted = await this._categoryRepository.DeleteAsync(id);
            return deleted.IsSuccess
                ? Result<Category>.GetSuccess(deleted.Value!.MapToDomain())
                : Result<Category>.GetFail(deleted.StatusCode, deleted.Message);
        }

        public async Task<Result<Category>> TryAddAsync(Category model)
        {
            var category = model.MapToEntity();
            var added = await this._categoryRepository.TryAddAsync(category);
            return added.IsSuccess
                ? Result<Category>.GetSuccess(added.Value!.MapToDomain())
                : Result<Category>.GetFail(added.StatusCode, added.Message);
        }

        public Result<IEnumerable<Category>> TryGetAll()
        {
            var res = this._categoryRepository.TryGetAll();
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }

            return Result<IEnumerable<Category>>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<Category>> TryGetByCondition(Func<Category, bool> predicate)
        {
            var res = this._categoryRepository.TryGetByCondition(x => predicate(x.MapToDomain()));
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }

            return Result<IEnumerable<Category>>.GetFail(res.StatusCode, res.Message);
        }

        public async Task<Result<Category>> TryGetByIdAsync(int id)
        {
            var res = await this._categoryRepository.TryGetByIdAsync(id);
            if (res.IsSuccess)
            {
                return Result<Category>.GetSuccess(res.Value!.MapToDomain());
            }
            return Result<Category>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<Category>> TryGetWithPagination(int page, int pageSize)
        {
            var res = this._categoryRepository.TryGetWithPagination(page, pageSize);
            if (res.IsSuccess)
            {
                return Result.GetSuccess(res.Value!.Select(x => x.MapToDomain()));
            }

            return Result<IEnumerable<Category>>.GetFail(res.StatusCode, res.Message);
        }

        public Result<IEnumerable<TRes>?> TryGetWithQuery<TRes>(Func<IQueryable<Category>, IQueryable<TRes>> query)
        {
            var res = this._categoryRepository.TryGetWithQuery<TRes>(
                x => query(
                    x.Select(
                        y=>y.MapToDomain()
                        )
                    )
                );

            if (res.IsSuccess)
            {
                return Result.GetSuccess(res?.Value?.AsEnumerable());
            }
            return Result<IEnumerable<TRes>?>.GetFail(res!.StatusCode, res!.Message);
        }

        public async Task<Result<Category>> TryUpdateAsync(Category model)
        {
            var category = model.MapToEntity();
            var updated = await this._categoryRepository.TryUpdateAsync(category);
            return updated.IsSuccess
                ? Result<Category>.GetSuccess(updated.Value!.MapToDomain())
                : Result<Category>.GetFail(updated.StatusCode, updated.Message);
        }

        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
    }
}
