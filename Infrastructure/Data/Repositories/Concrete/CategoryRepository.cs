using Infrastructure.Data.DB;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstract;

namespace Infrastructure.Data.Repositories.Concrete;

public class CategoryRepository : Repository<CategoryEntity>, ICategoryRepository
{
    public CategoryRepository(AppDbContext context) 
        : base(context)
    {
    }
}
