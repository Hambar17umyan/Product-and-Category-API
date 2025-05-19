using Domain.Results;

namespace Application.Services.ModelServices;

public interface IModelService<T>
{
    /// <summary>
    /// Attempts to retrieve an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to retrieve.</param>
    /// <returns>
    /// A <see cref="Task{Result{T}}"/> containing the entity if found; otherwise, a failed result.
    /// </returns>
    Task<Result<T>> TryGetByIdAsync(int id);

    /// <summary>
    /// Attempts to retrieve all entities.
    /// </summary>
    /// <returns>
    /// A <see cref="Task{Result{IEnumerable{T}}}"/> containing all entities; otherwise, a failed result.
    /// </returns>
    Result<IEnumerable<T>> TryGetAll();

    /// <summary>
    /// Attempts to retrieve entities that match the specified predicate.
    /// </summary>
    /// <param name="predicate">A function to test each entity for a condition.</param>
    /// <returns>
    /// A <see cref="Task{Result{IEnumerable{T}}}"/> containing the matching entities; otherwise, a failed result.
    /// </returns>
    Result<IEnumerable<T>> TryGetByCondition(Func<T, bool> predicate);

    /// <summary>
    /// Attempts to retrieve entities using a custom query.
    /// </summary>
    /// <param name="query">A function that applies a query to the set of entities.</param>
    /// <returns>
    /// A <see cref="Result{IEnumerable{T}}"/> containing the queried entities; otherwise, a failed result.
    /// </returns>
    Result<IEnumerable<TRes>?> TryGetWithQuery<TRes>(Func<IQueryable<T>, IQueryable<TRes>> query);

    /// <summary>
    /// Attempts to retrieve entities with pagination.
    /// </summary>
    /// <param name="page">The number of page.</param>
    /// <param name="pageSize">The size of a page.</param>
    /// <returns></returns>
    Result<IEnumerable<T>> TryGetWithPagination(int page, int pageSize);

    /// <summary>
    /// Attempts to add a new entity.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <returns>
    /// A <see cref="Task{Result{T}}</Result>"/> indicating the outcome of the add operation.
    /// </returns>
    Task<Result<T>> TryAddAsync(T entity);

    /// <summary>
    /// Attempts to update an existing entity.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <returns>
    /// A <see cref="Task{Result{T}}"/> indicating the outcome of the update operation.
    /// </returns>
    Task<Result<T>> TryUpdateAsync(T entity);

    /// <summary>
    /// Attempts to delete an entity by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the entity to delete.</param>
    /// <returns>
    /// A <see cref="Task{Result{T}}"/> indicating the outcome of the delete operation.
    /// </returns>
    Task<Result<T>> TryDeleteAsync(int id);
}
