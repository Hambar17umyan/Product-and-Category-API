using Infrastructure.Data.DB;
using Infrastructure.Data.Entities;
using Infrastructure.Data.Repositories.Abstract;

namespace Infrastructure.Data.Repositories.Concrete;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    public ProductRepository(AppDbContext context) 
        : base(context)
    {
        
    }
}
