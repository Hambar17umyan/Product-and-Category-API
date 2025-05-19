using Domain.Results;
using Infrastructure.Data.DB;
using Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories.Abstract;

public abstract class Repository<T> : IRepository<T> where T : class, IEntity
{
    public virtual async Task<Result<T>> DeleteAsync(int id)
    {
        var entity = await this._dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            return Result<T>.GetFail(StatusCode.NotFound, "Entity not found.");
        }

        var removed = this._dbSet.Remove(entity);
        this._context.SaveChanges();
        return Result.GetSuccess(removed.Entity);
    }

    public virtual async Task<Result<T>> TryAddAsync(T entity)
    {
        var added = await this._dbSet.AddAsync(entity);
        await this._context.SaveChangesAsync();
        return Result.GetSuccess(added.Entity);
    }

    public virtual Result<IEnumerable<T>> TryGetAll()
    {
        return Result.GetSuccess(this._dbSet.AsEnumerable());
    }

    public virtual Result<IEnumerable<T>> TryGetByCondition(Func<T, bool> predicate)
    {
        return Result.GetSuccess(this._dbSet
            .Where(x => predicate(x))
            .AsEnumerable());
    }

    public virtual async Task<Result<T>> TryGetByIdAsync(int id)
    {
        var entity = await this._dbSet.FirstOrDefaultAsync(x => x.Id == id);
        if (entity is null)
        {
            return Result<T>.GetFail(StatusCode.NotFound, "Entity not found.");
        }

        _context.SaveChanges();

        return Result<T>.GetSuccess(entity);
    }

    public virtual Result<IEnumerable<TRes>> TryGetWithQuery<TRes>(Func<IQueryable<T>, IQueryable<TRes>> query)
    {
        return Result.GetSuccess(query(_dbSet).AsEnumerable());
    }

    public virtual async Task<Result<T>> TryUpdateAsync(T entity)
    {
        var trackedEntity = await _dbSet.FirstOrDefaultAsync(x => x.Id == entity.Id);
        if (trackedEntity is null)
            return Result<T>.GetFail(StatusCode.NotFound, "Entity not found.");

        // Detach the old entity
        _context.Entry(trackedEntity).State = EntityState.Detached;

        // Attach and update the new entity
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return Result.GetSuccess(entity);
    }


    public virtual Result<IEnumerable<T>> TryGetWithPagination(int page, int pageSize)
    {
        if (page < 1 || pageSize < 1)
        {
            return Result.GetFail<IEnumerable<T>>(StatusCode.ArgumentInvalidError, "Page and page size must be greater than 0.");
        }

        if ((page - 1) * pageSize > this._dbSet.Count())
        {
            return Result.GetFail<IEnumerable<T>>(StatusCode.ArgumentInvalidError, "Page is out of range.");
        }

        var entities = this._dbSet
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .AsEnumerable();
        return Result.GetSuccess(entities);
    }


    /// <summary>
    /// Initializes a new instance of the <see cref="Repository{T}"/> class with the specified context.
    /// </summary>
    /// <param name="context">The DB context.</param>
    /// <exception cref="ArgumentNullException"></exception>
    public Repository(AppDbContext context)
    {
        this._context = context;
        this._dbSet = context.Set<T>();
        if(this._dbSet is null)
        {
            throw new ArgumentNullException(nameof(this._dbSet), "DbSet cannot be null.");
        }
    }

    /// <summary>
    /// Gets the DB context.
    /// </summary>
    protected AppDbContext _context { get; }

    /// <summary>
    /// Gets the DB set.
    /// </summary>
    protected DbSet<T> _dbSet { get; }
}
